using CapaBLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ListarDesconsolidado : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        cargarLista();
    }

    public void cargarLista()
    {
        if (Session["nombre"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            //Poner datos
        }
        string permiso = Session["permiso"].ToString();
        string terminal = Session["terminal"].ToString();
        StringBuilder strblVideo = new StringBuilder();
        Literal lTabla = new Literal();
        string tabla = string.Empty;

        DataTable dt = new PlanificacionDescBLL().sp_sel_planDescBLL();

        if (!permiso.Equals("Sup Contratista"))
        {
            strblVideo.Append("<thead>");
            strblVideo.Append("<th></th>");
            strblVideo.Append("<th></th>");
            strblVideo.Append("<th>BL</th>");
            strblVideo.Append("<th>CLIENTE</th>");
            strblVideo.Append("<th>NAVE</th>");
            strblVideo.Append("<th>CONTENEDOR</th>");
            strblVideo.Append("<th>FECHA</th>");
            strblVideo.Append("<th>TERMINAL</th>");
            strblVideo.Append("<th>CLAVE</th>");
            strblVideo.Append("<th>ESTADO</th>");
            strblVideo.Append("<th></th>");
            strblVideo.Append("</thead>");
            strblVideo.Append("<tbody>");
            foreach (DataRow row in dt.Rows)
            {

                DateTime date = new DateTime();
                date = Convert.ToDateTime(row["FECHA"]);
                strblVideo.Append("<tr class=odd gradeX>");
                strblVideo.Append("<td><button id=" + row["MANIFIESTO"] + " runat=\"server\" onclick=\"eliminar(this.id); \" class=\"btn red\" >" +
                                                     "<i class=\"fa fa-trash-o\"></i></button>" + "</td>");
                strblVideo.Append("<td><button id=" + row["MANIFIESTO"] + " runat=\"server\" onclick=\"modificar(this.id);\" class=\"btn blue\" >" +
                                                     "<i class=\"fa fa-edit\"></i></button>" + "</td>");
                strblVideo.Append("<td>" + row["BL"] + "</td>");
                strblVideo.Append("<td>" + row["CLIENTE"] + "</td>");
                strblVideo.Append("<td>" + row["NAVE"] + "</td>");
                strblVideo.Append("<td>" + row["CONTENEDOR"] + "</td>");
                strblVideo.Append("<td>" + date.Day + "/" + date.Month + "/" + date.Year + "</td>");
                strblVideo.Append("<td>" + row["terminal"] + "</td>");
                strblVideo.Append("<td>" + row["desbloqueo"] + "</td>");
                strblVideo.Append("<td>" + row["estado"] + "</td>");
                if (row["estado"].ToString().Equals("Cerradas"))
                {
                    strblVideo.Append("<td><button id=" + row["MANIFIESTO"] + " runat=\"server\" onclick=\"exportar(this.id); \" class=\"btn blue\" >" +
                                                     "<i class=\"fa fa-cloud-download\"></i></button>" + "</td>");
                }
                else
                {
                    strblVideo.Append("<td>En Proceso</td>");
                }
                strblVideo.Append("</tr>");

            }

            strblVideo.Append("</tbody>");
        }
        else
        {
            strblVideo.Append("<thead>");
            strblVideo.Append("<th>BL</th>");
            strblVideo.Append("<th>CLIENTE</th>");
            strblVideo.Append("<th>NAVE</th>");
            strblVideo.Append("<th>CONTENEDOR</th>");
            strblVideo.Append("<th>FECHA</th>");
            strblVideo.Append("<th>TERMINAL</th>");
            strblVideo.Append("<th>CLAVE</th>");
            strblVideo.Append("<th>ESTADO</th>");
            strblVideo.Append("<th></th>");
            strblVideo.Append("</thead>");
            strblVideo.Append("<tbody>");
            foreach (DataRow row in dt.Rows)
            {
                if (terminal.Equals(row["age_cod"].ToString()))
                {
                    DateTime date = new DateTime();
                    date = Convert.ToDateTime(row["FECHA"]);
                    strblVideo.Append("<tr class=odd gradeX>");
                    strblVideo.Append("<td>" + row["BL"] + "</td>");
                    strblVideo.Append("<td>" + row["CLIENTE"] + "</td>");
                    strblVideo.Append("<td>" + row["NAVE"] + "</td>");
                    strblVideo.Append("<td>" + row["CONTENEDOR"] + "</td>");
                    strblVideo.Append("<td>" + date.Day + "/" + date.Month + "/" + date.Year + "</td>");
                    strblVideo.Append("<td>" + row["terminal"] + "</td>");
                    strblVideo.Append("<td>" + row["desbloqueo"] + "</td>");
                    strblVideo.Append("<td>" + row["estado"] + "</td>");
                    if (row["estado"].ToString().Equals("Cerradas"))
                    {
                        strblVideo.Append("<td><button id=" + row["MANIFIESTO"] + " runat=\"server\" onclick=\"exportar(this.id); \" class=\"btn blue\" >" +
                                                         "<i class=\"fa fa-cloud-download\"></i></button>" + "</td>");
                    }
                    else
                    {
                        strblVideo.Append("<td>En Proceso</td>");
                    }
                    strblVideo.Append("</tr>");
                }
            }

            strblVideo.Append("</tbody>");
        }

        tabla = strblVideo.ToString();
        lTabla.Text = tabla;

        pnlTablaVideos.Controls.Add(lTabla);
        pnlTablaVideos.Visible = true;
        UpdatePanel1.Update();
        UpdatePanel1.Visible = true;
    }
}