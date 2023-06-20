using Board.Application.AppData.Contexts.ImageAdverts.Services;
using Board.Contracts;
using Board.Contracts.File;
using Board.Contracts.ImageAdvert;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Board.Host.Api.Controllers
{
    /// <summary>
    /// Контроллер для работы с файлами.
    /// </summary>
    /// <response code="500">Произошла внутренняя ошибка.</response>
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
    [Authorize]
    public class ImageAdvertController : Controller
    {
        private readonly ILogger<ImageAdvertController> _logger;
        private readonly IImageAdvertService _imageAdvertService;

        /// <summary>
        /// Инициализирует экземпляр <see cref="ImageAdvertController"/>
        /// </summary>
        /// <param name="imageAdvertService">Сервис работы с файлами.</param>
        /// <param name="logger">Сервис логирования.</param>
        public ImageAdvertController(IImageAdvertService imageAdvertService, ILogger<ImageAdvertController> logger)
        {
            _logger = logger;
            _imageAdvertService = imageAdvertService;
        }

        /// <summary>
        /// Получение информации о файле по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор файла.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <response code="200">Запрос выполнен успешно.</response>
        /// <response code="404">Файл с указанным идентификатором не найден.</response>
        /// <returns>Информация о файле.</returns>
        [HttpGet("{id}/info")]
        [ProducesResponseType(typeof(ImageAdvertInfoDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<IActionResult> GetInfoById(Guid id, Guid AdvertId, CancellationToken cancellationToken)
        {
            var result = await _imageAdvertService.GetInfoByIdAsync(id, AdvertId, cancellationToken);
            return result == null ? NotFound() : Ok(result);
        }

        /// <summary>
        /// Загрузка файла в систему.
        /// </summary>
        /// <param name="file">Файл.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <response code="201">Файл успешно загружен.</response>
        /// <response code="400">Модель данных запроса невалидна.</response>
        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
        [RequestFormLimits(ValueLengthLimit = int.MaxValue, MultipartBodyLengthLimit = long.MaxValue)]
        [DisableRequestSizeLimit]
        [Authorize]
        public async Task<IActionResult> Upload(IFormFile file, Guid AdvertId, CancellationToken cancellationToken)
        {
            var bytes = await GetBytesAsync(file, cancellationToken);
            var fileDto = new ImageAdvertDto
            {
                Content = bytes,
                ContentType = file.ContentType,
                Name = file.FileName,
                AdvertId = AdvertId
            };
            var result = await _imageAdvertService.UploadAsync(fileDto, AdvertId, cancellationToken);
            return StatusCode((int)HttpStatusCode.Created, result);
        }

        /// <summary>
        /// Скачивание файла по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор файла.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <response code="200">Запрос выполнен успешно.</response>
        /// <response code="404">Файл с указанным идентификатором не найден.</response>
        /// <returns>Файл в виде потока.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<IActionResult> Download(Guid id, Guid AdvertId, CancellationToken cancellationToken)
        {
            var result = await _imageAdvertService.DownloadAsync(id, AdvertId, cancellationToken);

            if (result == null)
            {
                return NotFound();
            }

            Response.ContentLength = result.Content.Length;
            return File(result.Content, result.ContentType, result.Name, true);
        }

        /// <summary>
        /// Удаление файла по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор файла.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <response code="403">Доступ запрещён.</response>
        /// <response code="404">Файл с указанным идентификатором не найден.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _imageAdvertService.DeleteAsync(id, cancellationToken);
            return NoContent();
        }



        private static async Task<byte[]> GetBytesAsync(IFormFile file, CancellationToken cancellationToken)
        {
            using var ms = new MemoryStream();
            await file.CopyToAsync(ms, cancellationToken);
            return ms.ToArray();
        }
    }
}
