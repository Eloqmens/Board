using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board.Contracts.Comment
{
    /// <summary>
    /// Краткая информация об коментарии.
    /// </summary>
    public class CommentShortInfo
    {
        /// <summary>
        /// Индификатор Отзыва
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Индификатор Пользователя оставившего отзыв
        /// </summary>
        public Guid SenderId { get; set; }

        /// <summary>
        /// Индификатор Пользователя которому оставили отзыв
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Содержимое отзыва
        /// </summary>
        public string Text { get; set; }
    }
}
