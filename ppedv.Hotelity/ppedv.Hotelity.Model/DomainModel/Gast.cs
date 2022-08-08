namespace ppedv.Hotelity.Model.DomainModel
{
    //POCO = Plain Old CLR Object
    public class Gast : Entity
    {
        public string Name { get; set; } = string.Empty;

        public DateTime? GebDatum { get; set; }

        public virtual ICollection<Buchung> Buchung { get; set; } = new HashSet<Buchung>();

    }
}