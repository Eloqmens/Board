using Board.Contracts.FavoriteAdvert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board.Application.AppData.Contexts.FavoriteAdverts.Services
{
    /// <summary>
    /// Сервис для работы с избранными объявлениями.
    /// </summary>
    public interface IFavoriteAdvertService
    {
        /// <summary>
        /// Получить список избранных объявлений.
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Список избранных объявлений.</returns>
        Task<FavoriteAdvertShortInfoDto[]> GetAll(CancellationToken cancellationToken);

        /// <summary>
        /// Получить избранное объявление по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор избранное объявление.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Модель коментариея.</returns>
        Task<FavoriteAdvertInfoDto> Get(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавить избранное объявление.
        /// </summary>
        /// <param name="entity">избранное объявление.</param>
        /// <param name="cancellation">Токен отмены операции.</param>
        /// <returns>Модель добавленного избранное объявление.</returns>
        Task<FavoriteAdvertInfoDto> Add(CreateFavoriteAdvertDto dto, CancellationToken cancellation);

        /// <summary>
        /// Удалить избранное объявление.
        /// </summary>
        /// <param name="id">Идентификатор избранное объявление.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns></returns>
        Task Delete(Guid id, CancellationToken cancellationToken);
    }
}
