using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N9_Server
{
  internal class GuidHandler
  {
    public void AssignGuid(Client client)
    {
      client.Guid = new Guid();
    }
  }
}
