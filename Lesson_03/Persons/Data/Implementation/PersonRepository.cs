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
		/// <summary>
		/// !DEBUG Тестовая коллекция
		/// </summary>
		private List<Person> persons { get; set; } = new List<Person>
		{
			new Person { Id = 1, FirstName = "Veda", LastName = "Richmond", Email = "ligula@necluctus.edu", Company = "Quisque Ac Libero LLP", Age = 42 },
			new Person { Id = 2, FirstName = "Demetria", LastName = "Andrews", Email = "feugiat.metus@penatibuset.org", Company = "Nulla Facilisi Foundation", Age = 31 },
			new Person { Id = 3, FirstName = "Byron", LastName = "Holmes", Email = "neque.Sed.eget@non.co.uk", Company = "Et Associates", Age = 63 },
			new Person { Id = 4, FirstName = "Alexander", LastName = "Cummings", Email = "egestas.ligula@ultricesDuisvolutpat.ca", Company = "Vel Institute", Age = 23 },
			new Person { Id = 5, FirstName = "Melinda", LastName = "Miles", Email = "justo.nec.ante@nonummyFusce.ca", Company = "Eu Nibh Vulputate Company", Age = 64 },
			new Person { Id = 6, FirstName = "Dustin", LastName = "Beck", Email = "iaculis@afeugiat.edu", Company = "Nec Diam Incorporated", Age = 35 },
			new Person { Id = 7, FirstName = "Ralph", LastName = "Maddox", Email = "ipsum@vulputatelacus.co.uk", Company = "Enim Corp.", Age = 22 },
		};

		public void Add()
		{
			throw new NotImplementedException();
		}

		public Person GetItem(int id)
		{
			throw new NotImplementedException();
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
