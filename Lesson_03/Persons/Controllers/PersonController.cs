using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Persons.Domain.Interfaces;
using Persons.Models.Dto.Requests;

namespace Persons.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PersonsController : ControllerBase
	{
		private readonly ILogger<PersonsController> _logger;
		private readonly IPersonManager _personManager;

		public PersonsController(ILogger<PersonsController> logger, IPersonManager personManager)
		{
			_logger = logger;
			_personManager = personManager;
		}

		/// <summary>
		/// Получение информации о человеке по идентификатору
		/// </summary>
		/// <param name="id">Идентификатор человека</param>
		/// <returns>Информация о запрашиваемом человеке</returns>
		[HttpGet("{id}")]
		public IActionResult GetPersonsById([FromRoute] int id)
		{
			_logger.LogDebug("Params: " +
				$"{nameof(id)} = {id}");

			var result = _personManager.GetPerson(id);
			return Ok(result);

		}

		/// <summary>
		/// Поиск информации о человеке по его имени
		/// </summary>
		/// <param name="searchTerm">Имя искомого человека</param>
		/// <returns>Информация о запрашиваемом человеке</returns>
		[HttpGet("search")]
		public IActionResult SearchPersonByName([FromQuery] string searchTerm)
		{
			_logger.LogDebug("Params: " +
				$"{nameof(searchTerm)} = {searchTerm}");

			if(searchTerm.Length != 0)
			{
				var result = _personManager.FindPerson(searchTerm);
				return Ok(result);
			}
			else
			{
				return BadRequest();
			}
		}


		/// <summary>
		/// Получение списка людей с пейджингом
		/// </summary>
		/// <param name="skip">Номер человека с которого начинать выборку</param>
		/// <param name="take">Количество людей в выборке</param>
		/// <returns>Информация о запрашиваемом человеке</returns>
		[HttpGet]
		public IActionResult GetPersonsList([FromQuery] int skip, [FromQuery] int take)
		{
			_logger.LogDebug("Params: " +
				$"{nameof(skip)} = {skip} " +
				$"{nameof(take)} = {take} ");

			var result = _personManager.GetPersonsList(skip, take);
			return Ok(result);
		}

		/// <summary>
		/// Добавление нового человека в базу данных
		/// </summary>
		/// <param name="request">DTO запроса на создание человека в базе</param>
		/// <returns>Id созданного человека</returns>
		[HttpPost]
		public IActionResult CreatePerson([FromBody] PersonRequest request)
		{
			_logger.LogDebug($"Params: {Environment.NewLine}" +
				$"{request}");

			var id = _personManager.CreatePerson(request);
			return Ok(id);
		}

		/// <summary>
		/// Изменение параметров человека в базе
		/// </summary>
		/// <param name="request">DTO запроса на изменение данных человека в базе</param>
		/// <param name="id">Id человека данные которогу нужно изменить</param>
		/// <returns>Id измененного человека</returns>
		[HttpPut]
		public IActionResult UpdatePerson([FromQuery] int id, [FromBody] PersonRequest request)
		{
			_logger.LogDebug($"Params: {Environment.NewLine}" +
				$"{nameof(id)}: {id} {Environment.NewLine}" +
				$"{request}");

			var status = _personManager.UpdatePerson(id, request);
			return status ? (IActionResult)Ok() : (IActionResult)BadRequest();
		}

		/// <summary>
		/// Удаление человека из базы данных
		/// </summary>
		/// <param name="id">Идентификатор человека</param>
		/// <returns></returns>
		[HttpDelete("{id}")]
		public IActionResult DeletePerson([FromRoute] int id)
		{
			_logger.LogDebug("Params: " +
				$"{nameof(id)} = {id}");

			var status = _personManager.DeletePerson(id);
			return status ? (IActionResult)Ok() : (IActionResult)BadRequest();
		}




	}
}
