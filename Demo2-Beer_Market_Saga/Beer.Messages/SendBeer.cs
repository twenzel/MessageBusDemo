using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beer.Messages
{
    public class SendBeer
    {
        public Beer[] Beer { get; set; }
        public string CustomerName { get; set; }
    }
}
