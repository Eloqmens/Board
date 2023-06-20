using Board.Application.AppData.Contexts.FavoriteAdverts.Services;
using Board.Contracts;
using Board.Contracts.FavoriteAdvert;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Board.Host.Api.Controllers
{
    /// <summary>
    /// Контроллер для работы с favorite.
    /// </summary>
    /// <response code="500">Произошла внутренняя ошибка.</response>
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
    public class FavoriteAdvertController : Controller
    {
        private readonly IFavoriteAdvertService _favoriteAdvertService;
        private readonly ILogger<FavoriteAdvertController> _logger;

        /// <summary>
        /// Инициализирует экземпляр <see cref="FavoriteAdvertController"/>
        /// </summary>
        /// <param name="logger">Сервис логирования.</param>
        /// <param name="favoriteAdvertService">Сервис для работы с favorite.</param>
        public FavoriteAdvertController(ILogger<FavoriteAdvertController> logger, IFavoriteAdvertService favoriteAdvertService)
        {
            _logger = logger;
            _favoriteAdvertService = favoriteAdvertService;
        }

        /// <summary>
        /// Получить список избранных объявлений.
        /// </summary>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <response code="200">Запрос выполнен успешно</response>
        /// <returns>Список моделей избранных объявлений.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<FavoriteAdvertShortInfoDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Запрос списка избранных объявлений");
            var result = await _favoriteAdvertService.GetAll(cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Получить избранный объявление по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <response code="200">Запрос выполнен успешно.</response>
        /// <response code="404">Комментарий с указанным идентификатором не найдено.</response>
        /// <returns>Модель избранный объявление.</returns>
        [HttpGet("{id:Guid}")]
        [ProducesResponseType(typeof(FavoriteAdvertInfoDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Запрос избранный объявление по идентификатору: {id}");
            var result = await _favoriteAdvertService.Get(id, cancellationToken);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        /// <summary>
        /// Создать новое избранный объявление.
        /// </summary>
        /// <param name="dto">Модель создания избранный объявление.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <response code="201">Комментарий успешно создано.</response>
        /// <response code="400">Модель данных запроса невалидна.</response>
        /// <response code="422">Произошёл конфликт бизнес-логики.</response>
        /// <returns>Модель созданного избранный объявление.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(FavoriteAdvertInfoDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status422UnprocessableEntity)]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateFavoriteAdvertDto dto, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Запрос на создание избранный объявление: {JsonConvert.SerializeObject(dto)}");
            var result = await _favoriteAdvertService.Add(dto, cancellationToken);
            return CreatedAtAction(nameof(Create), new { result.Id });
        }

        /// <summary>
        /// Обновить избранный объявление.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <param name="dto">Модель обновления избранный объявление.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <response code="200">Запрос выполнен успешно.</response>
        /// <response code="400">Модель данных запроса невалидна.</response>
        /// <response code="403">Доступ запрещён.</response>
        /// <response code="404">Комментарий с указанным идентификатором не найдено.</response>
        /// <response code="422">Произошёл конфликт бизнес-логики.</response>
        /// <returns>Модель обновлённого избранный объявление.</returns>
        [HttpPut("{id:Guid}")]
        [ProducesResponseType(typeof(FavoriteAdvertInfoDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status422UnprocessableEntity)]
        [Authorize]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateFavoriteAdvertDto dto, CancellationToken cancellationToken)
        {
            // TODO NotImplemented
            return await Task.Run(() => Ok(new FavoriteAdvertInfoDto()), cancellationToken);
        }

        /// <summary>
        /// Удалить избранный объявление по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <response code="204">Запрос выполнен успешно.</response>
        /// <response code="403">Доступ запрещён.</response>
        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status403Forbidden)]
        [Authorize]
        public async Task<IActionResult> DeleteById(Guid id, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Запрос на удаление избранный объявление по идентификатору: {id}");
            await _favoriteAdvertService.Delete(id, cancellationToken);
            return NoContent();
        }
    }
}
