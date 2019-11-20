using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class controladorProducto
    {
        DBADODataContext comand = new DBADODataContext();

        public List<Tbl_Producto> listarTodoProducto()
        {
            var lista = comand.Tbl_Producto.Where(li => li.Pro_Estado.Equals('A'));
            return lista.ToList();
        }

        public void guardarUsuario(Tbl_Producto pro)
        {
            pro.Pro_Estado = Convert.ToChar("A");
            comand.Tbl_Producto.InsertOnSubmit(pro);
            comand.SubmitChanges();
        }
        public Tbl_Producto buscarPorId(int id)
        {
            var usu = comand.Tbl_Producto.First(u => u.Pro_Id == id);
            return usu;
        }

        public void eliminarProducto(Tbl_Producto usu)
        {
            comand.Tbl_Producto.DeleteOnSubmit(usu);
            comand.SubmitChanges();
        }

        public void editarProducto(Tbl_Producto usu)
        {
            comand.SubmitChanges();
        }

    }
}
