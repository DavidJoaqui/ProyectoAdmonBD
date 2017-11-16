using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo;
using System.Data;

namespace Control
{
    public class ControlVehiculo
    {

        Vehiculo v = new Vehiculo();

        public DataSet mostrarVehiculos() {

            return v.mostrarVehiculos();
        }

        public DataSet mostrartipoVehiculos()
        {

            return v.llenarComboTipoV();
        }


        public DataSet mostrarPersonas()
        {

            return v.llenarComboPersonas();
        }


        public bool insertarVehiculo(string codigo, string placa, string color, string id_persona, string id_tvehiculo) {

            return v.insertarVehiculos(codigo, placa, codigo, id_persona, id_tvehiculo);
        }

        public bool actuaizarVehiculo(string codigo, string placa, string color, string id_persona, string id_tvehiculo)
        {

            return v.actualizarVehiculo(codigo, placa, codigo, id_persona, id_tvehiculo);
        }

        public bool eliminarVehiculo(string codigo) {

            return v.eliminarVehiculo(codigo);
        }
        public DataSet buscarporId(string codigo) { 
        
            return v.
        }
    }
}