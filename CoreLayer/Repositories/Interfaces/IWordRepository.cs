using CustomDictionary.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDictionary.CoreLayer.Repositories.Interfaces
{
    public interface IWordRepository
    {
        IEnumerable<Word> GetWordBySearch(string search);
        Word GetWordById(int id);
        void AddWord(Word word);
        void UpdateWord(Word word);
        void DeleteWord(Word word);
        void DeleteWord(int id);
    }
}
