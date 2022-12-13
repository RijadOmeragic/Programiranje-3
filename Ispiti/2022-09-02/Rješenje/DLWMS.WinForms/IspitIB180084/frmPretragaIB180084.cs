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
    public partial class frmPretragaIB180084 : Form
    {
        List<PomocnaKlasaIB180084> lista = new List<PomocnaKlasaIB180084>();

        public frmPretragaIB180084()
        {
            InitializeComponent();
            dgvPretraga.AutoGenerateColumns = false;
        }

        private void frmPretragaIB180084_Load(object sender, EventArgs e)
        {
            UcitajPodatke();
            this.Text = "Pretraga studenata";
        }

        private void UcitajPodatke()
        {
            foreach(var student in DLWMSdb.Baza.Studenti)
            {
                int brojPolozenih = 0;

                foreach(var sp in DLWMSdb.Baza.StudentiPredmeti)
                {
                    if(sp.Student==student)
                    {
                        brojPolozenih++;
                    }
                }

                var obj = new PomocnaKlasaIB180084()
                {
                    Indeks = student.Indeks,
                    Student = student,
                    Spol = student.Spol,
                    BrojPolozenih = brojPolozenih
                };

                lista.Add(obj);
            }

            dgvPretraga.DataSource = lista;
        }

        private void txtPretraga_TextChanged(object sender, EventArgs e)
        {
            FiltrirajPodatke();
        }

        private void FiltrirajPodatke()
        {
            List<PomocnaKlasaIB180084> filterLista = new List<PomocnaKlasaIB180084>();

            string filter1 = txtPretraga.Text;
            string filter2 = cmbSpolovi.Text;

            filterLista = lista.Where(o => ProvjeriSpol(o, filter2) && (o.Student.Ime.Contains(filter1) ||
            o.Student.Prezime.Contains(filter1) || o.Student.Indeks.Contains(filter1))).ToList();

            dgvPretraga.DataSource = filterLista;

        }

        private bool ProvjeriSpol(PomocnaKlasaIB180084 instanca, string filter2)
        {
            if (instanca.Spol.Naziv.Contains(filter2))
                return true;

            return false;
        }


        private void cmbSpolovi_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrirajPodatke();
        }

        private void dgvPretraga_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPretraga.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                var frmPoruke = new frmPorukeIB180084(dgvPretraga.SelectedRows[0].DataBoundItem as PomocnaKlasaIB180084);
                frmPoruke.ShowDialog();
            }
        }
    }
}
