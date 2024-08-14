using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

public class MessageReceiver
{
  private readonly NetworkStream _stream;

  public MessageReceiver(NetworkStream stream)
  {
    _stream = stream;
  }

  public async Task StartReceiving()
  {
    byte[] buffer = new byte[1024];
    int bytesRead;

    try
    {
      while ((bytesRead = await _stream.ReadAsync(buffer, 0, buffer.Length)) != 0)
      {
        string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
        Console.WriteLine("Otrzymano wiadomość: " + message);
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine("Błąd podczas odbierania wiadomości: " + ex.Message);
    }
  }
}
