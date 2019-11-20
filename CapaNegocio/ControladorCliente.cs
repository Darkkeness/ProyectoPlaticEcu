using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ControladorCliente
    {
        DBADODataContext comand = new DBADODataContext();
        public List<Tbl_Cliente> listarTodoCliente()
        {
            var lista = comand.Tbl_Cliente.Where(li => li.Cli_Estado.Equals('A'));
            return lista.ToList();
        }

        public void guardarCliente(Tbl_Cliente usu)
        {
            usu.Cli_Estado = Convert.ToChar("A");
            comand.Tbl_Cliente.InsertOnSubmit(usu);
            comand.SubmitChanges();
        }
        public Tbl_Cliente buscarPorIdCliente(int id)
        {
            var usu = comand.Tbl_Cliente.First(u => u.Cli_Id == id);
            return usu;
        }

        public void eliminarCliente(Tbl_Cliente usu)
        {
            comand.Tbl_Cliente.DeleteOnSubmit(usu);
            comand.SubmitChanges();
        }

        public void editarCliente(Tbl_Cliente usu)
        {
            comand.SubmitChanges();
        }

    }
}
