using Autofac;
using ppedv.Hotelity.Data.EfCore;
using ppedv.Hotelity.Logging;
using ppedv.Hotelity.Logic;
using ppedv.Hotelity.Model.Contracts.Infrastructure;
using ppedv.Hotelity.Model.Contracts.Services;
using ppedv.Hotelity.Model.DomainModel;
using ppedv.Hotelity.Services.BookingService;
using ppedv.Hotelity.Services.RoomService;
using System.Net.WebSockets;

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
builder.RegisterType<EfMainRepository>().As<IMainRepository>();
builder.RegisterType<BookingService>().As<IBookingService>();
builder.RegisterType<RoomService>().As<IRoomService>();
var container = builder.Build();


IMainRepository mainRepository = container.Resolve<IMainRepository>();
IBookingService bookingService = container.Resolve<IBookingService>();
IRoomService roomService = container.Resolve<IRoomService>();


Logger.Log.Information("Console gestartet");

var buchungenOfWeek = mainRepository.BuchungenRepository.GetBuchungenByDateRange(DateOnly.FromDateTime(DateTime.Now), DateOnly.FromDateTime(DateTime.Now.AddDays(7)));

var buchung = new Buchung() { Von = DateTime.Now, Bis = DateTime.Now.AddDays(4) };
var result = bookingService.CalculateCosts(buchung);
Console.WriteLine($"Buchung kostet: {result:c}");

Console.WriteLine("Alle Zimmer ab 4:");
foreach (var zimmer in mainRepository.ZimmerRepository.Query().Where(x => x.Nummer > 4)
                                                       .OrderBy(x => x.Nummer)
                                                       .ThenByDescending(x => x.AnzBetten))
{
    Console.WriteLine($"Nummer: {zimmer.Nummer} Betten: {zimmer.AnzBetten}");
}
Console.WriteLine("Alle verfügbaren Zimmer:");
foreach (var zimmer in roomService.GetAvailableRooms(DateTime.Now))
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


