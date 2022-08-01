using HalloSingelton;

Console.WriteLine("Hello Singelton");

//var logger = new Logger();

Parallel.For(1, 20, i => Logger.Instance.Log($"Test {i}"));

