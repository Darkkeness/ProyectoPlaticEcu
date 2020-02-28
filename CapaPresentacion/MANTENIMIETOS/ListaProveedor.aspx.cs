using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaNegocio;
namespace CapaPresentacion.MANTENIMIETOS
{
    public partial class ListaProveedor : System.Web.UI.Page
    {
        ControladorOrdenCompra controlador = new ControladorOrdenCompra();
        protected void Page_Load(object sender, EventArgs e)
        {
            GrvProveedor.DataSource = controlador.listaProveedores();
            GrvProveedor.DataBind();
        }

        
        protected void GrvCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlBotones.Visible = true;
            GridViewRow row = GrvProveedor.SelectedRow;
            String id = row.Cells[0].Text;
            hdId.Value = id;
            Tbl_Proveedor prv = controlador.obtenerProveedor(Convert.ToInt32(hdId.Value));
            etxtNombre.Text = prv.Prv_Nombre;
            etxtDireccion.Text = prv.Prv_Direccion;
            etxtNacionalidad.SelectedValue = prv.Prv_Nacionalidad;
            etxtTelefono.Text = prv.Prv_Telefono;
            etxtRuc.Text = prv.Prv_Ruc;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Tbl_Proveedor prv = new Tbl_Proveedor();
            prv.Prv_Nombre = txtNombre.Text;
            prv.Prv_Direccion = txtDireccion.Text;
            prv.Prv_Nacionalidad = txtNacionalidad.SelectedValue;
            prv.Prv_Telefono = txtTelefono.Text;
            prv.Prv_Ruc = txtRuc.Text;
            controlador.registrarProveedor(prv);
            Response.Write("<script>alert('Se registro correctamente');window.location.href='ListaProveedor.aspx';</script>");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Tbl_Proveedor prv = controlador.obtenerProveedor(Convert.ToInt32(hdId.Value));
            prv.Prv_Nombre = etxtNombre.Text;
            prv.Prv_Direccion = etxtDireccion.Text;
            prv.Prv_Nacionalidad = etxtNacionalidad.SelectedValue;
            prv.Prv_Telefono = etxtTelefono.Text;
            prv.Prv_Ruc = etxtRuc.Text;
            controlador.editarProveedor(prv);
            Response.Write("<script>alert('Se edito correctamente');window.location.href='ListaProveedor.aspx';</script>");
        }
    }
}