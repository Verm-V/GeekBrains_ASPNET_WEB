using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Persons.Models;

namespace Persons.Domain.Interfaces
{
	public interface IPersonManager
	{
		Person GetItem(int id);
	}
}
