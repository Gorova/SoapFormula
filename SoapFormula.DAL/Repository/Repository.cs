using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoapFormula.DAL.Repository.Interface;
using System.Data.Entity;

namespace SoapFormula.DAL.Repository
{ 
    public class Repository : IRepository
    {
        private readonly DbContext context;

        public Repository(DbContext context)
        {
            this.context = context;
        }

        public void Add<T>(T data) where T : class
        {
            this.context.Set<T>().Add(data);
        }

        public IQueryable<T> Get<T>() where T : class
        {
            return this.context.Set<T>();
        }

        public T Get<T>(int id) where T : class
        {
            return this.context.Set<T>().Find(id);
        }

        public void Delete<T>(T data) where T : class
        {
            this.context.Set<T>().Remove(data);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}
