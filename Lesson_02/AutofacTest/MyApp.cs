using Autofac;
using AutofacTest.Client;
using AutofacTest.FilesHandler;
using AutofacTest.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AutofacTest
{
	class MyApp : IMyApp
	{
		/// <summary>Id первого поста из списка который нужно получить</summary>
		private static readonly int FirstPostId = 4;
		/// <summary>Id последнего поста из списка который нужно получить</summary>
		private static readonly int LastPostId = 13;

		private readonly IMyClient _myClient;
		private readonly IPostsWriter _postsWriter;

		public MyApp(IMyClient myClient, IPostsWriter postsWriter)
		{
			_myClient = myClient;
			_postsWriter = postsWriter;
		}


		public async Task Run()
		{
			var request = new PostsRangeRequest(FirstPostId, LastPostId);
			Console.WriteLine($"Запрос постов с {FirstPostId} по {LastPostId}");

			var posts = await _myClient.GetPostsRangeAsync(request);
			Console.WriteLine($"Количество полученных постов: {posts.Count}");

			await _postsWriter.OutputPostsToFile(posts);
			Console.WriteLine("Список постов записан на диск");

			Console.WriteLine("Press any key to exit");
			Console.ReadKey();

		}

	}
}
