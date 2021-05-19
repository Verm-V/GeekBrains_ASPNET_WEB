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
		Person GetPerson(int id);
		Person FindPerson(string name);
		List<Person> GetPersonsList(int skip, int take);
		int CreatePerson(PersonRequest request);
		bool UpdatePerson(PersonRequest request);
		bool DeletePerson(int id);

	}
}
