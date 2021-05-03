using System;
using System.Collections.Generic;
using System.Text;

namespace ASPNET_Lesson_01_DI.Responses
{
	/// <summary>Ответ от сервера на запрос поста</summary>
	class PostResponse
	{
		/// <summary>ID пользователя</summary>
		public int UserId { get; set; }

		/// <summary>ID поста</summary>
		public int Id { get; set; }
		/// <summary>Заголовок поста</summary>
		public string Title { get; set; }
		/// <summary>Содержание поста</summary>
		public string Body { get; set; }

		public override string ToString()
		{
			return $"{UserId}\n{Id}\n{Title}\n{Body}\n";
		}
	}
}
