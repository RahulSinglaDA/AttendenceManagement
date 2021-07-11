using System;
using System.Collections.Generic;
using System.Text;

namespace DBManager.Repositories
{
    public interface IRepository<T>
    {
        public void Add(T entity);
        public T Get(int id);
        public void Update(int id, T entity);
        public IEnumerable<T> GetAll();
        public void Delete(int id);
    }
}
