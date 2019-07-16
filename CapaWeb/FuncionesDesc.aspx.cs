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

public partial class FuncionesDesc : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        cargarGrilla();
        if (!IsPostBack)
        {
            llenarPermisos();
            llenarPermsMod();
        }
    }

    private void llenarPermisos()
    {
        try
        {
            ddlPermisos.DataSource = new PermisosBLL().sp_sel_PermisosBLL();
            ddlPermisos.DataTextField = "nombre";
            ddlPermisos.DataValueField = "codigo";
            ddlPermisos.DataBind();
            ddlPermisos.Items.Add(new ListItem("Seleccione una opción: ", ""));
            ddlPermisos.SelectedValue = "";
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

    public void llenarPermsMod()
    {
        try
        {
            ddlPermisoMod.DataSource = new PermisosBLL().sp_sel_PermisosBLL();
            ddlPermisoMod.DataTextField = "nombre";
            ddlPermisoMod.DataValueField = "codigo";
            ddlPermisoMod.DataBind();
            ddlPermisoMod.Items.Add(new ListItem("Seleccione una opción: ", ""));
            ddlPermisoMod.SelectedValue = "";
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

    private void cargarGrilla()
    {
        StringBuilder strblVideo = new StringBuilder();
        Literal lTabla = new Literal();
        string tabla = string.Empty;

        DataTable dt = new DataTable();

        dt = new FuncionesBLL().sp_sel_funcionesBLL();
        strblVideo.Append("<thead>");
        strblVideo.Append("<th>ELIMINAR</th>");
        strblVideo.Append("<th>EDITAR</th>");
        strblVideo.Append("<th>CODIGO</th>");
        strblVideo.Append("<th>NOMBRE</th>");
        strblVideo.Append("<th>PERMISO</th>");
        strblVideo.Append("</thead>");
        strblVideo.Append("<tbody>");
        foreach (DataRow row in dt.Rows)
        {
            strblVideo.Append("<tr class=odd gradeX>");
            strblVideo.Append("<td><button id=" + row["cod_funcion"] + " runat=\"server\" onclick=\"eliminar(this.id); \" class=\"btn red\" >" +
                                                 "<i class=\"fa fa-trash-o\"></i></button>" + "</td>");
            strblVideo.Append("<td><button id=" + row["cod_funcion"] + " runat=\"server\" onclick=\"modificar(this.id);\" class=\"btn blue\" >" +
                                                 "<i class=\"fa fa-edit\"></i></button>" + "</td>");
            strblVideo.Append("<td>" + row["cod_funcion"] + "</td>");
            strblVideo.Append("<td>" + row["gls_nombre_fun"] + "</td>");
            strblVideo.Append("<td>" + row["cod_permiso"] + "</td>");
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


    [System.Web.Services.WebMethod]
    public static string eliminarFuncion(string codigo)
    {
        int id = Convert.ToInt32(codigo);
        DataTable dt = new DataTable();
        FuncionesBO func = new FuncionesBO();
        string codigostring = "";

        try
        {
            func.Fun_cod = id;
            dt = new FuncionesBLL().sp_del_funcionesBLL(func);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        codigostring = dt.Rows[0].ItemArray[0].ToString();

        return codigostring;

    }


    [System.Web.Services.WebMethod]
    public static Dictionary<string,string> modificarFuncion(string codigo)
    {
        int id = Convert.ToInt32(codigo);
        DataTable dt = new DataTable();

        try
        {
            dt = new FuncionesBLL().sp_sel_funcionIDBLL(id);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        Dictionary<string, string> func = new Dictionary<string, string>();

        func.Add("cod_funcion", dt.Rows[0].ItemArray[0].ToString());
        func.Add("gls_nombre_funcion", dt.Rows[0].ItemArray[1].ToString());
        func.Add("cod_permiso", dt.Rows[0].ItemArray[2].ToString());

        return func;
    }


    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        if (!ValidarCamposBusqueda())
        {
            return;
        }

        FuncionesBO funcion = new FuncionesBO();

        int permiso, codigo;
        string nombre;
        codigo = Convert.ToInt32(txtCodigo.Text);
        nombre = txtNombre.Text;
        permiso = int.Parse(ddlPermisos.SelectedValue);

        funcion.Fun_cod = codigo;
        funcion.Fun_nom = nombre;
        funcion.Per_cod = permiso;

        DataTable dt = new DataTable();

        try
        {
            dt = new FuncionesBLL().sp_ins_funcionesBLL(funcion);
        }
        catch(Exception ex)
        {
            var visibilityClass = "alert alert-danger";
            var style = "display:block;";
            mensajeError.Attributes["class"] = visibilityClass;
            mensajeError.Attributes["style"] = style;
            cv_Resultado.Text = "Ocurrio un error al cargar los datos: " + ex.Message;
        }
        
        
        limpiarFormulario();
        Response.Redirect("FuncionesDesc.aspx");
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        if (!ValidarCamposMod())
        {
            return;
        }

        FuncionesBO funcion = new FuncionesBO();

        int permiso, codigo;
        string nombre;
        codigo = Convert.ToInt32(txtCodMod.Text);
        nombre = txtNomMod.Text;
        permiso = int.Parse(ddlPermisoMod.SelectedValue);

        funcion.Fun_cod = codigo;
        funcion.Fun_nom = nombre;
        funcion.Per_cod = permiso;

        DataTable dt = new DataTable();

        try
        {
            dt = new FuncionesBLL().sp_updt_funcionesBLL(funcion);
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
        Response.Redirect("FuncionesDesc.aspx");
    }


    public bool ValidarCamposBusqueda()
    {
        bool isValid = true;
        var errorMessage = "Se han encontrado los siguientes errores: </br>";
        var visibilityClass = "alert alert-danger";
        var style = "display:block;";
        var classSuccess = "alert alert-success display-hide";
        var styleSuccess = "display:none;";

        int nombreFlag = 0;
        int PermisoFlag = 0;

        if (String.IsNullOrEmpty(txtNombre.Text.Trim())) nombreFlag = 1;
        if (ddlPermisos.SelectedItem.Text == "Seleccione una opción: ") PermisoFlag = 1;


        if (nombreFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_nombre.Text, "<br/");
            isValid = false;
        }

        if (PermisoFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_permiso.Text, "<br/");
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

        int nombreFlag = 0;
        int PermisoFlag = 0;

        if (String.IsNullOrEmpty(txtNomMod.Text.Trim())) nombreFlag = 1;
        if (ddlPermisoMod.SelectedItem.Text == "Seleccione una opción: ") PermisoFlag = 1;


        if (nombreFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_nombre.Text, "<br/");
            isValid = false;
        }

        if (PermisoFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_permiso.Text, "<br/");
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
        txtNombre.Text = "";
        ddlPermisos.SelectedValue = "";
    }
}