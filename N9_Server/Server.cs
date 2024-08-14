using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

public class Server : IDisposable
{
  private TcpListener _listener;
  private readonly ClientHandler _clientHandler;

  public Server(int port)
  {
    _listener = new TcpListener(IPAddress.Any, port);
    _clientHandler = new ClientHandler();
  }

  public async Task StartAsync()
  {
    _listener.Start();
    Console.WriteLine($"Serwer uruchomiony na porcie {_listener.LocalEndpoint}...");

    while (true)
    {
      TcpClient client = await _listener.AcceptTcpClientAsync();
      _clientHandler.HandleClientAsync(client);
    }
  }

  public void Stop()
  {
    _listener.Stop();
  }

  public void Dispose()
  {
    Stop();
    _listener = null;
  }
}
