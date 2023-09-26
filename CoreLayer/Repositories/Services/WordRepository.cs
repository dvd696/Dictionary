using CustomDictionary.CoreLayer.Repositories.Interfaces;
using CustomDictionary.DataLayer.Context;
using CustomDictionary.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDictionary.CoreLayer.Repositories.Services
{
    public class WordRepository : IWordRepository
    {
        private readonly DictionaryContext _db;

        public WordRepository(DictionaryContext db)
        {
            _db = db;
        }

        public void AddWord(Word word)
        {
            _db.Words.Add(word);
        }

        public void DeleteWord(Word word)
        {
            _db.Words.Remove(word);
        }

        public void DeleteWord(int id)
        {
            var word = GetWordById(id);
            DeleteWord(word);
        }

        public Word GetWordById(int id)
        {
            return _db.Words.Find(id);
        }

        public IEnumerable<Word> GetWordBySearch(string search)
        {
            return _db.Words.Where(x => x.Content.ToLower().Contains(search) || x.Translates.ToLower().Contains(search))
                .ToList();
        }

        public void UpdateWord(Word word)
        {
            ChechState(word.Id);
            _db.Update(word);
        }

        private void ChechState(int wordId)
        {
            var word = GetWordById(wordId);
            if (_db.Entry(word).State!=Microsoft.EntityFrameworkCore.EntityState.Detached) 
            {
                _db.Entry(word).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            }
        }
    }
}
