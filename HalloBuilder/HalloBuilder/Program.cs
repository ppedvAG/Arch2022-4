// See https://aka.ms/new-console-template for more information
using HalloBuilder;

Console.WriteLine("Hello, World!");


Schrank schrank1 = new Schrank.Builder()
                              .SetAnzahlTüren(5)
                              .SetOberfläche(Oberfläche.Lackiert)
                              .SetFarbe("Gelb")
                              .Create();

Schrank schrank2 = new Schrank.Builder()
                              .SetAnzahlTüren(1)
                              .SetOberfläche(Oberfläche.Unbehandelt)
                              .SetFarbe("Pink")
                              .Create();