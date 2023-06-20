using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board.Contracts.Interfaces
{
    /// <summary>
    /// Сервис для работы с запрещёнными словами.
    /// </summary>
    public interface IForbiddenWordsService
    {
        /// <summary>
        /// Получить список запрещённых слов.
        /// </summary>
        /// <returns>Список запрещённых слов.</returns>
        string[] GetForbiddenWords();
    }
}
