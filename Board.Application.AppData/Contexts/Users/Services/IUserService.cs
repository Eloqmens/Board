using Board.Contracts.User;

namespace Board.Application.AppData.Contexts.Users.Services
{
    /// <summary>
    /// Сервис для регистриции\авторизации пользователя.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Регистрация пользователя.
        /// </summary>
        /// <param name="login">Логин.</param>
        /// <param name="possword">Пароль.</param>
        /// <param name="cancellation">Токен отмены.</param>
        /// <returns>Идентификатор пользователя.</returns>
        Task<Guid> RegisterUserAsync(CreateUserDto userDto, CancellationToken cancellation);

        /// <summary>
        /// Авторизация пользователя.
        /// </summary>
        /// <param name="login">Логин.</param>
        /// <param name="possword">Пароль.</param>
        /// <param name="cancellation">Токен отмены.</param>
        /// <returns>Токен.</returns>
        Task<string> LoginAsync(LoginUserDto userDto, CancellationToken cancellation);

        /// <summary>
        /// Получение текущего пользователя.
        /// </summary>
        /// <param name="cancellation">Токен отмены.</param>
        /// <returns>Текущий пользователь.</returns>
        Task<UserDto> GetCurrentAsync(CancellationToken cancellation);

        /// <summary>
        /// Проверка является ли авторизованный пользователь администратором
        /// </summary>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        public Task<bool> IsUserAdmin(CancellationToken cancellation);
    }
}
