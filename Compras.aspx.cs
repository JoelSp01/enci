using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using MySqlX.XDevAPI.Relational;

namespace parqueo
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        Acc datos = new Acc();
        Double costoU, total;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                CargarClasificaciones();
                CargarProveedor();
                CargarIva();
                cargarCompras();
            }
        }

        protected void cerrarSesion_Click(object sender, EventArgs e)
        {
            Response.Redirect("IncioSesion.aspx");
        }

        public void CargarClasificaciones()
        {
            try
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
            catch (Exception)
            {
                MsgBox("alert", "UPS");
            }
        }

        public void CargarProveedor()
        {
            try
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
            catch (Exception)
            {
                MsgBox("alert", "algo ");
            }

        }

        public void CargarIva()
        {
            try
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
            catch (Exception)
            {
                MsgBox("alert", " ha pasado ");
            }
        }

        protected void listProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {

                lblIdProveedor.Text = listProveedor.SelectedValue.ToString();
                if (lblIdProveedor.Text != "[Seleccione]")
                {
                    DataSet dsProveedorId = datos.ObtenerProveedorId(Int32.Parse(lblIdProveedor.Text));
                    DataSet dsMatId = datos.obtenerMaterialRegistradoProveedor(Int32.Parse(lblIdProveedor.Text));

                    if (dsProveedorId.Tables[0].Rows.Count > 0)
                    {
                        txtRuc.Text = dsProveedorId.Tables[0].Rows[0]["prov_ruc"].ToString();
                    }
                    if (dsMatId.Tables[0].Rows.Count>0)
                    {
                        listMaterial.DataSource = dsMatId.Tables[0];
                        listMaterial.DataTextField = "mat_detalle";
                        listMaterial.DataValueField = "mat_id";
                        listMaterial.DataBind();
                        this.listMaterial.Items.Insert(0, "[Seleccione]");

                    }
                }
                else
                {
                    txtRuc.Text = "";
                }

            }
            catch (Exception)
            {
                MsgBox("alert", " por facor ");
            }

        }

        protected void addNuevo_Click(object sender, EventArgs e)
        {
            try
            {

                panelCompra.Visible = true;
                panelGridMat.Visible = true;

                btnIngresarMaterial.Text = "Confirmar";
                listProveedor.SelectedIndex = -1;
                txtRuc.Text = "";
                txtAut.Text = "";
                listClasificacion.SelectedIndex = -1;
                txtCantidad.Text = "0";
                txtCostoUnidad.Text = "0";
                //txtSubtotal.Text = "";
                listIva.SelectedIndex = -1;
                txtTotal.Text = "";


                lblErrorProveedor.Visible = false;
                lblErrorAutori.Visible = false;
                lblErrorDetalle.Visible = false;
                lblErrorCaracteristica.Visible = false;
                lblErrorCantidad.Visible = false;
                lblErrorCostoU.Visible = false;
                lblErrorIva.Visible = false;

            }
            catch (Exception)
            {
                MsgBox("alert", " revise ");
            }

        }

        protected void calcularSubTotal(object sender, EventArgs e)
        {
            try
            {

                if (verificarNumero(txtCantidad.Text) == true && verificarNumero(txtCostoUnidad.Text) == true)
                {

                    if (double.Parse(txtCantidad.Text) >= 0)
                    {
                        lblErrorCantidad.Visible = false;
                    }

                    if (double.Parse(txtCostoUnidad.Text) >= 0)
                    {
                        lblErrorCostoU.Visible = false;
                    }

                    if (listIva.SelectedValue != "[Seleccione]")
                    {
                        Double cantidad = Double.Parse(txtCantidad.Text);
                        Double costoUnitario = Double.Parse(txtCostoUnidad.Text);
                        Double subtotal = cantidad * costoUnitario;
                        Double total = (subtotal * Double.Parse(listIva.SelectedItem.Text)) + subtotal;

                        //txtSubtotal.Text = subtotal.ToString();
                        txtTotal.Text = total.ToString();


                    }
                    else
                    {
                        lblErrorCantidad.Visible = false;
                        lblErrorCostoU.Visible = false;

                        Double cantidad = Double.Parse(txtCantidad.Text);
                        Double costoUnitario = Double.Parse(txtCostoUnidad.Text);
                        Double subtotal = cantidad * costoUnitario;
                        Double total = (subtotal * 0) + subtotal;

                        //txtSubtotal.Text = subtotal.ToString();
                        txtTotal.Text = total.ToString();

                    }
                }
                else
                {


                    if (verificarNumero(txtCantidad.Text) == false)
                    {
                        lblErrorCantidad.Visible = true;
                        txtCantidad.Text = "0";
                    }


                    if (verificarNumero(txtCostoUnidad.Text) == false)
                    {
                        lblErrorCostoU.Visible = true;
                        txtCostoUnidad.Text = "0";
                    }

                }


            }
            catch (Exception)
            {
                MsgBox("alert", "UPS, algo ha pasado por facor revise que los campos esten correctos");
            }



        }


        public bool verificarNumero(String numComprobar)
        {
            Regex r = new Regex(@"\d+$");
            if (r.IsMatch(numComprobar))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        protected void listClasificacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblIdClasificacion.Text = listClasificacion.SelectedValue.ToString();
        }

        protected void btnIngresarMaterial_Click(object sender, EventArgs e)
        {
            try
            {
                double cantidad, precioU, cantidadE, precioTE, precioUE;
                string cant, precU;
                if (listProveedor.SelectedValue == "[Seleccione]")
                {
                    lblErrorProveedor.Visible = true;
                }
                else if (listProveedor.SelectedValue != "[Seleccione]")
                {
                    lblErrorProveedor.Visible = false;
                }

                if (txtAut.Text == "")
                {
                    lblErrorAutori.Visible = true;
                }
                else if (txtAut.Text != "")
                {
                    lblErrorAutori.Visible = false;
                }
                if (listClasificacion.SelectedValue == "[Seleccione]")
                {
                    lblErrorCaracteristica.Visible = true;
                }
                else if (listClasificacion.SelectedValue != "[Seleccione]")
                {
                    lblErrorCaracteristica.Visible = false;
                }

                if (listIva.SelectedValue == "[Seleccione]")
                {
                    lblErrorIva.Visible = true;
                }
                else if (listIva.SelectedValue != "[Seleccione]")
                {
                    lblErrorIva.Visible = false;
                }


                double calculoIva;
                if (listIva.SelectedItem.Text == "0")
                {
                    calculoIva = double.Parse(txtCostoUnidad.Text);
                }
                else
                {
                    calculoIva = Math.Round((double.Parse(listIva.SelectedItem.Text) * double.Parse(txtCostoUnidad.Text)) + double.Parse(txtCostoUnidad.Text), 4);
                }


                lblIdProveedor.Text = listProveedor.SelectedValue.ToString();
                lblIdMaterial.Text = listMaterial.SelectedValue.ToString();
                lblIdClasificacion.Text = listClasificacion.SelectedValue.ToString();
                lblIdIva.Text = listIva.SelectedItem.ToString();
                //INSERCION A COMPRAS
                datos.insertarCompras(Int32.Parse(lblIdProveedor.Text), Int32.Parse(lblIdClasificacion.Text),
                Int32.Parse(lblIdClasificacion.Text), txtFechaEntrada.Text, double.Parse(txtCantidad.Text), double.Parse(txtCostoUnidad.Text), double.Parse(lblIdIva.Text),
                double.Parse(txtSubtotal.Text), double.Parse(txtTotal.Text), Int32.Parse(txtAut.Text));
                cargarCompras();



                //INSERCION AL KARDEX
                DataSet dsVerificar = datos.VerificarMaterial(Int32.Parse(listMaterial.SelectedValue), int.Parse(listProveedor.SelectedValue));
                if (int.Parse(dsVerificar.Tables[0].Rows[0]["KDX_ID"].ToString()) > 0)
                {
                    DataSet dsCantidad = datos.CantidadMaterial(Int32.Parse(listMaterial.SelectedValue), int.Parse(listProveedor.SelectedValue));
                    DataSet dsPrecioUNitario = datos.PrecioUnitarioMaterial(Int32.Parse(listMaterial.SelectedValue), int.Parse(listProveedor.SelectedValue));
                    cantidadE = double.Parse(dsCantidad.Tables[0].Rows[0]["Cantidad"].ToString());
                    precioTE = double.Parse(dsPrecioUNitario.Tables[0].Rows[0]["Total"].ToString());
                    cantidad = double.Parse(txtCantidad.Text);
                    precioU = double.Parse(txtCostoUnidad.Text);
                    precioUE = ((cantidad * precioU) + precioTE) / (cantidad + cantidadE);
                    datos.InsertarKardex(Int32.Parse(listMaterial.SelectedValue), -1, Int32.Parse(lblIdProveedor.Text), txtFechaEntrada.Text, cantidad, precioU, cantidad+cantidadE, Math.Round(precioUE, 4));

                }
                else
                {
                    cant = txtCantidad.Text;
                    precU = txtCostoUnidad.Text;
                    cantidad = double.Parse(txtCantidad.Text);
                    precioU = double.Parse(txtCostoUnidad.Text);
                    datos.InsertarKardex(Int32.Parse(listMaterial.SelectedValue), -1, Int32.Parse(lblIdProveedor.Text), txtFechaEntrada.Text, cantidad, precioU, cantidad, precioU);
                    //double.Parse(cant.Replace('.', ','))
                    //double.Parse(precU.Replace('.', ','))

                }
                
               
                //datos.insertarKardex(Int32.Parse(lblIdMaterial.Text), -1, Int32.Parse(lblIdProveedor.Text), txtFechaEntrada.Text, Int32.Parse(txtCantidad.Text), double.Parse(txtCostoUnidad.Text), 1);


                //if (listProveedor.SelectedValue != "[Seleccione]" && txtAut.Text != "" && txtDetalle.Text != "" && listClasificacion.SelectedValue != "[Seleccione]" && txtSubtotal.Text != "" && txtTotal.Text != "" && listIva.SelectedValue != "[Seleccione]")
                //{

                //    if (btnIngresarMaterial.Text == "Actualizar")
                //    {
                //        DataSet dsDatos = datos.actualizarMateriales(Int32.Parse(listProveedor.SelectedValue), Int32.Parse(listClasificacion.SelectedValue), txtDetalle.Text, txtAut.Text, Double.Parse(txtCantidad.Text),
                //        Double.Parse(txtCostoUnidad.Text), Double.Parse(txtSubtotal.Text), Double.Parse(txtTotal.Text), int.Parse(listIva.SelectedValue), int.Parse(lblIdMaterial.Text));
                //        CargarMaterial();

                //    }
                //    else
                //    {
                //        DateTime fechaact = DateTime.Parse(DateTime.Now.ToShortDateString());
                //        fechaact.ToString("yyyy-MM-dd");
                //        string[] fechac = fechaact.ToString().Split('/');
                //        string fecha = fechac[2].Substring(0, 4) + "-" + fechac[1] + "-" + fechac[0];
                //        // lblFechaExp.Text = fechaact.ToString("yyyy-MM-dd");



                //        //DataSet dsDatos = datos.registrarMateriales(Int32.Parse(lblIdProveedor.Text), Int32.Parse(lblIdClasificacion.Text), txtDetalle.Text, txtAut.Text, 
                //        //Double.Parse(txtCantidad.Text), Double.Parse(txtCostoUnidad.Text), Double.Parse(txtSubtotal.Text), Double.Parse(txtTotal.Text), 1, int.Parse(listIva.SelectedValue), fecha);
                //        CargarMaterial();
                //    }


                //}

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

        protected void listIva_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblIdIva.Text = listIva.SelectedValue.ToString();
                lblErrorIva.Visible = false;
                costoU = Double.Parse(txtCostoUnidad.Text);
                
                if (txtCostoUnidad.Text != "")
                {
                    if (double.Parse(listIva.SelectedItem.Text)  != 0)
                    {
                        DataSet dsIva = datos.SacarCodigoIva(Int32.Parse(lblIdIva.Text));
                        Double dblIva = Double.Parse(dsIva.Tables[0].Rows[0]["itc_codigo"].ToString());
                        total = ((costoU * dblIva) / 100) + costoU;
                        txtSubtotal.Text = total.ToString();
                        Double totalC = total * (Double.Parse(txtCantidad.Text));
                        txtTotal.Text = totalC.ToString();
                    }
                    else
                    {
                        total = costoU;
                        txtSubtotal.Text = total.ToString();
                        Double totalC = total * (Double.Parse(txtCantidad.Text));
                        txtTotal.Text = totalC.ToString();
                    }

                }
                //else if (dblIva == 0)
                //{
                //    Double imprimir = costoU * (Double.Parse((txtCantidad.Text)));
                //    txtTotal.Text= imprimir.ToString();
                //}
            }
            catch (Exception)
            {
                MsgBox("alert", "UPS, algo ha pasado por facor revise que los campos esten correctos");
            }
        }


        protected void cargarCompras()
        {
            try
            {

                DataSet dsMat = datos.ObtenerCompras();
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
            catch (Exception)
            {
                MsgBox("alert", "UPS, algo ha pasado por facor revise que los campos esten correctos");
            }
        }

        protected void grdMateriales_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {

                int IdCompras = int.Parse(grdMateriales.DataKeys[e.RowIndex].Value.ToString());
                DataSet dsMaterialRId = datos.eliminarCompras(IdCompras);
                cargarCompras();
            }
            catch (Exception)
            {

            }
        }

        protected void grdMateriales_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            //try
            //{
            //    btnIngresarMaterial.Text = "Actualizar";
            //    int IdMaterial = int.Parse(((Label)grdMateriales.Rows[e.NewSelectedIndex].FindControl("lblMaterialId")).Text);
            //    lblIdMaterial.Text = IdMaterial.ToString();
            //    DataSet dsMaterialId = datos.ObtenerMaterialId(IdMaterial);

            //    if (dsMaterialId.Tables[0].Rows.Count > 0)
            //    {
            //        listProveedor.SelectedValue = dsMaterialId.Tables[0].Rows[0]["prov_id"].ToString();
            //        txtRuc.Text = dsMaterialId.Tables[0].Rows[0]["ruc"].ToString();
            //        txtAut.Text = dsMaterialId.Tables[0].Rows[0]["autorizacion"].ToString();
            //        txtDetalle.Text = dsMaterialId.Tables[0].Rows[0]["detalle"].ToString();
            //        listClasificacion.SelectedValue = dsMaterialId.Tables[0].Rows[0]["cla_id"].ToString();
            //        txtCantidad.Text = dsMaterialId.Tables[0].Rows[0]["cantidad"].ToString();
            //        txtCostoUnidad.Text = dsMaterialId.Tables[0].Rows[0]["costo_unitario"].ToString();
            //        txtSubtotal.Text = dsMaterialId.Tables[0].Rows[0]["costo_total"].ToString();
            //        listIva.SelectedValue = dsMaterialId.Tables[0].Rows[0]["iva_id"].ToString();
            //        txtTotal.Text = dsMaterialId.Tables[0].Rows[0]["total"].ToString();
            //    }



            //}
            //catch (Exception)
            //{
            //    MsgBox("alert", "UPS, algo ha pasado por facor revise que los campos esten correctos");
            //}

        }


    }
}