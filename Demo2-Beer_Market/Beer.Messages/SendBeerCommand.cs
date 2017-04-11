using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beer.Messages
{
    public class SendBeerCommand
    {
        public Beer[] Beer { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
