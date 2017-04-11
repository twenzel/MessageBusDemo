using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTrader
{
    public class PriceCalculator
    {
        private Dictionary<DateTime, int> _orderStatistics = new Dictionary<DateTime, int>();
        public const decimal BASE_PRICE = 2.5M;

        public decimal CalcPrice(int newlyOrderedAmount)
        {
            _orderStatistics.Add(DateTime.Now, newlyOrderedAmount);

            var twoMinutesAgo = DateTime.Now.AddMinutes(-2);

            int amountOrderedWithinLast2Minutes = _orderStatistics.Where(pair => pair.Key >= twoMinutesAgo).Sum(pair => pair.Value);

            return BASE_PRICE + (amountOrderedWithinLast2Minutes * 0.15M);
        }
    }
}
