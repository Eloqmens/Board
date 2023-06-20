using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board.Contracts.ImageAdvert
{
    public class ImageAdvertDto
    {
        /// <summary>
        /// Имя ImageAdvert.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Контент ImageAdvert.
        /// </summary>
        public byte[] Content { get; set; }

        /// <summary>
        /// ContentType ImageAdvert.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Индификатор Объявления
        /// </summary>
        public Guid AdvertId { get; set; }

    }
}
