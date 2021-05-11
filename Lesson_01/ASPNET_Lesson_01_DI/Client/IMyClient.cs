using ASPNET_Lesson_01_DI.Requests;
using ASPNET_Lesson_01_DI.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ASPNET_Lesson_01_DI.Client
{
	interface IMyClient
	{
		/// <summary>
		/// Запрашивает пост у сервера по его Id
		/// </summary>
		/// <param name="request">Запрос с Id поста</param>
		/// <returns>Запрашиваемый пост</returns>
		Task<PostResponse> GetPostAsync(PostRequest request);

		/// <summary>
		/// Запрашивает список постов у сервера по интервалу Id
		/// </summary>
		/// <param name="request">Запрос с интервалом Id постов</param>
		/// <returns>Список запрашиваемых постов</returns>
		Task<List<PostResponse>> GetPostsRangeAsync(PostsRangeRequest request);
	}
}
