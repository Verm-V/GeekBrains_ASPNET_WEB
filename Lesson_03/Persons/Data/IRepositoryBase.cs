using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persons.Data
{
	public interface IRepositoryBase<T>
	{
		T GetItem(int id);
		IEnumerable<T> GetItems();
		void Add();
		void Update();

	}
}
