using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBar
{
    class Cashier : ICashier
    {
        private decimal _price = 2.5M;

        public decimal GetPricePerBottle()
        {
            return _price;
        }

        public void UpdatePricePerBottle(decimal pricePerBottle)
        {
            _price = pricePerBottle;
        }
    }
}
