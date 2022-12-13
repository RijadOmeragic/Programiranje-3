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
        List<StudentiKonsultacijeIB180084> lista = new List<StudentiKonsultacijeIB180084>();

        public frmIzvjestajIB180084(List<StudentiKonsultacijeIB180084> lista)
        {
            InitializeComponent();
            this.lista = lista;
        }

        private void frmIzvjestajIB180084_Load(object sender, EventArgs e)
        {
            var rpc = new ReportParameterCollection();
            rpc.Add(new ReportParameter("ImeStudenta", lista[0].Student.ToString()));
            rpc.Add(new ReportParameter("BrojZahtjeva", lista.Count().ToString()));

            var rds = new ReportDataSource();
            var tbl = new DataSet1.StudentiNapomeneDataTable();
            int rb = 1;

            foreach(var instanca in lista)
            {
                var red = tbl.NewStudentiNapomeneRow();

                red.Rb = rb++.ToString();
                red.Predmet = instanca.Predmet.ToString();
                red.Vrijeme = instanca.VrijemeOdrzavanja.ToString();
                red.Napomena = instanca.Napomena;

                tbl.AddStudentiNapomeneRow(red);
            }
            rds.Name = "DataSet1";
            rds.Value = tbl;

            this.reportViewer1.LocalReport.SetParameters(rpc);
            this.reportViewer1.LocalReport.DataSources.Add(rds);


            this.reportViewer1.RefreshReport();
        }
    }
}
