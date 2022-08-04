using Microsoft.EntityFrameworkCore.Internal;
using ppedv.Hotelity.Model;
using ppedv.Hotelity.Model.Contracts;

namespace ppedv.Hotelity.Data.EfCore
{
    public class EfUnitOfWork : IUnitOfWork
    {
        EfContext _context = new EfContext();

        public IRepository<T> GetRepo<T>() where T : Entity
        {
            return new EfRepository<T>(_context);
        }

        public void SaveAll()
        {
            _context.SaveChanges();
        }
    }

    public class EfRepository<T> : IRepository<T> where T : Entity
    {
        private protected EfContext _context;

        internal EfRepository(EfContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public T GetId(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IQueryable<T> Query()
        {
            return _context.Set<T>();
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }
    }
}
