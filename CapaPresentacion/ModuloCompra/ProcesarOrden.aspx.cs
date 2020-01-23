using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaNegocio;
using Validaciones;

namespace CapaPresentacion.Modulo_Compra.ProcesarOrden
{
    public partial class ProcesarOrden : System.Web.UI.Page
    {
        ControladorOrdenCompra ordenC = new ControladorOrdenCompra();
        ValCedula val = new ValCedula();
        protected void Page_Load(object sender, EventArgs e)
        {
            grvOrden.DataSource = ordenC.listaOrdenEstadoProceso();
            grvOrden.DataBind();
        }

        protected void grvOrden_SelectedIndexChanged(object sender, EventArgs e)
        {

            Tbl_Compra compra = new Tbl_Compra();
            GridViewRow row = grvOrden.SelectedRow;
            string id = row.Cells[0].Text;
            idGuardado.Value = id;
            pnl.Visible = true;
            //Tbl_Orden_Compra ord =  ordenC.buscarPorIdOrden(Convert.ToInt32(id));
            //ord.Orc_Estado = Convert.ToChar("E");
            //ordenC.actualizarOrden(ord);
            //Response.Redirect("/ModuloCompra/EnviarOrden.aspx?id="+id);
        }

      
        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            Tbl_Proveedor prov = ordenC.buscarPorIdProveedor(Convert.ToInt32(proveedor.SelectedValue));
            Tbl_Orden_Compra ord = ordenC.buscarPorIdOrden(Convert.ToInt32(idGuardado.Value));
            Random r = new Random();
            int numero = r.Next(10, 100);
            ord.Orc_Estado = Convert.ToChar("E");
            ord.Orc_Empresa = prov.Prv_Nombre;
            ord.Orc_Entrega = DateTime.Now;
            ord.Orc_Ruc = prov.Prv_Ruc;
            ord.Orc_Telefono = prov.Prv_Telefono;
            ord.Orc_Presentacion = presentacion.SelectedValue;
            ord.Orc_Largo = largo.Text;
            ord.Orc_Ancho = ancho.Text;
            if ((numero % 2) == 0)
            {
                ord.Orc_EstadoPedido = "DISPONIBLE";
            }
            else
            {
                ord.Orc_EstadoPedido = "NO DISPONIBLE";
            }
            ord.Orc_Entrega = DateTime.Now.Add(TimeSpan.Parse("4"));
            ordenC.actualizarOrden(ord);
            Response.Write("<script>alert('Se envio Correctamente');window.location.href='/ModuloCompra/EnviarOrden.aspx';</script>");
        }
    }
}