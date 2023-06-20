using Board.Contracts.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Board.Contracts.User
{
    /// <summary>
    /// Информация об аккаунте.
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Логин.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Электронный адрес.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Признак блокировки.
        /// </summary>
        public bool IsBlocked { get; set; }

        /// <summary>
        /// Роль пользователя
        /// </summary>
        public InfoRoleDto Role { get; set; }

        public bool IsAuthenticated { get; set; }
        public string Scheme { get; set; }
        public List<Claim> Claims { get; set; } = new List<Claim>();

    }
}
