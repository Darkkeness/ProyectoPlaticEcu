using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class template : System.Web.UI.MasterPage
    {
        public String sesion;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                Tbl_Usuario usu = (Tbl_Usuario)Session["usuario"];
                sesion = usu.Usu_Nombre.ToUpper();
            }
            else
            {
                Response.Redirect("/Login.aspx");

            }

        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            Session["usuario"] = null;
            Response.Redirect("/Login.aspx");
        }
    }
}