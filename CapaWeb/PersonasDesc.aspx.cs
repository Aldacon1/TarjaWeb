using CapaBLL;
using CapaBO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PersonasDesc : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            llenarAgencias();
            llenarFunciones();
            llenarAgenciasMod();
            llenarFuncionesMod();
        }
        llenargvPersonas();
    }

    public void llenargvPersonas()
    {
        StringBuilder strblVideo = new StringBuilder();
        Literal lTabla = new Literal();
        string tabla = string.Empty;

        DataTable dt = new DataTable();

        dt = new PersonasBLL().sp_sel_personasBLL();
        strblVideo.Append("<thead>");
        strblVideo.Append("<th>ELIMINAR</th>");
        strblVideo.Append("<th>EDITAR</th>");
        strblVideo.Append("<th>RUT</th>");
        strblVideo.Append("<th>DV</th>");
        strblVideo.Append("<th>NOMBRE</th>");
        strblVideo.Append("<th>FUNCION</th>");
        strblVideo.Append("<th>TERMINAL</th>");
        strblVideo.Append("</thead>");
        strblVideo.Append("<tbody>");
        foreach (DataRow row in dt.Rows)
        {
            strblVideo.Append("<tr class=odd gradeX>");
            strblVideo.Append("<td><button id=" + row["rut_persona"] + " runat=\"server\" onclick=\"eliminar(this.id); \" class=\"btn red\" >" +
                                                 "<i class=\"fa fa-trash-o\"></i></button>" + "</td>");
            strblVideo.Append("<td><button id=" + row["rut_persona"] + " runat=\"server\" onclick=\"modificar(this.id);\" class=\"btn blue\" >" +
                                                 "<i class=\"fa fa-edit\"></i></button>" + "</td>");
            strblVideo.Append("<td>" + row["rut_persona"] + "</td>");
            strblVideo.Append("<td>" + row["dv_persona"] + "</td>");
            strblVideo.Append("<td>" + row["gls_nombre_pers"] + "</td>");
            strblVideo.Append("<td>" + row["funcion"] + "</td>");
            strblVideo.Append("<td>" + row["terminal"] + "</td>");
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

    public void llenarAgencias()
    {
        try
        {
            ddlAgencia.DataSource = new TerminalesBLL().sp_sel_terminalesBLL();
            ddlAgencia.DataTextField = "TERMINAL";
            ddlAgencia.DataValueField = "CODIGO";
            ddlAgencia.DataBind();
            ddlAgencia.Items.Add(new ListItem("Seleccione una opción: ", ""));
            ddlAgencia.SelectedValue = "";
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

    public void llenarAgenciasMod()
    {
        try
        {
            ddlModTerm.DataSource = new TerminalesBLL().sp_sel_terminalesBLL();
            ddlModTerm.DataTextField = "TERMINAL";
            ddlModTerm.DataValueField = "CODIGO";
            ddlModTerm.DataBind();
            ddlModTerm.Items.Add(new ListItem("Seleccione una opción: ", ""));
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

    public void llenarFunciones()
    {
        try
        {
            ddlFuncion.DataSource = new FuncionesBLL().sp_sel_funcionesBLL();
            ddlFuncion.DataTextField = "gls_nombre_fun";
            ddlFuncion.DataValueField = "cod_funcion";
            ddlFuncion.DataBind();
            ddlFuncion.Items.Add(new ListItem("Seleccione una opción: ", ""));
            ddlFuncion.SelectedValue = "";
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

    public void llenarFuncionesMod()
    {
        try
        {
            ddlModFun.DataSource = new FuncionesBLL().sp_sel_funcionesBLL();
            ddlModFun.DataTextField = "gls_nombre_fun";
            ddlModFun.DataValueField = "cod_funcion";
            ddlModFun.DataBind();
            ddlModFun.Items.Add(new ListItem("Seleccione una opción: ", ""));
            ddlModFun.SelectedValue = "";
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

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        if (!ValidarCamposBusqueda())
        {
            return;
        }
        
        int rut, funcion, agencia;
        string nombre, pass;
        DataTable dt = new DataTable();

        rut = Convert.ToInt32(txtRut.Text);
        nombre = txtNombre.Text;
        funcion = Convert.ToInt32(ddlFuncion.SelectedValue);
        agencia = Convert.ToInt32(ddlAgencia.SelectedValue);
        pass = txtPass.Text;

        PersonasBO persona = new PersonasBO();
        persona.Rut_persona = rut;
        persona.Nom_persona = nombre;
        persona.Fun_cod = funcion;
        persona.Age_cod = agencia;
        persona.Pass_persona = pass;

        try
        {
            dt = new PersonasBLL().sp_ins_personasBLL(persona);
        }
        catch(Exception ex)
        {
            var visibilityClass = "alert alert-danger";
            var style = "display:block;";
            mensajeError.Attributes["class"] = visibilityClass;
            mensajeError.Attributes["style"] = style;
            cv_Resultado.Text = "Ocurrio un error al cargar los datos: " + ex.Message;
        }

        Response.Redirect("PersonasDesc.aspx");
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        if (!ValidarCamposMod())
        {
            return;
        }

        int rut, funcion, agencia;
        string nombre, pass;
        DataTable dt = new DataTable();

        rut = Convert.ToInt32(txtModRut.Text);
        nombre = txtModNombre.Text;
        funcion = Convert.ToInt32(ddlModFun.SelectedValue);
        agencia = Convert.ToInt32(ddlModTerm.SelectedValue);
        pass = txtModPass.Text;

        PersonasBO persona = new PersonasBO();
        persona.Rut_persona = rut;
        persona.Nom_persona = nombre;
        persona.Fun_cod = funcion;
        persona.Age_cod = agencia;
        persona.Pass_persona = pass;

        try
        {
            dt = new PersonasBLL().sp_updt_personasBLL(persona);
        }
        catch (Exception ex)
        {
            var visibilityClass = "alert alert-danger";
            var style = "display:block;";
            mensajeError.Attributes["class"] = visibilityClass;
            mensajeError.Attributes["style"] = style;
            cv_Resultado.Text = "Ocurrio un error al cargar los datos: " + ex.Message;
        }

        Response.Redirect("PersonasDesc.aspx");
    }

    [System.Web.Services.WebMethod]
    public static string eliminarPersonas(string rut)
    {
        DataTable dt;
        int rutPersona = Convert.ToInt32(rut);
        PersonasBO persona = new PersonasBO();
        persona.Rut_persona = rutPersona;
        try
        {
            dt = new PersonasBLL().sp_del_personasBLL(persona);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        string codstring = dt.Rows[0].ItemArray[0].ToString();

        return codstring;
    }

    [System.Web.Services.WebMethod]
    public static Dictionary<string,string> modificarPersona(string rut)
    {
        DataTable dt = new DataTable();
        int rutP = Convert.ToInt32(rut);

        try
        {
            dt = new PersonasBLL().sp_sel_personasIDBLL(rutP);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        Dictionary<string, string> persona = new Dictionary<string, string>();

        persona.Add("RUT_PERSONA", dt.Rows[0].ItemArray[0].ToString());
        persona.Add("NOMBRE", dt.Rows[0].ItemArray[1].ToString());
        persona.Add("PASSWORD", dt.Rows[0].ItemArray[2].ToString());
        persona.Add("FUNCION", dt.Rows[0].ItemArray[3].ToString());
        persona.Add("TERMINAL", dt.Rows[0].ItemArray[4].ToString());


        return persona;
    }

    protected bool ValidarCamposBusqueda()
    {
        bool isValid = true;
        var errorMessage = "Se han encontrado los siguientes errores: </br>";
        var visibilityClass = "alert alert-danger";
        var style = "display:block;";
        var classSuccess = "alert alert-success display-hide";
        var styleSuccess = "display:none;";

        int rutFlag = 0;
        int nombreFlag = 0;
        int passFlag = 0;
        int funcionFlag = 0;
        int agenciaFlag = 0;

        if (String.IsNullOrEmpty(txtRut.Text.Trim())) rutFlag = 1;
        if (String.IsNullOrEmpty(txtNombre.Text.Trim())) nombreFlag = 1;
        if (String.IsNullOrEmpty(txtPass.Text.Trim())) passFlag = 1;
        if (ddlFuncion.SelectedValue == "") funcionFlag = 1;
        if (ddlAgencia.SelectedValue == "") agenciaFlag = 1;

        if (rutFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_rut.Text, "<br/");
            isValid = false;
        }
        if (nombreFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_nombre.Text, "<br/");
            isValid = false;
        }
        if (passFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_password.Text, "<br/");
            isValid = false;
        }
        if (agenciaFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_agencia.Text, "<br/");
            isValid = false;
        }
        if (funcionFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_funcion.Text, "<br/");
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

        int rutFlag = 0;
        int nombreFlag = 0;
        int passFlag = 0;
        int funcionFlag = 0;
        int agenciaFlag = 0;

        if (String.IsNullOrEmpty(txtModRut.Text.Trim())) rutFlag = 1;
        if (String.IsNullOrEmpty(txtModNombre.Text.Trim())) nombreFlag = 1;
        if (String.IsNullOrEmpty(txtModPass.Text.Trim())) passFlag = 1;
        if (ddlModFun.SelectedValue == "") funcionFlag = 1;
        if (ddlModTerm.SelectedValue == "") agenciaFlag = 1;

        if (rutFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_rut.Text, "<br/");
            isValid = false;
        }
        if (nombreFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_nombre.Text, "<br/");
            isValid = false;
        }
        if (passFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_password.Text, "<br/");
            isValid = false;
        }
        if (agenciaFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_agencia.Text, "<br/");
            isValid = false;
        }
        if (funcionFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_funcion.Text, "<br/");
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
        txtRut.Text = "";
        txtNombre.Text = "";
        txtPass.Text = "";
        ddlAgencia.SelectedValue = "";
        ddlFuncion.SelectedValue = "";
    }
}