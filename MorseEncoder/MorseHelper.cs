using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorseEncoder
{
    public static class MorseHelper
    {
        private static readonly Dictionary<string, string> _dictNumberMorse = new Dictionary<string, string>
        {
            { "0", "— — — — —"},
            { "1", "· — — — —"},
            { "2", "· · — — —"},
            { "3", "· · · — —"},
            { "4", "· · · · —"},
            { "5", "· · · · ·"},
            { "6", "— · · · ·"},
            { "7", "— — · · ·"},
            { "8", "— — — · ·"},
            { "9", "— — — — ·"},
        };

        public static string GBK2Morse(string gbkCode)
        {
            if (string.IsNullOrWhiteSpace(gbkCode) || gbkCode.Length != 4)
            {
                throw new ArgumentException($"{nameof(gbkCode)}非GBK区位码");
            }

            StringBuilder sbMorse = new StringBuilder();
            foreach (var s in gbkCode)
            {
                sbMorse.Append(_dictNumberMorse[s.ToString()]).Append("     ");
            }

            return sbMorse.ToString();
        }
    }
}
