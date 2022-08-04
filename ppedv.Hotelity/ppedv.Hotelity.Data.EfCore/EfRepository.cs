using ppedv.Hotelity.Model.Contracts;
using ppedv.Hotelity.Model.DomainModel;

namespace ppedv.Hotelity.Data.EfCore
{

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
