using N9_Server;
using System.Collections.Concurrent;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

public class MessageBroadcaster
{
  public async void BroadcastMessage(string message, Client senderClient, ConcurrentBag<Client> clients)
  {
    byte[] buffer = Encoding.UTF8.GetBytes(message);

    foreach (Client client in clients)
    {
      if (client != senderClient)
      {
        NetworkStream stream = client.tcpClient.GetStream();
        await stream.WriteAsync(buffer, 0, buffer.Length);
      }
    }
  }
}
