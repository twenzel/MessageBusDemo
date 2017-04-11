using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBar
{
    static class Utils
    {
        public static IEnumerable<T> Times<T>(this int times, Func<T> creator)
        {
            for (int i = 0; i < times; i++)
            {
                yield return creator();
            }
        }
    }
}
