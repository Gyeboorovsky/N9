using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace N9_Server
{
  public class Client
  {
    public Guid Guid { get; set; }
    public string Name { get; set; }
    public TcpClient tcpClient { get; set; }
  }
}
