namespace ppedv.Hotelity.Model.DomainModel
{
    public class Buchung : Entity
    {
        public DateTime? Buchungsdatum { get; set; }
        public DateTime? Von { get; set; }
        public DateTime? Bis { get; set; }

        public virtual ICollection<Zimmer> Zimmer { get; set; } = new HashSet<Zimmer>();

        public virtual Gast? Gast { get; set; }
    }
}