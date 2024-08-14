using System;
using System.Diagnostics;

class Program
{
  static void Main(string[] args)
  {
    // Ścieżki do plików .exe projektów, które chcesz uruchomić
    string server = @"C:\PROGRAMMING\N9\N9_Server\bin\Debug\net8.0\N9_Server.exe";
    string client = @"C:\PROGRAMMING\N9\N9_Client\bin\Debug\net8.0\N9_Client.exe";

    try
    {
      ProcessStartInfo startInfo1 = new ProcessStartInfo
      {
        FileName = server,
        UseShellExecute = false,
        CreateNoWindow = false
      };
      Process process1 = new Process();
      process1.StartInfo = startInfo1;
      process1.Start();
      Console.WriteLine("Rum N9_Server.exe");

      ProcessStartInfo startInfo2 = new ProcessStartInfo
      {
        FileName = client,
        UseShellExecute = false,
        CreateNoWindow = false
      };
      Process process2 = new Process();
      process2.StartInfo = startInfo2;
      process2.Start();
      Console.WriteLine("Run 1. N9_Client.exe");

      Process process3 = new Process();
      process3.StartInfo = startInfo2;
      process3.Start();
      Console.WriteLine("Run 2. N9_Client.exe");

      // Opcjonalnie: czekaj na zakończenie obu procesów
      process1.WaitForExit();
      process2.WaitForExit();
      process3.WaitForExit();

      Console.WriteLine("All Application ended");
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Error: {ex.Message}");
    }
  }
}
