using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;
using System.Data;

namespace Modelo
{
    public class UsuarioRol
    {
        Persistencia p = new Persistencia();

        public DataSet mostrarUsuarios()
        {

            OracleDataAdapter objAdapter = new OracleDataAdapter();
            DataSet datos = new DataSet();

            OracleCommand objSelectCmd = new OracleCommand();
            objSelectCmd.Connection = p.abrirConexion();
            objSelectCmd.CommandText = "GESTIONARUSUARIOROL.mostrarUsuarios";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("cur_items", OracleDbType.RefCursor).
            Direction = ParameterDirection.Output;

            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(datos);
            p.cerrarConexion();
            return datos;
        }



        public bool insertarUusrio(string codigo, string usu_rol)
        {
            bool ejecuto = false;
            int filas = 0;

            OracleCommand objSelectCmd = new OracleCommand();
            objSelectCmd.Connection = p.abrirConexion();
            objSelectCmd.CommandText = "GESTIONARUSUARIOROL.insertarUsuarios";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("id_usuario", OracleDbType.Varchar2, 20).Value = codigo;
            objSelectCmd.Parameters.Add("usu_rol", OracleDbType.Varchar2, 20).Value = usu_rol;
            objSelectCmd.Parameters.Add("ejecuto", OracleDbType.Int16).
            Direction = ParameterDirection.Output;

            try
            {
                objSelectCmd.ExecuteNonQuery();
                filas = int.Parse(objSelectCmd.Parameters[2].Value.ToString());
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




        public bool eliminarUsuario(string codigo)
        {
            bool ejecuto = false;
            int filas = 0;
            OracleCommand objSelectCmd = new OracleCommand();
            objSelectCmd.Connection = p.abrirConexion();
            objSelectCmd.CommandText = "GESTIONARUSUARIOROL.eliminarUsuario";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("id_usuario", OracleDbType.Varchar2, 20).Value = codigo;
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



        public bool actualizarUsuario(string codigo, string usu_rol)
        {
            bool ejecuto = false;
            int filas = 0;

            OracleCommand objSelectCmd = new OracleCommand();
            objSelectCmd.Connection = p.abrirConexion();
            objSelectCmd.CommandText = "GESTIONARUSUARIOROL.actualizarUsuario";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("id_usuario", OracleDbType.Varchar2, 20).Value = codigo;
            objSelectCmd.Parameters.Add("usu_rol", OracleDbType.Varchar2, 20).Value = usu_rol;
            objSelectCmd.Parameters.Add("ejecuto", OracleDbType.Int16).
            Direction = ParameterDirection.Output;

            try
            {
                objSelectCmd.ExecuteNonQuery();
                filas = int.Parse(objSelectCmd.Parameters[2].Value.ToString());
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