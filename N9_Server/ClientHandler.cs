using N9_Server;
using System;
using System.Collections.Concurrent;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

public class ClientHandler
{
  private readonly ConcurrentBag<Client> _clients;
  private readonly MessageBroadcaster _broadcaster;
  private readonly GuidHandler _guidHandler;

  byte[] buffer = new byte[1024];
  int bytesRead;

  public ClientHandler()
  {
    _clients = new ConcurrentBag<Client>();
    _broadcaster = new MessageBroadcaster();
    _guidHandler = new GuidHandler();
  }

  public async Task HandleClientAsync(TcpClient tcpClient)
  {
    var client = new Client() { tcpClient = tcpClient };
    _guidHandler.AssignGuid(client);
    _clients.Add(client);
    NetworkStream stream = client.tcpClient.GetStream();

    try
    {
      while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) != 0)
      {
        string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
        InitialMessage(client, message);
        Console.WriteLine($"{client.Name}: " + message);
        _broadcaster.BroadcastMessage(message, client, _clients);
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Problem with communication with {client.Name}: " + ex.Message);
    }
    finally
    {
      Client removedClient;
      _clients.TryTake(out removedClient);
      client.tcpClient.Close();
      Console.WriteLine($"{client.Name} disconnected.");
    }
  }

  private void InitialMessage(Client client, string message)
  {
    if (client.Name == null)
    {
      message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
      client.Name = message;

      Console.WriteLine($"{client.Name} connected.");
    }
  }
}
