using BLL;
using Entities;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrimerPacialA2.Reportes
{
    public partial class RepotePrestamos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RepositorioBase<Prestamos> repositorio = new RepositorioBase<Prestamos>();

                PrestamosReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                PrestamosReportViewer.Reset();

                PrestamosReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\Report_Prestamos.rdlc");
                PrestamosReportViewer.LocalReport.DataSources.Clear();
                PrestamosReportViewer.LocalReport.DataSources.Add(new ReportDataSource("Prestamos", repositorio.GetList(x => true)));
                PrestamosReportViewer.LocalReport.Refresh();
            }
        }
    }
}