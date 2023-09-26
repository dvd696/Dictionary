using CustomDictionary.CoreLayer.Repositories.Interfaces;
using CustomDictionary.CoreLayer.Repositories.Services;
using CustomDictionary.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDictionary.CoreLayer.Repositories.Managers
{
    public class UnitOfWork : IDisposable
    {
        private readonly DictionaryContext context;

        public UnitOfWork()
        {
            context = new DictionaryContext();
            context.Database.EnsureCreated();
        }


        private IWordRepository _wordRepository;
        public IWordRepository WordRepository 
        { 
            get 
            {
                if (_wordRepository==null)
                {
                    _wordRepository = new WordRepository(context);
                }
                return _wordRepository;
            } 
        }





        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
