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
    public partial class frmStudentSlikeIB180084 : Form
    {
        StudentiPredmetiIB180084 sp1;

        int index = 0;

        List<StudentiSlikeIB180084> lista = new List<StudentiSlikeIB180084>();

        public frmStudentSlikeIB180084(StudentiPredmetiIB180084 sp)
        {
            InitializeComponent();
           sp1 = sp;

            foreach(var instanca in DLWMSdb.Baza.StudentiSlike)
            {
                if(sp1.Student==instanca.Student)
                {
                    lista.Add(instanca);
                }
            }

            UcitajSliku();
        }

        private void UcitajSliku()
        {
            if (lista.Count == 0)
                return;

            pbSlikaDole.Image = ImageHelper.FromByteToImage(lista[index].Slika);
            lblBrSlike.Text = $"Slika {index+1}/{lista.Count} ";
            lblOpis.Text = lista[index].Opis;
            lblDatum.Text = lista[index].DatumDodavanja.ToString();
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
                P5.Validator.ValidirajKontrolu(pbSlikaGore, errorProvider1, Poruke.ObaveznaVrijednost))
            {
                var obj = new StudentiSlikeIB180084()
                {
                    Student=sp1.Student,
                    Slika = ImageHelper.FromImageToByte(pbSlikaGore.Image), 
                    Opis=txtOpis.Text,
                    DatumDodavanja = DateTime.Now
                };

                DLWMSdb.Baza.StudentiSlike.Add(obj);
                DLWMSdb.Baza.SaveChanges();

                lista.Add(obj);

                txtOpis.Clear();
                pbSlikaGore.Image = null;

                UcitajSliku();
            }
            
        }

        private void btnLijevo_Click(object sender, EventArgs e)
        {
            if(index !=0)
            {
                index--;
                UcitajSliku();
            }
        }

        private void btnDesno_Click(object sender, EventArgs e)
        {
            if(index !=lista.Count-1)
            {
                index++;
                UcitajSliku();
            }
        }
    }
}
