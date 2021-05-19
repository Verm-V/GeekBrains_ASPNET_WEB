using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Persons.Data.Interfaces;
using Persons.Domain.Interfaces;
using Persons.Models;
using Persons.Models.Dto.Requests;

namespace Persons.Domain.Implementation
{
	public class PersonManager : IPersonManager
	{
		private readonly IPersonRepository _personRepository;

		public PersonManager(IPersonRepository personRepository)
		{
			_personRepository = personRepository;
		}

		public int CreatePerson(PersonRequest request)
		{
			throw new NotImplementedException();
		}

		public bool DeletePerson(int id)
		{
			throw new NotImplementedException();
		}

		public Person FindPerson(string name)
		{

			throw new NotImplementedException();
		}

		public Person GetPerson(int id)
		{
			return _personRepository.GetItem(id);
		}

		public List<Person> GetPersonsList(int skip, int take)
		{
			throw new NotImplementedException();
		}

		public bool UpdatePerson(PersonRequest request)
		{
			throw new NotImplementedException();
		}
	}
}
