using DLWMS.WinForms.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace DLWMS.WinForms.IspitIB180084
{
    public partial class frmKonsultacijeIB180084 : Form
    {
        PomocnaKlasaIB180084 student;

        List<StudentiKonsultacijeIB180084> lista = new List<StudentiKonsultacijeIB180084>();

        public frmKonsultacijeIB180084(PomocnaKlasaIB180084 student)
        {
            InitializeComponent();
            dgvKonsultacije.AutoGenerateColumns = false;
            this.student = student;
        }

        private void frmKonsultacijeIB180084_Load(object sender, EventArgs e)
        {
            UcitajPodatke();
            lblStudent.Text = $"Lista zahtjeva za konsultacije studenta {student.Student}";
            cmbPredmeti.DataSource = DLWMSdb.Baza.Predmeti.ToList();
        }

        private void UcitajPodatke()
        {
            lista.Clear();
            dgvKonsultacije.DataSource = null;

            foreach(var sk in DLWMSdb.Baza.StudentiKonsultacija)
            {
                if(sk.Student==student.Student)
                {
                    lista.Add(sk);
                }
            }

            dgvKonsultacije.DataSource = lista;
            this.Text = $"Broj prikazanih zapisa {lista.Count}";
        }

        private void dgvKonsultacije_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvKonsultacije.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                var obj = dgvKonsultacije.Rows[e.RowIndex].DataBoundItem as StudentiKonsultacijeIB180084;
                //var obj = dgvKonsultacije.SelectedRows[0].DataBoundItem as StudentiKonsultacijeIB180084;

                if (MessageBox.Show("Da li zelite izbrisati zahtjev za konsultacijama?","Brisanje",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
                {
                    if (obj.VrijemeOdrzavanja > DateTime.Now)
                    { 
                        DLWMSdb.Baza.StudentiKonsultacija.Remove(obj);
                        DLWMSdb.Baza.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Nije dozvoljeno brisati realizirane konsultacije","Greška",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }

                UcitajPodatke();
            }
        }

        private void DodajZahtjev_Click(object sender, EventArgs e)
        {
            var frmNovaKonsultacija = new frmNovaKonsultacijaIB180084(student);
            frmNovaKonsultacija.ShowDialog();
            UcitajPodatke();
        }

        private void btnPrintaj_Click(object sender, EventArgs e)
        {
            var frmIzvjestaj = new frmIzvjestajIB180084(dgvKonsultacije.DataSource as List<StudentiKonsultacijeIB180084>);
            frmIzvjestaj.ShowDialog();
        }

        private async void btnDodaj_Click(object sender, EventArgs e)
        {
            if (P5.Validator.ValidirajKontrolu(txtBrZahtjeva, errorProvider1, Poruke.ObaveznaVrijednost) &&
                 P5.Validator.ValidirajKontrolu(cmbPredmeti, errorProvider1, Poruke.ObaveznaVrijednost))
            {
                txtInfo.Clear();
                PredmetiIB180084 predmet = cmbPredmeti.SelectedItem as PredmetiIB180084;

                await Task.Run(() => {
                    int brojZahtjeva = int.Parse(txtBrZahtjeva.Text.ToString());
                    string info;
                    for (int i = 0; i < brojZahtjeva; i++)
                    {
                        Thread.Sleep(500);
                        StudentiKonsultacijeIB180084 novaKonsultacija = new StudentiKonsultacijeIB180084
                        {
                            Student = student.Student,
                            Predmet = predmet,
                            VrijemeOdrzavanja = DateTime.Now,
                            Napomena = $"Dodavanje u threadu ({i + 1})"
                        };
                        DLWMSdb.Baza.StudentiKonsultacija.Add(novaKonsultacija);
                        info = $"Za {student.Student} dodat novi zahtjev za konsultacijama -> {predmet} | ({DateTime.Now}) {Environment.NewLine}";
                        Action akcija = () => txtInfo.Text += info;
                        BeginInvoke(akcija);
                    }
                    DLWMSdb.Baza.SaveChanges();
                });

                MessageBox.Show($"Uspjesno ste dodali {txtBrZahtjeva.Text} zahtjeva za konsultacije!", "Obavijest.");
                txtBrZahtjeva.Clear();

                UcitajPodatke();
            }
           
        }
    }
}
