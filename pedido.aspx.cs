using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace parqueo
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cerrarSesion_Click(object sender, EventArgs e)
        {
            Response.Redirect("IncioSesion.aspx");
        }

        protected void addNuevo_Click(object sender, EventArgs e)
        {
            panelPedido.Visible = true;
            PanelGridPedido.Visible = true;
            PanelMaterial.Visible = false;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            panelPedido.Visible = false;
            PanelMaterial.Visible = true;
        }
    }
}