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
    public partial class WebForm7 : System.Web.UI.Page
    {
        Acc datos = new Acc();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            // MsgBox("alert", "hola");
            if(txtRegNombre.Text=="" || txtRegUsuario.Text==""|| txtRegContrasena.Text=="")
            {
                MsgBox("alert", "No se ha registrado");
               
            }
            else
            {
                DataSet dsDatos = datos.registrarUsuario(1, txtRegNombre.Text, txtRegUsuario.Text, txtRegContrasena.Text);
            }

            
        }
        
        protected void btnLogIn_Click1(object sender, EventArgs e)
        {
            DataSet dsDatos = datos.verificarUs(txtUsuario.Text);

            if (dsDatos.Tables[0].Rows.Count > 0)
            {
                Response.Redirect("menu.aspx");
                MsgBox("alert", "Usuario encontrado");

            }
           else
            {
                MsgBox("alert", "Usuario no registrado");
            }


        }
        
        protected void MsgBox(string v_tipo_msg, string v_msg)
        {
            Response.Write("<script language='javascript'>");
            Response.Write(v_tipo_msg + "('" + v_msg + "')");
            Response.Write("</script>");
        }

    }

}