using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board.Domain
{
    public class ImageAdvert
    {
        /// <summary>
        /// Идентификатор файла.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Имя файла.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Контент файла.
        /// </summary>
        public byte[] Content { get; set; }

        /// <summary>
        /// ContentType файла.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Размер файла.
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// Время создания.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Индификатор Объявления
        /// </summary>
        public Guid AdvertId { get; set; }

        /// <summary>
        /// Объявление
        /// </summary>
        public Advert Ad { get; set; }
    }
}
