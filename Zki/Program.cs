using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zki.Crypt;

namespace Zki
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string txt = @"Система шифрования Цезаря с ключевым словом.Now with English support!И всех символов ;;\№%:№::?**4";
            Cezr cz = new Cezr(3,"Шифровка");
            var en = cz.Encode(txt);
            var dec = cz.Decode(en);
            Console.Write($"Text:{txt}\nEncoded:{en}\nDecoded:{dec}\n");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            string txtA = @"Система шифрования Цезаря(Афинская) с ключевым словом.Now with English support!И всех символов ;;\№%:№::?**4";
            CezrAffin cza = new CezrAffin(2,25);
            var ena = cza.Encode(txtA);
            var deca = cza.Decode(ena);
            Console.Write($"Text:{txtA}\nEncoded:{ena}\nDecoded:{deca}\n");
            Console.ReadKey();
        }
    }
}
