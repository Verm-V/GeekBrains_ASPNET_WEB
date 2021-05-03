﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ASPNET_Lesson_01
{
	class Program
	{
		private static readonly HttpClient client = new HttpClient();
		/// <summary>Id первого поста из списка который нужно получить</summary>
		private static readonly int FirstPostId = 4;
		/// <summary>Id последнего поста из списка который нужно получить</summary>
		private static readonly int LastPostId = 13;
		/// <summary>Имя файла в который будет сохранен результат</summary>
		private static readonly string fileName = "output.txt";

		static async Task Main(string[] args)
		{
			// Список задач на получение постов
			var tasks = new List<Task<Post>>();

			// Получаем нужные посты
			try
			{
				for (int i = FirstPostId; i <= LastPostId; i++)
				{
					tasks.Add(GetPostById(i));
				}

				// Ждем пока все посты соберуться
				await Task.WhenAll(tasks);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			Console.WriteLine($"Посты с {FirstPostId} по {LastPostId} получены");

			// Перегоняем посты из задач в список исключая те которые не были получены
			// (если например был какой-нибудь exception)
			var posts = tasks.Where(t => t.IsFaulted == false).Select(t => t.Result).ToList();

			// Записываем полученные посты в файл
			try
			{
				using (StreamWriter sw = new StreamWriter(fileName, false, System.Text.Encoding.UTF8))
				{
					foreach (var post in posts)
					{
						await sw.WriteLineAsync(post.ToString());
					}
				}
			}
			catch
			{
				Console.WriteLine("Запись в файл не удалась");
			}

			Console.WriteLine("Список постов записан на диск");

			Console.WriteLine("Press any key to continue.");
			Console.ReadKey();
		}

		/// <summary>
		/// Получает содержание поста
		/// </summary>
		/// <param name="id">Id поста который нужно получить</param>
		/// <returns>Запрашиваемый пост</returns>
		static async Task<Post> GetPostById(int id)
		{
			try
			{
				var response = await client.GetAsync($"https://jsonplaceholder.typicode.com/posts/{id}");
				var content = await response.Content.ReadAsStringAsync();
				var post = JsonConvert.DeserializeObject<Post>(content);
				return post;
			}
			catch
			{
				throw new Exception($"Не удалось получить пост №{id}");
			}
		}

	}
}
