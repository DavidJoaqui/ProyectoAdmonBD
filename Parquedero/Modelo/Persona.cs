using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;
using System.Data;
//metodos que se ejecutan implementando los procedimientos hechos en la BD con su respectiva funcion
namespace Modelo
{
    public class Persona
    {

        Persistencia p = new Persistencia();


        public DataSet mostrarPersonas()
        {

            OracleDataAdapter objAdapter = new OracleDataAdapter();
            DataSet datos = new DataSet();

            OracleCommand objSelectCmd = new OracleCommand();
            objSelectCmd.Connection = p.abrirConexion();
            objSelectCmd.CommandText = "GestionarPersonas.mostrarPersonas";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("cur_items", OracleDbType.RefCursor).
            Direction = ParameterDirection.Output;

            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(datos);
            p.cerrarConexion();
            return datos;
        }


        public DataSet buscarxid(string id_per)
        {           

            OracleDataAdapter objSeletcmd = new OracleDataAdapter();
            DataSet datos = new DataSet();
            OracleCommand objSelectCmd = new OracleCommand();
            objSelectCmd.Connection = p.abrirConexion();
            objSelectCmd.CommandText = "GestionarPersonas.buscarxid";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("cur_items", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            objSelectCmd.Parameters.Add("id_persona", OracleDbType.Varchar2, 20).Value = id_per;
            objSeletcmd.SelectCommand = objSelectCmd;
            objSeletcmd.Fill(datos);
            p.cerrarConexion();
            return datos;
            
        }

        public DataSet llenarComboUsuarios()
        {
            OracleDataAdapter objAdapter = new OracleDataAdapter();
            DataSet datos = new DataSet();
            OracleCommand objSelectCmd = new OracleCommand();
            objSelectCmd.Connection = p.abrirConexion();
            objSelectCmd.CommandText = "GestionarPersonas.cargarDatosCombo";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("cursorUsuarios", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(datos);
            p.cerrarConexion();
            return datos;
        }


        public bool insertarPersona(string codigo, string nombres, string apellidos, string cedula, string telefono, string id_usuario)
        {
            bool ejecuto = false;
            int filas = 0;

            OracleCommand objSelectCmd = new OracleCommand();
            objSelectCmd.Connection = p.abrirConexion();
            objSelectCmd.CommandText = "GestionarPersonas.insertarPersonas";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("id_persona", OracleDbType.Varchar2, 20).Value = codigo;
            objSelectCmd.Parameters.Add("nombres", OracleDbType.Varchar2, 20).Value = nombres;
            objSelectCmd.Parameters.Add("apellidos", OracleDbType.Varchar2, 20).Value = apellidos;
            objSelectCmd.Parameters.Add("cedula", OracleDbType.Varchar2, 20).Value = cedula;
            objSelectCmd.Parameters.Add("telefono", OracleDbType.Varchar2, 20).Value = telefono;
            objSelectCmd.Parameters.Add("id_usuario", OracleDbType.Varchar2, 20).Value = id_usuario;
            objSelectCmd.Parameters.Add("ejecuto", OracleDbType.Int16).
            Direction = ParameterDirection.Output;

            try
            {
                objSelectCmd.ExecuteNonQuery();
                filas = int.Parse(objSelectCmd.Parameters[6].Value.ToString());
                if (filas == 1)
                {
                    ejecuto = true;
                }

            }
            catch (Exception e)
            {

            }
            p.cerrarConexion();
            return ejecuto;
        }


        public bool eliminarPersona(string codigo)
        {
            bool ejecuto = false;
            int filas = 0;
            OracleCommand objSelectCmd = new OracleCommand();
            objSelectCmd.Connection = p.abrirConexion();
            objSelectCmd.CommandText = "GestionarPersonas.eliminarPersona";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("id_persona", OracleDbType.Varchar2, 20).Value = codigo;
            objSelectCmd.Parameters.Add("ejecuto", OracleDbType.Int16).
            Direction = ParameterDirection.Output;

            try
            {
                objSelectCmd.ExecuteNonQuery();
                filas = int.Parse(objSelectCmd.Parameters[1].Value.ToString());
                if (filas == 1)
                {
                    ejecuto = true;
                }

            }
            catch (Exception e)
            {

            }
            p.cerrarConexion();
            return ejecuto;

        }


        public bool actualizarPersona(string id_persona, string nombres, string apellidos, string cedula, string telefono, string id_usuario)
        {
            bool ejecuto = false;
            int filas = 0;

            OracleCommand objSelectCmd = new OracleCommand();
            objSelectCmd.Connection = p.abrirConexion();
            objSelectCmd.CommandText = "GestionarPersonas.actualizarPersona";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("id_persona", OracleDbType.Varchar2, 20).Value = id_persona;
            objSelectCmd.Parameters.Add("nombres", OracleDbType.Varchar2, 20).Value = nombres;
            objSelectCmd.Parameters.Add("apellidos", OracleDbType.Varchar2, 20).Value = apellidos;
            objSelectCmd.Parameters.Add("cedula", OracleDbType.Varchar2, 20).Value = cedula;
            objSelectCmd.Parameters.Add("telefono", OracleDbType.Varchar2, 20).Value = telefono;
            objSelectCmd.Parameters.Add("id_usuario", OracleDbType.Varchar2, 20).Value = id_usuario;
            objSelectCmd.Parameters.Add("ejecuto", OracleDbType.Int16).
            Direction = ParameterDirection.Output;

            try
            {
                objSelectCmd.ExecuteNonQuery();
                filas = int.Parse(objSelectCmd.Parameters[6].Value.ToString());
                if (filas == 1)
                {
                    ejecuto = true;
                }
            }
            catch (Exception e)
            {
            }
            p.cerrarConexion();
            return ejecuto;
        }
    }
}