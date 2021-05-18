using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Persons.Data.Interfaces;
using Persons.Domain.Interfaces;
using Persons.Models;

namespace Persons.Domain.Implementation
{
	public class PersonManager : IPersonManager
	{
		private readonly IPersonRepository _personRepository;

		public PersonManager(IPersonRepository personRepository)
		{
			_personRepository = personRepository;
		}

		public Person GetItem(int id)
		{
			return _personRepository.GetItem(id);
		}
	}
}
