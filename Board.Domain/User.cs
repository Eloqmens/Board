using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board.Domain
{
    /// <summary>
    /// Акаунт.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Логин пользователя.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Дата регистрации.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// ID Роли пользователя
        /// </summary>
        public Guid RoleId { get; set; }

        /// <summary>
        /// Роль пользователя
        /// </summary>
        [ForeignKey("RoleId")]
        public Role Role { get; set; }

        /// <summary>
        /// Отправленные сообщения
        /// </summary>
        public ICollection<Message> SendedMessages { get; set; }

        /// <summary>
        /// Полученные сообщения
        /// </summary>
        public ICollection<Message> RecievedMessages { get; set; }

        /// <summary>
        /// Отзывы оставленные пользователю
        /// </summary>
        public ICollection<Comment> SendedComments { get; set; }

        /// <summary>
        /// Отзывы оставленные пользователю
        /// </summary>
        public ICollection<Comment> RecievedComments { get; set; }

        /// <summary>
        /// Избранные объявления пользователя
        /// </summary>
        public ICollection<FavoriteAdvert> FavoriteAdvert { get; set; }
    }
}
