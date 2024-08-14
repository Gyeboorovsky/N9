using System;
using System.Threading.Tasks;

class Program
{
  static async Task Main(string[] args)
  {
    // config to move
    var port = 13000;
    using (Server server = new Server(port))
    {
      Console.CancelKeyPress += (sender, eventArgs) =>
      {
        eventArgs.Cancel = true;
        server.Stop();
        Console.WriteLine("Serwer zatrzymany.");
      };

      await server.StartAsync();
    }
  }
}
