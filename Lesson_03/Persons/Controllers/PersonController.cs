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

			var resultPerson = _personManager.GetItem(id);
			return Ok(resultPerson);


			return Ok();
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

			return Ok();
		}


		/// <summary>
		/// Получение списка людей с пейджингом
		/// </summary>
		/// <param name="skip">Номер человека с которого начинать выборку</param>
		/// <param name="take">Количество людей в выборке</param>
		/// <returns>Информация о запрашиваемом человеке</returns>
		[HttpGet]
		public IActionResult GetPersonsList([FromQuery] int? skip, [FromQuery] int? take)
		{
			_logger.LogDebug("Params: " +
				$"{nameof(skip)} = {(skip.HasValue ? skip.Value.ToString() : "n/a")} " +
				$"{nameof(take)} = {(take.HasValue ? take.Value.ToString() : "n/a")} ");

			return Ok();
		}

		/// <summary>
		/// Добавление нового человека в базу данных
		/// </summary>
		/// <param name="request">DTO запроса на создание человека в базе</param>
		/// <returns>Id созданного человека</returns>
		[HttpPost]
		public IActionResult CreatePerson([FromBody] PersonCreateRequest request)
		{
			_logger.LogDebug($"Params: {Environment.NewLine}" +
				$"{request.ToString()}");

			return Ok();
		}

		/// <summary>
		/// Изменение параметров человека в базе
		/// </summary>
		/// <param name="request">DTO запроса на изменение данных человека в базе</param>
		/// <returns>Id измененного человека</returns>
		[HttpPut]
		public IActionResult UpdatePerson([FromBody] PersonUpdateRequest request)
		{
			_logger.LogDebug($"Params: {Environment.NewLine}" +
				$"{request.ToString()}");

			return Ok();
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

			return Ok();
		}




	}
}
