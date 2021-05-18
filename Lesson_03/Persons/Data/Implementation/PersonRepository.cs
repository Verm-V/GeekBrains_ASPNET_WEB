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

		public void Add()
		{
			throw new NotImplementedException();
		}

		public Person GetItem(int id)
		{
			return GeneratedData.data.FirstOrDefault(x => x.Id == id);
		}

		public IEnumerable<Person> GetItems()
		{
			throw new NotImplementedException();
		}

		public void Update()
		{
			throw new NotImplementedException();
		}
	}
}
