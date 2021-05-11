using System;
using System.Collections.Generic;
using System.Text;

namespace ASPNET_Lesson_01_DI.Requests
{
	/// <summary>Запрос на получение поста по его ID</summary>
	class PostRequest
	{
		/// <summary>ID запрашиваемого поста</summary>
		public int Id { get; set; }

		public PostRequest(int id)
		{
			Id = id;
		}
	}
}
