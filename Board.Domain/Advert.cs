using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board.Domain
{
    /// <summary>
    /// Объявление.
    /// </summary>
    public class Advert
    {
        /// <summary>
        /// Индификатор
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Описание.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Цена.
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// Полный адрес.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Признак актуальности.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Фотографии объявления
        /// </summary>
        public ICollection<ImageAdvert> ImageAdverts { get; set; }

        /// <summary>
        /// Дата/время создания (UTC).
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Идентификатор категории.
        /// </summary>
        public Guid CategoryId { get; set; }

        /// <summary>
        /// Категория.
        /// </summary>
        public Category Category { get; set; }
    }
}
