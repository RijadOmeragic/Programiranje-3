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

namespace DLWMS.WinForms.IB180085
{
    public partial class frmPretragaIB180085 : Form
    {
        List<PomocnaKlasaIB180084> lista = new List<PomocnaKlasaIB180084>();
       
        public frmPretragaIB180085()
        {
            InitializeComponent();
            cmbStatus.SelectedIndex = 0;

        }

        private void frmPretragaIB180085_Load(object sender, EventArgs e)
        {
            UcitajPodatke();
        }

        private void UcitajPodatke()
        {
           foreach(var student in DLWMSdb.Baza.Studenti)
           {
                double prosjek = 0;
                int brojac = 0;
                string status;
                
                foreach(var sp in DLWMSdb.Baza.StudentiPredmeti)
                {
                    if(student==sp.Student)
                    {
                        prosjek += sp.Ocjena;
                        brojac++;
                    }
                }

                if (brojac != 0)
                    prosjek = Math.Round( prosjek / brojac,2);
                else
                    prosjek = 5;


                if (student.Aktivan == true)
                   status = "Aktivan";
                else
                    status = "Neaktivan";


                var obj = new PomocnaKlasaIB180084()
                {
                    Student = student,
                    Email = student.Email,
                    Status = status,
                    Prosjek =prosjek
                };

                lista.Add(obj);
           }

            dgvPretraga.DataSource = lista;
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            FiltrirajPodatke();
        }

        private void FiltrirajPodatke()
        {
            List<PomocnaKlasaIB180084> filterLista = new List<PomocnaKlasaIB180084>();

            string filter1 = txtEmail.Text;
            string filter2 = cmbStatus.Text;

            filterLista = lista.Where(o => ProvjeriStatus(o, filter2) && o.Email.Contains(filter1)).ToList();

            dgvPretraga.DataSource = filterLista;

        }

        private bool ProvjeriStatus(PomocnaKlasaIB180084 o, string filter2)
        {
            if (filter2 != "Svi")
                if (o.Status != filter2)
                    return false;

            return true;
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrirajPodatke();
        }
    }
}
