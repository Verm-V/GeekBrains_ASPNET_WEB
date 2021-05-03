using ASPNET_Lesson_01_DI.Client;
using ASPNET_Lesson_01_DI.FilesHandler;
using ASPNET_Lesson_01_DI.Requests;
using ASPNET_Lesson_01_DI.Responses;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNET_Lesson_01_DI
{
	class MyApp
	{
		/// <summary>Id первого поста из списка который нужно получить</summary>
		private static readonly int FirstPostId = 4;
		/// <summary>Id последнего поста из списка который нужно получить</summary>
		private static readonly int LastPostId = 13;

		private readonly ILogger _logger;
		private readonly IMyClient _myClient;
		private readonly IPostsWriter _postsWriter;

		public MyApp(ILogger<MyApp> logger, IMyClient myClient, IPostsWriter postsWriter)
		{
			_logger = logger;
			_logger.LogDebug("App service constructed");
			_myClient = myClient;
			_postsWriter = postsWriter;
		}

		internal async Task Run()
		{
			_logger.LogInformation("App start");

			var request = new PostsRangeRequest(FirstPostId, LastPostId);
			Console.WriteLine($"Запрос постов с {FirstPostId} по {LastPostId}");

			var posts = await _myClient.GetPostsRangeAsync(request);
			Console.WriteLine($"Количество полученных постов: {posts.Count}");

			await _postsWriter.OutputPostsToFile(posts);
			Console.WriteLine("Список постов записан на диск");

			Console.WriteLine("Press any key to exit");
			Console.ReadKey();
			_logger.LogInformation("App ends");
		}
	}
}
