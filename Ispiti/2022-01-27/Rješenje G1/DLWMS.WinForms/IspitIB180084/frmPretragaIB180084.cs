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
        public frmPretragaIB180084()
        {
            InitializeComponent();
            dgvPretraga.AutoGenerateColumns = false;
        }

        private void frmPretragaIB180084_Load(object sender, EventArgs e)
        {
            UcitajPodatke();
        }

        private void UcitajPodatke()
        {
            dgvPretraga.DataSource = DLWMSdb.Baza.StudentiPredmeti.ToList();
        }

        private void txtPretraga_TextChanged(object sender, EventArgs e)
        {
            FiltrirajPodatke();
        }

        private void FiltrirajPodatke()
        {
            List<StudentiPredmetiIB180084> filterLista = new List<StudentiPredmetiIB180084>();

            string filter = txtPretraga.Text;

            foreach(var instanca in DLWMSdb.Baza.StudentiPredmeti)
            {
                if(instanca.Predmet.ToString().Contains(filter))
                     filterLista.Add(instanca);
            }

            dgvPretraga.DataSource = filterLista;
            this.Text = $"Broj zapisa: {filterLista.Count}";
        }

        private void dgvPretraga_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            var column = dgvPretraga.Columns[e.ColumnIndex];

            if(column is DataGridViewButtonColumn)
            {
                if (column.Index==4)
                {
                     var obj = dgvPretraga.Rows[e.RowIndex].DataBoundItem as StudentiPredmetiIB180084;
                     
                    if(MessageBox.Show("Da li zaista zelite izbrisati red?","Warning",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
                    {
                        DLWMSdb.Baza.StudentiPredmeti.Remove(obj);
                        DLWMSdb.Baza.SaveChanges();

                        UcitajPodatke();
                    }
                }
                else if(column.Index==5)
                {
                    var frmStudentiSlike = new frmStudentSlikeIB180084(dgvPretraga.Rows[e.RowIndex].DataBoundItem as StudentiPredmetiIB180084);
                    frmStudentiSlike.ShowDialog();
                }
            }
           
        }

        private void btnPrintaj_Click(object sender, EventArgs e)
        {
            var frmIyzvjestj = new frmIzvjestajIB180084(dgvPretraga.DataSource as List<StudentiPredmetiIB180084>);
            frmIyzvjestj.ShowDialog();
        }

        private void btnSumiraj_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDo.Text) || string.IsNullOrEmpty(txtOd.Text))
                return;

            int Od = int.Parse(txtOd.Text);
            int Do = int.Parse(txtDo.Text);
            int suma = 0;

            var sumiranje = Task.Run(() =>
            {
                for (int i = Od; i <= Do; i++)
                {
                    suma += i;
                }
            });

            var cekanje = sumiranje.GetAwaiter();

            cekanje.OnCompleted(() =>
            {
                txtSuma.Text = suma.ToString();
            });
        }
    }
}
