using System;
using System.Collections.Generic;
using System.Text;

namespace ASPNET_Lesson_01_DI.Requests
{
	/// <summary>Запрос на получение списка постов по интервалу ID</summary>
	class PostsRangeRequest
	{
		/// <summary>первый ID в списке запрашиваемых постов</summary>
		public int FirstId { get; set; }
		/// <summary>последний ID в списке запрашиваемых постов</summary>
		public int LastId { get; set; }

		public PostsRangeRequest(int firstId, int lastId)
		{
			FirstId = firstId;
			LastId = lastId;
		}
	}
}
