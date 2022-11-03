using MappingPerformance.Adapters.IDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MappingPerformance.Adapters.DataAccess
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DatabaseContext _context;

        public Repository(DatabaseContext context)
        {
            _context = context;
        }

        public List<T> List()
        {
            return _context.Set<T>().ToList();
        }

        public List<T> List(Expression<Func<T, bool>> where)
        {
            return _context.Set<T>().Where(where).ToList();
        }

        public IQueryable<T> ListQueryable()
        {
            return _context.Set<T>().AsQueryable<T>();
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return _context.Set<T>().FirstOrDefault(where);
        }

        public int Insert(T obj)
        {
            _context.Set<T>().Add(obj);
            return Save();
        }

        public int Update(T obj)
        {
            _context.Set<T>().Update(obj);
            return Save();
        }

        public int Delete(T obj)
        {
            _context.Set<T>().Remove(obj);
            return Save();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
