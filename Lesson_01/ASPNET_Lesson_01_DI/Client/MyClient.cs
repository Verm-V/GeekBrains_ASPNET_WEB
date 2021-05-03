using ASPNET_Lesson_01_DI.Requests;
using ASPNET_Lesson_01_DI.Responses;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ASPNET_Lesson_01_DI.Client
{
	public enum ApiNames
	{
		Posts,
	}

	class MyClient : IMyClient
	{

		private readonly string BlogUrl = "https://jsonplaceholder.typicode.com";

		private readonly HttpClient _httpClient;
		private readonly ILogger _logger;

		private readonly Dictionary<ApiNames, string> apiNames = new Dictionary<ApiNames, string>()
		{
			{ApiNames.Posts, "posts" },
		};


		public MyClient(HttpClient httpClient, ILogger<MyClient> logger)
		{
			_httpClient = httpClient;
			_logger = logger;
			_logger.LogDebug("MyClient service constructed");
		}




		public async Task<PostResponse> GetPostAsync(PostRequest request)
		{

			var postResponse = new PostResponse();

			try
			{
				//// !DEBUG выброс исключений для отладки - УБРАТЬ в окончательном варианте
				//if (request.Id == 4 || request.Id == 8)
				//{
				//	//_logger.LogError(ex.Message);
				//	_ = 1 / (request.Id - request.Id);
				//}

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
				_logger.LogError(ex.Message);
				throw new Exception($"Не удалось получить пост №{request.Id}");
			}

		}

		public async Task<List<PostResponse>> GetPostsRangeAsync(PostsRangeRequest request)
		{
			// Получаем нужные посты
			var posts = new List<PostResponse>();

			// Список задач на получение постов
			var tasks = new List<Task<PostResponse>>();
			// Получаем все посты в цикле асинхронно
			for (int i = request.FirstId; i <= request.LastId; i++)
			{
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
				_logger.LogError(ex.Message);
				// На тот случай если исключений было несколько залоггируем их все
				_logger.LogError($"{nameof(GetPostsRangeAsync)} IsFaulted: " + allTasks.IsFaulted);
				foreach (var inx in allTasks.Exception.InnerExceptions)
				{
					_logger.LogError(inx.Message);
				}
			}

			// Перегоняем посты из задач в список исключая те которые не были получены
			// (если например был какой-нибудь exception)
			posts = tasks.Where(t => t.IsFaulted == false).Select(t => t.Result).ToList();

			return posts;

		}
	}
}

