using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion.Reporte
{
    public partial class FacturaProveedor : System.Web.UI.Page
    {
        string id;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["id"];
            if (!IsPostBack)
            {
                ReportParameter inicio = new ReportParameter("ComId", id);
                ReportViewer1.LocalReport.SetParameters(inicio);
                ReportViewer1.LocalReport.Refresh();
            }
          
        }

       
    }
}