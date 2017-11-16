using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;
using System.Data;

namespace Modelo
{
    public class Venta
    {
        Persistencia p = new Persistencia();

        public DataSet mostrarVenta()
        {

            OracleDataAdapter objAdapter = new OracleDataAdapter();
            DataSet datos = new DataSet();

            OracleCommand objSelectCmd = new OracleCommand();
            objSelectCmd.Connection = p.abrirConexion();
            objSelectCmd.CommandText = "GESTIONARVENTAS.mostrarVentas";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("cur_items", OracleDbType.RefCursor).
            Direction = ParameterDirection.Output;

            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(datos);
            p.cerrarConexion();
            return datos;
        }


        public DataSet llenarComboVehiculos()
        {
            OracleDataAdapter objAdapter = new OracleDataAdapter();
            DataSet datos = new DataSet();
            OracleCommand objSelectCmd = new OracleCommand();
            objSelectCmd.Connection = p.abrirConexion();
            objSelectCmd.CommandText = "GESTIONARVENTAS.cargarDatosCombo";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("cursorVehiculos", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            objAdapter.SelectCommand = objSelectCmd;
            objAdapter.Fill(datos);
            p.cerrarConexion();
            return datos;
        }


        public bool insertarVenta(string codigo, string hora_entrada, string hora_salida, Int32 precio, string id_vehiculo)
        {
            bool ejecuto = false;
            int filas = 0;

            OracleCommand objSelectCmd = new OracleCommand();
            objSelectCmd.Connection = p.abrirConexion();
            objSelectCmd.CommandText = "GESTIONARVENTAS.insertarVenta";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("id_venta", OracleDbType.Varchar2, 20).Value = codigo;
            objSelectCmd.Parameters.Add("hora_entrada", OracleDbType.Varchar2, 20).Value = hora_entrada;
            objSelectCmd.Parameters.Add("hora_salida", OracleDbType.Varchar2, 20).Value = hora_salida;
            objSelectCmd.Parameters.Add("precio", OracleDbType.Int32, 20).Value = precio;
            objSelectCmd.Parameters.Add("id_vehiculo", OracleDbType.Varchar2, 20).Value = id_vehiculo;
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

        public bool actualizarVenta(string codigo, string hora_entrada, string hora_salida, Int32 precio, string id_vehiculo)
        {
            bool ejecuto = false;
            int filas = 0;

            OracleCommand objSelectCmd = new OracleCommand();
            objSelectCmd.Connection = p.abrirConexion();
            objSelectCmd.CommandText = "GESTIONARVENTAS.actualizarVenta";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("id_venta", OracleDbType.Varchar2, 20).Value = codigo;
            objSelectCmd.Parameters.Add("hora_entrada", OracleDbType.Varchar2, 20).Value = hora_entrada;
            objSelectCmd.Parameters.Add("hora_salida", OracleDbType.Varchar2, 20).Value = hora_salida;
            objSelectCmd.Parameters.Add("precio", OracleDbType.Int32, 20).Value = precio;
            objSelectCmd.Parameters.Add("id_vehiculo", OracleDbType.Varchar2, 20).Value = id_vehiculo;
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

        public bool eliminarVenta(string codigo)
        {
            bool ejecuto = false;
            int filas = 0;
            OracleCommand objSelectCmd = new OracleCommand();
            objSelectCmd.Connection = p.abrirConexion();
            objSelectCmd.CommandText = "GESTIONARVENTAS.eliminarVenta";
            objSelectCmd.CommandType = CommandType.StoredProcedure;
            objSelectCmd.Parameters.Add("id_venta", OracleDbType.Varchar2, 20).Value = codigo;
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




    }
}