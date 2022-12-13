using DLWMS.WinForms.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
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
        }

        private void frmPretragaIB180084_Load(object sender, EventArgs e)
        {
            UcitajPodatke();
        }

        private void UcitajPodatke()
        {
            foreach(var sp in DLWMSdb.Baza.StudentiPredmeti)
            {
                var obj = new PomocnaKlasaIB180084()
                {
                    Indeks = sp.Student.Indeks,
                    Student = sp.Student,
                    Predmet = sp.Predmet,
                    Ocjena = sp.Ocjena,
                    DatumPolaganja = sp.DatumPolaganja
                };

                lista.Add(obj);
            }

            dgvPretraga.DataSource = lista;
        }

     
        private void FiltrirajPodatke()
        {

            List<PomocnaKlasaIB180084> filterLista = new List<PomocnaKlasaIB180084>();

            int filter1 = int.Parse(cmbOcjene.SelectedItem.ToString());
            var filter2 = dtpOd.Value.Date;
            var filter3 = dtpDo.Value.Date;

            foreach (var instanca in lista)
            {
                if (instanca.Ocjena == filter1 && (instanca.DatumPolaganja >= filter2 && instanca.DatumPolaganja <= filter3))
                {
                    filterLista.Add(instanca);
                }
            }

            dgvPretraga.DataSource = filterLista;

            MessageBox.Show($"U periodu od {filter2} - {filter3} studenti su polozili {filterLista.Count} predmeta.");
        }

  
        private void cmbOcjene_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrirajPodatke();
        }

        private void dgvPretraga_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPretraga.Columns[e.ColumnIndex] is DataGridViewButtonColumn)   // samo test 
            {
                var frmPoruke = new frmPorukeIB180084(dgvPretraga.SelectedRows[0].DataBoundItem as PomocnaKlasaIB180084);
                frmPoruke.ShowDialog();
            }
        }
    }
}
