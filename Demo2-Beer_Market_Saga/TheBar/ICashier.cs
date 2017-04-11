using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBar
{
    public interface ICashier
    {
        decimal GetPricePerBottle();
        void UpdatePricePerBottle(decimal pricePerBottle);
    }
}
