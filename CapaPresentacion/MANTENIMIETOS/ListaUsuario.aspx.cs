using CapaDatos;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Validaciones;

namespace CapaPresentacion.MANTENIMIETOS
{
    public partial class ListaUsuario : System.Web.UI.Page
    {
        String id;
        ControladorUsuario usuarioC = new ControladorUsuario();
        public Tbl_Usuario usuario = new Tbl_Usuario();
        ValCedula validar = new ValCedula();
        protected void Page_Load(object sender, EventArgs e)
        {
          
            GrvUsuario.DataSource = GrvUsuario_GetData();
            GrvUsuario.DataBind();

        }

        public List<Tbl_Usuario> GrvUsuario_GetData()
        {
            List<Tbl_Usuario> listaUsu = new List<Tbl_Usuario>();
            listaUsu = usuarioC.listarTodo();
            return listaUsu;
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            Tbl_Usuario usu = new Tbl_Usuario();
            Tbl_Persona per = new Tbl_Persona();
            try
            {
                if (validar.ValidarCedula(txtCedula.Text) == true)
                {
                    if (usuarioC.buscarPersona(txtCedula.Text) == null)
                    {

                        per.Per_Nombre = txtNombre.Text;
                        per.Per_Apellido_Materno = txtApellido.Text;
                        per.Per_Apellido_Paterno = txtApellido.Text;
                        per.Per_Cedula = txtCedula.Text;
                        per.Per_Direccion = txtEmail.Text;
                        per.Per_Telefono = txtTelefono.Text;
                        per.Per_Estado = Convert.ToChar("A");
                        usuarioC.guardarPersona(per);


                        usu.Usu_Nombre = txtNombre.Text;
                        usu.Usu_Contrasenia = validar.Encriptar(txtContraseña.Text);
                        usu.Usu_Rol_Id = 1;
                        usu.Usu_Estado = Convert.ToChar("A");
                        usu.Usu_Per_Id = usuarioC.buscarPersona(per.Per_Cedula).Per_Id;
                        usuarioC.guardarUsuario(usu);

                        Response.Write("<script>alert('Se creo Correctamente');window.location.href = 'ListaUsuario.aspx';</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Usuario con numero de cedula existente');</script>");
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

        protected void GrvUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlBotones.Visible = true;
            try
            {
                GridViewRow row = GrvUsuario.SelectedRow;
                id = row.Cells[0].Text;
                usuario = usuarioC.buscarPorId(Convert.ToInt32(id));
                etxtNombres.Text = usuario.Usu_Nombre;
                hdId.Value = Convert.ToString(usuario.Usu_Id);

            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('ERROR AL SELECCIONAR');window.location.href = 'ListaUsuario.aspx';</script>");
            }
           
            
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                usuario = usuarioC.buscarPorId(Convert.ToInt32(hdId.Value));
                usuario.Usu_Nombre = etxtNombres.Text;
                usuarioC.editarUsuario(usuario);
                Response.Redirect("ListaUsuario.aspx");
            }
            catch
            {
                Response.Write("<script>alert('ERROR AL EDITAR');window.location.href = 'ListaUsuario.aspx';</script>");
            }
            
           
        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                usuarioC.eliminarUsuario(usuarioC.buscarPorId(Convert.ToInt32(hdId.Value)));
                Response.Redirect("ListaUsuario.aspx");
            }catch{
                Response.Write("<script>alert('ERROR AL ELIMINAR REGISTRO REFERENCIADO');window.location.href = 'ListaUsuario.aspx';</script>");
            }
            
        }
    }
}