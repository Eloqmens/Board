using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board.Contracts.Advert
{
    /// <summary>
    /// Краткая информация об объявлении.
    /// </summary>
    public class AdvertShortInfoDto
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Цена.
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// Полный адрес.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Дата/время создания (UTC).
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Признак актуальности.
        /// </summary>
        public bool IsActive { get; set; }
    }
}
