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
        List<StudentiPredmetiIB180084> lista = new List<StudentiPredmetiIB180084>();

        public frmIzvjestajIB180084(List<StudentiPredmetiIB180084> lista)
        {
            InitializeComponent();
            this.lista = lista;
        }

        private void frmIzvjestajIB180084_Load(object sender, EventArgs e)
        {
            var rpt = new ReportParameterCollection();
            rpt.Add(new ReportParameter("ProsjecnaOcjena", lista.Average(o => o.Ocjena).ToString()));

            var rds = new ReportDataSource();
            var tbl = new DataSet1.StudentiPredmetiDataTable();

            foreach(var instanca in lista)
            {
                var red = tbl.NewStudentiPredmetiRow();

                red.ImePrezime = instanca.Student.ToString();
                red.Predmet = instanca.Predmet.ToString();
                red.Datum = instanca.DatumPolaganja.ToString();
                red.Ocjena = instanca.Ocjena.ToString();

                tbl.AddStudentiPredmetiRow(red);
            }
            rds.Name = "DataSet1";
            rds.Value = tbl;

            this.reportViewer1.LocalReport.SetParameters(rpt);
            this.reportViewer1.LocalReport.DataSources.Add(rds);


            this.reportViewer1.RefreshReport();
        }
    }
}
