// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var brot1 = new Salami(new Brot());
Console.WriteLine($"Brot1: {brot1.Name} {brot1.Preis}");

var pizza1 = new Käse( new Käse(new Salami(new Pizza())));
Console.WriteLine($"Pizza1: {pizza1.Name} {pizza1.Preis}");


public class Salami : Deco
{
    public Salami(ICompo parent) : base(parent)
    { }

    public override string Name => $" {parent.Name} Salami";

    public override decimal Preis => parent.Preis + 4.7m;
}

public class Käse : Deco
{
    public Käse(ICompo parent) : base(parent)
    { }

    public override string Name => $" {parent.Name} Käse";

    public override decimal Preis => parent.Preis + 2.5m;
}

public abstract class Deco : ICompo
{
    protected readonly ICompo parent;

    protected Deco(ICompo parent)
    {
        this.parent = parent;
    }

    public abstract string Name { get; }

    public abstract decimal Preis { get; }
}

public interface ICompo
{
    public string Name { get; }
    public decimal Preis { get; }
}




public class Brot : ICompo
{
    public string Name => "Brot";
    public decimal Preis => 5m;
}

public class Pizza : ICompo
{
    public string Name => "Pizza";
    public decimal Preis => 8m;
}