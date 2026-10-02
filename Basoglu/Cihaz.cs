using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basoglu
{
    public class Cihaz
    {
        public string Isim { get; set; }
        public string Cihaz_model { get; set; }
        public int Adet { get; set; }
        public DateTime AlimTarihi { get; set; }
        public DateTime? TeslimTarihi { get; set; }

        public List<YIServisFirma> ServisFirmalari { get; set; } = new List<YIServisFirma> ();
    }
}
