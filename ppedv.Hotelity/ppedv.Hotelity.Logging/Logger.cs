using Serilog;
using Serilog.Events;
using Serilog.Exceptions;

namespace ppedv.Hotelity.Logging
{
    public class Logger
    {
        public static ILogger Log { get => Serilog.Log.Logger; }

        static Logger()
        {
            Serilog.Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                        .MinimumLevel.Debug()
                        .Enrich.WithExceptionDetails()
                        .Enrich.FromLogContext()
                        .Enrich.WithProperty("User", Environment.UserName)
                        .WriteTo.Debug(restrictedToMinimumLevel: LogEventLevel.Debug)
                        .WriteTo.File("log/log.txt", rollingInterval: RollingInterval.Month)
                        .WriteTo.Seq("http://20.4.186.69")

                        .CreateLogger();
        }

    }
}