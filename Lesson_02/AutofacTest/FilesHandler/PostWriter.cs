using AutofacTest.Responses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AutofacTest.FilesHandler
{
	class PostsWriter : IPostsWriter
	{
		///<summary>Имя файла в который будет сохранен результат</summary>
		private static readonly string fileName = "result.txt";

		public async Task OutputPostsToFile(List<PostResponse> posts)
		{
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
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				Console.WriteLine("Запись в файл не удалась");
			}
		}
	}
}
