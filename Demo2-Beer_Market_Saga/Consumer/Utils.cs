using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer
{
    static class Utils
    {
        public static decimal RoundToNextNoteValue(this decimal value)
        {
            var noteValues = new int[] { 5, 10, 20, 50, 100, 200, 500, 1000 };

            var values = noteValues.Where(v => v > value);

            return values.Any() ? values.First() : value * 0.1M;
        }
    }
}
