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

public partial class GruasDesc : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        cargarGrilla();
        if (!IsPostBack)
        {
            llenarTerminales();
            llenarTerminalesMod();
        }
    }

    private void llenarTerminales()
    {
        try
        {
            ddlTerminal.DataSource = new TerminalesBLL().sp_sel_terminalesBLL();
            ddlTerminal.DataTextField = "TERMINAL";
            ddlTerminal.DataValueField = "CODIGO";
            ddlTerminal.DataBind();
            ddlTerminal.Items.Add(new ListItem("Seleccione", ""));
            ddlTerminal.SelectedValue = "";
        }
        catch (Exception ex)
        {
            var visibilityClass = "alert alert-danger";
            var style = "display:block;";
            mensajeError.Attributes["class"] = visibilityClass;
            mensajeError.Attributes["style"] = style;
            cv_Resultado.Text = "Ocurrio un error al cargar los datos: " + ex.Message;
        }

    }

    private void llenarTerminalesMod()
    {
        try
        {
            ddlModTerm.DataSource = new TerminalesBLL().sp_sel_terminalesBLL();
            ddlModTerm.DataTextField = "TERMINAL";
            ddlModTerm.DataValueField = "CODIGO";
            ddlModTerm.DataBind();
            ddlModTerm.Items.Add(new ListItem("Seleccione", ""));
            ddlModTerm.SelectedValue = "";
        }
        catch (Exception ex)
        {
            var visibilityClass = "alert alert-danger";
            var style = "display:block;";
            mensajeError.Attributes["class"] = visibilityClass;
            mensajeError.Attributes["style"] = style;
            cv_Resultado.Text = "Ocurrio un error al cargar los datos: " + ex.Message;
        }

    }


    public void cargarGrilla()
    {
        StringBuilder strblVideo = new StringBuilder();
        Literal lTabla = new Literal();
        string tabla = string.Empty;

        DataTable dt = new DataTable();

        dt = new GruasDescBLL().sp_sel_gruasBLL();
        strblVideo.Append("<thead>");
        strblVideo.Append("<th>ELIMINAR</th>");
        strblVideo.Append("<th>EDITAR</th>");
        strblVideo.Append("<th>PATENTE</th>");
        strblVideo.Append("<th>MARCA</th>");
        strblVideo.Append("<th>TERMINAL</th>");
        strblVideo.Append("</thead>");
        strblVideo.Append("<tbody>");
        foreach (DataRow row in dt.Rows)
        {
            strblVideo.Append("<tr class=odd gradeX>");
            strblVideo.Append("<td><button id=" + row["gls_patente"] + " runat=\"server\" onclick=\"eliminar(this.id); \" class=\"btn red\" >" +
                                                 "<i class=\"fa fa-trash-o\"></i></button>" + "</td>");
            strblVideo.Append("<td><button id=" + row["gls_patente"] + " runat=\"server\" onclick=\"modificar(this.id);\" class=\"btn blue\" >" +
                                                 "<i class=\"fa fa-edit\"></i></button>" + "</td>");
            strblVideo.Append("<td>" + row["gls_patente"] + "</td>");
            strblVideo.Append("<td>" + row["gls_marca"] + "</td>");
            strblVideo.Append("<td>" + row["n_terminal"] + "</td>");
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



    public void btnGuardar_Click(object sender, EventArgs e)
    {
        if (!ValidarCamposBusqueda())
        {
            return;
        }

        GruasDescBO grua = new GruasDescBO();

        string patente = txtPatente.Text;
        string marca = txtMarca.Text;
        int terminal = Convert.ToInt32(ddlTerminal.SelectedValue.ToString());

        grua.Patente = patente;
        grua.MarcaMod = marca;
        grua.Cod_term = terminal;

        DataTable dt = new DataTable();

        try
        {
            dt = new GruasDescBLL().sp_ins_gruasBLL(grua);
        }
        catch (Exception ex)
        {
            var visibilityClass = "alert alert-danger";
            var style = "display:block;";
            mensajeError.Attributes["class"] = visibilityClass;
            mensajeError.Attributes["style"] = style;
            cv_Resultado.Text = "Ocurrio un error al cargar los datos: " + ex.Message;
        }
        
        limpiarFormulario();
        Response.Redirect("GruasDesc.aspx");
    }


    public void btnModificar_Click(object sender, EventArgs e)
    {
        if (!ValidarCamposMod())
        {
            return;
        }

        GruasDescBO grua = new GruasDescBO();

        string patente = txtModPatente.Text;
        string marca = txtModMarca.Text;
        int terminal = Convert.ToInt32(ddlModTerm.SelectedValue.ToString());

        grua.Patente = patente;
        grua.MarcaMod = marca;
        grua.Cod_term = terminal;

        DataTable dt = new DataTable();

        try
        {
            dt = new GruasDescBLL().sp_updt_gruasBLL(grua);
        }
        catch (Exception ex)
        {
            var visibilityClass = "alert alert-danger";
            var style = "display:block;";
            mensajeError.Attributes["class"] = visibilityClass;
            mensajeError.Attributes["style"] = style;
            cv_Resultado.Text = "Ocurrio un error al cargar los datos: " + ex.Message;
        }

        limpiarFormulario();
        Response.Redirect("GruasDesc.aspx");
    }

    [System.Web.Services.WebMethod]
    public static string eliminarGruas(string codigo)
    {
        DataTable dt = new DataTable();
        GruasDescBO grua = new GruasDescBO();

        grua.Patente = codigo;
        string codstring;

        try
        {
            dt = new GruasDescBLL().sp_del_gruasBLL(grua);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        codstring = dt.Rows[0].ItemArray[0].ToString();

        return codstring;
    }

    [System.Web.Services.WebMethod]
    public static Dictionary<string,string> modificarGruas(string codigo)
    {
        DataTable dt = new DataTable();
        GruasDescBO grua = new GruasDescBO();
        grua.Patente=codigo;

        try
        {
            dt = new GruasDescBLL().sp_sel_funcionIDBLL(grua);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        Dictionary<string, string> gruas = new Dictionary<string, string>();

        gruas.Add("Patente", dt.Rows[0].ItemArray[0].ToString());
        gruas.Add("Marca", dt.Rows[0].ItemArray[1].ToString());
        gruas.Add("Terminal", dt.Rows[0].ItemArray[2].ToString());

        return gruas;
    }

    public bool ValidarCamposBusqueda()
    {
        bool isValid = true;
        var errorMessage = "Se han encontrado los siguientes errores: </br>";
        var visibilityClass = "alert alert-danger";
        var style = "display:block;";
        var classSuccess = "alert alert-success display-hide";
        var styleSuccess = "display:none;";

        int terminalFlag = 0;
        int patenteFlag = 0;
        int marcaFlag = 0;

        if (ddlTerminal.SelectedItem.Text == "Seleccione") terminalFlag = 1;
        if (String.IsNullOrEmpty(txtPatente.Text.Trim())) patenteFlag = 1;
        if (String.IsNullOrEmpty(txtMarca.Text.Trim())) marcaFlag = 1;

        if (terminalFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_terminal.Text, "<br/");
            isValid = false;
        }

        if (patenteFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_patente.Text, "<br/");
            isValid = false;
        }
        if (marcaFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_marca.Text, "<br/");
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

        int terminalFlag = 0;
        int patenteFlag = 0;
        int marcaFlag = 0;

        if (ddlModTerm.SelectedItem.Text == "Seleccione") terminalFlag = 1;
        if (String.IsNullOrEmpty(txtModPatente.Text.Trim())) patenteFlag = 1;
        if (String.IsNullOrEmpty(txtModMarca.Text.Trim())) marcaFlag = 1;

        if (terminalFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_terminal.Text, "<br/");
            isValid = false;
        }

        if (patenteFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_patente.Text, "<br/");
            isValid = false;
        }
        if (marcaFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_marca.Text, "<br/");
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
        ddlTerminal.SelectedValue = "";
        txtPatente.Text = "";
        txtMarca.Text = "";
        ddlModTerm.SelectedValue = "";
        txtModMarca.Text = "";
        txtModPatente.Text = "";
    }
}