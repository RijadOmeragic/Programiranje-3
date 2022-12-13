using Microsoft.Reporting.WinForms;
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
    public partial class frmIzvjestajIB180084 : Form
    {
        List<StudentPorukaIB180084> lista = new List<StudentPorukaIB180084>();

        public frmIzvjestajIB180084(List<StudentPorukaIB180084> lista)
        {
            InitializeComponent();
            this.lista = lista; 
        }

        private void frmIzvjestajIB180084_Load(object sender, EventArgs e)
        {
            var rpc = new ReportParameterCollection();
            rpc.Add(new ReportParameter("BrojPoruka", lista.Count.ToString()));
            rpc.Add(new ReportParameter("ImeStudenta", lista[0].Student.ToString()));

            var rds = new ReportDataSource();
            var tbl = new DataSet1.StudentiPorukeDataTable();

            int rb = 1;

            foreach(var instanca in lista)
            {
                var red = tbl.NewStudentiPorukeRow();

                red.Rb = rb++.ToString();
                red.Predmet = instanca.Predmet.ToString();
                red.Vrijeme = instanca.VrijemeKreiranja.ToString();
                red.Sadrzaj = instanca.Sadrzaj;
                red.BrojZnakova = instanca.Sadrzaj.Count().ToString();


                if (instanca.Slika != null)
                    red.PosjedujeSliku = "Da";
                else
                    red.PosjedujeSliku = "Ne";

                tbl.AddStudentiPorukeRow(red);

            }
            rds.Name = "DataSet1";
            rds.Value = tbl;

            this.reportViewer1.LocalReport.SetParameters(rpc);
            this.reportViewer1.LocalReport.DataSources.Add(rds);


            this.reportViewer1.RefreshReport();
        }
    }
}
