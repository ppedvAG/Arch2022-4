namespace ppedv.Hotelity.Model.Contracts
{
    public interface IBuchungenRepository : IRepository<Buchung>
    {
        IEnumerable<Buchung> GetBuchungenByDateRange(DateOnly start, DateOnly end);
    }


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
        IRepository<Gast> GastRepository { get; }
        IRepository<Zimmer> ZimmerRepository { get; }
        IBuchungenRepository BuchungenRepository { get; }

        //entweder alle Repos per Property oder die generische methode
        //hier machen wir nur zu testen beides

        IRepository<T> GetRepo<T>() where T : Entity;

        void SaveAll();
    }
}
