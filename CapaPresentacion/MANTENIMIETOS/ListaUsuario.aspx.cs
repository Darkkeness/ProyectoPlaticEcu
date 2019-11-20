using CapaDatos;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion.MANTENIMIETOS
{
    public partial class ListaUsuario : System.Web.UI.Page
    {
        String id;
        ControladorUsuario usuarioC = new ControladorUsuario();
        public Tbl_Usuario usuario = new Tbl_Usuario();
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
            //Tbl_Usuario objUsu = new Tbl_Usuario();
            //try
            //{
            //objUsu.Usu_Nombre = txtNombres.Text;
            //objUsu. = txtApellidos.Text;
            //objUsu.Usu_Contrasenia = txtContraseña.Text;
            //objUsu.UsuCorreo = txtCorreo.Text;
            //objUsu.UsuDireccion = txtDireccion.Text;
            //objUsu.UsuNomLogin = txtNombres.Text;
            //objUsu.UsuTelefono = txtTelefono.Text;
            //objUsu.UsuFHR = DateTime.Now;
            //objUsu.TusId = 1;
            //usuarioC.guardarUsuario(objUsu);
            //Response.Write("<script>alert('Se Guardo Correctamente');window.location.href = 'ListaUsuario.aspx';</script>");
            //}
            //catch (Exception ex)
            //{
            //    Response.Write("<script>alert('ERROR AL GUARDAR');window.location.href = 'ListaUsuario.aspx';</script>");
            //    Console.Write(ex);
                
            //}

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
                Response.Write("<script>alert('ERROR AL ELIMINAR');window.location.href = 'ListaUsuario.aspx';</script>");
            }
            
        }
    }
}