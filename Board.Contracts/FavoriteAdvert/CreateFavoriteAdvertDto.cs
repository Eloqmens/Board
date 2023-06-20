using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board.Contracts.FavoriteAdvert
{
    /// <summary>
    /// Добавить в избранное
    /// </summary>
    public class CreateFavoriteAdvertDto
    {
        /// <summary>
        /// Индификатор Пользователя добавившего объявление в избранные
        /// </summary>
        [Required]
        public Guid UserId { get; set; }

        /// <summary>
        /// Индификатор Объявления
        /// </summary>
        [Required]
        public Guid AdvertId { set; get; }
    }
}
