using Board.Application.AppData.Contexts.Messages.Services;
using Board.Contracts;
using Board.Contracts.Message;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Board.Host.Api.Controllers
{
    /// <summary>
    /// Контроллер для работы с Сообщениями.
    /// </summary>
    /// <response code="500">Произошла внутренняя ошибка.</response>
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly ILogger<MessageController> _logger;

        /// <summary>
        /// Инициализирует экземпляр <see cref="MessageController"/>
        /// </summary>
        /// <param name="logger">Сервис логирования.</param>
        /// <param name="messageService">Сервис для работы с Сообщениями.</param>
        public MessageController(ILogger<MessageController> logger, IMessageService messageService)
        {
            _logger = logger;
            _messageService = messageService;
        }

        /// <summary>
        /// Получить список сообщений.
        /// </summary>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <response code="200">Запрос выполнен успешно</response>
        /// <returns>Список моделей сообщений.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MessageShortInfoDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Запрос списка сообщений");
            var result = await _messageService.GetAll(cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Получить сообщения по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <response code="200">Запрос выполнен успешно.</response>
        /// <response code="404">Комментарий с указанным идентификатором не найдено.</response>
        /// <returns>Модель сообщения.</returns>
        [HttpGet("{id:Guid}")]
        [ProducesResponseType(typeof(MessageInfoDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Запрос сообщения по идентификатору: {id}");
            var result = await _messageService.Get(id, cancellationToken);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        /// <summary>
        /// Создать новое сообщения.
        /// </summary>
        /// <param name="dto">Модель создания сообщения.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <response code="201">Комментарий успешно создано.</response>
        /// <response code="400">Модель данных запроса невалидна.</response>
        /// <response code="422">Произошёл конфликт бизнес-логики.</response>
        /// <returns>Модель созданного сообщения.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(MessageInfoDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status422UnprocessableEntity)]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateMessageDto dto, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Запрос на создание сообщения: {JsonConvert.SerializeObject(dto)}");
            var result = await _messageService.Add(dto, cancellationToken);
            return CreatedAtAction(nameof(Create), new { result.Id });
        }

        /// <summary>
        /// Обновить сообщения.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <param name="dto">Модель обновления сообщения.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <response code="200">Запрос выполнен успешно.</response>
        /// <response code="400">Модель данных запроса невалидна.</response>
        /// <response code="403">Доступ запрещён.</response>
        /// <response code="404">Комментарий с указанным идентификатором не найдено.</response>
        /// <response code="422">Произошёл конфликт бизнес-логики.</response>
        /// <returns>Модель обновлённого сообщения.</returns>
        [HttpPut("{id:Guid}")]
        [ProducesResponseType(typeof(MessageInfoDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status422UnprocessableEntity)]
        [Authorize]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateMessageDto dto, CancellationToken cancellationToken)
        {
            // TODO NotImplemented
            return await Task.Run(() => Ok(new MessageInfoDto()), cancellationToken);
        }

        /// <summary>
        /// Удалить сообщения по идентификатору.
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
            _logger.LogInformation($"Запрос на удаление сообщения по идентификатору: {id}");
            await _messageService.Delete(id, cancellationToken);
            return NoContent();
        }
    }
}
