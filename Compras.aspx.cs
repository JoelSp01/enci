using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace parqueo
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        Acc datos = new Acc();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                CargarClasificaciones();
                CargarProveedor();
                CargarIva();
                CargarMaterial();
            }
        }

        protected void cerrarSesion_Click(object sender, EventArgs e)
        {
            Response.Redirect("IncioSesion.aspx");
        }

        public void CargarClasificaciones()
        {
            DataSet dsDatos = datos.ItemsCatalogo("CLASMAT");
            if (dsDatos.Tables[0].Rows.Count > 0)
            {
                listClasificacion.DataSource = dsDatos.Tables[0];
                listClasificacion.DataTextField = "ITC_CODIGO";
                listClasificacion.DataValueField = "ITC_ID";
                listClasificacion.DataBind();
                this.listClasificacion.Items.Insert(0, "[Seleccione]");
            }
        }

        public void CargarProveedor()
        {
            DataSet dsDatos = datos.ObtenerProveedor();
            if (dsDatos.Tables[0].Rows.Count > 0)
            {
                listProveedor.DataSource = dsDatos.Tables[0];
                listProveedor.DataTextField = "PROV_NOMBRE";
                listProveedor.DataValueField = "PROV_ID";
                listProveedor.DataBind();
                this.listProveedor.Items.Insert(0, "[Seleccione]");
            }
         
        }

        public void CargarIva()
        {
            DataSet dsDatos = datos.ItemsCatalogo("IVA");
            if (dsDatos.Tables[0].Rows.Count > 0)
            {
                listIva.DataSource = dsDatos.Tables[0];
                listIva.DataTextField = "ITC_CODIGO";
                listIva.DataValueField = "ITC_ID";
                listIva.DataBind();
                this.listIva.Items.Insert(0, "[Seleccione]");
            }
        }

        protected void listProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblIdProveedor.Text = listProveedor.SelectedValue.ToString();
            if (lblIdProveedor.Text!= "[Seleccione]")
            {
                DataSet dsProveedorId = datos.ObtenerProveedorId(Int32.Parse(lblIdProveedor.Text));
                if (dsProveedorId.Tables[0].Rows.Count > 0)
                {
                    txtRuc.Text = dsProveedorId.Tables[0].Rows[0]["prov_ruc"].ToString();
                }
            }
            else
            {
                txtRuc.Text = "";
            }
          
        }

        protected void addNuevo_Click(object sender, EventArgs e)
        {
            panelCompra.Visible = true;
            panelGridMat.Visible = true;

            btnIngresarMaterial.Text = "Confirmar";
            listProveedor.SelectedIndex = -1;
            txtRuc.Text = "";
            txtAut.Text = "";
            txtDetalle.Text = "";
            listClasificacion.SelectedIndex = -1;
            txtCantidad.Text = "0";
            txtCostoUnidad.Text = "0";
            txtSubtotal.Text = "";
            listIva.SelectedIndex = -1;
            txtTotal.Text = "";

        }

        protected void calcularSubTotal(object sender, EventArgs e)
        {
            if (listIva.SelectedValue != "[Seleccione]")
            {      
            Double cantidad = Double.Parse(txtCantidad.Text);
            Double costoUnitario = Double.Parse(txtCostoUnidad.Text);
            Double subtotal= cantidad * costoUnitario;
            Double total = (subtotal * Double.Parse(listIva.SelectedItem.Text)) + subtotal;
            
            txtSubtotal.Text = subtotal.ToString();
            txtTotal.Text = total.ToString();
            }
            else
            {
                Double cantidad = Double.Parse(txtCantidad.Text);
                Double costoUnitario = Double.Parse(txtCostoUnidad.Text);
                Double subtotal = cantidad * costoUnitario;
                Double total = (subtotal * 0) + subtotal;

                txtSubtotal.Text = subtotal.ToString();
                txtTotal.Text = total.ToString();

            }




        }

        protected void listClasificacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblIdClasificacion.Text= listClasificacion.SelectedValue.ToString();
        }

        protected void btnIngresarMaterial_Click(object sender, EventArgs e)
        {
            /* if (listProveedor.SelectedValue == "[Seleccione]" && txtRuc.Text == "" && txtAut.Text == "" && txtDetalle.Text == ""
                 && listClasificacion.SelectedValue == "[Seleccione]" && txtCantidad.Text == "" && txtCostoUnidad.Text == "" && txtSubtotal.Text == ""
                 && listIva.SelectedValue == "[Seleccione]" && txtTotal.Text == "")
             {
                 MsgBox("alert", "Complete los campos establecidos");
             }
             else
             { */
            try
            {
                if (btnIngresarMaterial.Text == "Actualizar")
                {
                    DataSet dsDatos = datos.actualizarMateriales(Int32.Parse(listProveedor.SelectedValue), Int32.Parse(listClasificacion.SelectedValue), txtDetalle.Text, txtAut.Text, Double.Parse(txtCantidad.Text),
                    Double.Parse(txtCostoUnidad.Text), Double.Parse(txtSubtotal.Text), Double.Parse(txtTotal.Text), int.Parse(listIva.SelectedValue), int.Parse(lblIdMaterial.Text));
                    CargarMaterial();

                }
                else
                {
                    DataSet dsDatos = datos.registrarMateriales(Int32.Parse(lblIdProveedor.Text), Int32.Parse(lblIdClasificacion.Text), txtDetalle.Text, txtAut.Text, Double.Parse(txtCantidad.Text), Double.Parse(txtCostoUnidad.Text), Double.Parse(txtSubtotal.Text), Double.Parse(txtTotal.Text), 1, int.Parse(listIva.SelectedValue));
                    CargarMaterial();
                }

            }
            catch (Exception )
            {
                MsgBox("alert", "Complete los campos establecidos");
            }
               

            }
            
         
        
        protected void MsgBox(string v_tipo_msg, string v_msg)
        {
            Response.Write("<script language='javascript'>");
            Response.Write(v_tipo_msg + "('" + v_msg + "')");
            Response.Write("</script>");
        }

        protected void listIva_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblIdIva.Text = listIva.SelectedValue.ToString();


            DataSet dsIva = datos.SacarCodigoIva(Int32.Parse(lblIdIva.Text));
            Double dblIva = Double.Parse(dsIva.Tables[0].Rows[0]["itc_codigo"].ToString());
            Double total = (Double.Parse(txtSubtotal.Text) * dblIva) + Double.Parse(txtSubtotal.Text);
            txtTotal.Text = total.ToString();
        }

        
        protected void CargarMaterial()
        {
            DataSet dsMat = datos.ObtenerMaterial();
            if (dsMat.Tables[0].Rows.Count > 0)
            {
                grdMateriales.DataSource = dsMat.Tables[0];
                grdMateriales.DataBind();
            }
            else
            {
                grdMateriales.DataSource = "";
                grdMateriales.DataBind();
            }

        }

        protected void grdMateriales_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {

                int IdMaterial = int.Parse(grdMateriales.DataKeys[e.RowIndex].Value.ToString());
                DataSet dsMatId = datos.EliminarMaterial(IdMaterial);
                CargarMaterial();

            }
            catch(Exception )
            {

            }
        }

        protected void grdMateriales_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                btnIngresarMaterial.Text = "Actualizar";
                int IdMaterial = int.Parse(((Label)grdMateriales.Rows[e.NewSelectedIndex].FindControl("lblMaterialId")).Text);
                lblIdMaterial.Text = IdMaterial.ToString();
                DataSet dsMaterialId = datos.ObtenerMaterialId(IdMaterial);

                if (dsMaterialId.Tables[0].Rows.Count > 0)
                {
                    listProveedor.SelectedValue = dsMaterialId.Tables[0].Rows[0]["prov_id"].ToString();
                    txtRuc.Text = dsMaterialId.Tables[0].Rows[0]["ruc"].ToString();
                    txtAut.Text= dsMaterialId.Tables[0].Rows[0]["autorizacion"].ToString();
                    txtDetalle.Text= dsMaterialId.Tables[0].Rows[0]["detalle"].ToString();
                    listClasificacion.SelectedValue = dsMaterialId.Tables[0].Rows[0]["cla_id"].ToString();
                    txtCantidad.Text= dsMaterialId.Tables[0].Rows[0]["cantidad"].ToString();
                    txtCostoUnidad.Text= dsMaterialId.Tables[0].Rows[0]["costo_unitario"].ToString();
                    txtSubtotal.Text = dsMaterialId.Tables[0].Rows[0]["costo_total"].ToString();
                    listIva.SelectedValue = dsMaterialId.Tables[0].Rows[0]["iva_id"].ToString();
                    txtTotal.Text= dsMaterialId.Tables[0].Rows[0]["total"].ToString();
                }



            }
            catch (Exception )
            {

            }
            
        }

        
    }
}