using ASPNET_Lesson_01_DI.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ASPNET_Lesson_01_DI.FilesHandler
{
	/// <summary>Сохраняет посты на диск</summary>
	interface IPostsWriter
	{
		/// <summary>Сохраняет список постов на диск</summary>
		/// <param name="posts">Список постов</param>
		/// <returns></returns>
		Task OutputPostsToFile(List<PostResponse> posts);
	}
}

