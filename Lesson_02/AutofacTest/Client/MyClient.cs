using AutofacTest.Requests;
using AutofacTest.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AutofacTest.Client
{
	/// <summary>Перечисление для возможных API</summary>
	public enum ApiNames
	{
		Posts,
	}

    class MyClient : IMyClient
    {
		/// <summary>Основной URL</summary>
        private readonly string BlogUrl = "https://jsonplaceholder.typicode.com";

		private readonly HttpClient _httpClient;

		/// <summary>Тесатовые представления для возможных API</summary>
		private readonly Dictionary<ApiNames, string> apiNames = new Dictionary<ApiNames, string>()
        {
            {ApiNames.Posts, "posts" },
        };

		public MyClient(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<PostResponse> GetPostAsync(PostRequest request)
        {
			var postResponse = new PostResponse();

			try
			{

				var httpRequest = new HttpRequestMessage(
					HttpMethod.Get,
					$"{BlogUrl}/{apiNames[ApiNames.Posts]}/{request.Id}");
				var serverResponse = await _httpClient.SendAsync(httpRequest);
				var content = await serverResponse.Content.ReadAsStringAsync();
				postResponse = JsonConvert.DeserializeObject<PostResponse>(content);
				return postResponse;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				throw new Exception($"Не удалось получить пост №{request.Id}");
			}
		}

        public async Task<List<PostResponse>> GetPostsRangeAsync(PostsRangeRequest request)
        {
			{
				// Получаем нужные посты
				var posts = new List<PostResponse>();

				// Список задач на получение постов
				var tasks = new List<Task<PostResponse>>();
				// Получаем все посты в цикле асинхронно
				for (int i = request.FirstId; i <= request.LastId; i++)
				{
					Console.WriteLine($"id: {i}");
					tasks.Add(GetPostAsync(new PostRequest(i)));
				}

				// Ждем пока все посты соберуться
				var allTasks = Task.WhenAll(tasks);
				try
				{
					await allTasks;
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
					Console.WriteLine($"{nameof(GetPostsRangeAsync)} IsFaulted: " + allTasks.IsFaulted);
					foreach (var inx in allTasks.Exception.InnerExceptions)
					{
						Console.WriteLine(inx.Message);
					}
				}

				// Перегоняем посты из задач в список исключая те которые не были получены
				// (если например был какой-нибудь exception)
				posts = tasks.Where(t => t.IsFaulted == false).Select(t => t.Result).ToList();

				return posts;

			}
		}
    }
}
