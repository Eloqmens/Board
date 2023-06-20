using Board.Application.AppData.Contexts.Comments.Services;
using Board.Contracts;
using Board.Contracts.Comment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Board.Host.Api.Controllers
{
    /// <summary>
    /// Контроллер для работы с комментариями.
    /// </summary>
    /// <response code="500">Произошла внутренняя ошибка.</response>
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly ILogger<CommentController> _logger;

        /// <summary>
        /// Инициализирует экземпляр <see cref="CommentController"/>
        /// </summary>
        /// <param name="logger">Сервис логирования.</param>
        /// <param name="commentService">Сервис для работы с комментариями.</param>
        public CommentController(ILogger<CommentController> logger, ICommentService commentService)
        {
            _logger = logger;
            _commentService = commentService;
        }

        /// <summary>
        /// Получить список комментариев.
        /// </summary>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <response code="200">Запрос выполнен успешно</response>
        /// <returns>Список моделей комментариев.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CommentShortInfo>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Запрос списка комментариев");
            var result = await _commentService.GetAll(cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Получить комментарий по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <response code="200">Запрос выполнен успешно.</response>
        /// <response code="404">Комментарий с указанным идентификатором не найдено.</response>
        /// <returns>Модель комментария.</returns>
        [HttpGet("{id:Guid}")]
        [ProducesResponseType(typeof(CommentInfoDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Запрос комментария по идентификатору: {id}");
            var result = await _commentService.Get(id, cancellationToken);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        /// <summary>
        /// Создать новое комментарий.
        /// </summary>
        /// <param name="dto">Модель создания комментария.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <response code="201">Комментарий успешно создано.</response>
        /// <response code="400">Модель данных запроса невалидна.</response>
        /// <response code="422">Произошёл конфликт бизнес-логики.</response>
        /// <returns>Модель созданного комментария.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(CommentInfoDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status422UnprocessableEntity)]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateCommentDto dto, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Запрос на создание комментария: {JsonConvert.SerializeObject(dto)}");
            var result = await _commentService.Add(dto, cancellationToken);
            return CreatedAtAction(nameof(Create), new { result.Id });
        }

        /// <summary>
        /// Обновить комментарий.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <param name="dto">Модель обновления комментария.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <response code="200">Запрос выполнен успешно.</response>
        /// <response code="400">Модель данных запроса невалидна.</response>
        /// <response code="403">Доступ запрещён.</response>
        /// <response code="404">Комментарий с указанным идентификатором не найдено.</response>
        /// <response code="422">Произошёл конфликт бизнес-логики.</response>
        /// <returns>Модель обновлённого комментария.</returns>
        [HttpPut("{id:Guid}")]
        [ProducesResponseType(typeof(CommentInfoDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status422UnprocessableEntity)]
        [Authorize]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCommentDto dto, CancellationToken cancellationToken)
        {
            // TODO NotImplemented
            return await Task.Run(() => Ok(new CommentInfoDto()), cancellationToken);
        }

        /// <summary>
        /// Удалить комментарий по идентификатору.
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
            _logger.LogInformation($"Запрос на удаление комментария по идентификатору: {id}");
            await _commentService.Delete(id, cancellationToken);
            return NoContent();
        }
    }
}
