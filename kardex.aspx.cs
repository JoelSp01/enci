using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace parqueo
{
    public partial class kardex : System.Web.UI.Page
    {
        Acc datos = new Acc();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                // CargarClasificaciones();
                CargarProveedor();
            }

        }



        protected void listProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (listProveedor.SelectedItem.Text == "[Seleccione]")
                {
                    string mensaje = "Debe Seleccionar un Proveedor";

                }
                else
                {

                    DataSet data = datos.obtenerMaterialRegistradoProveedor(Int32.Parse(listProveedor.SelectedValue));

                    if (data.Tables[0].Rows.Count > 0)
                    {
                        listMaterial.DataSource = data.Tables[0];
                        listMaterial.DataTextField = "mat_detalle";
                        listMaterial.DataValueField = "mat_id";
                        listMaterial.DataBind();
                        this.listMaterial.Items.Insert(0, "[Seleccione]");
                        this.listMaterial.Items.Insert(1, "[Todos]");
                        panelMat.Visible = true;
                        Panel1.Visible = false;
                    }

                }
            }
            catch (Exception)
            {
                //  MsgBox("alert", "UPS, algo ha pasado por facor revise que los campos esten correctos");
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
                //  MsgBox("alert", "UPS, algo ha pasado por facor revise que los campos esten correctos");
            }

        }


        protected void listMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (listMaterial.SelectedItem.Text == "[Seleccione]")
                {
                    string mensaje = "Debe Seleccionar un Proveedor";

                }
                else
                {
                    if (listMaterial.SelectedItem.Text == "[Todos]")
                    {
                        lblIdMat.Text = "-1";
                        DataSet obtenerKardex = datos.obtenerKardexMat(Int32.Parse(lblIdMat.Text), Int32.Parse(listProveedor.SelectedValue));

                        if (obtenerKardex.Tables[0].Rows.Count > 0)
                        {
                            Panel1.Visible = true;
                            grdKardex.DataSource = obtenerKardex.Tables[0];
                            grdKardex.DataBind();
                        }
                        else
                        {
                            grdKardex.DataSource = "";
                            grdKardex.DataBind();
                        }

                    }
                    else
                    {
                        DataSet obtenerKardexMat = datos.obtenerKardexMat(Int32.Parse(listMaterial.SelectedValue),Int32.Parse(listProveedor.SelectedValue));

                        if (obtenerKardexMat.Tables[0].Rows.Count > 0)
                        {
                            Panel1.Visible = true;
                            grdKardex.DataSource = obtenerKardexMat.Tables[0];
                            grdKardex.DataBind();
                        }
                        else
                        {
                            grdKardex.DataSource = "";
                            grdKardex.DataBind();
                        }

                    }
                }

            }
            catch (Exception)
            {
                //  MsgBox("alert", "UPS, algo ha pasado por facor revise que los campos esten correctos");
            }

        }
    }
}