using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beer.Messages
{
    public class BeerPriceUpdatedEvent
    {
        public decimal PricePerBottle { get; set; }
    }
}
