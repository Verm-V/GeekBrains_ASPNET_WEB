using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persons.Models
{
	/// <summary>Класс описывающий человека</summary>
	public class Person
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>Имя</summary>
		public string FirstName { get; set; }
		/// <summary>Фамилия</summary>
		public string LastName { get; set; }
		/// <summary>Электронная почта</summary>
		public string Email { get; set; }
		/// <summary>Компания</summary>
		public string Company  { get; set; }
		/// <summary>Возраст</summary>
		public int Age { get; set; }
	}
}
