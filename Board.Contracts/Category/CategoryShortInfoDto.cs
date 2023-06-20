using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board.Contracts.Category
{
    /// <summary>
    /// Краткая информация о категории.
    /// </summary>
    public class CategoryShortInfoDto
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор родительской категории.
        /// </summary>
        public Guid ParentId { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Признак актуальности.
        /// </summary>
        public bool IsActive { get; set; }
    }
}
