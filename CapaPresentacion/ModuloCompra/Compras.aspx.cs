using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;
using CapaDatos;

namespace CapaPresentacion.ModuloCompra
{
    public partial class Compras : System.Web.UI.Page
    {
        ControladorOrdenCompra ordC = new ControladorOrdenCompra();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void categoria_TextChanged(object sender, EventArgs e)
        {
            if (categoria.SelectedValue.Equals("INSUMOS"))
            {
                grvPaletizado.Visible = false;
                grvRepuesto.Visible = false;
                grvMaquinaria.Visible = false;
                grvPolimeros.Visible = false;
                grvComprasIns.Visible = true;
                grvComprasIns.DataSource = ordC.listacompraIns();
                grvComprasIns.DataBind();
            }
            if (categoria.SelectedValue.Equals("POLIMEROS"))
            {
                grvPaletizado.Visible = false;
                grvRepuesto.Visible = false;
                grvMaquinaria.Visible = false;
                grvPolimeros.Visible = true;
                grvComprasIns.Visible = false;
                grvPolimeros.DataSource = ordC.listacompraPol();
                grvPolimeros.DataBind();

            }
            if (categoria.SelectedValue.Equals("MAQUINARIA"))
            {
                grvPaletizado.Visible = false;
                grvRepuesto.Visible = false;
                grvMaquinaria.Visible = true;
                grvPolimeros.Visible = false;
                grvComprasIns.Visible = false;
                grvMaquinaria.DataSource = ordC.listacompraMaq();
                grvMaquinaria.DataBind();
            }
            if (categoria.SelectedValue.Equals("REPUESTO"))
            {
                grvPaletizado.Visible = false;
                grvRepuesto.Visible = true;
                grvMaquinaria.Visible = false;
                grvPolimeros.Visible = false;
                grvComprasIns.Visible = false;
                grvRepuesto.DataSource = ordC.listacompraRep();
                grvRepuesto.DataBind();

            }
            if (categoria.SelectedValue.Equals("PALETIZADA"))
            {
                grvPaletizado.Visible = true;
                grvRepuesto.Visible = false;
                grvMaquinaria.Visible = false;
                grvPolimeros.Visible = false;
                grvComprasIns.Visible = false;
                grvPaletizado.DataSource = ordC.listacompraPal();
                grvPaletizado.DataBind();
            }
        }
    }
}