using DLWMS.WinForms.DB;
using DLWMS.WinForms.Helpers;
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
    public partial class frmNovaPorukaIB180084 : Form
    {
        PomocnaKlasaIB180084 student;

        public frmNovaPorukaIB180084(PomocnaKlasaIB180084 student)
        {
            InitializeComponent();
            this.student = student;
        }

        private void frmNovaPorukaIB180084_Load(object sender, EventArgs e)
        {
            cmbPredmeti.DataSource = DLWMSdb.Baza.Predmeti.ToList();
            this.Text = "Poruka";
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (P5.Validator.ValidirajKontrolu(cmbPredmeti, errorProvider1, Poruke.ObaveznaVrijednost) &&
              P5.Validator.ValidirajKontrolu(txtSadrzaj, errorProvider1, Poruke.ObaveznaVrijednost))
            {
                var obj = new StudentPorukaIB180084()
                {
                    Student = student.Student,
                    Predmet = cmbPredmeti.SelectedItem as PredmetIB180084,
                    VrijemeKreiranja = DateTime.Now,
                    Sadrzaj = txtSadrzaj.Text,
                };

                if (pbSlika.Image != null)
                {
                    obj.Slika = ImageHelper.FromImageToByte(pbSlika.Image);
                }

                DLWMSdb.Baza.StudentiPoruke.Add(obj);
                DLWMSdb.Baza.SaveChanges();

                Close();
            }
            
        }
     

        private void pbSlika_DoubleClick(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbSlika.Image = Image.FromFile(ofd.FileName);
            }
    

        }
    }
}
