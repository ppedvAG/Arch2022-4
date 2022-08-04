using Autofac;
using Autofac.Core;
using ppedv.Hotelity.Data.EfCore;
using ppedv.Hotelity.Logging;
using ppedv.Hotelity.Logic;
using ppedv.Hotelity.Model;
using ppedv.Hotelity.Model.Contracts;
using System.Reflection;

Console.WriteLine("*** Hotelity v0.1 ***");

//injection per Hand
//Core core = new Core(new ppedv.Hotelity.Data.EfCore.EfRepository());

//Injection per Reflection
//var path = @"C:\Users\Fred\source\repos\Arch2022-4\ppedv.Hotelity\ppedv.Hotelity.Data.EfCore\bin\Debug\net6.0\ppedv.Hotelity.Data.EfCore.dll";
//var ass = Assembly.LoadFrom(path);
//var efRepoType = ass.GetTypes().FirstOrDefault(x => x.GetInterfaces().Contains(typeof(IRepository)));
//var repo = (IRepository)Activator.CreateInstance(efRepoType);
//Core core = new Core(repo);

//Injection per AutoFac
var builder = new ContainerBuilder();
builder.RegisterType<EfRepository>().As<IRepository>();
var container = builder.Build();

Core core = new Core(container.Resolve<IRepository>());

Logger.Log.Information("Console gestartet");

foreach (var zimmer in core.Repository.Query<Zimmer>().Where(x => x.Nummer > 4)
                                                       .OrderBy(x => x.Nummer)
                                                       .ThenByDescending(x => x.AnzBetten))
{
    Console.WriteLine($"Nummer: {zimmer.Nummer} Betten: {zimmer.AnzBetten}");

}



//try
//{
//    throw new OutOfMemoryException();
//}
//catch (Exception ex)
//{

//    Logger.Log.Fatal(ex,"Schade");
//    Serilog.Log.CloseAndFlush();
//}


