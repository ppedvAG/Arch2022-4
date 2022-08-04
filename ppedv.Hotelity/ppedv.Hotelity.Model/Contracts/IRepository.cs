using ppedv.Hotelity.Model.DomainModel;

namespace ppedv.Hotelity.Model.Contracts
{
    public interface IRepository<T> where T : Entity
    {
        IQueryable<T> Query();
        T GetId(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
