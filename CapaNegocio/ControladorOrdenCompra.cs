using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ControladorOrdenCompra
    {
        DBADODataContext comand = new DBADODataContext();

        public List<Tbl_Orden_Compra> listaOrdenEstadoProceso()
        {
            var lista = comand.Tbl_Orden_Compra.Where(li => li.Orc_Estado.Equals('P'));
            return lista.ToList();
        }
        public void registrarProveedor(Tbl_Proveedor proveedor)
        {
            comand.Tbl_Proveedor.InsertOnSubmit(proveedor);
            comand.SubmitChanges();
        }
        public void editarProveedor(Tbl_Proveedor proveedor)
        {
            comand.SubmitChanges();
        }
        public List<Tbl_Proveedor> listaProveedores()
        {
            return comand.Tbl_Proveedor.ToList();
        }
        public Tbl_Proveedor obtenerProveedor(int prvId)
        {
            return comand.Tbl_Proveedor.First(prv=>prv.Prv_Id == prvId);
        }
        public List<Tbl_Compra> listacompraIns()
        {
            var lista = comand.Tbl_Compra.Where(li => li.Com_Ins_Id != null);
            return lista.ToList();
        }
        public List<Tbl_Compra> listacompraPol()
        {
            var lista = comand.Tbl_Compra.Where(li => li.Com_Pol_Id != null);
            return lista.ToList();
        }
        public List<Tbl_Compra> listacompraMaq()
        {
            var lista = comand.Tbl_Compra.Where(li => li.Com_Maq_Id != null);
            return lista.ToList();
        }
        public List<Tbl_Compra> listacompraRep()
        {
            var lista = comand.Tbl_Compra.Where(li => li.Com_Rep_Id != null);
            return lista.ToList();
        }
        public List<Tbl_Compra> listacompraPal()
        {
            var lista = comand.Tbl_Compra.Where(li => li.Com_Pal_Id != null);
            return lista.ToList();
        }
        public List<Tbl_Detalle_OrdenCompra> listadetalle(int id)
        {
            var lista = comand.Tbl_Detalle_OrdenCompra.Where(li => li.Orc_Id == id);
            return lista.ToList();
        }

        public List<Tbl_Orden_Compra> listaOrdenDisponibles()
        {
            var lista = comand.Tbl_Orden_Compra.Where(li => li.Orc_EstadoPedido.Equals("DISPONIBLE"));
            return lista.ToList();
        }

        public List<Tbl_Orden_Compra> listaOrdenNoDisponibles()
        {
            var lista = comand.Tbl_Orden_Compra.Where(li => li.Orc_EstadoPedido.Equals("NO DISPONIBLE"));
            return lista.ToList();
        }


        public void guardarOrden(Tbl_Orden_Compra orden)
        {
            orden.Orc_Estado = Convert.ToChar("P");
            comand.Tbl_Orden_Compra.InsertOnSubmit(orden);
            comand.SubmitChanges();
        }
        public buscarIdResult buscarGuardada()
        {
            var ord = comand.buscarId();
            return ord.First();
        }

        public Tbl_Proveedor buscarPorIdProveedor(int id)
        {
            var pro = comand.Tbl_Proveedor.First(u => u.Prv_Id == id);
            return pro;
        }
        public Tbl_Proveedor buscarPorRucProveedor(string id)
        {
            var pro = comand.Tbl_Proveedor.First(u => u.Prv_Ruc == id);
            return pro;
        }
        public Tbl_Orden_Compra buscarPorIdOrden(int id)
        {
            var pro = comand.Tbl_Orden_Compra.First(u => u.Orc_Id == id);
            return pro;
        }
        public void actualizarOrden(Tbl_Orden_Compra ord)
        {
            comand.SubmitChanges();
        }
        public void guardarOrdenDetalle(Tbl_Detalle_OrdenCompra ordDetalle)
        {
            comand.Tbl_Detalle_OrdenCompra.InsertOnSubmit(ordDetalle);
            comand.SubmitChanges();
        }

        public void guardarCOMPRAPROVEEDOR(Tbl_Proveedor_Compra prov)
        {
            comand.Tbl_Proveedor_Compra.InsertOnSubmit(prov);
            comand.SubmitChanges();
        }
        public void guardarInsumos(Tbl_Insumos insumos)
        {
            comand.Tbl_Insumos.InsertOnSubmit(insumos);
            comand.SubmitChanges();
        }
        public void guardarPolimeros(Tbl_Polimeros polimeros)
        {
            comand.Tbl_Polimeros.InsertOnSubmit(polimeros);
            comand.SubmitChanges();
        }
        public void guardarMaquinaria(Tbl_Maquinaria maquinaria)
        {
            comand.Tbl_Maquinaria.InsertOnSubmit(maquinaria);
            comand.SubmitChanges();
        }
        public void guardarRepuesto(Tbl_Repuesto repuesto)
        {
            comand.Tbl_Repuesto.InsertOnSubmit(repuesto);
            comand.SubmitChanges();
        }
        public void guardarPaletizado(Tbl_Paletizado paletizado)
        {
            comand.Tbl_Paletizado.InsertOnSubmit(paletizado);
            comand.SubmitChanges();
        }
        public void guardarCompra(Tbl_Compra compra)
        {
            comand.Tbl_Compra.InsertOnSubmit(compra);
            comand.SubmitChanges();
        }
        public polIdResult buscaridPolimeros()
        {
            var ord = comand.polId();
            return ord.First();
        }
        public insIdResult buscaridInsumo()
        {
            var ord = comand.insId();
            return ord.First();
        }
        public maqIdResult buscaridMaquinaria()
        {
            var ord = comand.maqId();
            return ord.First();
        }
        public repIdResult buscaridRepuesto()
        {
            var ord = comand.repId();
            return ord.First();
        }
        public palIdResult buscaridPaletizada()
        {
            var ord = comand.palId();
            return ord.First();
        }
        public compraIdResult buscaridComp()
        {
            var ord = comand.compraId();
            return ord.First();
        }

    }
}
