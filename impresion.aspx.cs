using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace parqueo
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        Acc datos = new Acc();
        public String idProducto;
        public String idPedido;
        public String especificacion;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    idProducto = Session["idProd"].ToString();
                    idPedido = Session["idPedido"].ToString();
                    especificacion=Session["especificacion"].ToString();


                    cargarPedido();
                }
                catch (Exception)
                {

                }
            }
        }



        protected void cargarPedido()
        {
            DateTime fechaact = DateTime.Parse(DateTime.Now.ToShortDateString());
            fechaact.ToString("yyyy-MM-dd");
            lblFechaExp.Text = fechaact.ToString("yyyy-MM-dd");

            DataSet dsImprimir = datos.impresion(int.Parse(idProducto));

            if (dsImprimir.Tables[0].Rows.Count > 0)
            {

                lblArticulo.Text = dsImprimir.Tables[0].Rows[0]["pro_nombre"].ToString();
                DateTime dt5 = DateTime.Parse(dsImprimir.Tables[0].Rows[0]["orp_fechaIngreso"].ToString());
                lblFechaI.Text = dt5.ToString("yyyy-MM-dd");
                DateTime dt6 = DateTime.Parse(dsImprimir.Tables[0].Rows[0]["orp_fechaFinal"].ToString());
                lblFechaF.Text = dt6.ToString("yyyy-MM-dd");
                lblCantidad.Text = dsImprimir.Tables[0].Rows[0]["pro_cantidad"].ToString();
                lblNumPedido.Text = idPedido;
                lblEspecificacion.Text = especificacion;
                lblNumOrden.Text = idProducto;
                double total = 0;
                grdImprimir.DataSource = dsImprimir.Tables[0];
                grdImprimir.DataBind();

                for (int i = 0; i < grdImprimir.Rows.Count; i++)
                {
                    total = total + double.Parse(grdImprimir.Rows[i].Cells[7].Text.ToString());
                }
                lblTotal.Text = total.ToString();
            }






        }

        protected void btnRegresar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("menu.aspx");
        }
    }
}