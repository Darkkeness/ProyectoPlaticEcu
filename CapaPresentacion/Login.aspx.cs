using CapaDatos;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using Validaciones;

namespace CapaPresentacion
{
    public partial class Login : System.Web.UI.Page
    {
        ValCedula validar = new ValCedula();
        ControladorUsuario controladorUsuario = new ControladorUsuario();
        
        protected void Page_Load(object sender, EventArgs e)
        {
         
            if (Session["intento"] == null)
            {
                Session["intento"] = "0";
            }
            
        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            int intento = Convert.ToInt32(Session["intento"].ToString());
            Tbl_Usuario usu = controladorUsuario.buscarUsuario(txtUser.Text, validar.Encriptar(txtPass.Text));

            if (usu != null)
            {
                if (usu.Tbl_Rol.Rol_Nombre.Equals("Administrador")) { 
                if (usu.Usu_Estado.Equals(Convert.ToChar("R")))
                {
                    Response.Redirect("cambiarContraseña.aspx?id=" + usu.Usu_Id);
                }
                else
                {
                    Session["usuario"] = usu;
                    Response.Redirect("Menu.aspx");
                }
                }
                else
                {
                   //AQUI SE REDIRECCIONA AL TEMPLATE DEL USUARIO
                }
                }
                else
                {
                if (controladorUsuario.buscarPorNombre(txtUser.Text) != null)
                {
                    Response.Write("<script>window.alert('LA COTRASEÑA ES INCORRECTA')</script>");
                }
                else
                {
                    Response.Write("<script>window.alert('EL USUARIO NO EXISTE')</script>");
                }
                if (intento >= 2)
                {
                    ingresar.Enabled = false;
                    intentos.Text = "INTENTE MAS TARDE";

                }
                else
                {
                    
                    intento = intento + 1;
                    Session["intento"] = intento;
                    intentos.Text = "INTENTOS   :" + intento;

                }
                 }
        }

       

    }
}