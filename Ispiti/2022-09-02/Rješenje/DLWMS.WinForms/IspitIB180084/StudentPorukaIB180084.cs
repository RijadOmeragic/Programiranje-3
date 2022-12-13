using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLWMS.WinForms.IspitIB180084
{
    [Table("StudentiPoruke")]

    public class StudentPorukaIB180084
    {
        public int Id { get; set; }
        public virtual Student Student { get; set; }
        public virtual PredmetIB180084 Predmet { get; set; }
        public DateTime VrijemeKreiranja { get; set; }
        public string Sadrzaj { get; set; }
        public byte[] Slika { get; set; }

    }
}
