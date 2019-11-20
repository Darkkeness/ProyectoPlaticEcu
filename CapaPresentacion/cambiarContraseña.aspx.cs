using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using Validaciones;

namespace CapaPresentacion
{
    public partial class cambiarContraseña : System.Web.UI.Page
    {
        ControladorUsuario controladorUsu = new ControladorUsuario();
        ValCedula validar = new ValCedula();
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void ingresar_Click(object sender, EventArgs e)
        {
          Tbl_Usuario usu = controladorUsu.buscarPorId(Convert.ToInt32(Request.QueryString["id"]));
            if (txtNuevaContraseña.Text.Equals(txtRepita.Text))
            {
                usu.Usu_Contrasenia = validar.Encriptar(txtNuevaContraseña.Text);
                usu.Usu_Estado = Convert.ToChar("A");
                controladorUsu.editarUsuario(usu);
                Session["usuario"] = usu;
                Response.Write("<script>alert('Se cambia su contraseña');window.location.href = 'Menu.aspx';</script>");
            }
            else
            {
                Response.Write("<script>window.alert('No coincide')</script>");
            }
        }
    }
}