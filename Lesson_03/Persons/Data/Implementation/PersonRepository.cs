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
		public int LastId => GeneratedData.data.Last().Id;

		public bool Add(Person item)
		{
			GeneratedData.data.Add(item);
			return true;
		}

		public bool Delete(int id)
		{
			var index = GeneratedData.data.IndexOf(GeneratedData.data.FirstOrDefault(item => item.Id == id));
			GeneratedData.data.RemoveAt(index);
			return true;
		}

		public Person GetItem(int id)
		{
			return GeneratedData.data.FirstOrDefault(x => x.Id == id);
		}

		public IEnumerable<Person> GetItems(int skip, int take)
		{
			throw new NotImplementedException();
		}

		public bool Update(Person item)
		{
			throw new NotImplementedException();
		}
	}
}
