using CapaBO;
using CapaBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

public partial class Desconsolidado : System.Web.UI.Page
{
    string CorrelativoPlan = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["nombre"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            llenarGrilla();
            llenarDdlTerminal();
            llenarDdlNaves();
            llenarDdlPuertos();
            llenarDdlCliente();
            llenarDdlIsoCont();
            llenarDdlTarjador();
            llenarDdlTerminalMod();
            llenarDdlNavesMod();
            llenarDdlPuertosMod();
            llenarDdlClienteMod();
            llenarDdlIsoContMod();
            llenarDdlTarjadorMod();
        }
    }

    public void llenarDdlTerminal()
    {
        try
        {
            ddlTerminal.DataSource = new TerminalesBLL().sp_sel_terminalesBLL();
            ddlTerminal.DataValueField = "CODIGO";
            ddlTerminal.DataTextField = "TERMINAL";
            ddlTerminal.DataBind();
            ddlTerminal.Items.Add(new ListItem("Seleccione", ""));
            ddlTerminal.SelectedValue = Session["terminal"].ToString();
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

    public void llenarDdlTerminalMod()
    {
        try
        {
            ddlTermMod.DataSource = new TerminalesBLL().sp_sel_terminalesBLL();
            ddlTermMod.DataValueField = "CODIGO";
            ddlTermMod.DataTextField = "TERMINAL";
            ddlTermMod.DataBind();
            ddlTermMod.Items.Add(new ListItem("Seleccione", ""));
            ddlTermMod.SelectedValue = Session["terminal"].ToString();
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

    protected void llenarDdlNaves()
    {
        try
        {
            ddlNaves.DataSource = new NavesBLL().sp_sel_navesBLL();
            ddlNaves.DataValueField = "cod_nave";
            ddlNaves.DataTextField = "gls_nombre_nave";
            ddlNaves.DataBind();
            ddlNaves.Items.Add(new ListItem("Seleccione", ""));
            ddlNaves.SelectedValue = "";
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

    protected void llenarDdlNavesMod()
    {
        try
        {
            ddlNaveMod.DataSource = new NavesBLL().sp_sel_navesBLL();
            ddlNaveMod.DataValueField = "cod_nave";
            ddlNaveMod.DataTextField = "gls_nombre_nave";
            ddlNaveMod.DataBind();
            ddlNaveMod.Items.Add(new ListItem("Seleccione", ""));
            ddlNaveMod.SelectedValue = "";
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

    protected void llenarDdlPuertos()
    {
        try
        {
            ddlOrigen.DataSource = ddlDestino.DataSource = new PuertoBLL().sp_sel_puertoBLL();
            ddlOrigen.DataValueField = ddlDestino.DataValueField = "CODIGO";
            ddlOrigen.DataTextField = ddlDestino.DataTextField = "NOMBRE";
            ddlOrigen.DataBind();
            ddlDestino.DataBind();
            ddlOrigen.Items.Add(new ListItem("Seleccione", ""));
            ddlDestino.Items.Add(new ListItem("Seleccione", ""));

            string terminal = Session["terminal"].ToString();

            switch (terminal)
            {
                case "PLACILLA": ddlDestino.SelectedValue = "CLVAP";
                    break;
                case "SAN ANTONIO": ddlDestino.SelectedValue = "CLSAI";
                    break;
                case "IQUIQUE": ddlDestino.SelectedValue = "CLIQQ";
                    break;
                case "ARICA": ddlDestino.SelectedValue = "CLARI";
                    break;
                case "PTO CHACABUCO": ddlDestino.SelectedValue = "CLCHB";
                    break;
            }

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

    protected void llenarDdlPuertosMod()
    {
        try
        {
            ddlPueOrMod.DataSource = ddlPueDesMod.DataSource = new PuertoBLL().sp_sel_puertoBLL();
            ddlPueOrMod.DataValueField = ddlPueDesMod.DataValueField = "CODIGO";
            ddlPueOrMod.DataTextField = ddlPueDesMod.DataTextField = "NOMBRE";
            ddlPueOrMod.DataBind();
            ddlPueDesMod.DataBind();
            ddlPueOrMod.Items.Add(new ListItem("Seleccione", ""));
            ddlPueDesMod.Items.Add(new ListItem("Seleccione", ""));

            string terminal = Session["terminal"].ToString();

            switch (terminal)
            {
                case "PLACILLA": ddlPueDesMod.SelectedValue = "CLVAP";
                    break;
                case "SAN ANTONIO": ddlPueDesMod.SelectedValue = "CLSAI";
                    break;
                case "IQUIQUE": ddlPueDesMod.SelectedValue = "CLIQQ";
                    break;
                case "ARICA": ddlPueDesMod.SelectedValue = "CLARI";
                    break;
                case "PTO CHACABUCO": ddlPueDesMod.SelectedValue = "CLCHB";
                    break;
            }

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

    protected void llenarDdlCliente()
    {
        try
        {
            ddlCliente.DataSource = new ForwardersBLL().sp_sel_ForwarderBLL();
            ddlCliente.DataValueField = "rut_cliente";
            ddlCliente.DataTextField = "gls_nombre_cliente";
            ddlCliente.DataBind();
            ddlCliente.Items.Add(new ListItem("Seleccione", ""));
            ddlCliente.SelectedValue = "";
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

    protected void llenarDdlClienteMod()
    {
        try
        {
            ddlClienteMod.DataSource = new ForwardersBLL().sp_sel_ForwarderBLL();
            ddlClienteMod.DataValueField = "rut_cliente";
            ddlClienteMod.DataTextField = "gls_nombre_cliente";
            ddlClienteMod.DataBind();
            ddlClienteMod.Items.Add(new ListItem("Seleccione", ""));
            ddlClienteMod.SelectedValue = "";
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


    protected void llenarDdlIsoCont()
    {
        try
        {
            ddlISO.DataSource = new IsoDescBLL().sp_sel_isoBLL();
            ddlISO.DataValueField = "cod_iso";
            ddlISO.DataTextField = "desc_iso";
            ddlISO.DataBind();
            ddlISO.Items.Add(new ListItem("Seleccione", ""));
            ddlISO.SelectedValue = "";
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

    protected void llenarDdlIsoContMod()
    {
        try
        {
            ddlIsoMod.DataSource = new IsoDescBLL().sp_sel_isoBLL();
            ddlIsoMod.DataValueField = "cod_iso";
            ddlIsoMod.DataTextField = "desc_iso";
            ddlIsoMod.DataBind();
            ddlIsoMod.Items.Add(new ListItem("Seleccione", ""));
            ddlIsoMod.SelectedValue = "";
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

    protected void llenarDdlTarjador()
    {
        try
        {
            string terminal = Session["terminal"].ToString();
            ddlTarjador.DataSource = new PersonasBLL().sp_sel_tarjadorBLL(terminal);
            ddlTarjador.DataValueField = "rut_persona";
            ddlTarjador.DataTextField = "gls_nombre_pers";
            ddlTarjador.DataBind();
            ddlTarjador.Items.Add(new ListItem("Seleccione", ""));
            ddlTarjador.SelectedValue = "";
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

    protected void llenarDdlTarjadorMod()
    {
        try
        {
            string terminal = Session["terminal"].ToString();
            ddlTarjadorMod.DataSource = new PersonasBLL().sp_sel_tarjadorBLL(terminal);
            ddlTarjadorMod.DataValueField = "rut_persona";
            ddlTarjadorMod.DataTextField = "gls_nombre_pers";
            ddlTarjadorMod.DataBind();
            ddlTarjadorMod.Items.Add(new ListItem("Seleccione", ""));
            ddlTarjadorMod.SelectedValue = "";
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

    protected void llenarGrilla()
    {
        string permiso = Session["permiso"].ToString();
        string terminal = Session["terminal"].ToString();
        StringBuilder strblVideo = new StringBuilder();
        Literal lTabla = new Literal();
        string tabla = string.Empty;


        DataTable dt = new DataTable();

        try
        {
            dt = new PlanificacionDescBLL().sp_sel_planDescBLL();
        }
        catch (Exception ex)
        {
            throw ex;
        }

        if (!permiso.Equals("Administrador"))
        {
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
                    if (terminal.Equals(row["terminal"].ToString()))
                    {
                        DateTime date = new DateTime();
                        date = Convert.ToDateTime(row["FECHA"]);
                        strblVideo.Append("<tr class=odd gradeX>");
                        strblVideo.Append("<td><button id=" + row["corr_planificacion"] + " runat=\"server\" onclick=\"eliminar(this.id); \" class=\"btn red\" >" +
                                                             "<i class=\"fa fa-trash-o\"></i></button>" + "</td>");
                        strblVideo.Append("<td><button id=" + row["corr_planificacion"] + " runat=\"server\" onclick=\"modificar(this.id);\" class=\"btn blue\" >" +
                                                             "<i class=\"fa fa-edit\"></i></button>" + "</td>");
                        strblVideo.Append("<td>" + row["gls_bl"] + "</td>");
                        strblVideo.Append("<td>" + row["CLIENTE"] + "</td>");
                        strblVideo.Append("<td>" + row["NAVE"] + "</td>");
                        strblVideo.Append("<td>" + row["CONTENEDOR"] + "</td>");
                        strblVideo.Append("<td>" + date.Day + "/" + date.Month + "/" + date.Year + "</td>");
                        strblVideo.Append("<td>" + row["terminal"] + "</td>");
                        strblVideo.Append("<td>" + row["desbloqueo"] + "</td>");
                        strblVideo.Append("<td>" + row["estado"] + "</td>");
                        if (row["estado"].ToString().Equals("Cerradas"))
                        {
                            strblVideo.Append("<td><button id=" + row["corr_planificacion"] + " runat=\"server\" onclick=\"exportar(this.id); \" class=\"btn blue\" >" +
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
                    if (terminal.Equals(row["terminal"].ToString()))
                    {
                        DateTime date = new DateTime();
                        date = Convert.ToDateTime(row["FECHA"]);
                        strblVideo.Append("<tr class=odd gradeX>");
                        strblVideo.Append("<td>" + row["gls_bl"] + "</td>");
                        strblVideo.Append("<td>" + row["CLIENTE"] + "</td>");
                        strblVideo.Append("<td>" + row["NAVE"] + "</td>");
                        strblVideo.Append("<td>" + row["CONTENEDOR"] + "</td>");
                        strblVideo.Append("<td>" + date.Day + "/" + date.Month + "/" + date.Year + "</td>");
                        strblVideo.Append("<td>" + row["terminal"] + "</td>");
                        strblVideo.Append("<td>" + row["desbloqueo"] + "</td>");
                        strblVideo.Append("<td>" + row["estado"] + "</td>");
                        if (row["estado"].ToString().Equals("Cerradas"))
                        {
                            strblVideo.Append("<td><button id=" + row["corr_planificacion"] + " runat=\"server\" onclick=\"exportar(this.id); \" class=\"btn blue\" >" +
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
        }
        else
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
                strblVideo.Append("<td><button id=" + row["corr_planificacion"] + " runat=\"server\" onclick=\"eliminar(this.id); \" class=\"btn red\" >" +
                                                     "<i class=\"fa fa-trash-o\"></i></button>" + "</td>");
                strblVideo.Append("<td><button id=" + row["corr_planificacion"] + " runat=\"server\" onclick=\"modificar(this.id);\" class=\"btn blue\" >" +
                                                     "<i class=\"fa fa-edit\"></i></button>" + "</td>");
                strblVideo.Append("<td>" + row["gls_bl"] + "</td>");
                strblVideo.Append("<td>" + row["CLIENTE"] + "</td>");
                strblVideo.Append("<td>" + row["NAVE"] + "</td>");
                strblVideo.Append("<td>" + row["CONTENEDOR"] + "</td>");
                strblVideo.Append("<td>" + date.Day + "/" + date.Month + "/" + date.Year + "</td>");
                strblVideo.Append("<td>" + row["terminal"] + "</td>");
                strblVideo.Append("<td>" + row["desbloqueo"] + "</td>");
                strblVideo.Append("<td>" + row["estado"] + "</td>");
                if (row["estado"].ToString().Equals("Cerradas"))
                {
                    strblVideo.Append("<td><button id=" + row["corr_planificacion"] + " runat=\"server\" onclick=\"exportar(this.id); \" class=\"btn blue\" >" +
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
            llenarGrilla();
            return;
        }

        DateTime date = DateTime.Today;
        Random rnd = new Random();
        CorrelativoPlan = date.Year.ToString() + date.Month.ToString() + date.Day.ToString() + date.Hour.ToString() + date.Minute.ToString() + date.Second.ToString() + "-" + date.Millisecond.ToString() + rnd.Next(0, 99999);

        DataTable dt = new DataTable();
        PlanificacionDescBO plan = new PlanificacionDescBO();

        plan.Bl = txtBL.Text;
        plan.Mddt = txtMddt.Text;
        plan.Cod_manifiesto = CorrelativoPlan;
        plan.Cod_agencia = Convert.ToInt32(ddlTerminal.SelectedValue);
        plan.Cod_nave = ddlNaves.SelectedValue;
        plan.Cod_viaje = Convert.ToInt32(txtViaje.Text);
        plan.Pue_codO = ddlOrigen.SelectedValue;
        plan.Pue_codD = ddlDestino.SelectedValue;
        plan.Rut_cliente = Convert.ToInt32(ddlCliente.SelectedValue);
        plan.Cod_iso = ddlISO.SelectedValue;
        plan.Estado_tarja = 1;
        plan.Cod_contenedor = txtContenedor.Text + txtContenedorNum.Text + txtContenedorDV.Text;
        plan.Sello1 = txtSello1.Text;
        plan.Sello2 = txtSello2.Text;
        plan.Sello3 = txtSello3.Text;
        plan.Fecha = DateTime.ParseExact(txtFecha.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        plan.HoraI = TimeSpan.ParseExact(txtHoraI.Text, @"h\:mm", CultureInfo.InvariantCulture);
        plan.HoraT = TimeSpan.ParseExact(txtHoraT.Text, @"h\:mm", CultureInfo.InvariantCulture);
        if (ddlTarjador.SelectedValue != "")
        {
            plan.Rut_tarjador = Convert.ToInt32(ddlTarjador.SelectedValue);
        }
        else
        {
            plan.Rut_tarjador = 0;
        }
        DateTime pass = DateTime.Today;
        plan.Desbloqueo_sello = pass.Month.ToString() + pass.Day.ToString();

        try
        {
            dt = new PlanificacionDescBLL().sp_ins_planDescBLL(plan);

        }
        catch (Exception ex)
        {
            throw new Exception("Ha ocurrido el siguiente error: " + ex.ToString());
        }

        llenarGrilla();
        limpiarFormulario();
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        if (!ValidarCamposMod())
        {
            return;
        }

        DateTime date = DateTime.Today;
        Random rnd = new Random();
        CorrelativoPlan = date.Year.ToString() + date.Month.ToString() + date.Day.ToString() + date.Hour.ToString() + date.Minute.ToString() + date.Second.ToString() + "-" + date.Millisecond.ToString() + rnd.Next(0, 99999);

        DataTable dt = new DataTable();
        PlanificacionDescBO plan = new PlanificacionDescBO();

        plan.Bl = txtBlMod.Text;
        plan.Mddt = txtManoMod.Text;
        plan.Cod_manifiesto = corrPlan.Text;
        plan.Cod_agencia = Convert.ToInt32(ddlTermMod.SelectedValue);
        plan.Cod_nave = ddlNaveMod.SelectedValue;
        plan.Cod_viaje = Convert.ToInt32(txtViajeMod.Text);
        plan.Pue_codO = ddlPueOrMod.SelectedValue;
        plan.Pue_codD = ddlPueDesMod.SelectedValue;
        plan.Rut_cliente = Convert.ToInt32(ddlClienteMod.SelectedValue);
        plan.Cod_iso = ddlIsoMod.SelectedValue;
        plan.Estado_tarja = 1;
        plan.Cod_contenedor = txtNumContMod.Text + txtSiglaContMod.Text + txtDvContMod.Text;
        plan.Sello1 = txtSello1Mod.Text;
        plan.Sello2 = txtSello2Mod.Text;
        plan.Sello3 = txtSello3Mod.Text;
        plan.Fecha = DateTime.ParseExact(txtFechaMod.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        plan.HoraI = TimeSpan.ParseExact(txtHoraIMod.Text, @"h\:mm", CultureInfo.InvariantCulture);
        plan.HoraT = TimeSpan.ParseExact(txtHoraTMod.Text, @"h\:mm", CultureInfo.InvariantCulture);
        if (ddlTarjador.SelectedValue != "")
        {
            plan.Rut_tarjador = Convert.ToInt32(ddlTarjadorMod.SelectedValue);
        }
        else
        {
            plan.Rut_tarjador = 0;
        }
        DateTime pass = DateTime.Today;
        plan.Desbloqueo_sello = pass.Month.ToString() + pass.Day.ToString();

        try
        {
            dt = new PlanificacionDescBLL().sp_updt_planDescBLL(plan);

        }
        catch (Exception ex)
        {
            throw new Exception("Ha ocurrido el siguiente error: " + ex.ToString());
        }

        llenarGrilla();
    }

    public bool ValidarCamposBusqueda()
    {
        bool isValid = true;
        var errorMessage = "Se han encontrado los siguientes errores: </br>";
        var visibilityClass = "alert alert-danger";
        var style = "display:block;";
        var classSuccess = "alert alert-success display-hide";
        var styleSuccess = "display:none;";


        int TerminalFlag = 0;
        int NaveFlag = 0;
        int ViajeFlag = 0;
        int PuertoOFlag = 0;
        int PuertoDFlag = 0;
        int ClienteFlag = 0;
        int ContenedorFlag = 0;
        int IsoFlag = 0;
        int SelloFlag = 0;
        int FechaFlag = 0;
        int HoraIFlag = 0;
        int HoraTFlag = 0;

        if (ddlTerminal.SelectedItem.Text == "Seleccione") TerminalFlag = 1;
        if (ddlNaves.SelectedValue == "") NaveFlag = 1;
        if (String.IsNullOrEmpty(txtViaje.Text.Trim())) ViajeFlag = 1;
        if (ddlOrigen.SelectedValue == "") PuertoOFlag = 1;
        if (ddlDestino.SelectedValue == "") PuertoDFlag = 1;
        if (ddlCliente.SelectedValue == "") ClienteFlag = 1;
        if (String.IsNullOrEmpty(txtContenedor.Text.Trim()) || String.IsNullOrEmpty(txtContenedorNum.Text.Trim()) || String.IsNullOrEmpty(txtContenedorDV.Text.Trim())) ContenedorFlag = 1;
        if (ddlISO.SelectedValue == "") IsoFlag = 1;
        if (String.IsNullOrEmpty(txtSello1.Text.Trim())) SelloFlag = 1;
        if (String.IsNullOrEmpty(txtFecha.Text.Trim()))
        {
            FechaFlag = 1;
        }
        else
        {
            DateTime fecha = DateTime.ParseExact(txtFecha.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            if (fecha < DateTime.Today.Date) FechaFlag = 1;
        }
        if (String.IsNullOrEmpty(txtHoraI.Text.Trim())) HoraIFlag = 1;
        if (String.IsNullOrEmpty(txtHoraT.Text.Trim())) HoraTFlag = 1;


        if (TerminalFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_Terminal.Text, "<br/");
            isValid = false;
        }
        if (NaveFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_Nave.Text, "<br/");
            isValid = false;
        }
        if (ViajeFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_viaje.Text, "<br/");
            isValid = false;
        }
        if (PuertoOFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_puertoO.Text, "<br/");
            isValid = false;
        }
        if (PuertoDFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_puertoD.Text, "<br/");
            isValid = false;
        }
        if (ClienteFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_cliente.Text, "<br/");
            isValid = false;
        }
        if (ContenedorFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_contenedor.Text, "<br/");
            isValid = false;
        }
        if (IsoFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_iso.Text, "<br/");
            isValid = false;
        }
        if (SelloFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_sello.Text, "<br/");
            isValid = false;
        }
        if (FechaFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_fecha.Text, "<br/");
            isValid = false;
        }
        if (HoraIFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_horai.Text, "<br/");
            isValid = false;
        }
        if (HoraTFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_horat.Text, "<br/");
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


        int TerminalFlag = 0;
        int NaveFlag = 0;
        int ViajeFlag = 0;
        int PuertoOFlag = 0;
        int PuertoDFlag = 0;
        int ClienteFlag = 0;
        int ContenedorFlag = 0;
        int IsoFlag = 0;
        int SelloFlag = 0;
        int FechaFlag = 0;
        int HoraIFlag = 0;
        int HoraTFlag = 0;

        if (ddlTermMod.SelectedItem.Text == "Seleccione") TerminalFlag = 1;
        if (ddlNaveMod.SelectedValue == "") NaveFlag = 1;
        if (String.IsNullOrEmpty(txtViajeMod.Text.Trim())) ViajeFlag = 1;
        if (ddlPueOrMod.SelectedValue == "") PuertoOFlag = 1;
        if (ddlPueDesMod.SelectedValue == "") PuertoDFlag = 1;
        if (ddlClienteMod.SelectedValue == "") ClienteFlag = 1;
        if (String.IsNullOrEmpty(txtNumContMod.Text.Trim()) || String.IsNullOrEmpty(txtSiglaContMod.Text.Trim()) || String.IsNullOrEmpty(txtDvContMod.Text.Trim())) ContenedorFlag = 1;
        if (ddlIsoMod.SelectedValue == "") IsoFlag = 1;
        if (String.IsNullOrEmpty(txtSello1Mod.Text.Trim())) SelloFlag = 1;
        if (String.IsNullOrEmpty(txtFechaMod.Text.Trim()))
        {
            FechaFlag = 1;
        }
        else
        {
            DateTime fecha = DateTime.ParseExact(txtFechaMod.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            if (fecha < DateTime.Today.Date) FechaFlag = 1;
        }
        if (String.IsNullOrEmpty(txtHoraIMod.Text.Trim())) HoraIFlag = 1;
        if (String.IsNullOrEmpty(txtHoraTMod.Text.Trim())) HoraTFlag = 1;


        if (TerminalFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_Terminal.Text, "<br/");
            isValid = false;
        }
        if (NaveFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_Nave.Text, "<br/");
            isValid = false;
        }
        if (ViajeFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_viaje.Text, "<br/");
            isValid = false;
        }
        if (PuertoOFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_puertoO.Text, "<br/");
            isValid = false;
        }
        if (PuertoDFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_puertoD.Text, "<br/");
            isValid = false;
        }
        if (ClienteFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_cliente.Text, "<br/");
            isValid = false;
        }
        if (ContenedorFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_contenedor.Text, "<br/");
            isValid = false;
        }
        if (IsoFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_iso.Text, "<br/");
            isValid = false;
        }
        if (SelloFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_sello.Text, "<br/");
        }
        if (FechaFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_fecha.Text, "<br/");
            isValid = false;
        }
        if (HoraIFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_horai.Text, "<br/");
            isValid = false;
        }
        if (HoraTFlag == 1)
        {
            errorMessage = string.Concat(errorMessage, " - ", lbl_mensaje_horat.Text, "<br/");
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
        txtBL.Text = "";
        txtMddt.Text = "";
        ddlTerminal.SelectedValue = "";
        ddlNaves.SelectedValue = "";
        txtViaje.Text = "";
        ddlOrigen.SelectedValue = "";
        ddlDestino.SelectedValue = "";
        ddlCliente.SelectedValue = "";
        txtContenedor.Text = "";
        ddlISO.SelectedValue = "";
        txtSello1.Text = "";
        txtSello2.Text = "";
        txtSello3.Text = "";
    }

    [System.Web.Services.WebMethod]
    public static string eliminarPlanDesc(string corr_plan)
    {
        DataTable dt;
        try
        {
            dt = new PlanificacionDescBLL().sp_del_planDescBLL(corr_plan);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        string codstring = dt.Rows[0].ItemArray[0].ToString();

        return codstring;
    }

    [System.Web.Services.WebMethod]
    public static Dictionary<string, string> modificarPlanDesc(string corr_plan)
    {
        DataTable dt = new DataTable();
        try
        {
            dt = new PlanificacionDescBLL().sp_selPlanDescIDBLL(corr_plan);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        Dictionary<string, string> plan = new Dictionary<string, string>();

        var contenedor = dt.Rows[0].ItemArray[4].ToString();

        plan.Add("corr_planificacion", dt.Rows[0].ItemArray[0].ToString().Trim());
        plan.Add("gls_bl", dt.Rows[0].ItemArray[1].ToString().Trim());
        plan.Add("cod_puerto_or", dt.Rows[0].ItemArray[2].ToString().Trim());
        plan.Add("cod_puerto_dest", dt.Rows[0].ItemArray[3].ToString().Trim());
        plan.Add("numcont", contenedor.Substring(0, 4).Trim());
        plan.Add("siglacont", contenedor.Substring(4, 6).Trim());
        plan.Add("dvCont", contenedor.Substring(10, 1).Trim());
        plan.Add("cod_iso", dt.Rows[0].ItemArray[5].ToString().Trim());
        plan.Add("gls_sello1", dt.Rows[0].ItemArray[6].ToString().Trim());
        plan.Add("gls_sello2", dt.Rows[0].ItemArray[7].ToString().Trim());
        plan.Add("gls_sello3", dt.Rows[0].ItemArray[8].ToString().Trim());
        plan.Add("rut_cliente", dt.Rows[0].ItemArray[9].ToString().Trim());
        //plan.Add("fecha", dt.Rows[0].ItemArray[10].ToString().Substring(0, 8).Trim());
        plan.Add("horaI", dt.Rows[0].ItemArray[11].ToString().Substring(0, 5).Trim());
        plan.Add("horaT", dt.Rows[0].ItemArray[12].ToString().Substring(0, 5).Trim());
        plan.Add("mano_trabajo", dt.Rows[0].ItemArray[13].ToString().Trim());
        plan.Add("cod_nave", dt.Rows[0].ItemArray[14].ToString().Trim());
        plan.Add("n_viaje", dt.Rows[0].ItemArray[15].ToString().Trim());
        plan.Add("cod_terminal", dt.Rows[0].ItemArray[16].ToString().Trim());
        plan.Add("n_estado", dt.Rows[0].ItemArray[17].ToString().Trim());
        plan.Add("desbloqueo", dt.Rows[0].ItemArray[18].ToString().Trim());
        plan.Add("rut_tarjador", dt.Rows[0].ItemArray[19].ToString().Trim());

        return plan;
    }
}