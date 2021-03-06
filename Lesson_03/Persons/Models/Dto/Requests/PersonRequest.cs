using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persons.Models.Dto.Requests
{
	/// <summary>Запрос на добавление человека в базу данных</summary>
	public class PersonRequest
	{
		/// <summary>Имя</summary>
		public string FirstName { get; set; }
		/// <summary>Фамилия</summary>
		public string LastName { get; set; }
		/// <summary>Электронная почта</summary>
		public string Email { get; set; }
		/// <summary>Компания</summary>
		public string Company { get; set; }
		/// <summary>Возраст</summary>
		public int Age { get; set; }

		/// <summary>
		/// Текстовое представление параметров запроса
		/// </summary>
		/// <returns>Текстовое представление параметров запроса</returns>
		public override string ToString()
		{
			return $"{nameof(FirstName)}: {FirstName}{Environment.NewLine}" +
				$"{nameof(LastName)}: {LastName}{Environment.NewLine}" +
				$"{nameof(Email)}: {Email}{Environment.NewLine}" +
				$"{nameof(Company)}: {Company}{Environment.NewLine}" +
				$"{nameof(Age)}: {Age}{Environment.NewLine}";
		}

	}
}
