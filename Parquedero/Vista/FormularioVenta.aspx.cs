using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Control;

namespace Vista
{
    public partial class FormularioVenta : System.Web.UI.Page
    {
        ControlVenta cv = new ControlVenta();
        bool ejecuto = false;

        string codigo, hora_entra, hora_sale, id_vehiculo;
        int precio,valor=1500,total=0,hora,minutos;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                mostrarVenta();
                cargarComboCategorias();
            }
        }

        protected void Btnagregar_Click(object sender, EventArgs e)
        {

            codigo = txtcodigo.Text;
            hora_entra = txtentrada.Text;
            hora_sale = txtsalida.Text;
            //precio = int.Parse(txtprecio.Text);
            id_vehiculo = ddlusuarios.SelectedItem.Value.ToString();

            total = valor * int.Parse(hora_sale);
            txtprecio.Text = total.ToString();

                ejecuto = cv.insertarVenta(codigo, hora_entra, hora_sale, total, id_vehiculo);


                if (ejecuto)
                {
                    txtcodigo.Text = "insertado";
                    mostrarVenta();
                    
                }
                else
                {
                    txtcodigo.Text = "NO insertado";

                }
            
        }

        public void cargarComboCategorias()
        {
            DataSet datos = new DataSet();
            datos = cv.mostrarVehiculos();
            ddlusuarios.DataSource = datos;
            ddlusuarios.DataValueField = "id_vehiculo";
            ddlusuarios.DataTextField = "V_placa";
            ddlusuarios.DataBind();

        }

        public void mostrarVenta()
        {

            DataSet datos = new DataSet();
            datos = cv.mostrarVentas();
            gruillaventas.DataSource = datos;
            gruillaventas.DataBind();
        }

        protected void Btneliminar_Click(object sender, EventArgs e)
        {
            codigo = txtcodigo.Text;
            ejecuto = cv.elimnarVenta(codigo);

            if (ejecuto)
            {
                txtcodigo.Text = "Eliminado Correctamente";
                mostrarVenta();
                
            }
            else
            {
                txtcodigo.Text = "Elemento no eliminado ";
                mostrarVenta();
               
            }
        }
    }
}