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
    public partial class WebForm8 : System.Web.UI.Page
    {
        Acc datos = new Acc();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            DataSet dsProDatos = datos.reportes(txtFechaDesde.Text, txtFechaHasta.Text);

            if (dsProDatos.Tables[0].Rows.Count > 0)
            {
                btnExportar.Visible = true;
                grdReporte.Visible = true;
                grdReporte.DataSource = dsProDatos.Tables[0];
                grdReporte.DataBind();
            }

        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {

                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("Content-Disposition", "attachment;filename=ReportePorFechas.xls");
                Response.Charset = "UTF-8";
                Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1252");
                //Response.ContentEncoding = System.Text.Encoding.UTF8;
                Response.Write(HTML(grdReporte, "REPORTES")); //Llamada al procedimiento HTML
                Response.End();

                //   udpContenido.Update();
            }
            catch (Exception excError)
            {
                //ModalPopupExtender mp = (ModalPopupExtender)Master.FindControl("modalPopUpMensajes");
                //mp.Show();
                //Label lblPilaErrores = (Label)Master.FindControl("lblPilaErrores");
                //lblPilaErrores.Text = excError.Message + "<br /> <hr style='margin - top: 1px; border - width: 2px; ' />" + "ERROR:" + excError.StackTrace;
            }
        }

        public string HTML(GridView gvExportar, string titulo)
        {
            Page page1 = new Page();
            HtmlForm form = new HtmlForm();

            gvExportar.EnableViewState = false;
            if (gvExportar.DataSource != null)
            {
                gvExportar.DataBind();
            }

            gvExportar.EnableViewState = false;
            page1.EnableViewState = false;

            page1.Controls.Add(form);
            form.Controls.Add(gvExportar);

            System.Text.StringBuilder builder1 = new System.Text.StringBuilder();
            System.IO.StringWriter writer1 = new System.IO.StringWriter(builder1);
            HtmlTextWriter writer2 = new HtmlTextWriter(writer1);

            writer2.Write("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\n<head>\n<title>Datos</title>\n<meta http-equiv=\"Content-Type\" content=\"text/html; charset=iso-8859-1\" />\n<style>\n</style>\n</head>\n<body>\n");
            writer2.Write("<table><tr><font face=Times New Roman size=3><left>ESCUELA DE NEGOCIOS Y COMERCIOS INTERNACIONALES</left></font></tr></table>");
            writer2.Write("<table><tr><font face=Times New Roman size=3><left>" + titulo + "</left></font></tr></table>");
            writer2.Write("<table><tr><font face=Times New Roman size=3><left>FECHA DE REPORTE: </left></font>" + System.DateTime.Now.ToString() + "</tr></table>");

            page1.DesignerInitialize();
            page1.RenderControl(writer2);
            writer2.Write("\n</body>\n</html>");
            page1.Dispose();
            page1 = null;
            return builder1.ToString();
        }
    }
}