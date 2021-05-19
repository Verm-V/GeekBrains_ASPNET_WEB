using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Persons.Models;
using Persons.Models.Dto.Requests;

namespace Persons.Domain.Interfaces
{
	public interface IPersonManager
	{
		/// <summary>Извлекает из репозитория данные о человеке по Id</summary>
		/// <param name="id">Id искомого человека</param>
		/// <returns>Данные о человеке</returns>
		Person GetPerson(int id);

		/// <summary>Ищет человека в репозитории по имени</summary>
		/// <param name="name">Имя искомого человека</param>
		/// <returns>Данные о человеке</returns>
		Person FindPerson(string name);

		/// <summary>Извлекает из репозитория список данных о челвеках</summary>
		/// <param name="skip">Номер с которого начинать извлечение</param>
		/// <param name="take">Сколько человеков нужно извлечь</param>
		/// <returns>Список с данными о человеках</returns>
		IEnumerable<Person> GetPersonsList(int skip, int take);

		/// <summary>Создает в репозитории нового человека</summary>
		/// <param name="request">Запрос на создание человека</param>
		/// <returns>Id вновь созданного человека</returns>
		int CreatePerson(PersonRequest request);

		/// <summary>Изменяет данные заданного человека в репозитории</summary>
		/// <param name="id">Id элемента который нужно обновить</param>
		/// <param name="request">Запрос на изменение данных</param>
		/// <returns>Статус операции</returns>
		bool UpdatePerson(int id, PersonRequest request);
		
		/// <summary>Удаляет указанного человека из репозитория</summary>
		/// <param name="id">Id человека которого нужно удалить</param>
		/// <returns>Статус операции</returns>
		bool DeletePerson(int id);

	}
}
