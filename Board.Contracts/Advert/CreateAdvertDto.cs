﻿using Board.Contracts.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board.Contracts.Advert
{
    /// <summary>
    /// Модель создания объявления.
    /// </summary>
    public class CreateAdvertDto
    {
        /// <summary>
        /// Наименование.
        /// </summary>
        [Required(ErrorMessage = "Наименование не указано")]
        [StringLength(32, ErrorMessage = "Наименование либо слишком короткое, либо слишком длинное", MinimumLength = 3)]
        [ForbiddenWordsValidation]
        public string Name { get; set; }

        /// <summary>
        /// Описание.
        /// </summary>
        [StringLength(100, ErrorMessage = "Описание либо слишком короткое, либо слишком длинное", MinimumLength = 10)]
        [ForbiddenWordsValidation]
        public string Description { get; set; }

        /// <summary>
        /// Идентификатор категории.
        /// </summary>
        [Required(ErrorMessage = "Категория не указана")]
        public Guid? CategoryId { get; set; }

        /// <summary>
        /// Цена.
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// Полный адрес.
        /// </summary>
        [Required(ErrorMessage = "Адрес не указан")]
        [StringLength(250, ErrorMessage = "Адрес либо слишком короткий, либо слишком длинный", MinimumLength = 3)]
        [ForbiddenWordsValidation]
        public string Address { get; set; }
    }
}
