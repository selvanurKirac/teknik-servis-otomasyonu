using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basoglu
{
     public class YIUrun
    {

        public string UrunIsmi { get; set; }
        public string ModelNumarasi { get; set; }
        public string SeriNo { get; set; }
        public int Miktar { get; set; }
        public bool Kaynak { get; set; } // true = stoktan, false = dışardan
    }
}
