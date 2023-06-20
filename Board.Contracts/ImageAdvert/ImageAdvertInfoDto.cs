using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board.Contracts.ImageAdvert
{
    public class ImageAdvertInfoDto
    {
        /// <summary>
        /// Идентификатор ImageAdvert.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование ImageAdvert.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Дата создания ImageAdvert.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Размер ImageAdvert.
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// Индификатор Объявления
        /// </summary>
        public Guid AdvertId { get; set; }
    }
}
