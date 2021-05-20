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

		public bool Add(Person item)
		{
			GeneratedData.data.Add(item);
			return true;
		}

		public bool Delete(int id)
		{
			var index = GeneratedData.data.IndexOf(GeneratedData.data.FirstOrDefault(x => x.Id == id));
			bool isDeleted = false;
			if (index >=0)
			{
				GeneratedData.data.RemoveAt(index);
				isDeleted = true;
			}
			return isDeleted;
		}

		public Person FindItem(string name)
		{
			return GeneratedData.data.FirstOrDefault(x => x.FirstName == name || x.LastName == name);
		}

		public Person GetItem(int id)
		{
			return GeneratedData.data.FirstOrDefault(x => x.Id == id);
		}

		public IEnumerable<Person> GetItems(int skip, int take)
		{
			// Проверка входных значений
			skip = skip < 0 ? 0 : skip;
			take = take < 0 ? 0 : take;
			if (take > GeneratedData.data.Count - skip)
			{
				take = GeneratedData.data.Count - skip;
			}

			return GeneratedData.data.GetRange(skip, take);
		}

		public bool Update(Person item)
		{
			var index = GeneratedData.data.IndexOf(GeneratedData.data.FirstOrDefault(x => x.Id == item.Id));
			bool isUpdated = false;
			if (index >=0)
			{
				GeneratedData.data[index] = item;
				isUpdated = true;
			}
			return isUpdated;
		}
	}
}
