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

    public interface IUnitOfWork
    {
        IRepository<T> GetRepo<T>() where T : Entity;

        void SaveAll();
    }
}
