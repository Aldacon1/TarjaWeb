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

public partial class TerminalesDesc : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        cargarGrilla();
    }

    public void cargarGrilla()
    {
        StringBuilder strblVideo = new StringBuilder();
        Literal lTabla = new Literal();
        string tabla = string.Empty;

        DataTable dt = new DataTable();

        dt = new TerminalesBLL().sp_sel_terminalesBLL();

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
            strblVideo.Append("<td>" + row["TERMINAL"] + "</td>"); strblVideo.Append("</tr>");
        }

        strblVideo.Append("</tbody>");

        tabla = strblVideo.ToString();
        lTabla.Text = tabla;

        pnlTablaTerminales.Controls.Clear();

        pnlTablaTerminales.Controls.Add(lTabla);
        pnlTablaTerminales.Visible = true;
        UpdatePanel1.Update();

    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        if (!ValidarCamposBusqueda())
        {
            cargarGrilla();
            return;
        }

        int codigo = Convert.ToInt32(txtCodigo.Text);
        string nombre = txtNombre.Text;
        DataTable dt = new DataTable();

        TerminalesBO terminal = new TerminalesBO();
        terminal.Age_cod = codigo;
        terminal.Age_nom = nombre;

        try
        {
            dt = new TerminalesBLL().sp_ins_terminalesBLL(terminal);
            cargarGrilla();
        }
        catch (Exception ex)
        {
            throw ex;
        }

        limpiarForm();
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        if (!ValidarCamposMod())
        {
            cargarGrilla();
            return;
        }

        DataTable dt = new DataTable();
        TerminalesBO terminalBO = new TerminalesBO();

        try
        {
            terminalBO.Age_cod = Convert.ToInt32(txtCodMod.Text);
            terminalBO.Age_nom = txtNomMod.Text;

            dt = new TerminalesBLL().sp_updt_terminalesBLL(terminalBO);

            cargarGrilla();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    [System.Web.Services.WebMethod]
    public static string eliminarTerminal(string codigo)
    {
        TerminalesBO terminal = new TerminalesBO();
        terminal.Age_cod = Convert.ToInt32(codigo);

        DataTable dt = new TerminalesBLL().sp_del_terminalesBLL(terminal);

        string codstring = dt.Rows[0].ItemArray[0].ToString();

        return codstring;
    }

    [System.Web.Services.WebMethod]
    public static Dictionary<string, string> modificarTerminal(string codigo)
    {
        int id = Convert.ToInt32(codigo);

        DataTable dt = new DataTable();
        try
        {
            dt = new TerminalesBLL().sp_sel_terminalIDBLL(id);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        Dictionary<string, string> terminal = new Dictionary<string, string>();

        terminal.Add("Age_cod", dt.Rows[0].ItemArray[0].ToString());
        terminal.Add("Age_nom", dt.Rows[0].ItemArray[1].ToString());

        return terminal;
    }

    protected void limpiarForm()
    {
        txtCodigo.Text = "";
        txtNombre.Text = "";
    }

    protected bool ValidarCamposBusqueda()
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
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_nombre.Text, "<br/");
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

        int CodigoFlag = 0;
        int NombreFlag = 0;

        if (String.IsNullOrEmpty(txtCodMod.Text.Trim())) CodigoFlag = 1;
        if (String.IsNullOrEmpty(txtNomMod.Text.Trim())) NombreFlag = 1;

        if (CodigoFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_codigo.Text, "<br/");
            isValid = false;
        }

        if (NombreFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_nombre.Text, "<br/");
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
}