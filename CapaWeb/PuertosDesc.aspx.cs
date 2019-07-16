using CapaBO;
using CapaBLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;

public partial class PuertosDesc : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        cargarGrilla();
    }

    private void cargarGrilla()
    {
        StringBuilder strblVideo = new StringBuilder();
        Literal lTabla = new Literal();
        string tabla = string.Empty;

        DataTable dt = new DataTable();

        dt = new PuertoBLL().sp_sel_puertoBLL();
        
        strblVideo.Append("<thead>");
        strblVideo.Append("<th>ELIMINAR</th>");
        strblVideo.Append("<th>EDITAR</th>");
        strblVideo.Append("<th>CODIGO</th>");
        strblVideo.Append("<th>NOMBRE</th>");
        strblVideo.Append("</thead>");
        strblVideo.Append("<tbody>");
        foreach (DataRow row in dt.Rows)
        {
            strblVideo.Append("<tr class=odd gradeX>");
            strblVideo.Append("<td><button id=" + row["CODIGO"] + " runat=\"server\" onclick=\"eliminar(this.id); \" class=\"btn red\" >" +
                                                 "<i class=\"fa fa-trash-o\"></i></button>" + "</td>");
            strblVideo.Append("<td><button id=" + row["CODIGO"] + " runat=\"server\" onclick=\"modificar(this.id);\" class=\"btn blue\" >" +
                                                 "<i class=\"fa fa-edit\"></i></button>" + "</td>");
            strblVideo.Append("<td>" + row["CODIGO"] + "</td>");
            strblVideo.Append("<td>" + row["NOMBRE"] + "</td>"); strblVideo.Append("</tr>");
        }

        strblVideo.Append("</tbody>");

        tabla = strblVideo.ToString();
        lTabla.Text = tabla;

        pnlTablaVideos.Controls.Add(lTabla);
        pnlTablaVideos.Visible = true;
        UpdatePanel1.Update();
        UpdatePanel1.Visible = true;

    }
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        if (!ValidarCamposBusqueda())
        {
            return;
        }
        DataTable dt = new DataTable();

        string cod = txtCodigo.Text;
        string nombre = txtNombre.Text;

        PuertosBO puerto = new PuertosBO();
        puerto.Cod_puerto = cod;
        puerto.Gls_nombre_puerto = nombre;

        try
        {
            dt = new PuertoBLL().sp_ins_puertoBLL(puerto);
        }
        catch (Exception ex)
        {
            var visibilityClass = "alert alert-danger";
            var style = "display:block;";
            mensajeError.Attributes["class"] = visibilityClass;
            mensajeError.Attributes["style"] = style;
            cv_Resultado.Text = "Ocurrio un error al cargar los datos: " + ex.Message;
        }

        Response.Redirect("PuertosDesc.aspx");
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        if (!ValidarCamposMod())
        {
            return;
        }
        DataTable dt = new DataTable();

        string cod = txtModCOd.Text;
        string nombre = txtNomMod.Text;

        PuertosBO puerto = new PuertosBO();
        puerto.Cod_puerto = cod;
        puerto.Gls_nombre_puerto = nombre;

        try
        {
            dt = new PuertoBLL().sp_updt_puertoBLL(puerto);
        }
        catch (Exception ex)
        {
            var visibilityClass = "alert alert-danger";
            var style = "display:block;";
            mensajeError.Attributes["class"] = visibilityClass;
            mensajeError.Attributes["style"] = style;
            cv_Resultado.Text = "Ocurrio un error al cargar los datos: " + ex.Message;
        }

        Response.Redirect("PuertosDesc.aspx");
    }

    [System.Web.Services.WebMethod]
    public static string eliminarPuertos(string codigo)
    {
        PuertosBO puertos = new PuertosBO();
        puertos.Cod_puerto = codigo;

        DataTable dt = new PuertoBLL().sp_del_puertoBLL(puertos);

        string codstring = dt.Rows[0].ItemArray[0].ToString();

        return codstring;
    }

    [System.Web.Services.WebMethod]
    public static Dictionary<string,string> modificarPuertos(string codigo)
    {
        DataTable dt = new DataTable();
        try
        {
            dt = new PuertoBLL().sp_sel_puertoIDBLL(codigo);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        Dictionary<string, string> puerto = new Dictionary<string, string>();

        puerto.Add("Cod_puerto", dt.Rows[0].ItemArray[0].ToString());
        puerto.Add("Nom_puerto", dt.Rows[0].ItemArray[1].ToString());

        return puerto;
    }

    public bool ValidarCamposBusqueda()
    {
        bool isValid = true;
        var errorMessage = "Se han encontrado los siguientes errores: </br>";
        var visibilityClass = "alert alert-danger";
        var style = "display:block;";
        var classSuccess = "alert alert-success display-hide";
        var styleSuccess = "display:none;";

        int CodigoFlag = 0;
        int NombreFlag = 0;
        if (String.IsNullOrEmpty(txtCodigo.Text.Trim())) CodigoFlag = 1;
        if (String.IsNullOrEmpty(txtNombre.Text.Trim())) NombreFlag = 1;

        if (CodigoFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_codigo.Text, "<br/");
            isValid = false;
        }
        if (NombreFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_Nombre.Text, "<br/");
            isValid = false;
        }

        if (isValid)
        {
            visibilityClass += "display-hide";
            style = "display:none;";
            classSuccess = "alert alert-success";
            styleSuccess = "display:block;";
        }

        mensajeError.Attributes["class"] = visibilityClass;
        mensajeError.Attributes["style"] = style;
        cv_Resultado.Text = errorMessage;

        mensajeSuccess.Attributes["class"] = classSuccess;
        mensajeSuccess.Attributes["style"] = styleSuccess;
        lblSuccess.Text = "Ingreso de datos correcto";

        return isValid;
    }

    public bool ValidarCamposMod()
    {
        bool isValid = true;
        var errorMessage = "Se han encontrado los siguientes errores: </br>";
        var visibilityClass = "alert alert-danger";
        var style = "display:block;";
        var classSuccess = "alert alert-success display-hide";
        var styleSuccess = "display:none;";

        int CodigoFlag = 0;
        int NombreFlag = 0;
        if (String.IsNullOrEmpty(txtModCOd.Text.Trim())) CodigoFlag = 1;
        if (String.IsNullOrEmpty(txtNomMod.Text.Trim())) NombreFlag = 1;

        if (CodigoFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_codigo.Text, "<br/");
            isValid = false;
        }
        if (NombreFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_Nombre.Text, "<br/");
            isValid = false;
        }

        if (isValid)
        {
            visibilityClass += "display-hide";
            style = "display:none;";
            classSuccess = "alert alert-success";
            styleSuccess = "display:block;";
        }

        mensajeError.Attributes["class"] = visibilityClass;
        mensajeError.Attributes["style"] = style;
        cv_Resultado.Text = errorMessage;

        mensajeSuccess.Attributes["class"] = classSuccess;
        mensajeSuccess.Attributes["style"] = styleSuccess;
        lblSuccess.Text = "Ingreso de datos correcto";

        return isValid;
    }


    protected void limpiarFormulario()
    {
        txtCodigo.Text = "";
        txtNombre.Text = "";
    }    
}