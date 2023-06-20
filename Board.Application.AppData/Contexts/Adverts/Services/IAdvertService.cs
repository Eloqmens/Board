using Board.Contracts.Advert;
using Microsoft.AspNetCore.Http;

namespace Board.Application.AppData.Contexts.Adverts.Services
{
    public interface IAdvertService
    {
        /// <summary>
        /// Получить список объявлений.
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Список объявлений.</returns>
        Task<AdvertShortInfoDto[]> GetAll(CancellationToken cancellationToken);

        /// <summary>
        /// Получить объявление по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор объявления.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Модель объявления.</returns>
        Task<AdvertInfoDto> Get(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавить объявление.
        /// </summary>
        /// <param name="entity">Объявление.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Модель добавленного объявления.</returns>
        Task<AdvertInfoDto> Add(CreateAdvertDto dto, CancellationToken cancellationToken);

        /// <summary>
        /// Обновляет данные объявления.
        /// </summary>
        /// <param name="id">Идентификатор объявления.</param>
        /// <param name="model">Обновленная модель представления объявления.</param>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <param name="cancellation">Маркер отмены.</param>
        public Task UpdateAdvt(Guid id, UpdateAdvertDto model, HttpRequest Request, CancellationToken cancellation);

        /// <summary>
        /// Удалить объявление.
        /// </summary>
        /// <param name="id">Идентификатор объявления.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns></returns>
        Task Delete(Guid id, CancellationToken cancellationToken);
    }
}
