using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Modelo;


namespace Control
{
    public class ControlVenta
    {
        Venta venta = new Venta();


        public DataSet mostrarVentas() {


            return venta.mostrarVenta();
        }


        public DataSet mostrarVehiculos() {

            return venta.llenarComboVehiculos();
        }

        public bool insertarVenta(string codigo, string hora_e, string hora_ll, int precio, string id_vehiculo)
        {

            return venta.insertarVenta(codigo, hora_e, hora_ll, precio, id_vehiculo);
        }


        public bool elimnarVenta(string codigo) {

            return venta.eliminarVenta(codigo);
        }





    }
}