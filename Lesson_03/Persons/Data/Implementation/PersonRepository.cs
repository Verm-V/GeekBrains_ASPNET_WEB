using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Persons.Data.Interfaces;
using Persons.Models;

namespace Persons.Data.Implementation
{
	public class PersonRepository : IPersonRepository
	{
		public int LastId => GeneratedData.data.Max(x => x.Id);

		public void Add(Person person)
		{
			GeneratedData.data.Add(person);
		}

		public bool Delete(int id)
		{
			var index = FindIndexById(id);
			bool isDeleted = false;
			if (index >=0)
			{
				GeneratedData.data.RemoveAt(index);
				isDeleted = true;
			}
			return isDeleted;
		}

		public Person FindItem(string searchTerm)
		{
			return GeneratedData.data.FirstOrDefault(x => x.FirstName == searchTerm || x.LastName == searchTerm);
		}

		public Person GetItem(int id)
		{
			return GeneratedData.data.FirstOrDefault(x => x.Id == id);
		}

		public IEnumerable<Person> GetItems(int skip, int take)
		{
			// Проверка входных значений
			var count = GeneratedData.data.Count;
			skip = (skip < 0) ? 0 : skip;
			skip = (skip > count) ? count : skip;
			take = (take < 0) ? 0 : take;
			take = (take > count - skip) ? count - skip : take;

			return GeneratedData.data.GetRange(skip, take);
		}

		public bool Update(Person person)
		{
			var index = FindIndexById(person.Id);
			bool isUpdated = false;
			if (index >=0)
			{
				GeneratedData.data[index] = person;
				isUpdated = true;
			}
			return isUpdated;
		}

		private int FindIndexById(int id)
		{
			return GeneratedData.data.IndexOf(GeneratedData.data.FirstOrDefault(x => x.Id == id));
		}

	}
}
