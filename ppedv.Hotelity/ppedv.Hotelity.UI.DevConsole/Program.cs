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
//Core core = new Core(new ppedv.Hotelity.Data.EfCore.EfUnitOfWork());

//Injection per Reflection
//var path = @"C:\Users\Fred\source\repos\Arch2022-4\ppedv.Hotelity\ppedv.Hotelity.Data.EfCore\bin\Debug\net6.0\ppedv.Hotelity.Data.EfCore.dll";
//var ass = Assembly.LoadFrom(path);
//var efUoWType = ass.GetTypes().FirstOrDefault(x => x.GetInterfaces().Contains(typeof(IUnitOfWork)));
//var repo = (IUnitOfWork)Activator.CreateInstance(efUoWType);
//Core core = new Core(repo);

//Injection per AutoFac
var builder = new ContainerBuilder();
builder.RegisterType<EfUnitOfWork>().As<IUnitOfWork>();
var container = builder.Build();

Core core = new Core(container.Resolve<IUnitOfWork>());

Logger.Log.Information("Console gestartet");

var result = core.UnitOfWork.BuchungenRepository.GetBuchungenByDateRange(DateOnly.FromDateTime(DateTime.Now), DateOnly.FromDateTime(DateTime.Now.AddDays(7)));


foreach (var zimmer in core.UnitOfWork.ZimmerRepository.Query().Where(x => x.Nummer > 4)
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


