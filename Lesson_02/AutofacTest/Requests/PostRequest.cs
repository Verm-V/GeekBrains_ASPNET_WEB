using System;
using System.Collections.Generic;
using System.Text;

namespace AutofacTest.Requests
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
