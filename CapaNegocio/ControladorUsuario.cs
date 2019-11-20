using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{

    public class ControladorUsuario
    {
        DBADODataContext comand = new DBADODataContext();

        public Tbl_Usuario buscarUsuario(string usuario, string contraseña)
        {
            var usua = comand.Tbl_Usuario.FirstOrDefault(usu => usu.Usu_Nombre.Equals(usuario) && usu.Usu_Contrasenia.Equals(contraseña));
            return usua;
        }
        public Tbl_Usuario recuperarContraseña(string user, string email)
        {
            var usua = comand.Tbl_Usuario.FirstOrDefault(usu => usu.Usu_Nombre.Equals(user) && usu.Tbl_Persona.Per_Direccion.Equals(email));
            return usua;
        }
        public Tbl_Usuario buscarPorNombre(String usuario)
        {
            var nom = comand.Tbl_Usuario.FirstOrDefault(usu => usu.Usu_Nombre.Equals(usuario));
            return nom;
        }

        public Tbl_Persona buscarPersona(string cedula)
        {
            var nom = comand.Tbl_Persona.FirstOrDefault(usu => usu.Per_Cedula.Equals(cedula));
            return nom;
        }

        public List<Tbl_Usuario> listarTodo()
        {
            var lista = comand.Tbl_Usuario.Where(li => li.Usu_Estado.Equals('A'));
            return lista.ToList();
        }

        public void guardarUsuario(Tbl_Usuario usu)
        {
            usu.Usu_Estado = Convert.ToChar("A");
            comand.Tbl_Usuario.InsertOnSubmit(usu);
            comand.SubmitChanges();
        }
        public void guardarPersona(Tbl_Persona per)
        {
            comand.Tbl_Persona.InsertOnSubmit(per);
            comand.SubmitChanges();
        }
        public Tbl_Usuario buscarPorId(int id)
        {
            var usu = comand.Tbl_Usuario.First(u => u.Usu_Id == id);
            return usu;
        }

        public void eliminarUsuario(Tbl_Usuario usu)
        {
            comand.Tbl_Usuario.DeleteOnSubmit(usu);
            comand.SubmitChanges();
        }

        public void editarUsuario(Tbl_Usuario usu)
        {
            comand.SubmitChanges();
        }
        
    }
}
