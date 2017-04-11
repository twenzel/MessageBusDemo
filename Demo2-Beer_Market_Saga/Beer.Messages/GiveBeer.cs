using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beer.Messages
{
    public class GiveBeer
    {
        public int Amount { get; set; }
        public string CustomerName { get; set; }
    }
}
