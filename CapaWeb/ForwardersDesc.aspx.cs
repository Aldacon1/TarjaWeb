using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaBLL;
using CapaBO;
using CapaDAL;

public partial class ForwardersDesc : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        cargarForwarders();
    }

    public void cargarForwarders()
    {
        StringBuilder strblVideo = new StringBuilder();
        Literal lTabla = new Literal();
        string tabla = string.Empty;

        DataTable dt = new ForwardersBLL().sp_sel_ForwarderBLL();

        strblVideo.Append("<thead>");
        strblVideo.Append("<th>ELIMINAR</th>");
        strblVideo.Append("<th>EDITAR</th>");
        strblVideo.Append("<th>RUT</th>");
        strblVideo.Append("<th>DV</th>");
        strblVideo.Append("<th>NOMBRE</th>");
        strblVideo.Append("<th>PASS</th>");
        strblVideo.Append("<th>FONO</th>");
        strblVideo.Append("<th>EMAIL</th>");
        strblVideo.Append("</thead>");
        strblVideo.Append("<tbody>");
        foreach (DataRow row in dt.Rows)
        {
            strblVideo.Append("<tr class=odd gradeX>");
            strblVideo.Append("<td><button id=" + row["rut_cliente"] + " runat=\"server\" onclick=\"eliminar(this.id); \" class=\"btn red\" >" +
                                                 "<i class=\"fa fa-trash-o\"></i></button>" + "</td>");
            strblVideo.Append("<td><button id=" + row["rut_cliente"] + " runat=\"server\" onclick=\"modificar(this.id);\" class=\"btn blue\" >" +
                                                 "<i class=\"fa fa-edit\"></i></button>" + "</td>");
            strblVideo.Append("<td>" + row["rut_cliente"] + "</td>");
            strblVideo.Append("<td>" + row["dv_cliente"] + "</td>");
            strblVideo.Append("<td>" + row["gls_nombre_cliente"] + "</td>");
            strblVideo.Append("<td>" + row["gls_password"] + "</td>");
            strblVideo.Append("<td>" + row["n_fono"] + "</td>");
            strblVideo.Append("<td>" + row["gls_mail"] + "</td>");
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

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        if (!ValidarCamposBusqueda())
        {
            return;
        }

        DataTable dt = new DataTable();

        try
        {
            string razon, password, email;
            int rut, fono;
            razon = txtRazon.Text;
            password = txtPass.Text;
            email = txtMail.Text;
            rut = Convert.ToInt32(txtRut.Text);
            fono = Convert.ToInt32(txtFono.Text);

            ForwardersBO forwarder = new ForwardersBO();
            forwarder.Rut_cliente = rut;
            forwarder.Nombre_cliente = razon;
            forwarder.Pass_cliente = password;
            forwarder.Email_cliente = email;
            forwarder.Fono_cliente = fono;

            dt = new ForwardersBLL().sp_inst_ForwarderBLL(forwarder);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
        limpiarFormulario();
        Response.Redirect("ForwardersDesc.aspx");
    }


    protected void btnModificar_Click(object sender, EventArgs e)
    {
        if (!ValidarCamposMod())
        {
            return;
        }

        DataTable dt = new DataTable();
        ForwardersBO fw = new ForwardersBO();

        try
        {
            string razon, password, email;
            int rut, fono;
            razon = txtRazMod.Text;
            password = txtPassMod.Text;
            email = txtEmailMod.Text;
            rut = Convert.ToInt32(txtRutMod.Text);
            fono = Convert.ToInt32(txtFonoMod.Text);

            ForwardersBO forwarder = new ForwardersBO();
            forwarder.Rut_cliente = rut;
            forwarder.Nombre_cliente = razon;
            forwarder.Pass_cliente = password;
            forwarder.Email_cliente = email;
            forwarder.Fono_cliente = fono;

            dt = new ForwardersBLL().sp_updt_ForwarderBLL(forwarder);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        limpiarFormulario();
        Response.Redirect("ForwardersDesc.aspx");
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
        int razonFlag = 0;
        int passFlag = 0;
        int fonoFlag = 0;
        int emailFlag = 0;

        if (String.IsNullOrEmpty(txtRut.Text.Trim())) rutFlag = 1;
        if (String.IsNullOrEmpty(txtRazon.Text.Trim())) razonFlag = 1;
        if (String.IsNullOrEmpty(txtPass.Text.Trim())) passFlag = 1;
        if (String.IsNullOrEmpty(txtFono.Text.Trim())) fonoFlag = 1;
        if (String.IsNullOrEmpty(txtMail.Text.Trim())) emailFlag = 1;

        if (rutFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_rut.Text, "<br/");
            isValid = false;
        }
        if (razonFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_Razon.Text, "<br/");
            isValid = false;
        }
        if (passFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_pass.Text, "<br/");
            isValid = false;
        }
        if (fonoFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_fono.Text, "<br/");
            isValid = false;
        }
        if (emailFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_email.Text, "<br/");
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
        int razonFlag = 0;
        int passFlag = 0;
        int fonoFlag = 0;
        int emailFlag = 0;

        if (String.IsNullOrEmpty(txtRutMod.Text.Trim())) rutFlag = 1;
        if (String.IsNullOrEmpty(txtRazMod.Text.Trim())) razonFlag = 1;
        if (String.IsNullOrEmpty(txtPassMod.Text.Trim())) passFlag = 1;
        if (String.IsNullOrEmpty(txtFonoMod.Text.Trim())) fonoFlag = 1;
        if (String.IsNullOrEmpty(txtEmailMod.Text.Trim())) emailFlag = 1;

        if (rutFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_rut.Text, "<br/");
            isValid = false;
        }
        if (razonFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_Razon.Text, "<br/");
            isValid = false;
        }
        if (passFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_pass.Text, "<br/");
            isValid = false;
        }
        if (fonoFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_fono.Text, "<br/");
            isValid = false;
        }
        if (emailFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_email.Text, "<br/");
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


    [System.Web.Services.WebMethod]
    public static string eliminarCliente(string rut)
    {
        ForwardersBO cliente = new ForwardersBO();
        cliente.Rut_cliente = Convert.ToInt32(rut);

        DataTable dt = new ForwardersBLL().sp_del_ForwarderBLL(cliente);

        string codstring = dt.Rows[0].ItemArray[0].ToString();

        return codstring;   
    }

    [System.Web.Services.WebMethod]
    public static Dictionary<string, string> modificarCliente(string rut)
    {
        int id = Convert.ToInt32(rut);

        DataTable dt = new DataTable();
        try
        {
            dt = new ForwardersBLL().sp_selPlanDesc_forwarderBLL(id);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        Dictionary<string, string> cliente = new Dictionary<string, string>();

        cliente.Add("Rut_cliente", dt.Rows[0].ItemArray[0].ToString());
        cliente.Add("gls_nombre_cliente", dt.Rows[0].ItemArray[1].ToString());
        cliente.Add("gls_password", dt.Rows[0].ItemArray[2].ToString());
        cliente.Add("gls_mail", dt.Rows[0].ItemArray[4].ToString());
        cliente.Add("dv_cliente", dt.Rows[0].ItemArray[5].ToString());
        cliente.Add("fono", dt.Rows[0].ItemArray[3].ToString());

        return cliente;
    }

    public void setearSession(string rut)
    {
        Session["rutCliente"] = rut;
    }

    protected void limpiarFormulario()
    {
        txtRut.Text = "";
        txtRazon.Text = "";
        txtPass.Text = "";
        txtFono.Text = "";
        txtMail.Text = "";
    }
}