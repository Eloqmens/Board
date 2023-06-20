using Board.Contracts.FavoriteAdvert;
using Board.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board.Application.AppData.Contexts.FavoriteAdverts.Repositories
{
    /// <summary>
    /// Репозиторий для работы с избранными объявленими.
    /// </summary>
    public interface IFavoriteAdvertRepository
    {
        /// <summary>
        /// Получить список избранными объявленими.
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Список избранными объявленими.</returns>
        Task<FavoriteAdvertShortInfoDto[]> GetAll(CancellationToken cancellationToken);

        /// <summary>
        /// Получить избранными объявленими по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сообщения.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Модель сообщения.</returns>
        Task<FavoriteAdvertInfoDto> Get(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавить избранными объявленими.
        /// </summary>
        /// <param name="entity">избранный объявление.</param>
        /// <param name="cancellation">Токен отмены операции.</param>
        /// <returns>Модель добавленного сообщения.</returns>
        Task<FavoriteAdvertInfoDto> Add(FavoriteAdvert entity, CancellationToken cancellation);

        /// <summary>
        /// Удалить избранными объявленими.
        /// </summary>
        /// <param name="id">Идентификатор сообщения.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns></returns>
        Task Delete(Guid id, CancellationToken cancellationToken);
    }
}
