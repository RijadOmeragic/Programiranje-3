using DLWMS.WinForms.DB;
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
    public partial class frmNovaKonsultacijaIB180084 : Form
    {
        PomocnaKlasaIB180084 student;

        public frmNovaKonsultacijaIB180084(PomocnaKlasaIB180084 student)
        {
            InitializeComponent();
            this.student = student;
        }

        private void frmNovaKonsultacijaIB180084_Load(object sender, EventArgs e)
        {
            cmbPredmeti.DataSource = DLWMSdb.Baza.Predmeti.ToList();
            this.Text = "Novi zahtjev za konsultacijama";

        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if(P5.Validator.ValidirajKontrolu(txtNapomena,errorProvider1,Poruke.ObaveznaVrijednost) &&
                P5.Validator.ValidirajKontrolu(cmbPredmeti, errorProvider1, Poruke.ObaveznaVrijednost) &&
                P5.Validator.ValidirajKontrolu(dtpVrijeme, errorProvider1, Poruke.ObaveznaVrijednost))
            {
                var obj = new StudentiKonsultacijeIB180084()
                {
                    Student = student.Student,
                    Predmet = cmbPredmeti.SelectedItem as PredmetiIB180084,
                    VrijemeOdrzavanja = dtpVrijeme.Value,
                    Napomena = txtNapomena.Text
                };

                DLWMSdb.Baza.StudentiKonsultacija.Add(obj);
                DLWMSdb.Baza.SaveChanges();

                Close();
            }

          
        }
    }
}
