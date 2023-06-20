using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board.Domain
{
    /// <summary>
    /// Категория.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор родительской категории.
        /// </summary>
        public Guid? ParentId { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Признак актуальности.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Дата/время создания (UTC).
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Объявления.
        /// </summary>
        public virtual List<Advert> Adverts { get; set; }
    }
}
