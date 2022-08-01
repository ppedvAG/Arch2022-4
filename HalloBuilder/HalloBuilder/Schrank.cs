namespace HalloBuilder
{
    public class Schrank
    {
        public int AnzahlTüren { get; private set; }
        public Oberfläche Oberfläche { get; private set; }
        public string Farbe { get; private set; }
        public int AnzahlBöden { get; private set; }
        public bool Metallschienen { get; private set; }
        public bool Kleiderstange { get; private set; }

        private Schrank()
        { }

        public class Builder
        {
            Schrank newSchrank = new Schrank();

            public Builder SetAnzahlTüren(int anzahl)
            {
                if (anzahl < 0 || anzahl > 7)
                    throw new ArgumentException("Es sind nut 2-7 Türen Erlaubt");

                newSchrank.AnzahlTüren = anzahl;

                return this;
            }

            public Builder SetOberfläche(Oberfläche oberfläche)
            {
                newSchrank.Oberfläche = oberfläche;

                if (oberfläche != Oberfläche.Lackiert)
                    newSchrank.Farbe = string.Empty;

                return this;
            }

            public Builder SetFarbe(string farbe)
            {
                if (newSchrank.Oberfläche != Oberfläche.Lackiert)
                    throw new ArgumentException();

                newSchrank.Farbe = farbe;

                return this;
            }

            public Schrank Create()
            {
                return newSchrank;
            }
        }
    }

    public enum Oberfläche
    {
        Unbehandelt,
        Gewachst,
        Lackiert
    }
}
