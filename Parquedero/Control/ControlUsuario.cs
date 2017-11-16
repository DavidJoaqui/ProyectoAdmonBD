using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo;
using System.Data;

namespace Control
{
    public class ControlUsuario
    {
        UsuarioRol ur = new UsuarioRol();

        public DataSet mostrarUsuarios()
        {

            return ur.mostrarUsuarios();
        }

        public bool insertarUusario(string codigo, string usu_rol)
        {

            return ur.insertarUusrio(codigo, usu_rol);
        }

        public bool actualizarUsuario(string codigo, string usu_rol)
        {

            return ur.actualizarUsuario(codigo, usu_rol);
        }
        public bool eliminarUsuario(string codigo)
        {

            return ur.eliminarUsuario(codigo);
        }
    }
}