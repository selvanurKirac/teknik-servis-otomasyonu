using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basoglu
{
    public class YapilanIs
    {
        public int Id { get; set; }
        public string FirmaIsmi { get; set; }
        public bool ServisTuru { get; set; }
        public string Aciklama { get; set; }
        public bool Sonuc { get; set; }
        public DateTime? OlusturulmaTarihi { get; set; }
        public DateTime? DegistirilmeTarihi { get; set; }
        public decimal Fiyat { get; set; }
        public DateTime Tarih { get; set; }
    }
}
