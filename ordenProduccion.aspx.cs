using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace parqueo
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        Acc datos = new Acc();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cerrarSesion_Click(object sender, EventArgs e)
        {
            Response.Redirect("IncioSesion.aspx");
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            try
            {

                if (txtNumPedido.Text != "")
                {
                    lblErrorIdPedido.Visible = false;
                    int idPedido = int.Parse(txtNumPedido.Text);
                    DataSet dsClienteDatos = datos.OrdenPedidoOPId(idPedido);
                    if (dsClienteDatos.Tables[0].Rows.Count > 0)
                    {
                        txtCliente.Text = dsClienteDatos.Tables[0].Rows[0]["cli_nombre"].ToString();
                        txtCedula.Text = dsClienteDatos.Tables[0].Rows[0]["cli_ruc"].ToString();

                        DateTime dt5 = DateTime.Parse(dsClienteDatos.Tables[0].Rows[0]["orp_fechaIngreso"].ToString());
                        txtFechaI.Text = dt5.ToString("yyyy-MM-dd");
                        DateTime dt6 = DateTime.Parse(dsClienteDatos.Tables[0].Rows[0]["orp_fechaFinal"].ToString());
                        txtFechaF.Text = dt6.ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        lblErrorIdPedido.Visible = true;
                        grdProductoPedido.Visible = false;
                        txtCliente.Text = "";
                        txtCedula.Text = "";
                        txtFechaI.Text = "";
                        txtFechaF.Text = "";
                        txtPvpProducto.Text = "";
                        grdMat.Visible = false;
                        grdProductoPedido.SelectedIndex = -1;
                    }


                    DataSet dsProDatos = datos.ProductoOPId(idPedido);

                    if (dsProDatos.Tables[0].Rows.Count > 0)
                    {
                        grdProductoPedido.Visible = true;
                        grdProductoPedido.DataSource = dsProDatos.Tables[0];
                        grdProductoPedido.DataBind();

                    }
                }
                else
                {
                    lblErrorIdPedido.Visible = true;
                    grdProductoPedido.Visible = false;
                    txtCliente.Text = "";
                    txtCedula.Text = "";
                    txtFechaI.Text = "";
                    txtFechaF.Text = "";
                    txtPvpProducto.Text = "";
                    grdMat.Visible = false;
                }




            }
            catch (Exception)
            {
                MsgBox("alert", "UPS, algo ha pasado por facor revise que los campos esten correctos");
            }
        }

        protected void grdProductoPedido_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

            try
            {

                int idProducto = int.Parse(((Label)grdProductoPedido.Rows[e.NewSelectedIndex].FindControl("lblIdProducto")).Text);
                lblIdProducto.Text = idProducto.ToString();
                Session["idProd"] = idProducto.ToString();


                DataSet dsProDatos = datos.ProductoDatosOP(idProducto);
                if (dsProDatos.Tables[0].Rows.Count > 0)
                {
                    txtPvpProducto.Text = dsProDatos.Tables[0].Rows[0]["pro_pvp"].ToString();
                }



                DataSet dsMatDatos = datos.ProductoTotalOPId(idProducto);
                if (dsMatDatos.Tables[0].Rows.Count > 0)
                {
                    grdMat.Visible = true;
                    grdMat.DataSource = dsMatDatos.Tables[0];
                    grdMat.DataBind();
                }
                else
                {

                    grdMat.Visible = false;
                }
                btnGenerarDocumento.Visible = true;
                lblEspecificaion.Visible = true;
                txtEspecificaion.Visible = true;

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

        protected void btnGenerarDocumento_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtEspecificaion.Text != "")
                {

                    DateTime fechaact = DateTime.Parse(DateTime.Now.ToShortDateString());
                    fechaact.ToString("yyyy-MM-dd");
                    string fecdia = fechaact.Day.ToString();
                    string fecmes = fechaact.Month.ToString();
                    string fecanio = fechaact.Year.ToString();
                    if (int.Parse(fecdia) < 10) fecdia = "0" + fecdia; else fecdia = fecdia;
                    if (int.Parse(fecmes) < 10) fecmes = "0" + fecmes; else fecmes = fecmes;

                    String fecha = fecanio + "-" + fecmes + "-" + fecdia;
                    DataSet dsProDatos = datos.insertarEspe(txtEspecificaion.Text, fecha, int.Parse(txtNumPedido.Text), int.Parse(lblIdProducto.Text));



                    lblErrorEspecificacion.Visible = false;
                    Session["idProd"] = lblIdProducto.Text;
                    Session["idPedido"] = txtNumPedido.Text;
                    Session["especificacion"] = txtEspecificaion.Text;
                    Response.Redirect("impresion.aspx");
                }
                else
                {
                    lblErrorEspecificacion.Visible = true;
                }

            }
            catch (Exception)
            {
                MsgBox("alert", "UPS, algo ha pasado por favor revise que los campos esten correctos");
            }


        }

        protected void txtEspecificaion_TextChanged(object sender, EventArgs e)
        {

        }
    }
}