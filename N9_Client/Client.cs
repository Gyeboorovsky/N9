using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

public class Client : IDisposable
{
  private TcpClient _tcpClient;
  private NetworkStream _stream;
  private readonly MessageReceiver _receiver;

  public Client(string serverAddress, int port)
  {
    _tcpClient = new TcpClient(serverAddress, port);
    _stream = _tcpClient.GetStream();
    _receiver = new MessageReceiver(_stream);
  }

  public void Start()
  {
    Console.WriteLine("Connected to the server");
    Console.Write("Type your name: ");
    Task.Run(() => _receiver.StartReceiving());

    while (true)
    {
      string message = Console.ReadLine();
      SendMessageAsync(message).Wait();
    }
  }

  private async Task SendMessageAsync(string message)
  {
    byte[] data = Encoding.UTF8.GetBytes(message);
    await _stream.WriteAsync(data, 0, data.Length);
  }

  public void Dispose()
  {
    _stream?.Close();
    _tcpClient?.Close();
  }
}
