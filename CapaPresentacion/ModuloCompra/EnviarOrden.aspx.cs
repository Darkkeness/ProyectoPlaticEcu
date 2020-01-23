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
    public partial class EnviarOrden : System.Web.UI.Page
    {
        ControladorOrdenCompra ordenControlador = new ControladorOrdenCompra();
        protected void Page_Load(object sender, EventArgs e)
        {
            grvDisponible.DataSource = ordenControlador.listaOrdenDisponibles();
            grvDisponible.DataBind();
            grvNoDispobles.DataSource = ordenControlador.listaOrdenNoDisponibles();
            grvNoDispobles.DataBind();
        }

        protected void grvNoDispobles_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tbl_Compra compra = new Tbl_Compra();
            GridViewRow row = grvNoDispobles.SelectedRow;
            string id = row.Cells[0].Text;
            idGuardado.Value = id;
            pnl.Visible = true;
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            Tbl_Proveedor prov = ordenControlador.buscarPorIdProveedor(Convert.ToInt32(proveedor.SelectedValue));
            Tbl_Orden_Compra ord = ordenControlador.buscarPorIdOrden(Convert.ToInt32(idGuardado.Value));
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
            ordenControlador.actualizarOrden(ord);
            Response.Write("<script>alert('Se reenvio correctamente');window.location.href='/ModuloCompra/EnviarOrden.aspx';</script>");
        }

        protected void grvDisponible_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tbl_Compra compra = new Tbl_Compra();
            GridViewRow row = grvDisponible.SelectedRow;
            string id = row.Cells[0].Text;
            Tbl_Orden_Compra ordenElegida = ordenControlador.buscarPorIdOrden(Convert.ToInt32(id));
            Tbl_Proveedor prov = ordenControlador.buscarPorRucProveedor(ordenElegida.Orc_Ruc);
            List<Tbl_Detalle_OrdenCompra> listaDetalles = ordenControlador.listadetalle(ordenElegida.Orc_Id);
            if (ordenElegida.Orc_Categoria.Equals("INSUMOS"))
            {
                foreach(Tbl_Detalle_OrdenCompra item in listaDetalles)
                {
                    Tbl_Insumos insumos = new Tbl_Insumos();
                    insumos.Ins_Cantidad = item.OdtCantidad;
                    insumos.Ins_Nombre = item.OdtDescripcion;
                    insumos.Ins_Descripcion = item.OdtDescripcion;
                    insumos.Ins_Precio_Unitario = Convert.ToDouble(item.OdtPrecio);
                    insumos.Ins_Precio_Neto =Convert.ToDouble(item.OdtTotal);
                    insumos.Ins_Cai_Id = 1;
                    ordenControlador.guardarInsumos(insumos);
                }
                insIdResult insG = ordenControlador.buscaridInsumo();
                compra.Com_Ins_Id = insG.InsId;
                ordenControlador.guardarCompra(compra);
                compraIdResult compG = ordenControlador.buscaridComp();
                Tbl_Proveedor_Compra prvCom = new Tbl_Proveedor_Compra();
                prvCom.Prc_Com_Id = compG.compId;
                prvCom.Prc_Prv_Id = prov.Prv_Id;
                ordenControlador.guardarCOMPRAPROVEEDOR(prvCom);
            }
            if (ordenElegida.Orc_Categoria.Equals("POLIMEROS"))
            {
                foreach (Tbl_Detalle_OrdenCompra item in listaDetalles)
                {
                    Tbl_Polimeros polimeros = new Tbl_Polimeros();
                    polimeros.Pol_Cantidad = item.OdtCantidad;
                    polimeros.Pol_Descripcion = item.OdtDescripcion;
                    polimeros.Pol_Nombre = item.OdtDescripcion;
                    polimeros.Pol_Precio_Unitario = Convert.ToDouble(item.OdtPrecio);
                    polimeros.Pol_Percio_Neto = Convert.ToDouble(item.OdtTotal);
                    polimeros.Pol_Cap_Id = 1;
                    ordenControlador.guardarPolimeros(polimeros);
                }
                polIdResult polG = ordenControlador.buscaridPolimeros();
                compra.Com_Pol_Id = polG.PolId;
                ordenControlador.guardarCompra(compra);
                compraIdResult compG = ordenControlador.buscaridComp();
                Tbl_Proveedor_Compra prvCom = new Tbl_Proveedor_Compra();
                prvCom.Prc_Com_Id = compG.compId;
                prvCom.Prc_Prv_Id = prov.Prv_Id;
                ordenControlador.guardarCOMPRAPROVEEDOR(prvCom);

            }
            if (ordenElegida.Orc_Categoria.Equals("MAQUINARIA"))
            {
                foreach (Tbl_Detalle_OrdenCompra item in listaDetalles)
                {
                    Tbl_Maquinaria maquinaria = new Tbl_Maquinaria();
                    maquinaria.Maq_Cantidad = item.OdtCantidad;
                    maquinaria.Maq_Descripcion = item.OdtDescripcion;
                    maquinaria.Maq_Nombre = item.OdtDescripcion;
                    maquinaria.Maq_Precio_Unitario = Convert.ToDouble(item.OdtPrecio);
                    maquinaria.Maq_Cam_Id = 1;
                    ordenControlador.guardarMaquinaria(maquinaria);
                }
                maqIdResult maqG = ordenControlador.buscaridMaquinaria();
                compra.Com_Maq_Id = maqG.MaqId;
                ordenControlador.guardarCompra(compra);
                compraIdResult compG = ordenControlador.buscaridComp();
                Tbl_Proveedor_Compra prvCom = new Tbl_Proveedor_Compra();
                prvCom.Prc_Com_Id = compG.compId;
                prvCom.Prc_Prv_Id = prov.Prv_Id;
                ordenControlador.guardarCOMPRAPROVEEDOR(prvCom);
            }
            if (ordenElegida.Orc_Categoria.Equals("REPUESTO"))
            {
                foreach (Tbl_Detalle_OrdenCompra item in listaDetalles)
                {
                    Tbl_Repuesto repuesto = new Tbl_Repuesto();
                    repuesto.Rep_Cantidad = item.OdtCantidad;
                    repuesto.Rep_Descripcion = item.OdtDescripcion;
                    repuesto.Rep_Nombre = item.OdtDescripcion;
                    repuesto.Rep_Precio_Unitario = Convert.ToDouble(item.OdtPrecio);
                    repuesto.Rep_Ctr_Id = 1;
                    ordenControlador.guardarRepuesto(repuesto);
                }
                repIdResult repG = ordenControlador.buscaridRepuesto();
                compra.Com_Rep_Id = repG.repId;
                ordenControlador.guardarCompra(compra);
                compraIdResult compG = ordenControlador.buscaridComp();
                Tbl_Proveedor_Compra prvCom = new Tbl_Proveedor_Compra();
                prvCom.Prc_Com_Id = compG.compId;
                prvCom.Prc_Prv_Id = prov.Prv_Id;
                ordenControlador.guardarCOMPRAPROVEEDOR(prvCom);
            }
            if (ordenElegida.Orc_Categoria.Equals("PALETIZADA"))
            {
                foreach (Tbl_Detalle_OrdenCompra item in listaDetalles)
                {
                    Tbl_Paletizado paletizado = new Tbl_Paletizado();
                    paletizado.Pal_Cantidad = item.OdtCantidad;
                    paletizado.Pal_Descripcion = item.OdtDescripcion;
                    paletizado.Pal_Nombre = item.OdtDescripcion;
                    paletizado.Pal_Precio_Unitario = Convert.ToDouble(item.OdtPrecio);
                    paletizado.Pal_Precio_Neto = Convert.ToDouble(item.OdtTotal);
                    paletizado.Pal_Tipo_Paletizado = "MADERA";
                    ordenControlador.guardarPaletizado(paletizado);
                }
                palIdResult palG = ordenControlador.buscaridPaletizada();
                compra.Com_Pal_Id = palG.palId;
                ordenControlador.guardarCompra(compra);
                compraIdResult compG = ordenControlador.buscaridComp();
                Tbl_Proveedor_Compra prvCom = new Tbl_Proveedor_Compra();
                prvCom.Prc_Com_Id = compG.compId;
                prvCom.Prc_Prv_Id = prov.Prv_Id;
                ordenControlador.guardarCOMPRAPROVEEDOR(prvCom);
            }
            ordenElegida.Orc_EstadoPedido = "REALIZADA";
            ordenControlador.actualizarOrden(ordenElegida);
            Response.Write("<script>alert('Se realizo la compra correctamente');window.location.href='/ModuloCompra/Compras.aspx';</script>");
        }
    }
}