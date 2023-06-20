using Board.Contracts.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board.Contracts.Category
{
    /// <summary>
    /// Модель создания категории.
    /// </summary>
    public class CreateCategoryDto
    {
        /// <summary>
        /// Наименование.
        /// </summary>
        [Required(ErrorMessage = "Наименование не указано")]
        [StringLength(32, ErrorMessage = "Наименование либо слишком короткое, либо слишком длинное", MinimumLength = 3)]
        [ForbiddenWordsValidation]
        public string Name { get; set; }

        /// <summary>
        /// Идентификатор родительской категории.
        /// </summary>
        public Guid? ParentId { get; set; }

        /// <summary>
        /// Признак актуальности.
        /// </summary>
        public bool IsActive { get; set; } = true;
    }
}
