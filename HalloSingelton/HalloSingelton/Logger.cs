namespace HalloSingelton
{
    internal class Logger
    {
        private static Logger _logger;
        private static object _sync = new object();

        public static Logger Instance
        {
            get
            {
                lock (_sync)
                {
                    _logger ??= new Logger();
                }

                return _logger;
            }
        }

        private Logger()
        {
            Log("Neuer Logger");
        }

        public void Log(string msg)
        {
            Console.WriteLine($"[{DateTime.Now:G}] {msg}");
        }
    }
}
