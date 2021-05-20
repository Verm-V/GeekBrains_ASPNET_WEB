using AutoMapper;
using Persons.Models.Dto.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persons.Models
{
	/// <summary>
	/// Настройки автомаппера
	/// </summary>
	public class MapperProfile : Profile
	{
		public MapperProfile()
		{
			CreateMap<PersonRequest, Person>();
		}
	}
}
