using CapaDatos;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Validaciones;

namespace CapaPresentacion
{
    public partial class recuperarContraseña : System.Web.UI.Page
    {
        ValCedula validar = new ValCedula();
        ControladorUsuario controladorUsuario = new ControladorUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
       

        protected void enviar(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int contraseña = rnd.Next();
            Tbl_Usuario usu = controladorUsuario.recuperarContraseña(txtRecuperarUser.Text, txtRecuperarEmail.Text);
            try
            {
                if (usu != null)
                {
                    usu.Usu_Contrasenia = validar.Encriptar(Convert.ToString(contraseña));
                    usu.Usu_Estado = Convert.ToChar("R");
                    controladorUsuario.editarUsuario(usu);
                    validar.enviarEmail(usu.Tbl_Persona.Per_Direccion, "RECUPERAR CONTRSEÑA", "SU CONTRASEÑA ES :" + Convert.ToString(contraseña));
                    Response.Write("<script>window.alert('EL EMAIL FUE ENVIADO CORRECTAMENTE')</script>");
                }
                else
                {
                    if (controladorUsuario.buscarPorNombre(txtRecuperarUser.Text) == null)
                    {
                        Response.Write("<script>window.alert('EL USUARIO NO EXISTE')</script>");
                    }
                    else
                    {
                        Response.Write("<script>window.alert('EL EMAIL INCORRECTO')</script>");
                    }
                }

            }catch(Exception EX)
            {
                Response.Write("<script>window.alert('NO HAY CONEXION A INTERNET')</script>");
            }
            
        }
    }
}