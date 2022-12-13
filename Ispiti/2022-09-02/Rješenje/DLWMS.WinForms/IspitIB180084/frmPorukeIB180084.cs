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
    public partial class frmPorukeIB180084 : Form
    {
        PomocnaKlasaIB180084 student;

        List<StudentPorukaIB180084> lista = new List<StudentPorukaIB180084>();

        public frmPorukeIB180084(PomocnaKlasaIB180084 student)
        {
            InitializeComponent();
            dgvPoruke.AutoGenerateColumns = false;
            this.student = student;
        }

        private void frmPorukeIB180084_Load(object sender, EventArgs e)
        {
            UcitajPodatke();
            this.Text = $"Broj poruka {lista.Count}";
            lblStudent.Text = $"Poruke studenta {student.Student}";

            cmbPredmeti.DataSource = DLWMSdb.Baza.Predmeti.ToList();
        }

        private void UcitajPodatke()
        {
            dgvPoruke.DataSource = null;
            lista.Clear();

            foreach(var sp in DLWMSdb.Baza.StudentiPoruke)
            {
                if(student.Student==sp.Student)
                {
                    lista.Add(sp);
                }
            }
            dgvPoruke.DataSource = lista;
        }

        private void dgvPoruke_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPoruke.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {

                if (MessageBox.Show("Da li zaista zelite izbrisati poruku?","Brisanje",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
                {
                    var obj = dgvPoruke.SelectedRows[0].DataBoundItem as StudentPorukaIB180084;

                    DLWMSdb.Baza.StudentiPoruke.Remove(obj);
                    DLWMSdb.Baza.SaveChanges();

                    UcitajPodatke();
                }
            }
        }

        private void btnNovaPoruka_Click(object sender, EventArgs e)
        {
            var novaPoruka = new frmNovaPorukaIB180084(student);
            novaPoruka.ShowDialog();
            UcitajPodatke();
        }

        private void btnPrintaj_Click(object sender, EventArgs e)
        {
            var frmIzvjestaj = new frmIzvjestajIB180084(dgvPoruke.DataSource as List<StudentPorukaIB180084>);
            frmIzvjestaj.ShowDialog();
        }

      
    }
}
