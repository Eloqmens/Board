using Board.Contracts.Message;
using Board.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board.Application.AppData.Contexts.Messages.Repositories
{
    /// <summary>
    /// Репозиторий для работы с сообщениями.
    /// </summary>
    public interface IMessageRepository
    {
        /// <summary>
        /// Получить список сообщений.
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Список сообщений.</returns>
        Task<MessageShortInfoDto[]> GetAll(CancellationToken cancellationToken);

        /// <summary>
        /// Получить сообщение по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сообщения.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Модель сообщения.</returns>
        Task<MessageInfoDto> Get(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавить сообщение.
        /// </summary>
        /// <param name="entity">Коментарий.</param>
        /// <param name="cancellation">Токен отмены операции.</param>
        /// <returns>Модель добавленного сообщения.</returns>
        Task<MessageInfoDto> Add(Message entity, CancellationToken cancellation);

        /// <summary>
        /// Удалить сообщение.
        /// </summary>
        /// <param name="id">Идентификатор сообщения.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns></returns>
        Task Delete(Guid id, CancellationToken cancellationToken);
    }
}
