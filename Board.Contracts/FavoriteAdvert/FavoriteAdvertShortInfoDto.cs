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
    /// Коротко о избранном объявление
    /// </summary>
    public class FavoriteAdvertShortInfoDto
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
