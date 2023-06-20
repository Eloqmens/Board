using Board.Contracts.ImageAdvert;
using Board.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board.Application.AppData.Contexts.ImageAdverts.Repositories
{
    /// <summary>
    /// Репозиторий картинок объявления.
    /// </summary>
    public interface IImageAdvertRepository
    {
        /// <summary>
        /// Получение информации о файле по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор файла.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Информация о файле.</returns>
        Task<ImageAdvertInfoDto> GetInfoByIdAsync(Guid id, Guid AdvertId, CancellationToken cancellationToken);

        /// <summary>
        /// Загрузка файла в систему.
        /// </summary>
        /// <param name="model">Модель файла.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Идентификатор загруженного файла.</returns>
        Task<Guid> UploadAsync(Domain.ImageAdvert model, CancellationToken cancellationToken);

        /// <summary>
        /// Скачивание файла.
        /// </summary>
        /// <param name="id">Идентификатор файла.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Информация о скачиваемом файле.</returns>
        Task<ImageAdvertDto> DownloadAsync(Guid id, Guid AdvertId,  CancellationToken cancellationToken);

        /// <summary>
        /// Удаление файла по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор файла.</param>
        /// <param name="cancellationToken">Токен отмены.</param>        
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
