using Serilog;
using Serilog.Exceptions;

namespace ppedv.Hotelity.Logging
{
    public class Logger
    {
        public static ILogger Log { get => Serilog.Log.Logger; }

        static Logger()
        {
            Serilog.Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Debug()
                        .Enrich.WithExceptionDetails()
                        .WriteTo.Debug()
                        .WriteTo.File("log/log.txt", rollingInterval: RollingInterval.Month)
                        .WriteTo.Seq("http://20.4.186.69")
                        .CreateLogger();
        }

        ~Logger()
        {
            Serilog.Log.CloseAndFlush();
        }
    }
}