using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;
using System.Data;

namespace Modelo
{
    public class Vehiculo
    {
        Persistencia p = new Persistencia();



        public DataSet mostrarVehiculos()
        {

            OracleDataAdapter objAdapter = new OracleDataAdapter();
            DataSet datos = new DataSet();

            OracleCommand objSelectCmd = new OracleCommand();
            objSelectCmd.Connection = p.abrirConexion();
            objSelectCmd.CommandText = "GestionarVehiculo.mostrarVehiculos";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("cur_items", OracleDbType.RefCursor).
            Direction = ParameterDirection.Output;

            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(datos);
            p.cerrarConexion();
            return datos;
        }

        public DataSet llenarComboTipoV()
        {
            OracleDataAdapter objAdapter = new OracleDataAdapter();
            DataSet datos = new DataSet();
            OracleCommand objSelectCmd = new OracleCommand();
            objSelectCmd.Connection = p.abrirConexion();
            objSelectCmd.CommandText = "GestionarVehiculo.cargarDatosCombo";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("cursorUsuarios", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(datos);
            p.cerrarConexion();
            return datos;
        }

        public DataSet llenarComboPersonas()
        {
            OracleDataAdapter objAdapter = new OracleDataAdapter();
            DataSet datos = new DataSet();
            OracleCommand objSelectCmd = new OracleCommand();
            objSelectCmd.Connection = p.abrirConexion();
            objSelectCmd.CommandText = "GestionarVehiculo.cargarDatosComboPersona";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("cursorUsuarios", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(datos);
            p.cerrarConexion();
            return datos;
        }

        public bool insertarVehiculos(string codigo, string placa, string color, string id_persona, string id_tvehiculo)
        {
            bool ejecuto = false;
            int filas = 0;

            OracleCommand objSelectCmd = new OracleCommand();
            objSelectCmd.Connection = p.abrirConexion();
            objSelectCmd.CommandText = "GestionarVehiculo.insertarVehuculo";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("id_vehiculo", OracleDbType.Varchar2, 20).Value = codigo;
            objSelectCmd.Parameters.Add("v_placa", OracleDbType.Varchar2, 20).Value = placa;
            objSelectCmd.Parameters.Add("v_color", OracleDbType.Varchar2, 20).Value = color;
            objSelectCmd.Parameters.Add("id_persona", OracleDbType.Varchar2, 20).Value = id_persona;
            objSelectCmd.Parameters.Add("id_tvehiculo", OracleDbType.Varchar2, 20).Value = id_tvehiculo;
            objSelectCmd.Parameters.Add("ejecuto", OracleDbType.Int16).
            Direction = ParameterDirection.Output;

            try
            {
                objSelectCmd.ExecuteNonQuery();
                filas = int.Parse(objSelectCmd.Parameters[5].Value.ToString());
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



        public bool eliminarVehiculo(string codigo)
        {
            bool ejecuto = false;
            int filas = 0;
            OracleCommand objSelectCmd = new OracleCommand();
            objSelectCmd.Connection = p.abrirConexion();
            objSelectCmd.CommandText = "GestionarVehiculo.eliminarVehiculo";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("id_vehiculo", OracleDbType.Varchar2, 20).Value = codigo;
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



        public bool actualizarVehiculo(string codigo, string placa, string color, string id_persona, string id_tvehiculo)
        {
            bool ejecuto = false;
            int filas = 0;

            OracleCommand objSelectCmd = new OracleCommand();
            objSelectCmd.Connection = p.abrirConexion();
            objSelectCmd.CommandText = "GestionarVehiculo.actualizarVehiculo";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("id_vehiculo", OracleDbType.Varchar2, 20).Value = codigo;
            objSelectCmd.Parameters.Add("v_placa", OracleDbType.Varchar2, 20).Value = placa;
            objSelectCmd.Parameters.Add("v_color", OracleDbType.Varchar2, 20).Value = color;
            objSelectCmd.Parameters.Add("id_persona", OracleDbType.Varchar2, 20).Value = id_persona;
            objSelectCmd.Parameters.Add("id_tvehiculo", OracleDbType.Varchar2, 20).Value = id_tvehiculo;
            objSelectCmd.Parameters.Add("ejecuto", OracleDbType.Int16).
            Direction = ParameterDirection.Output;

            try
            {
                objSelectCmd.ExecuteNonQuery();
                filas = int.Parse(objSelectCmd.Parameters[5].Value.ToString());
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

        public DataSet buscarxId(string codigo) {

            OracleDataAdapter objSelectcmd = new OracleDataAdapter();
            DataSet datos = new DataSet();
            OracleCommand objSelectCmd = new OracleCommand();
            objSelectCmd.Connection = p.abrirConexion();
            objSelectCmd.CommandText = "GestionarVehiculo.buscarporId";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("cur_items", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            objSelectCmd.Parameters.Add("id_vehiculo", OracleDbType.Varchar2, 20).Value = codigo;
            objSelectcmd.SelectCommand = objSelectCmd;
            objSelectcmd.Fill(datos);
            p.cerrarConexion();
            return datos;
        }
    }
}