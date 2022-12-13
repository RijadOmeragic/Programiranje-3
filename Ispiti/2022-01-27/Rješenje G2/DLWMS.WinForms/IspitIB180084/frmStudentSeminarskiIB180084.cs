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
    public partial class frmStudentSeminarskiIB180084 : Form
    {
        List<PredmetiSeminarskiIB180084> lista = new List<PredmetiSeminarskiIB180084>();

        StudentiPredmetiIB180084 sp;

        int index = 0;

        public frmStudentSeminarskiIB180084(StudentiPredmetiIB180084 sp)
        {
            InitializeComponent();
            this.sp = sp;

            foreach(var instanca in DLWMSdb.Baza.PredmetiSeminarski)
            {
                if(instanca.Predmet==sp.Predmet && instanca.Student==sp.Student)
                {
                    lista.Add(instanca);
                }
            }

            lblStudent.Text = sp.Student.ToString();
            lblPredmet.Text = sp.Predmet.ToString();

            UcitajSlike();  // da bi se slika na pocetku ucitala

        }

        private void pbSlikaGore_DoubleClick(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();

            if(ofd.ShowDialog()==DialogResult.OK)
            {
                pbSlikaGore.Image = Image.FromFile(ofd.FileName);
            }

        }

        private void btnDodajSliku_Click(object sender, EventArgs e)
        {
            if(P5.Validator.ValidirajKontrolu(pbSlikaGore,errorProvider1,Poruke.ObaveznaVrijednost) &&
                P5.Validator.ValidirajKontrolu(txtOpis, errorProvider1, Poruke.ObaveznaVrijednost))
            {
                var obj = new PredmetiSeminarskiIB180084()
                {
                    Student = sp.Student,
                    Predmet = sp.Predmet,
                    Slika = ImageHelper.FromImageToByte(pbSlikaGore.Image), 
                    Opis = txtOpis.Text,
                    DatumDodavanja = DateTime.Now
                };

                DLWMSdb.Baza.PredmetiSeminarski.Add(obj);
                DLWMSdb.Baza.SaveChanges();

                lista.Add(obj);

                txtOpis.Clear();
                pbSlikaGore.Image = null;

                UcitajSlike();
            }
        }

        private void UcitajSlike()
        {
            if (lista.Count == 0)
            {
                return;
            }

            pbSlikaDole.Image = ImageHelper.FromByteToImage(lista[index].Slika);

            lblBrStranice.Text = $"Stranica {index+1}/{lista.Count()}";
            lblDatum.Text = lista[index].DatumDodavanja.ToString();
            lblOpis.Text = lista[index].Opis;
        }

        private void btnLijevo_Click(object sender, EventArgs e)
        {
            if (index != 0)
            {
                --index;
                UcitajSlike();
            }
        }

        private void btnDesno_Click(object sender, EventArgs e)
        {
            if (index != lista.Count - 1)
            {
                ++index;
                UcitajSlike();
            }
        }
    }
}
