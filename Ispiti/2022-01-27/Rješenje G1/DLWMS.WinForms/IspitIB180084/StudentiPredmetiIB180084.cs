using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLWMS.WinForms.IspitIB180084
{
    [Table("StudentiPredmeti")]

    public class StudentiPredmetiIB180084
    {
        public int Id { get; set; }
        public virtual Student Student { get; set; }
        public virtual PredmetiIB180084 Predmet { get; set; }
        public int Ocjena { get; set; }
        public DateTime DatumPolaganja { get; set; }
    }
}
