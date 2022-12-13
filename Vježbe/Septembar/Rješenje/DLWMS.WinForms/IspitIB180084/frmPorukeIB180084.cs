using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DLWMS.WinForms.IspitIB180084
{
    public partial class frmPorukeIB180084 : Form
    {
        PomocnaKlasaIB180084 sp;

        public frmPorukeIB180084(PomocnaKlasaIB180084 sp)
        {
            InitializeComponent();
            this.sp = sp;
        }

       
    }
}
