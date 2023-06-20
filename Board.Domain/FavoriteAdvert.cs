using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board.Domain
{
    /// <summary>
    /// Избранное объявление.
    /// </summary>
    public class FavoriteAdvert
    {
        /// <summary>
        /// Индификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Индификатор пользователя.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Пользователь добавивший объявление в избранные.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Индификатор Объявления.
        /// </summary>
        public Guid AdvertId { set; get; }

        /// <summary>
        /// Объявления.
        /// </summary>
        public Advert Advert { get; set; }
    }
}
