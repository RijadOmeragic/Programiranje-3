using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLWMS.WinForms.IspitIB180084
{
    public class PomocnaKlasaIB180084
    {
        public string Indeks { get; set; }
        public virtual Student Student { get; set; }
        public virtual SpolIB180084 Spol { get; set; }
        public int BrojPolozenih { get; set; }
    }
}
