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
        List<PomocnaKlasaIB180084> lista = new List<PomocnaKlasaIB180084>();

        public frmPretragaIB180084()
        {
            InitializeComponent();
            cmbGodine.SelectedIndex = 0;
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
                double prosjek = 0;
                int brojac = 0;

                foreach(var sp in DLWMSdb.Baza.StudentiPredmeti)
                {
                    if(student==sp.Student)
                    {
                        prosjek += sp.Ocjena;
                        brojac++;
                    }
                }

                if (brojac != 0)
                    prosjek = Math.Round(prosjek / brojac, 2);
                else
                    prosjek = 5;

                var obj = new PomocnaKlasaIB180084()
                {
                    Student = student,
                    GodinaStudija = student.GodinaStudija,
                    ProsjecnaOcjena = prosjek
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
            var filter2 = cmbGodine.SelectedItem;

            filterLista = lista.Where(o => ProvjeriGodinu(o, filter2) && o.Student.ToString().Contains(filter1)).ToList();

            dgvPretraga.DataSource = filterLista;
        }

        private bool ProvjeriGodinu(PomocnaKlasaIB180084 o, object filter2)
        {
            if (filter2.ToString() != "Sve")
            {
                int filter = int.Parse(filter2.ToString());

                if (o.GodinaStudija != filter)
                    return false;
            }
            return true;
        }

        private void cmbGodine_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrirajPodatke();
        }

        private void dgvPretraga_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPretraga.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                var frmKonsultacije = new frmKonsultacijeIB180084(dgvPretraga.SelectedRows[0].DataBoundItem as PomocnaKlasaIB180084);
                frmKonsultacije.ShowDialog();
            }
        }
    }
}
