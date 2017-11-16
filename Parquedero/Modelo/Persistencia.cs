using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;
using System.Configuration;
using System.Data;

namespace Modelo
{
    public class Persistencia
    {
        //Aqui se hace todo lo que es la ejecucion de las consultas y conexion con la BD
        OracleConnection cadena = new OracleConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ConnectionString);


        public bool ejecutarDML(string sql)
        {
            bool ejecuto = false;
            cadena.Open();
            OracleCommand comando = new OracleCommand(sql, cadena);
            if (comando.ExecuteNonQuery() > 0)
            {
                ejecuto = true;

            }
            cadena.Close();
            return ejecuto;
        }


        public DataSet ejecutarConsulta(string sql)
        {

            DataSet datos = new DataSet();
            cadena.Open();
            OracleDataAdapter adaptador = new OracleDataAdapter(sql, cadena);
            adaptador.Fill(datos);
            cadena.Close();
            return datos;
        }


        public OracleConnection abrirConexion()
        {
            try
            {
                cadena.Open();
                return cadena;
            }
            catch (Exception e)
            {
                return null;
            }

        }


        public void cerrarConexion()
        {

            cadena.Close();
        }
    }
}