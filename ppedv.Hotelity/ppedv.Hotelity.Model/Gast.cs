namespace ppedv.Hotelity.Model
{
    public class Gast : Entity
    {
        public string Name { get; set; } = string.Empty;

        public DateTime? GebDatum { get; set; }

        public ICollection<Buchung> Buchung { get; set; } = new HashSet<Buchung>();

    }
}