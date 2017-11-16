using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo;
using System.Data;

namespace Control
{
    public class ControlTipoV
    {
        TipoVehiculo tipo = new TipoVehiculo();

        public DataSet mostrarTiposV()
        {

            return tipo.mostrarTipoVehiculo();
        }

        public bool insertarTiposV(string codigo, string tipovehiculo)
        {

            return tipo.insertartipoV(codigo, tipovehiculo);
        }

        public bool actualizarTipoV(string codigo, string tipovehiculo)
        {

            return tipo.actualizarTipoV(codigo, tipovehiculo);
        }
        public bool eliminarTipoV(string codigo)
        {

            return tipo.eliminarTipoVehiculo(codigo);
        }

    }
}