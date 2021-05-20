using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persons.Data
{
	public interface IRepositoryBase<T>
	{
		/// <summary>Последний Id используемый в хранилище</summary>
		int LastId { get; }

		/// <summary>Возвращает элемент из хранилища</summary>
		/// <param name="id">Id нужного элемента</param>
		/// <returns>Икомый элемент</returns>
		T GetItem(int id);

		/// <summary>Возвращает список элементов из хранилища</summary>
		/// <param name="skip">Номер с которого начинать извлечение</param>
		/// <param name="take">Сколько человеков нужно извлечь</param>
		/// <returns>Коллекция с искомыми элементами</returns>
		IEnumerable<T> GetItems(int skip, int take);

		/// <summary>Ищет и возвращает элемент из хранилища по имени</summary>
		/// <param name="searchString">Имя искомого элемента</param>
		/// <returns>Искомый элемент</returns>
		T FindItem(string searchString);

		/// <summary>Добавляет элемент в хранилище</summary>
		/// <param name="item">Элемент который нужно добавить в хранилище</param>
		void Add(T item);

		/// <summary>Изменяет элемент в хранилище</summary>
		/// <param name="item">Новый элемент взамен старого</param>
		/// <returns>Статус операции</returns>
		bool Update(T item);

		/// <summary>Удаляет элемент из хранилища</summary>
		/// <param name="id">Id элемента который нужно удалить</param>
		/// <returns>Статус операции</returns>
		bool Delete(int id);
	}
}
