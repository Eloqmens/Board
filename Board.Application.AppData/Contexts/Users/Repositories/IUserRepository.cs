using Board.Domain;
using System.Linq.Expressions;

namespace Board.Application.AppData.Contexts.Users.Repositories
{
    /// <summary>
    /// Репозиторий для работы с объявлениями.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Поиск пользователя по фильтру.
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        Task<User> FindWhere(Expression<Func<User, bool>> predicate, CancellationToken cancellation);

        /// <summary>
        /// Поиск пользователя по идентификатору.
        /// </summary>
        /// <param name="id"> Идентификатор пользователя</param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        Task<User> FindById(Guid id, CancellationToken cancellation);

        /// <summary>
        /// Добавление пользователя.
        /// </summary>
        /// <param name="entity">Пользователь.</param>
        /// <returns></returns>
        Task<Guid> AddAsync(User entity, CancellationToken cancellation);
    }
}
