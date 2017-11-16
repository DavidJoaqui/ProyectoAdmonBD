using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo;
using System.Data;
//Aqui se hace el manejo de los procedimientos empaquetados que tenemos hechos en la BD
namespace Control
{
    public class ControlPersona
    {
        Persona p = new Persona();


        public DataSet mostrarPersonas() {

            return p.mostrarPersonas();
        }

        public DataSet mostrarUusarios()
        {
            return p.llenarComboUsuarios();
        }

        public DataSet buscarxid(string id_persona) {

            return p.buscarxid(id_persona);   
        }

        public bool insertarPersonas(string codigo,string nombres,string apellidos,string cedula,string telefono,string id_usuario) {

            return p.insertarPersona(codigo, nombres, apellidos, cedula, telefono, id_usuario);
        }

        public bool actualizarPersonas(string id_persona, string nombres, string apellidos, string cedula, string telefono, string id_usuario)
        {

            return p.actualizarPersona(id_persona, nombres, apellidos, cedula, telefono, id_usuario);
        }
        public bool eliminarPersona(string id_persona) {

            return p.eliminarPersona(id_persona);
        }

    }

}