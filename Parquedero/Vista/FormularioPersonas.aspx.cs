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
    public partial class WebForm1 : System.Web.UI.Page
    {

        ControlPersona cp = new ControlPersona();

        string codigo, nombres, apellidos, cedula, telefono, cod_usu;
        bool ejecuto = false;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
            mostrarPersonas();
            cargarComboCategorias();
            }
        }

        protected void Btnagregar_Click(object sender, EventArgs e)
        {
            codigo = txtcodigo.Text;
            nombres = txtnombres.Text;
            apellidos = txtapellidos.Text;
            cedula = txtcedula.Text;
            telefono = txTelefono.Text;
            cod_usu = ddlusuarios.SelectedItem.Value.ToString();
            ejecuto = cp.insertarPersonas(codigo, nombres, apellidos, cedula, telefono, cod_usu);


            if (ejecuto)
            {
                txtcodigo.Text = "Insertado Correctamente";
                mostrarPersonas();
                limpiar();
            }
            else
            {
                txtcodigo.Text = "Elemento no insertado ";
                limpiar();
            }


        }

        public void cargarComboCategorias()
        {
            DataSet datos = new DataSet();
            datos = cp.mostrarUusarios();
            ddlusuarios.DataSource = datos;
            ddlusuarios.DataValueField = "id_usuario";
            ddlusuarios.DataTextField = "usu_rol";
            ddlusuarios.DataBind();

        }

        public void mostrarPersonas()
        {

            DataSet datos = new DataSet();
            datos = cp.mostrarPersonas();
            gruillapersonas.DataSource = datos;
            gruillapersonas.DataBind();
        }

        public void limpiar()
        {

            txtnombres.Text = " ";
            txtapellidos.Text = " ";
            txtcedula.Text = " ";
            txTelefono.Text = " ";
        }

        protected void Btneliminar_Click(object sender, EventArgs e)
        {
            codigo = txtcodigo.Text;
            ejecuto = cp.eliminarPersona(codigo);

            if (ejecuto)
            {
                txtcodigo.Text = "Eliminado Correctamente";
                mostrarPersonas();
                limpiar();
            }
            else
            {
                txtcodigo.Text = "Elemento no eliminado ";
                limpiar();
            }


        }

        protected void Btnactualizar_Click(object sender, EventArgs e)
        {
            codigo = txtcodigo.Text;
            nombres = txtnombres.Text;
            apellidos = txtapellidos.Text;
            cedula = txtcedula.Text;
            telefono = txTelefono.Text;
            cod_usu = ddlusuarios.SelectedItem.Value.ToString();
            ejecuto = cp.actualizarPersonas(codigo, nombres, apellidos, cedula, telefono, cod_usu);
            if (ejecuto)
            {
                txtcodigo.Text = "Actualizado Correctamente";
                mostrarPersonas();
                limpiar();

            }
            else
            {
                txtcodigo.Text = "Elemento no Actualizado ";
                limpiar();
            }

        }

        protected void Btnbuscar_Click(object sender, EventArgs e)
        {
            string codigo = txtcodigo.Text;
            DataSet datos = new DataSet();
            datos = cp.buscarxid(codigo);
            txtnombres.Text = datos.Tables[0].Rows[0]["nombres"].ToString();
            txtapellidos.Text = datos.Tables[0].Rows[0]["apellidos"].ToString();
            txtcedula.Text = datos.Tables[0].Rows[0]["cedula"].ToString();
            txTelefono.Text = datos.Tables[0].Rows[0]["telefono"].ToString();
                       
            ddlusuarios.DataSource = datos.Tables[0].Rows[0]["id_usuario"].ToString();
            
        }

        protected void txtcodigo_TextChanged(object sender, EventArgs e)
        {

        }

        protected void gruillapersonas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}