using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaNegocio;

namespace CapaPresentacion.ModuloCompra
{
    public partial class OrdenCompra : System.Web.UI.Page
    {
        ControladorOrdenCompra ordC = new ControladorOrdenCompra();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Random r = new Random();
                ordFecha.Text =Convert.ToString(DateTime.Now);
                ordNumero.Text = Convert.ToString(r.Next(10, 101));
                Session["PRODUCTOS"] = null;
            }
        }

        protected void btnAgragra_Click(object sender, EventArgs e)
        {

            Tbl_Detalle_OrdenCompra det = new Tbl_Detalle_OrdenCompra();
            List<Tbl_Detalle_OrdenCompra> detalle = new List<Tbl_Detalle_OrdenCompra>();
            if (Session["PRODUCTOS"] != null)
            {
                detalle = (List<Tbl_Detalle_OrdenCompra>)Session["PRODUCTOS"];
            }

            det.OdtDescripcion = ordProducto.Text;
            det.OdtCantidad = Convert.ToInt32(ordCantidad.Text);
            det.OdtPrecio = Convert.ToDecimal(ordPrecio.Text);
            det.OdtTotal = det.OdtPrecio * det.OdtCantidad;
            detalle.Add(det);
            Session["PRODUCTOS"] = detalle;
            grvDtalle.DataSource = detalle;
            grvDtalle.DataBind();
            ordProducto.Text = "";
            ordCantidad.Text = "";
            ordPrecio.Text = "";
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Tbl_Usuario usuario = (Tbl_Usuario) Session["usuario"];
            Tbl_Orden_Compra ordenCabecera = new Tbl_Orden_Compra();
            ordenCabecera.Orc_Orden = ordNumero.Text;
            ordenCabecera.Orc_Fecha_Orc = Convert.ToDateTime(ordFecha.Text);
            ordenCabecera.Orc_Tipo_Pago = ordTipo.SelectedValue;
            ordenCabecera.Orc_Email = "";
            ordenCabecera.Orc_Categoria = categoria.SelectedValue;
            ordenCabecera.Orc_Moneda = moneda.SelectedValue;
            ordenCabecera.Orc_TipoCompra = ordTipoCompra.SelectedValue;
            ordenCabecera.Orc_Descripcion = "COMPRA REALIZADA EN :" + ordFecha.Text;
            ordenCabecera.Orc_Per_Id = usuario.Tbl_Persona.Per_Id;
            ordC.guardarOrden(ordenCabecera);
            buscarIdResult ordenGuardada = ordC.buscarGuardada();
            List<Tbl_Detalle_OrdenCompra> detalles = new List<Tbl_Detalle_OrdenCompra>();
            detalles = (List<Tbl_Detalle_OrdenCompra>) Session["PRODUCTOS"];

            foreach (var deta in detalles)
            {
                deta.Orc_Id = ordenGuardada.OrcId;
                ordC.guardarOrdenDetalle(deta);
            }
            Response.Write("<script>alert('Se a Ingresado Correctamente');window.location.href='/ModuloCompra/ProcesarOrden.aspx';</script>");
        }
    }
}