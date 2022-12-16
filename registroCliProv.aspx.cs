using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace parqueo
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        int IdCliente;
        int IdProveedor;
        Acc datos = new Acc();
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarClientes();
            CargarProveedor();
        }

        protected void CargarClientes()
        {
            DataSet dsClientes = datos.ObtenerClientes();
            if (dsClientes.Tables[0].Rows.Count > 0)
            {
                grdClientes.DataSource = dsClientes.Tables[0];
                grdClientes.DataBind();
            }
            else
            {
                grdClientes.DataSource = "";
                grdClientes.DataBind();
            }
        }


        protected void CargarProveedor()
        {
            DataSet dsProveedor = datos.ObtenerProveedor();
            if (dsProveedor.Tables[0].Rows.Count > 0)
            {
                grdProveedor.DataSource = dsProveedor.Tables[0];
                grdProveedor.DataBind();
            }
            else
            {
                grdProveedor.DataSource = "";
                grdProveedor.DataBind();
            }
        }

        protected void cerrarSesion_Click(object sender, EventArgs e)
        {
            Response.Redirect("IncioSesion.aspx");
        }

        protected void btnRegistrarCliente_Click(object sender, EventArgs e)
        {
            if (btnRegistrarCliente.Text == "Actualizar")
            {
                //Pongo las instrucciones para Actualizar
                DataSet dsDatos = datos.actualizarCliente(Int32.Parse(lblIdCliente.Text), txtCliNombre.Text, txtCliCedula.Text, txtCliTelefono.Text, txtCliCorreo.Text);
               btnRegistrarCliente.Text = "Registar";

            }
            else
            {
                if (txtCliNombre.Text == "")
                {
                    lblErrorNombre.Visible = true;
                }
                if (txtCliCedula.Text == "")
                {
                    lblErrorRuc.Visible = true;
                }
                if (txtCliTelefono.Text == "")
                {
                    lblErorTelefono.Visible = true;
                }
                if (txtCliCorreo.Text == "")
                {
                    lblErrorCorreo.Visible = true;
                }
                else
                {
                    DataSet dsDatos = datos.registrarCliente(1, txtCliNombre.Text, txtCliCedula.Text, txtCliTelefono.Text, txtCliCorreo.Text);
                }
            }
            CargarClientes();
            txtCliNombre.Text = "";
            txtCliCedula.Text = "";
            txtCliTelefono.Text = "";
            txtCliCorreo.Text = "";


        }


        protected void cliente_Click(object sender, EventArgs e)
        {
            pnlClientes.Visible = true;
            panelCliente.Visible = true;
            panelProveedor.Visible = false;
            txtCliNombre.Text = "";
            txtCliCedula.Text = "";
            txtCliTelefono.Text = "";
            txtCliCorreo.Text = "";
            pnlProveedor.Visible = false;

            btnRegistrarCliente.Text = "Registrar";
        }

        protected void proveedor_Click(object sender, EventArgs e)
        {
            pnlProveedor.Visible = true;
            panelProveedor.Visible = true;
            panelCliente.Visible = false;

            txtProvNombre.Text = "";
            txtProvRuc.Text = "";
            txtProvRazonSocial.Text = "";
            pnlClientes.Visible = false;
            btnRegProveedor.Text = "Registrar";
        }

        protected void grdClientes_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                btnRegistrarCliente.Text = "Actualizar";
                IdCliente = int.Parse(((Label)grdClientes.Rows[e.NewSelectedIndex].FindControl("lblClienteId")).Text);
                lblIdCliente.Text = IdCliente.ToString();
                DataSet dsClienteId = datos.ObtenerClienteId(IdCliente);
                if (dsClienteId.Tables[0].Rows.Count > 0)
                {
                    txtCliNombre.Text = dsClienteId.Tables[0].Rows[0]["cli_nombre"].ToString();
                    txtCliCedula.Text = dsClienteId.Tables[0].Rows[0]["cli_ruc"].ToString();
                    txtCliTelefono.Text = dsClienteId.Tables[0].Rows[0]["cli_telefono"].ToString();
                    txtCliCorreo.Text = dsClienteId.Tables[0].Rows[0]["cli_correoElectronico"].ToString();
                }
            }
            catch (Exception)
            {

            }
        }

        protected void grdClientes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {

                int IdCliente = int.Parse(grdClientes.DataKeys[e.RowIndex].Value.ToString());
                DataSet dsClienteId = datos.EliminarCliente(IdCliente);
                CargarClientes();
            }
            catch (Exception )
            {

            }
        }

     




        protected void grdProveedor_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {

                int IdProveedor = int.Parse(grdProveedor.DataKeys[e.RowIndex].Value.ToString());
                DataSet dsProveedorId = datos.EliminarProveedor(IdProveedor);
                CargarProveedor();
            }
            catch (Exception)
            {

            }

        }

        protected void grdProveedor_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

            try
            {
                btnRegProveedor.Text = "Actualizar";
                IdProveedor = int.Parse(((Label)grdProveedor.Rows[e.NewSelectedIndex].FindControl("lblProveedorId")).Text);
                lblIdProveedor.Text = IdProveedor.ToString();
                DataSet dsProveedorId = datos.ObtenerProveedorId(IdProveedor);
                if (dsProveedorId.Tables[0].Rows.Count > 0)
                {
                    txtProvNombre.Text = dsProveedorId.Tables[0].Rows[0]["prov_nombre"].ToString();
                    txtProvRuc.Text = dsProveedorId.Tables[0].Rows[0]["prov_ruc"].ToString();
                    txtProvRazonSocial.Text = dsProveedorId.Tables[0].Rows[0]["prov_razonSocial"].ToString();
                }
            }
            catch (Exception )
            {

            }
        }

        protected void btnRegProveedor_Click(object sender, EventArgs e)
        {

            if (btnRegProveedor.Text == "Actualizar")
            {
                //Pongo las instrucciones para Actualizar
                DataSet dsProveedor = datos.actualizarProveedor(Int32.Parse(lblIdProveedor.Text),txtProvNombre.Text,txtProvRuc.Text,txtProvRazonSocial.Text);
                btnRegProveedor.Text = "Registar";

            }
            else
            {
                if (txtProvNombre.Text == "")
                {
                    lblErrorNombreProv.Visible = true;
                }
                if (txtProvRuc.Text == "")
                {
                    lblErrorRucProv.Visible = true;
                }
                if (txtProvRazonSocial.Text == "")
                {
                    lblErrorRazonSocial.Visible = true;
                }
                else
                {
                    DataSet dsDatos = datos.registrarProveedor(1, txtProvNombre.Text, txtProvRuc.Text, txtProvRazonSocial.Text);
                }
            }
            CargarProveedor();
            txtProvNombre.Text = "";
            txtProvRuc.Text = "";
            txtProvRazonSocial.Text = "";



        }

  
    }
}