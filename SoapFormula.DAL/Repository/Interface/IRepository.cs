using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoapFormula.DAL.Repository.Interface
{
    public interface IRepository
    {
        void Add<T>(T data) where T : class;

        IQueryable<T> Get<T>() where T : class;

        T Get<T>(int id) where T : class;

        void Delete<T>(T data) where T : class;

        void Save();
    }
}
