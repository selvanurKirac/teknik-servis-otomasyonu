using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basoglu
{
    public class YIUrunler
    {
        public static List<YIUrun> Urunler { get; private set; } = new List<YIUrun>();

        public static void Ekle(YIUrun urun)
        {
            Urunler.Add(urun);
        }

        public static void Temizle()
        {
            Urunler.Clear();
        }
    }
}
