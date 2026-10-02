using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basoglu
{
    public class YIServisFirma
    {
        public int Id { get; set; }
        public string FirmaIsmi { get; set; }
        public string FirmaTel { get; set; }
        public string FirmaAdres { get; set; }
        public string FirmaEposta { get; set; }
        public DateTime FirmaEklenmeTarihi { get; set; }

        public DateTime AlimTarihi { get; set; }
        public DateTime? TeslimTarihi { get; set; } // Nullable
    }

}
