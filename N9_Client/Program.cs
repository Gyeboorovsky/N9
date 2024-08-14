using System;

class Program
{
  static void Main(string[] args)
  {
    // config to move
    var port = 13000;
    var ip = "127.0.0.1";

    Client client = new Client(ip, port);
    client.Start();
  }
}
