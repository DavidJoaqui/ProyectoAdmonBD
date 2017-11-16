using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;
using System.Data;

namespace Modelo
{
    public class TipoVehiculo
    {

        Persistencia p = new Persistencia();


        public DataSet mostrarTipoVehiculo()
        {

            OracleDataAdapter objAdapter = new OracleDataAdapter();
            DataSet datos = new DataSet();

            OracleCommand objSelectCmd = new OracleCommand();
            objSelectCmd.Connection = p.abrirConexion();
            objSelectCmd.CommandText = "GESTIONARTIPOVEHICULO.mostrarTiposVehiculos";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("cur_items", OracleDbType.RefCursor).
            Direction = ParameterDirection.Output;

            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(datos);
            p.cerrarConexion();
            return datos;
        }

        public bool insertartipoV(string codigo, string tipovehiculo)
        {
            bool ejecuto = false;
            int filas = 0;

            OracleCommand objSelectCmd = new OracleCommand();
            objSelectCmd.Connection = p.abrirConexion();
            objSelectCmd.CommandText = "GESTIONARTIPOVEHICULO.insertarTipoVehiculo";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("id_tvehhiculo", OracleDbType.Varchar2, 20).Value = codigo;
            objSelectCmd.Parameters.Add("tipo_vehiculo", OracleDbType.Varchar2, 20).Value = tipovehiculo;
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


        public bool eliminarTipoVehiculo(string codigo)
        {
            bool ejecuto = false;
            int filas = 0;
            OracleCommand objSelectCmd = new OracleCommand();
            objSelectCmd.Connection = p.abrirConexion();
            objSelectCmd.CommandText = "GESTIONARTIPOVEHICULO.eliminarTipoVehiculo";
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
                e.Message.ToString();
            }
            p.cerrarConexion();
            return ejecuto;

        }

        public bool actualizarTipoV(string codigo, string tipovehiculo)
        {
            bool ejecuto = false;
            int filas = 0;

            OracleCommand objSelectCmd = new OracleCommand();
            objSelectCmd.Connection = p.abrirConexion();
            objSelectCmd.CommandText = "GESTIONARTIPOVEHICULO.actualizarTipoVehiculo";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("id_tvehhiculo", OracleDbType.Varchar2, 20).Value = codigo;
            objSelectCmd.Parameters.Add("tipo_vehiculo", OracleDbType.Varchar2, 20).Value = tipovehiculo;
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