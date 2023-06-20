using Board.Contracts.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board.Application.AppData.Contexts.Messages.Services
{
    /// <summary>
    /// Сервис для работы с сообщениями.
    /// </summary>
    public interface IMessageService
    {
        /// <summary>
        /// Получить список сообщений.
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Список сообщений.</returns>
        Task<MessageShortInfoDto[]> GetAll(CancellationToken cancellationToken);

        /// <summary>
        /// Получить сообщения по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сообщения.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Модель коментариея.</returns>
        Task<MessageInfoDto> Get(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавить сообщения.
        /// </summary>
        /// <param name="entity">Сообщения.</param>
        /// <param name="cancellation">Токен отмены операции.</param>
        /// <returns>Модель добавленного сообщения.</returns>
        Task<MessageInfoDto> Add(CreateMessageDto dto, CancellationToken cancellation);

        /// <summary>
        /// Удалить сообщения.
        /// </summary>
        /// <param name="id">Идентификатор сообщения.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns></returns>
        Task Delete(Guid id, CancellationToken cancellationToken);
    }
}
