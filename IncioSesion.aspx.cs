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
            try { 

                if (txtRegNombre.Text == "")
                {
                    lblErrorNombre.Visible = true;
                }
                else if (txtRegNombre.Text != "")
                {
                    lblErrorNombre.Visible = false;
                }

                if (txtRegUsuario.Text == "")
                {
                    lblErrorUsRe.Visible = true;
                }
                else if (txtRegUsuario.Text != "")
                {
                    lblErrorUsRe.Visible = false;
                }

                if (txtRegContrasena.Text == "")
                {
                    lblErrorContraReg.Visible = true;
                }
                else if (txtRegContrasena.Text != "")
                {
                    lblErrorContraReg.Visible = false;
                }


                if (txtRegNombre.Text != "" && txtRegUsuario.Text != "" && txtRegContrasena.Text != "")
                {
                    DataSet dsDatos = datos.registrarUsuario(1, txtRegNombre.Text, txtRegUsuario.Text, txtRegContrasena.Text);
                }
            }
            catch (Exception)
            {
                MsgBox("alert", "UPS, algo ha pasado por facor revise que los campos esten correctos");
            }
        }

        protected void btnLogIn_Click1(object sender, EventArgs e)
        {
            try{

                if (txtUsuario.Text == "")
                {
                    lblErrorUsuarioIn.Visible = true;

                }
                else if (txtUsuario.Text != "")
                {
                    lblErrorUsuarioIn.Visible = false;
                }

                if (txtContrasena.Text == "")
                {
                    lblErrorContraIn.Visible = true;
                }
                else if (txtContrasena.Text != "")
                {
                    lblErrorContraIn.Visible = false;


                }

                if (txtUsuario.Text != "" && txtContrasena.Text != "")
                {
                    DataSet dsDatos = datos.verificarUs(txtUsuario.Text, txtContrasena.Text);

                    if (dsDatos.Tables[0].Rows.Count > 0)
                    {
                        Session["idUsuario"] = dsDatos.Tables[0].Rows[0]["us_id"].ToString();
                        Response.Redirect("menu.aspx");
                    }
                    else
                    {
                        MsgBox("alert", "Usuario no registrado");
                        txtUsuario.Text = "";
                        txtContrasena.Text = "";
                    }
                }

            }
            catch (Exception x)
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

    }

}