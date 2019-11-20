using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;

namespace CapaPresentacion.MANTENIMIETOS
{
    public partial class ListaCliente : System.Web.UI.Page
    {
        ControladorCliente con = new ControladorCliente();
        String id;
        protected void Page_Load(object sender, EventArgs e)
        {

            GrvCliente.DataSource = con.listarTodoCliente();
            GrvCliente.DataBind();
        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Tbl_Cliente clie = con.buscarPorIdCliente(Convert.ToInt32(hdId.Value));
            clie.Cli_Cargo = txetCargo.Text;
            con.editarCliente(clie);
            Response.Redirect("ListaCliente.aspx");
        }

        protected void GrvCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlBotones.Visible = true;
            try
            {
                GridViewRow row = GrvCliente.SelectedRow;
                id = row.Cells[0].Text;
                hdId.Value = id;

                Tbl_Cliente or = con.buscarPorIdCliente(Convert.ToInt32(hdId.Value));
                txetCargo.Text = or.Cli_Cargo; 

            }
            catch
            {

            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Tbl_Cliente cli = new Tbl_Cliente();
            cli.Cli_Estado = Convert.ToChar("A");
            cli.Cli_Cargo = txtCargo.Text;
            cli.Cli_Per_Id = 1;
            con.guardarCliente(cli);
            Response.Write("<script>alert('Se A Ingresado Correctamente');window.location.href='ListaCliente.aspx';</script>");

        }

        protected void SubmitBtn_Click1(object sender, EventArgs e)
        {
            Tbl_Cliente cliente = 
            con.buscarPorIdCliente(Convert.ToInt32 (hdId.Value));
            con.eliminarCliente(cliente);
            Response.Redirect("ListaCliente.aspx");
        }
    }
}