using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Control;
using System.Data;

namespace Vista
{
    public partial class FormularioVehiculo : System.Web.UI.Page
    {
        ControlVehiculo cv = new ControlVehiculo();

        string codigo, color, placa,id_persona,id_tvehiculo;
        bool ejecuto = false;
            

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack) {

                mostrarVehiculos();
                cargarComboPersona();
                cargarComboTipoVehiculo();
            }
        }

        public void mostrarVehiculos() {

            DataSet datos = new DataSet();
            datos = cv.mostrarVehiculos();
            gruillavehiculo.DataSource = datos;
            gruillavehiculo.DataBind();
        }

        public void cargarComboPersona() {

            DataSet datos = new DataSet();
            datos = cv.mostrarPersonas();
            ddlpersona.DataSource = datos;
            ddlpersona.DataValueField = "id_persona";
            ddlpersona.DataTextField = "cedula";
            ddlpersona.DataBind();
        }

        public void cargarComboTipoVehiculo() {

            DataSet datos = new DataSet();
            datos = cv.mostrartipoVehiculos();
            ddltipovehiculo.DataSource = datos;
            ddltipovehiculo.DataValueField = "id_tvehiculo";
            ddltipovehiculo.DataTextField = "tipo_vehiculo";
            ddltipovehiculo.DataBind();
        }       

        protected void Btnagregar_Click(object sender, EventArgs e)
        {
            codigo = txtcodigo.Text;
            placa = txtplaca.Text;
            color = txtcolor.Text;
            id_persona = ddlpersona.SelectedItem.Value.ToString();
            id_tvehiculo = ddltipovehiculo.SelectedItem.Value.ToString();
            ejecuto = cv.insertarVehiculo(codigo, placa, color, id_persona, id_tvehiculo);           


            if (ejecuto)
            {

                txtcodigo.Text = "Insertado Correctamente";
                mostrarVehiculos();
                limpiar();                
            }
            else {
                txtcodigo.Text = "Elemento no insertado";
                limpiar();
            }

        }

        public void limpiar() {

            txtcolor.Text = " ";
            txtplaca.Text = " ";
        
        }

        protected void Btnactualizar_Click(object sender, EventArgs e)
        {
            codigo = txtcodigo.Text;
            placa = txtplaca.Text;
            color = txtcolor.Text;
            id_persona = ddlpersona.SelectedItem.Value.ToString();
            id_tvehiculo = ddltipovehiculo.SelectedItem.Value.ToString();
            ejecuto = cv.actuaizarVehiculo(codigo, placa, color, id_persona, id_tvehiculo);
            if (ejecuto)
            {

                txtcodigo.Text = "Actualizado Correctamente";
                mostrarVehiculos();
                limpiar();
            }
            else {

                txtcodigo.Text = "Elemento no Actualizado";
                limpiar();
            }
        }

        protected void Btnbuscar_Click(object sender, EventArgs e)
        {
            string codigo = txtcodigo.Text;
            DataSet datos = new DataSet();
            datos = cv.buscarporId(codigo);
            txtplaca.Text = datos.Tables[0].Rows[0]["v_placa"].ToString();
            txtcolor.Text = datos.Tables[0].Rows[0]["v_color"].ToString();
            ddlpersona.DataSource = datos.Tables[0].Rows[0]["id_persona"].ToString();
            ddltipovehiculo.DataSource = datos.Tables[0].Rows[0]["id_tvehiculo"].ToString();
        }

        protected void Btneliminar_Click(object sender, EventArgs e)
        {
            codigo = txtcodigo.Text;
            ejecuto = cv.eliminarVehiculo(codigo);

            if (ejecuto)
            {

                txtcodigo.Text = "Eliminado Correctamente";
                mostrarVehiculos();
                limpiar();
            }
            else {

                txtcodigo.Text = "Elemento no Eliminado";
                limpiar();
            }
        }
    }
}