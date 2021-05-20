using AutofacTest.Requests;
using AutofacTest.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AutofacTest.Client
{
	/// <summary>
	/// HTTP клиент для работы с постами блога
	/// </summary>
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
