using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zki.Crypt
{
    class Cezr
    {
        private int k;

        private string kwrd;

        public Cezr(string kwrd) : this(0, kwrd) { }

        public Cezr(int k, string kwrd)
        {
            this.k = k;
            this.kwrd = kwrd;
        }

        private readonly char[] abs = Enumerable.Range(char.MinValue , char.MaxValue).Select(x => (char)x).ToArray();


        private char[] ArrayMoveTo(IEnumerable<char> src,int k)
        {
            var tmp = src.ToArray();
            var _Arr = new char[src.Count()];
            for (int i = 0; i < tmp.Length; i++)
            {
                _Arr[(i + k) % tmp.Length] = tmp[i]; 
            }

            return _Arr;
        }

        public string Encode(string txt)
        {       
            if (kwrd.Contains(' ')) throw new ArgumentException("Ключевое слово содержит пробел");
            kwrd = kwrd.ToUpper();
            var _arr = abs.Where(x => kwrd.ToCharArray().All(y => y != x)).ToArray();
            var _ntabl = new List<char>();
            _ntabl.AddRange(kwrd.ToCharArray());
            _ntabl.AddRange(_arr);
            _ntabl = ArrayMoveTo(_ntabl, k).ToList();
            var _ftabl = new Dictionary<char,char>();
            for (int i = 0; i < abs.Length; i++)
            {
                _ftabl.Add(abs[i], _ntabl[i]);
            };
            return string.Join("", txt.Select(x => _ftabl[x]));
        }

        public string Decode(string txt)
        {
            if (kwrd.Contains(' ')) throw new ArgumentException("Ключевое слово содержит пробел");
            kwrd = kwrd.ToUpper();
            var _arr = abs.Where(x => kwrd.ToCharArray().All(y => y != x)).ToArray();
            var _ntabl = new List<char>();
            _ntabl.AddRange(kwrd.ToCharArray());
            _ntabl.AddRange(_arr);
            _ntabl = ArrayMoveTo(_ntabl, k).ToList();
            var _ftabl = new Dictionary<char, char>();
            for (int i = 0; i < abs.Length; i++)
            {
                _ftabl.Add(_ntabl[i], abs[i]);
            };
            return string.Join("",txt.Select(x => _ftabl[x]));
        }
    }
}
