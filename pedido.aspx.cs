using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Data;

namespace parqueo
{
    public partial class WebForm3 : System.Web.UI.Page
    {

        Acc datos = new Acc();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                DataSet dsMaxPedido = datos.ObtenerMaxPedido();

                if (dsMaxPedido.Tables[0].Rows[0]["num"].ToString() != "")
                {
                    int idPed = int.Parse(dsMaxPedido.Tables[0].Rows[0]["num"].ToString()) - 1;
                    lblIdPedido.Text = idPed.ToString();
                    lblIdPedido.Visible = false;
                }

                // lblIdPedido.Text=
                CargarClientes();
                cargarPedidos();
                // lblIdUsuario.Text = Session["idUsuario"].ToString();
            }
        }


        public void CargarClientes()
        {

            try
            {

                DataSet dsDatos = datos.ObtenerClientes();
                if (dsDatos.Tables[0].Rows.Count > 0)
                {
                    listCliente.DataSource = dsDatos.Tables[0];
                    listCliente.DataTextField = "CLI_NOMBRE";
                    listCliente.DataValueField = "CLI_ID";
                    listCliente.DataBind();
                    this.listCliente.Items.Insert(0, "[Seleccione]");
                }

            }
            catch (Exception)
            {
                MsgBox("alert", "UPS, algo ha pasado por facor revise que los campos esten correctos");
            }

        }



        protected void cerrarSesion_Click(object sender, EventArgs e)
        {
            Response.Redirect("IncioSesion.aspx");
        }

        protected void addNuevo_Click(object sender, EventArgs e)
        {

            try
            {
                panelPedido.Visible = true;
                PanelMaterial.Visible = false;
                pnlProducto.Visible = false;
                btnProducto.Enabled = true;
                grdProductos.DataSource = "";
                grdProductos.DataBind();
                listCliente.SelectedIndex = -1;
                txtCedula.Text = "";
                txtFechaI.Text = "";
                txtFechaF.Text = "";
                grdProductos.Visible = false;

                DataSet dsMaxPedido = datos.ObtenerMaxPedido();
                if (dsMaxPedido.Tables[0].Rows[0]["num"].ToString() != "")
                {
                    lblIdPedido.Text = dsMaxPedido.Tables[0].Rows[0]["num"].ToString();
                }
                else
                {
                    lblIdPedido.Text = "1";
                }

                grdMaterial.DataSource = "";
                grdMaterial.DataBind();
                PanelGridMaterial.Visible = false;
                btnProducto.Text = "Producto";
                lblTitulo.Visible = true;

            }
            catch (Exception)
            {
                MsgBox("alert", "UPS, algo ha pasado por facor revise que los campos esten correctos");
            }
        }

        protected void btnProducto_Click(object sender, EventArgs e)
        {

            try
            {

                if (listCliente.SelectedItem.Text != "[Seleccione]")
                {
                    lblErrorCliente.Visible = false;

                    if (btnProducto.Text == "Actualizar")
                    {
                        datos.actualizarPedido(int.Parse(lblIdPedido.Text), txtFechaI.Text, txtFechaF.Text, int.Parse(listCliente.SelectedValue));
                        cargarPedidos();
                    }
                    else
                    {

                        if (txtFechaI.Text == "")
                        {
                            lblErrorFechaInicio.Visible = true;
                        }
                        else if (txtFechaI.Text != "")
                        {
                            lblErrorFechaInicio.Visible = false;
                        }

                        if (txtFechaF.Text == "")
                        {
                            lblErrorFechaFin.Visible = true;
                        }
                        else if (txtFechaF.Text != "")
                        {

                            DateTime fechaact = DateTime.Parse(DateTime.Now.ToShortDateString());
                            DateTime fechaI = DateTime.Parse(txtFechaI.Text.Substring(8, 2) + "-" + txtFechaI.Text.Substring(5, 2) + "-" + txtFechaI.Text.Substring(0, 4));
                            DateTime fechaF = DateTime.Parse(txtFechaF.Text.Substring(8, 2) + "-" + txtFechaF.Text.Substring(5, 2) + "-" + txtFechaF.Text.Substring(0, 4));
                            //if (fechaI >= fechaact)
                            if (fechaI >= fechaact && fechaF >= fechaI)
                            {

                                lblCompararFechaInicio.Visible = false;
                                pnlProducto.Visible = true;
                                btnProducto.Enabled = false;
                                datos.insertarPedido(int.Parse(lblIdPedido.Text), 1, txtFechaI.Text, txtFechaF.Text, int.Parse(listCliente.SelectedValue), int.Parse(Session["idUsuario"].ToString()));
                                cargarPedidos();
                                lblErrorCliente.Visible = false;
                                lblErrorFechaInicio.Visible = false;
                                lblErrorFechaFin.Visible = false;



                            }
                            else
                            {
                                lblCompararFechaInicio.Visible = true;
                            }



                        }

                    }


                }
                else
                {
                    lblErrorCliente.Visible = true;
                    //MsgBox("alert", "Seleccione un cliente");
                }

            }
            catch (Exception)
            {
                MsgBox("alert", "UPS, algo ha pasado por facor revise que los campos esten correctos");
            }

        }


        protected void seleccionarCliente(object sender, EventArgs e)
        {

            try
            {

                lblIdCLiente.Text = listCliente.SelectedValue.ToString();
                if (lblIdCLiente.Text != "[Seleccione]")
                {
                    DataSet dsClietneId = datos.ObtenerClienteId(Int32.Parse(lblIdCLiente.Text));
                    if (dsClietneId.Tables[0].Rows.Count > 0)
                    {
                        txtCedula.Text = dsClietneId.Tables[0].Rows[0]["cli_ruc"].ToString();
                    }
                }
                else
                {
                    txtCedula.Text = "";
                }

            }
            catch (Exception)
            {
                MsgBox("alert", "UPS, algo ha pasado por facor revise que los campos esten correctos");
            }
        }



        protected void MsgBox(string v_tipo_msg, string v_msg)
        {
            Response.Write("<script language='javascript'>");
            Response.Write(v_tipo_msg + "('" + v_msg + "')");
            Response.Write("</script>");
        }

        protected void btnAgregarPro_Click(object sender, EventArgs e)
        {

            try
            {

                if (txtNombreProducto.Text == "")
                {
                    lblErrorProducto.Visible = true;
                }
                else if (txtNombreProducto.Text != "")
                {
                    lblErrorProducto.Visible = false;
                }

                if (txtCantidadProducto.Text == "")
                {
                    lblErrorCantidadProducto.Visible = true;
                }
                else if (txtCantidadProducto.Text != "")
                {
                    lblErrorCantidadProducto.Visible = false;
                }

                if (txtPvpProducto.Text == "")
                {
                    lblErrorPvp.Visible = true;
                }
                else if (txtPvpProducto.Text != "")
                {
                    lblErrorPvp.Visible = false;


                    datos.insertarProducto(1, txtNombreProducto.Text, double.Parse(txtCantidadProducto.Text), double.Parse(txtPvpProducto.Text), int.Parse(lblIdPedido.Text));
                    txtCantidadProducto.Text = "";
                    txtNombreProducto.Text = "";
                    txtPvpProducto.Text = "";
                    cargarProductos();
                }
            }
            catch (Exception)
            {
                MsgBox("alert", "UPS, algo ha pasado por facor revise que los campos esten correctos");
            }
        }


        protected void cargarProductos()
        {
            try
            {
                DataSet dsProductos = datos.ObtenerProductos(int.Parse(lblIdPedido.Text));
                if (dsProductos.Tables[0].Rows.Count > 0)
                {
                    grdProductos.Visible = true;
                    grdProductos.DataSource = dsProductos.Tables[0];
                    grdProductos.DataBind();
                    pnlProducto.Visible = true;
                    //btnProducto.Enabled = false;
                }
                else
                {
                    grdProductos.Visible = false;
                    grdProductos.DataSource = "";
                    grdProductos.DataBind();
                }
            }
            catch (Exception)
            {
                MsgBox("alert", "UPS, algo ha pasado por facor revise que los campos esten correctos");
            }
        }

        protected void cargarMatProductoId()
        {
            //try
            //{
            //if (lblIdPedido.Text!="")
            //{
            DataSet dsMatProductoId = datos.ObtenerMatProductoId(int.Parse(lblIdPedido.Text));
            if (dsMatProductoId.Tables[0].Rows.Count > 0)
            {
                grdMaterial.Visible = true;
                grdMaterial.DataSource = dsMatProductoId.Tables[0];
                grdMaterial.DataBind();
                PanelMaterial.Visible = true;
            }
            else
            {
                grdMaterial.DataSource = "";
                grdMaterial.DataBind();
                PanelMaterial.Visible = false;
            }
            //}
            //else
            //{

            //}

            //}
            //catch (Exception)
            //{
            //    MsgBox("alert", "UPS, algo ha pasado por facor revise que los campos esten correctos");
            //}
        }

        protected void cargarPedidos()
        {
            try
            {
                DataSet dsPedidos = datos.ObtenerPedidos();
                if (dsPedidos.Tables[0].Rows.Count > 0)
                {

                    grdOrdenes.Visible = true;
                    grdOrdenes.DataSource = dsPedidos.Tables[0];
                    grdOrdenes.DataBind();

                }
                else
                {
                    grdOrdenes.DataSource = "";
                    grdOrdenes.DataBind();
                    grdOrdenes.Visible = false;
                }
            }
            catch (Exception)
            {
                MsgBox("alert", "UPS, algo ha pasado por facor revise que los campos esten correctos");
            }
        }

        public void CargarMateriales()
        {
            try
            {
                DataSet dsDatos = datos.ObtenerMaterial();
                if (dsDatos.Tables[0].Rows.Count > 0)
                {
                    listMaterial.DataSource = dsDatos.Tables[0];
                    listMaterial.DataTextField = "DETALLE";
                    listMaterial.DataValueField = "MAT_ID";
                    listMaterial.DataBind();
                    this.listMaterial.Items.Insert(0, "[Seleccione]");
                }
            }
            catch (Exception)
            {
                MsgBox("alert", "UPS, algo ha pasado por facor revise que los campos esten correctos");
            }
        }

        protected void grdProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarMateriales();
                PanelMaterial.Visible = true;
            }
            catch (Exception)
            {
                MsgBox("alert", "UPS, algo ha pasado por facor revise que los campos esten correctos");
            }
        }

        protected void btnAgMat_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblIdProducto.Text != "0")
                {
                    if (listMaterial.SelectedItem.Text != "[Seleccione]")
                    {
                        datos.insertarPedProMat(int.Parse(Session["IdProd"].ToString()), int.Parse(listMaterial.SelectedValue));
                        cargarMatProductoId();
                        lblErrorMaterial.Visible = false;
                        listMaterial.SelectedIndex = -1;
                        PanelGridMaterial.Visible = true;
                    }
                    else
                    {
                        lblErrorMaterial.Text = "Debe seleccionar un Material";
                        lblErrorMaterial.Visible = true;
                    }
                }
                else
                {
                    lblErrorMaterial.Text = "Debe seleccionar un Producto";
                    lblErrorMaterial.Visible = true;
                }
            }
            catch (Exception)
            {
                lblErrorMaterial.Text = "Debe seleccionar un Producto";
                lblErrorMaterial.Visible = true;
            }
        }

        protected void listMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdProductos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int IdProducto = int.Parse(((Label)grdProductos.Rows[e.NewSelectedIndex].FindControl("lblMaterialId")).Text);
            lblIdProducto.Text = IdProducto.ToString();
            Session["IdProd"] = IdProducto.ToString();
            lblErrorMaterial.Visible = false;
        }

        protected void grdOrdenes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdOrdenes_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                btnProducto.Text = "Actualizar";
                panelPedido.Visible = true;
                int idPedidos = int.Parse(((Label)grdOrdenes.Rows[e.NewSelectedIndex].FindControl("lblOrdenId")).Text);
                lblIdPedido.Text = idPedidos.ToString();

                lblIdPedidoAc.Text = idPedidos.ToString();
                DataSet dsPedidoId = datos.ObtenerPedidosId(idPedidos);

                if (dsPedidoId.Tables[0].Rows.Count > 0)
                {
                    //REVISAR LAS FECHAS PARA CARGAR
                    listCliente.SelectedValue = dsPedidoId.Tables[0].Rows[0]["cli_id"].ToString();
                    txtCedula.Text = dsPedidoId.Tables[0].Rows[0]["cli_ruc"].ToString();
                    DateTime dt5 = DateTime.Parse(dsPedidoId.Tables[0].Rows[0]["orp_fechaIngreso"].ToString());
                    txtFechaI.Text = dt5.ToString("yyyy-MM-dd");
                    DateTime dt6 = DateTime.Parse(dsPedidoId.Tables[0].Rows[0]["orp_fechaFinal"].ToString());
                    txtFechaF.Text = dt6.ToString("yyyy-MM-dd");
                }

                cargarProductos();
                this.listMaterial.Items.Insert(0, "[Seleccione]");
                this.listMaterial.SelectedIndex = -1;
                cargarMatProductoId();
                lblIdProducto.Text = "0";
            }
            catch (Exception)
            {

            }
        }

        protected void grdMaterial_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int IdMaterial = int.Parse(grdMaterial.DataKeys[e.RowIndex].Value.ToString());
                DataSet dsMatId = datos.eliminarMat(IdMaterial);
                cargarMatProductoId();
                grdProductos.SelectedIndex = -1;
                lblIdProducto.Text = "0";
            }
            catch (Exception)
            {

            }
        }

        protected void grdProductos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int IdPro = int.Parse(grdProductos.DataKeys[e.RowIndex].Value.ToString());
                DataSet dsMatProd = datos.eliminarMatProducto(IdPro);
                cargarMatProductoId();
                cargarProductos();

            }
            catch (Exception)
            {
                MsgBox("alert", "UPS, algo ha pasado por facor revise que los campos esten correctos");
            }
        }

        protected void grdOrdenes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            //try
            //{
            int IdProOrden = int.Parse(grdOrdenes.DataKeys[e.RowIndex].Value.ToString());
            DataSet dsMatProdOrden = datos.eliminarMatProductoOrden(IdProOrden);

            cargarMatProductoId();
            cargarProductos();
            cargarPedidos();

            pnlProducto.Visible = false;
            this.listCliente.SelectedIndex = -1;
            txtFechaI.Text = "";
            txtFechaF.Text = "";
            txtCedula.Text = "";
            lblIdPedido.Visible = false;
            panelPedido.Visible = false;
            grdOrdenes.SelectedIndex = -1;
            //}
            //catch (Exception)
            //{
            //    MsgBox("alert", "UPS, algo ha pasado por facor revise que los campos esten correctos");
            //}
        }


    }
}

