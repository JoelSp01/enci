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
    public partial class WebForm1 : System.Web.UI.Page
    {
        Acc datos = new Acc();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnXd_Click(object sender, EventArgs e)
        {
           // DataSet dsDatos = datos.iniciarSesion(1, txtNombre.Text, txtApellido.Text, txtUsuario.Text, txtContrasena.Text);
        }
    }
}