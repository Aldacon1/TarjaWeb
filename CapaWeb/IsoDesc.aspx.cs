using CapaBLL;
using CapaBO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IsoDesc : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cargarGrilla();
        }
    }

    protected void cargarGrilla()
    {
        StringBuilder strblVideo = new StringBuilder();
        Literal lTabla = new Literal();
        string tabla = string.Empty;

        DataTable dt = new DataTable();

        dt = new IsoDescBLL().sp_sel_isoBLL();

        strblVideo.Append("<thead>");
        strblVideo.Append("<th>ELIMINAR</th>");
        strblVideo.Append("<th>EDITAR</th>");
        strblVideo.Append("<th>CODIGO</th>");
        strblVideo.Append("<th>NOMBRE</th>");
        strblVideo.Append("<th>TARA</th>");
        strblVideo.Append("</thead>");
        strblVideo.Append("<tbody>");
        foreach (DataRow row in dt.Rows)
        {
            DateTime date = new DateTime();
            strblVideo.Append("<tr class=odd gradeX>");
            strblVideo.Append("<td><button id=" + row["cod_iso"] + " runat=\"server\" onclick=\"eliminar(this.id); \" class=\"btn red\" >" +
                                                 "<i class=\"fa fa-trash-o\"></i></button>" + "</td>");
            strblVideo.Append("<td><button id=" + row["cod_iso"] + " runat=\"server\" onclick=\"modificar(this.id);\" class=\"btn blue\" >" +
                                                 "<i class=\"fa fa-edit\"></i></button>" + "</td>");
            strblVideo.Append("<td>" + row["cod_iso"] + "</td>");
            strblVideo.Append("<td>" + row["desc_iso"] + "</td>");
            strblVideo.Append("<td>" + row["tara"] + "</td>");
            strblVideo.Append("</tr>");
        }

        strblVideo.Append("</tbody>");

        tabla = strblVideo.ToString();
        lTabla.Text = tabla;

        pnlTablaVideos.Controls.Add(lTabla);
        pnlTablaVideos.Visible = true;
        UpdatePanel1.Update();
        UpdatePanel1.Visible = true;
    }

    protected void btnGuardar_Click(Object sender, EventArgs e)
    {
        if (!ValidarCamposBusqueda())
            return;

        DataTable dt = new DataTable();
        string codigo = txtCodigo.Text;
        string nombre = txtNombre.Text;
        int tara = Convert.ToInt32(txtTarad.Text);
        IsoDescBO iso = new IsoDescBO();

        iso.Iso_cod = codigo;
        iso.Iso_nom = nombre;
        iso.Iso_tara = tara;

        try
        {
            dt = new IsoDescBLL().sp_ins_isoBLL(iso);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
        limpiarFormulario();
        Response.Redirect("IsoDesc.aspx");
    }

    protected void btnModificar_Click(Object sender, EventArgs e)
    {
        if (!ValidarCamposMod())
            return;

        DataTable dt = new DataTable();
        string codigo = txtCodMod.Text;
        string nombre = txtNomMod.Text;
        int tara = Convert.ToInt32(txtTaraMod.Text);
        IsoDescBO iso = new IsoDescBO();

        iso.Iso_cod = codigo;
        iso.Iso_nom = nombre;
        iso.Iso_tara = tara;

        try
        {
            dt = new IsoDescBLL().sp_updt_isoBLL(iso);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        limpiarFormulario();
        Response.Redirect("IsoDesc.aspx");
    }

    [System.Web.Services.WebMethod]
    public static string eliminariSO(string codigo)
    {
        IsoDescBO iso = new IsoDescBO();
        iso.Iso_cod = codigo;
        string codstring;

        DataTable dt = new DataTable();

        try
        {
            dt = new IsoDescBLL().sp_del_isoBLL(iso);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        codstring = dt.Rows[0].ItemArray[0].ToString();

        return codstring;
    }

    [System.Web.Services.WebMethod]
    public static Dictionary<string,string> modificarIso(string codigo)
    {
        Dictionary<string, string> iso = new Dictionary<string, string>();
        DataTable dt = new DataTable();

        try
        {
            dt = new IsoDescBLL().sp_sel_isoIDBLL(codigo);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        iso.Add("cod_iso", dt.Rows[0].ItemArray[0].ToString());
        iso.Add("desc_iso", dt.Rows[0].ItemArray[1].ToString());
        iso.Add("tara", dt.Rows[0].ItemArray[2].ToString());

        return iso;
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
        int TaraFlag = 0;
        if (String.IsNullOrEmpty(txtCodigo.Text.Trim())) CodigoFlag = 1;
        if (String.IsNullOrEmpty(txtNombre.Text.Trim())) NombreFlag = 1;
        if (String.IsNullOrEmpty(txtTarad.Text.Trim())) TaraFlag = 1;
        if (CodigoFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_Codigo.Text, "<br/");
            isValid = false;
        }
        if (NombreFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensjae_Nombre.Text, "<br/");
            isValid = false;
        }
        if (TaraFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_tara.Text, "<br/");
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
        int TaraFlag = 0;
        if (String.IsNullOrEmpty(txtCodMod.Text.Trim())) CodigoFlag = 1;
        if (String.IsNullOrEmpty(txtNomMod.Text.Trim())) NombreFlag = 1;
        if (String.IsNullOrEmpty(txtTaraMod.Text.Trim())) TaraFlag = 1;
        if (CodigoFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_Codigo.Text, "<br/");
            isValid = false;
        }
        if (NombreFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensjae_Nombre.Text, "<br/");
            isValid = false;
        }
        if (TaraFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_tara.Text, "<br/");
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
        txtTarad.Text = "";

        txtCodMod.Text = "";
        txtNomMod.Text = "";
        txtTaraMod.Text = "";
    }

    
}