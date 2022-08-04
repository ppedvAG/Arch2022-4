using ppedv.Hotelity.Model.DomainModel;

namespace ppedv.Hotelity.Model.Contracts
{
    /// <summary>
    /// Unit-of-Work implementierung, aber MainRepo genannt zum besseren klarheit
    /// </summary>
    public interface IMainRepository
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
