using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zki.Crypt
{
    class CezrAffin
    {
        private int k,a;

        public CezrAffin() : this(0,0) { }

        public CezrAffin(int k,int a)
        {
            this.k = k;
            this.a = a;
        }

        private readonly char[] abs = Enumerable.Range(char.MinValue, char.MaxValue).Select(x => (char)x).ToArray();

        private char GetNextChar(char c)
        {
            return (char)((k * c + a) % abs.Length);
        }

        private char GetDecodedChar(char y)
        {     
            int invK = char.MinValue;
            while ((invK * k) % abs.Length != 1)
            {
                if (invK > abs.Length) break;
                invK++;
            }
            int x = (invK * (y + abs.Length - a)) % abs.Length;
            return (char)x;
        }
        public string Encode(string txt)
        {
            return string.Join("", txt.Select(x => GetNextChar(x)));
        }

        public string Decode(string txt)
        {
            return string.Join("", txt.Select(x => GetDecodedChar(x)));
        }
    }
}
