using System;
using System.Collections.Generic;
using System.Text;

namespace ASPNET_Lesson_01
{
	/// <summary>Содержит информацию о посте</summary>
	class Post
	{
		/// <summary>Id пользователя</summary>
		public int UserId { get; set; }
		/// <summary>Id поста</summary>
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
