using Board.Contracts.Advert;
using Board.Contracts.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board.Contracts.FavoriteAdvert
{
    /// <summary>
    /// Избранные объявление
    /// </summary>
    public class FavoriteAdvertInfoDto
    {
        /// <summary>
        /// Индификатор Избранного объявления
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Индификатор Пользователя добавившего объявление в избранные
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Индификатор Объявления
        /// </summary>
        public Guid AdvertId { set; get; }

    }
}
