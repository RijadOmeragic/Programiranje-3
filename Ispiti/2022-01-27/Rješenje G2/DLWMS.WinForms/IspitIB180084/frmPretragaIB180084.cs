using DLWMS.WinForms.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DLWMS.WinForms.IspitIB180084
{
    public partial class frmPretragaIB180084 : Form
    {
        public frmPretragaIB180084()
        {
            InitializeComponent();
            dgvPretraga.AutoGenerateColumns = false;
        }

        private void frmPretragaIB180084_Load(object sender, EventArgs e)
        {
            UcitajPodatke();
            cmbStudenti.DataSource = DLWMSdb.Baza.Studenti.ToList();
        }

        private void UcitajPodatke()
        {
            dgvPretraga.DataSource = DLWMSdb.Baza.StudentiPredmeti.ToList();
        }

        private void btnPretraga_Click(object sender, EventArgs e)
        {
            FiltrirajPodatke();
        }

        private void FiltrirajPodatke()
        {
            if(cmbOcjene.Text=="")
            {
                MessageBox.Show("Izaberite ocjenu!");
                return;
            }    

            List<StudentiPredmetiIB180084> filterLista = new List<StudentiPredmetiIB180084>();

            int filter = int.Parse(cmbOcjene.Text);

            foreach(var instanca in DLWMSdb.Baza.StudentiPredmeti)
            {
                if(instanca.Ocjena >= filter)
                    filterLista.Add(instanca);  
            }

            dgvPretraga.DataSource = filterLista;
            this.Text = $"Ukupno zapisa: {filterLista.Count}";
        }

        private void btnPrintaj_Click(object sender, EventArgs e)
        {
            var frmIzvjestaj = new frmIzvjestajIB180084(dgvPretraga.DataSource as List<StudentiPredmetiIB180084>);
            frmIzvjestaj.ShowDialog();
        }

        private void dgvPretraga_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPretraga.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                var frmStudentSeminarski = new frmStudentSeminarskiIB180084(dgvPretraga.SelectedRows[0].DataBoundItem as StudentiPredmetiIB180084);
                frmStudentSeminarski.ShowDialog();
            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            var student = cmbStudenti.SelectedItem as Student;
            var brojOcjena = int.Parse(txtBrOcjena.Text);
            var rand = new Random();
            int brojac = 0;

            var dodavanje = Task.Run(() =>
            {
                for (int i = 0; i < brojOcjena; i++)
                {
                    var tempSP = new StudentiPredmetiIB180084();

                    tempSP.Student = student;
                    tempSP.Predmet =
                    DLWMSdb.Baza.Predmeti.ToList().ElementAt(rand.Next(0,
                    DLWMSdb.Baza.Predmeti.Count()));
                    tempSP.Ocjena = rand.Next(6, 11);
                    tempSP.DatumPolaganja = DateTime.Now;

                    DLWMSdb.Baza.StudentiPredmeti.Add(tempSP);
                    DLWMSdb.Baza.SaveChanges();

                    Action akcija = () => txtInfo.Text += $"Za {student} je dodat polozen predmet {tempSP.Predmet} ({tempSP.Ocjena})" + Environment.NewLine;
                    BeginInvoke(akcija);
                }
            });

            var cekanje = dodavanje.GetAwaiter();
            cekanje.OnCompleted(() => 
            {
                UcitajPodatke();
            });
        }

       
    }
}
