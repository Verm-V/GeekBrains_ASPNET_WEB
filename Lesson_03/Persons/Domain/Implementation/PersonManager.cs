using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Persons.Data.Interfaces;
using Persons.Domain.Interfaces;
using Persons.Models;
using Persons.Models.Dto.Requests;

namespace Persons.Domain.Implementation
{
	public class PersonManager : IPersonManager
	{
		private readonly IPersonRepository _personRepository;
		private readonly IMapper _mapper;

		public PersonManager(IPersonRepository personRepository, IMapper mapper)
		{
			_personRepository = personRepository;
			_mapper = mapper;
		}

		public int CreatePerson(PersonRequest request)
		{
			var id = _personRepository.LastId + 1;
			var person = _mapper.Map<Person>(request);
			person.Id = id;
			_personRepository.Add(person);
			return id;
		}

		public bool DeletePerson(int id)
		{
			return _personRepository.Delete(id);
		}

		public Person FindPerson(string name)
		{
			return _personRepository.FindItem(name);
		}

		public Person GetPerson(int id)
		{
			return _personRepository.GetItem(id);
		}

		public IEnumerable<Person> GetPersonsList(int skip, int take)
		{
			return _personRepository.GetItems(skip, take);
		}

		public bool UpdatePerson(int id, PersonRequest request)
		{
			var person = _mapper.Map<Person>(request);
			person.Id = id;
			return _personRepository.Update(person);
		}
	}
}
