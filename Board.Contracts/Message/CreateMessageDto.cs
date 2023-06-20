using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board.Contracts.Message
{
    /// <summary>
    /// Создание сообщения
    /// </summary>
    public class CreateMessageDto
    {
        /// <summary>
        /// Индификатор Получателя
        /// </summary>
        [Required]
        public Guid RecieverId { get; set; }


        /// <summary>
        /// Содержимое сообщения
        /// </summary>
        [MinLength(1)]
        [Required]
        public string Containment { get; set; }
    }
}
