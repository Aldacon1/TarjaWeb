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
using System.IO;
using System.Data.SqlClient;

public partial class TipoDocumento : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        cargarGrilla();
    }

    protected void cargarGrilla()
    {
        StringBuilder strblVideo = new StringBuilder();
        Literal lTabla = new Literal();
        string tabla = string.Empty;

        DataTable dt = new DataTable();

        dt = new TIpoDocumentoBLL().sp_sel_tipoDocBLL();
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
            strblVideo.Append("<td><button id=" + row["cod_tipo"] + " runat=\"server\" onclick=\"eliminar(this.id); \" class=\"btn red\" >" +
                                                 "<i class=\"fa fa-trash-o\"></i></button>" + "</td>");
            strblVideo.Append("<td><button id=" + row["cod_tipo"] + " runat=\"server\" onclick=\"modificar(this.id);\" class=\"btn blue\" >" +
                                                 "<i class=\"fa fa-edit\"></i></button>" + "</td>");
            strblVideo.Append("<td>" + row["cod_tipo"] + "</td>");
            strblVideo.Append("<td>" + row["gls_desc_tipo"] + "</td>"); strblVideo.Append("</tr>");
        }

        strblVideo.Append("</tbody>");

        tabla = strblVideo.ToString();
        lTabla.Text = tabla;

        pnlTablaVideos.Controls.Add(lTabla);
        pnlTablaVideos.Visible = true;
        UpdatePanel1.Update();
        UpdatePanel1.Visible = true;
    }

    protected bool ValidarCamposBusqueda()
    {
        bool isValid = true;
        var errorMessage = "Se han encontrado los siguientes errores: </br>";
        var visibilityClass = "alert alert-danger";
        var style = "display:block;";
        var classSuccess = "alert alert-success display-hide";
        var styleSuccess = "display:none;";

        int codFlag = 0;
        int tipoFlag = 0;

        if (String.IsNullOrEmpty(txtCodigo.Text.Trim())) codFlag = 1;
        if (String.IsNullOrEmpty(txtTipoDoc.Text.Trim())) tipoFlag = 1;

        if (codFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_codigo.Text, "<br/");
            isValid = false;
        }
        if (tipoFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_tipo.Text, "<br/");
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

    protected bool ValidarCamposMod()
    {
        bool isValid = true;
        var errorMessage = "Se han encontrado los siguientes errores: </br>";
        var visibilityClass = "alert alert-danger";
        var style = "display:block;";
        var classSuccess = "alert alert-success display-hide";
        var styleSuccess = "display:none;";

        int codFlag = 0;
        int tipoFlag = 0;

        if (String.IsNullOrEmpty(txtModCod.Text.Trim())) codFlag = 1;
        if (String.IsNullOrEmpty(txtNomMod.Text.Trim())) tipoFlag = 1;

        if (codFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_codigo.Text, "<br/");
            isValid = false;
        }
        if (tipoFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_tipo.Text, "<br/");
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
        txtTipoDoc.Text = "";
        txtModCod.Text = "";
        txtNomMod.Text = "";
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        if (!ValidarCamposBusqueda())
        {

            return;
        }

        DataTable dt = new DataTable();
        string tipoDoc;
        int codigo;
        TipoDocumentoBO tipo = new TipoDocumentoBO();

        codigo = Convert.ToInt32(txtCodigo.Text);
        tipoDoc = txtTipoDoc.Text;

        tipo.Cod_tipo = codigo;
        tipo.Gls_desc_tipo = tipoDoc;

        try
        {
            dt = new TIpoDocumentoBLL().sp_ins_tipoDocBLL(tipo);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        limpiarFormulario();
        Response.Redirect("TipoDocumento.aspx");
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        if (!ValidarCamposMod())
        {

            return;
        }

        DataTable dt = new DataTable();
        string tipoDoc;
        int codigo;
        TipoDocumentoBO tipo = new TipoDocumentoBO();

        codigo = Convert.ToInt32(txtModCod.Text);
        tipoDoc = txtNomMod.Text;

        tipo.Cod_tipo = codigo;
        tipo.Gls_desc_tipo = tipoDoc;

        try
        {
            dt = new TIpoDocumentoBLL().sp_updt_tipoDocBLL(tipo);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        limpiarFormulario();
        Response.Redirect("TipoDocumento.aspx");
    }

    [System.Web.Services.WebMethod]
    public static string eliminarTipoDocs(string codigo)
    {
        TipoDocumentoBO doc = new TipoDocumentoBO();
        doc.Cod_tipo = Convert.ToInt32(codigo);

        DataTable dt = new DataTable();

        try
        {
            dt = new TIpoDocumentoBLL().sp_del_tipoDocBLL(doc);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        string codstring = dt.Rows[0].ItemArray[0].ToString();

        return codstring;
        
    }

    [System.Web.Services.WebMethod]
    public static Dictionary<string,string> modificarTipoDoc(string codigo)
    {
        int id = Convert.ToInt32(codigo);

        DataTable dt = new DataTable();
        try
        {
            dt = new TIpoDocumentoBLL().sp_sel_tipoDocIDBLL(id);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        Dictionary<string, string> bulto = new Dictionary<string, string>();

        bulto.Add("Cod_TipoDoc", dt.Rows[0].ItemArray[0].ToString());
        bulto.Add("Nom_doc", dt.Rows[0].ItemArray[1].ToString());

        return bulto;
    }
}