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

public partial class Bultos : System.Web.UI.Page
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

        DataTable dt = new BultosBLL().sp_sel_bultosBLL();

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

        pnlTablaVideos.Controls.Clear();
        pnlTablaVideos.Controls.Add(lTabla);
        pnlTablaVideos.Visible = true;
        UpdatePanel1.Update();
        UpdatePanel1.Visible = true;

    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        if (!ValidarCamposBusqueda())
        {
            cargarGrilla();
            return;
        }

        int codigo;
        string nombre;
        nombre = txtNombre.Text;
        codigo = Convert.ToInt32(txtCodigo.Text);
        DataTable dt = new DataTable();

        BultosBO bulto = new BultosBO();

        bulto.Cod_bulto = codigo;
        bulto.Desc_bulto = nombre;

        try
        {
            dt = new BultosBLL().sp_ins_bultosBLL(bulto);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        limpiarFormulario();
        cargarGrilla();
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        if (!ValidarCamposModificar())
        {
            cargarGrilla();
            return;
        }

        DataTable dt = new DataTable();
        BultosBO bultobo = new BultosBO();

        try
        {
            bultobo.Cod_bulto = Convert.ToInt32(txtCodMod.Text);
            bultobo.Desc_bulto = txtNomMod.Text;

            dt = new BultosBLL().sp_updt_bultosBLL(bultobo);

            cargarGrilla();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    [System.Web.Services.WebMethod]
    public static string eliminarBulto(string codigo)
    {
        BultosBO bulto = new BultosBO();
        bulto.Cod_bulto = Convert.ToInt32(codigo);

        DataTable dt = new DataTable();

        try
        {
           dt = new BultosBLL().sp_del_bultoBLL(bulto);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        string codstring = dt.Rows[0].ItemArray[0].ToString();

        return codstring;        
    }

    [System.Web.Services.WebMethod]
    public static Dictionary<string, string> modificarBulto(string codigo)
    {
        int id = Convert.ToInt32(codigo);

        DataTable dt = new DataTable();
        try
        {
            dt = new BultosBLL().sp_sel_bultosIDBLL(id);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        Dictionary<string, string> bulto = new Dictionary<string, string>();

        bulto.Add("Cod_bulto", dt.Rows[0].ItemArray[0].ToString());
        bulto.Add("Desc_bulto", dt.Rows[0].ItemArray[1].ToString());

        return bulto;
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
        int TipoFlag = 0;

        if (String.IsNullOrEmpty(txtCodigo.Text.Trim())) CodigoFlag = 1;
        if (String.IsNullOrEmpty(txtNombre.Text.Trim())) TipoFlag = 1;

        if (CodigoFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_codigo.Text, "<br/");
            isValid = false;
        }
        if (TipoFlag == 1)
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

    protected bool ValidarCamposModificar()
    {
        bool isValid = true;
        var errorMessage = "Se han encontrado los siguientes errores: </br>";
        var visibilityClass = "alert alert-danger";
        var style = "display:block;";
        var classSuccess = "alert alert-success display-hide";
        var styleSuccess = "display:none;";

        int CodigoFlag = 0;
        int TipoFlag = 0;

        if (String.IsNullOrEmpty(txtCodMod.Text.Trim())) CodigoFlag = 1;
        if (String.IsNullOrEmpty(txtNomMod.Text.Trim())) TipoFlag = 1;

        if (CodigoFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_codigo.Text, "<br/");
            isValid = false;
        }
        if (TipoFlag == 1)
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
        txtNombre.Text = "";

    }
}