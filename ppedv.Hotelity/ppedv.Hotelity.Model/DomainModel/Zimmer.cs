namespace ppedv.Hotelity.Model.DomainModel
{
    public class Zimmer : Entity
    {
        public int Nummer { get; set; }
        public int AnzBetten { get; set; }

        //public ICollection<Gast> Gaeste { get; set; } = new HashSet<Gast>();
        public ICollection<Buchung> Buchung { get; set; } = new HashSet<Buchung>();

    }
}