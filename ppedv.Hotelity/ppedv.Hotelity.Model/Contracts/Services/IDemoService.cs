using ppedv.Hotelity.Model.DomainModel;

namespace ppedv.Hotelity.Model.Contracts.Services
{
    public interface IDemoService
    {
        IEnumerable<Gast> GetDemoGaeste();
    }
}
