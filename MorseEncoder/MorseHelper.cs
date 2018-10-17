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

        private static readonly Dictionary<string, string> _dictMorseNumber = new Dictionary<string, string>
        {
            { "—————", "0"},
            { "·————", "1"},
            { "··———", "2"},
            { "···——", "3"},
            { "····—", "4"},
            { "·····", "5"},
            { "—····", "6"},
            { "——···", "7"},
            { "———··", "8"},
            { "————·", "9"},
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

        public static string Morse2GBK(string morseCode)
        {
            if (string.IsNullOrWhiteSpace(morseCode))
            {
                throw new ArgumentNullException($"{nameof(morseCode)}不能为空");
            }

            morseCode = morseCode.Replace(" ", "");
            if (morseCode.Length != 20)
            {
                throw new ArgumentNullException($"{nameof(morseCode)}非GBK编码");
            }

            StringBuilder sbGBK = new StringBuilder();
            int index = 0;
            for (int i = 0; i < 4; i++)
            {
                index = 5 * i;
                var morseNumber = morseCode.Substring(index, 5);
                sbGBK.Append(_dictMorseNumber[morseNumber]);
            }

            return sbGBK.ToString();
        }
    }
}
