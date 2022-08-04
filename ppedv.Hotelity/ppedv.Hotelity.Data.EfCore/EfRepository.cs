using Microsoft.EntityFrameworkCore.Internal;
using ppedv.Hotelity.Model;
using ppedv.Hotelity.Model.Contracts;

namespace ppedv.Hotelity.Data.EfCore
{
    public class EfRepository : IRepository
    {
        EfContext _context = new EfContext();

        public void Add<T>(T entity) where T : Entity
        {
            //if(typeof(T) == typeof(Zimmer))
            //    _context.Zimmer.Add(entity as Zimmer);   
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : Entity
        {
            _context.Remove(entity);
        }

        public IQueryable<T> Query<T>() where T : Entity
        {
            return _context.Set<T>();
        }

        public T GetId<T>(int id) where T : Entity
        {
            return _context.Set<T>().Find(id);
        }

        public void SaveAll()
        {
            _context.SaveChanges();
        }

        public void Update<T>(T entity) where T : Entity
        {
            _context.Update(entity);
        }
    }
}
