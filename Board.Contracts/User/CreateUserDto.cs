using Board.Contracts.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board.Contracts.User
{
    /// <summary>
    /// Модель для создания аккаунта.
    /// </summary>
    public class CreateUserDto
    {
        /// <summary>
        /// Логин.
        /// </summary>
        [Required(ErrorMessage = "Логин не указан")]
        [StringLength(64, ErrorMessage = "Логин либо слишком короткий, либо слишком длинный", MinimumLength = 3)]
        [ForbiddenWordsValidation]
        public string Login { get; set; }

        /// <summary>
        /// Пароль.
        /// </summary>
        [Required(ErrorMessage = "Пароль не указан")]
        [StringLength(32, MinimumLength = 8)]
        public string Password { get; set; }

        /// <summary>
        /// Электронный адрес.
        /// </summary>
        [RegularExpression(@"^.+\@.+\..+$")]
        public string Email { get; set; }

        /// <summary>
        /// ID Роли
        /// </summary>
        public Guid RoleId { get; set; }

    }
}
