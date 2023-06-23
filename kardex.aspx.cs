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

                //lblIdProveedor.Text = listProveedor.SelectedValue.ToString();

                if (listProveedor.SelectedItem.Text == "[Seleccione]")
                {
                    string mensaje = "Debe Seleccionar un Proveedor";
                    
                }
                else
                {
                    if (listProveedor.SelectedItem.Text == "Todos")
                    {
                        lblIdProveedor.Text = "-1";
                        DataSet obtenerKardex = datos.obtenerKardex(Int32.Parse(lblIdProveedor.Text));

                        if (obtenerKardex.Tables[0].Rows.Count > 0)
                        {
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
                        DataSet obtenerKardex = datos.obtenerKardex(Int32.Parse(listProveedor.SelectedValue));

                        if (obtenerKardex.Tables[0].Rows.Count > 0)
                        {
                            grdKardex.DataSource = obtenerKardex.Tables[0];
                            grdKardex.DataBind();
                        }
                        else
                        {
                            grdKardex.DataSource = "";
                            grdKardex.DataBind();
                        }

                    }
                }


                //if (lblIdProveedor.Text != "[Seleccione]")
                //{
                //    DataSet dsProveedorId = datos.ObtenerProveedorId(Int32.Parse(lblIdProveedor.Text));
                //    if (dsProveedorId.Tables[0].Rows.Count > 0)
                //    {
                //       // txtRuc.Text = dsProveedorId.Tables[0].Rows[0]["prov_ruc"].ToString();
                //    }
                //}
                //else
                //{
                //   // txtRuc.Text = "";
                //}

            }
            catch (Exception)
            {
                //  MsgBox("alert", "UPS, algo ha pasado por facor revise que los campos esten correctos");
            }
        }




        //        protected void CargarKardex()
        //        {
        //            try
        //            {
        //                DataSet dsMat = datos.obtenerKardex();
        //                if (dsMat.Tables[0].Rows.Count > 0)
        //                {
        //                    grdMateriales.DataSource = dsMat.Tables[0];
        //                    grdMateriales.DataBind();
        //                }
        //                else
        //                {
        //                    grdMateriales.DataSource = "";
        //                    grdMateriales.DataBind();
        //                }
        //            }
        //            catch (Exception)
        //            {
        //    MsgBox("alert", "UPS, algo ha pasado por facor revise que los campos esten correctos");
        //}
        //        }


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
                    this.listProveedor.Items.Insert(1, "Todos");
                }

            }
            catch (Exception)
            {
                //  MsgBox("alert", "UPS, algo ha pasado por facor revise que los campos esten correctos");
            }

        }





    }
}