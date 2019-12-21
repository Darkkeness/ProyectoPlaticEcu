using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;
using CapaDatos;
using Validaciones;

namespace CapaPresentacion
{
    public partial class crearUsuarioNuevo : System.Web.UI.Page
    {
        ValCedula validar = new ValCedula();
        ControladorUsuario usuar = new ControladorUsuario();
      
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ingresar_Click(object sender, EventArgs e)
        {
            Tbl_Usuario usu = new Tbl_Usuario();
            Tbl_Persona per = new Tbl_Persona();
            try { 
            if (validar.ValidarCedula(txtCedula.Text)==true) {
                    if (validar.ValidatePassword(txtContraseña.Text) == true) { 
                        if (usuar.buscarPersona(txtCedula.Text) == null) { 

                per.Per_Nombre = txtNombre.Text;
                per.Per_Apellido_Materno = txtApellido.Text;
                per.Per_Apellido_Paterno = txtApellido.Text;
                per.Per_Cedula = txtCedula.Text;
                per.Per_Direccion = txtEmail.Text;
                per.Per_Telefono = txtTelefono.Text;
                per.Per_Estado = Convert.ToChar("A");
                usuar.guardarPersona(per);


                usu.Usu_Nombre = txtNombre.Text;
                usu.Usu_Contrasenia = validar.Encriptar(txtContraseña.Text);
                usu.Usu_Rol_Id = 1;
                usu.Usu_Estado = Convert.ToChar("A");
                usu.Usu_Per_Id = usuar.buscarPersona(per.Per_Cedula).Per_Id;
                usuar.guardarUsuario(usu);
                
                Response.Write("<script>alert('Se creo Correctamente');window.location.href = 'Login.aspx';</script>");
                }
                else
                {
                    Response.Write("<script>alert('Usuario con numero de cedula existente');</script>");
                }
                    }
                    else
                    {
                        Response.Write("<script>alert('La contraseña debe tener almenos un mayusculo y caracter especial');</script>");
                    }
                }
            else
            {
                Response.Write("<script>alert('Cedula Erronea');</script>");
            }
            }
            catch
            {
                Response.Write("<script>alert('Telefono mayor al digitos permitidos');</script>");
            }
        }
    }
}