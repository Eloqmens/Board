using Board.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board.Application.AppData.Services
{
    public class ForbiddenWordsService : IForbiddenWordsService
    {
        public string[] GetForbiddenWords()
        {
            return new[] { "дурак", "реклама", "взятка", "мяу" };
        }
    }
}
