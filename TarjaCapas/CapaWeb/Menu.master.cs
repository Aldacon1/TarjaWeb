using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Menu : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["nombre"] == null)
        {
            Response.Redirect("Login.aspx");
        }

        string permiso;

        Literal lTabla = new Literal();
        StringBuilder Menu = new StringBuilder();
        string tabla = Menu.ToString();

        DataTable dt = new DataTable();
        permiso = Session["permiso"].ToString();
        Menu.Append("<ul class='page-sidebar-menu' data-keep-expanded='false' data-auto-scroll='true' data-slide-speed='200'>");
        Menu.Append("<li>");
        Menu.Append("<a href='Principal.aspx'>");
        Menu.Append("<i class='icon-home'></i>");
        Menu.Append("<span class='title'>Inicio</span>");
        Menu.Append("</a>");
        Menu.Append("</li>");
        Menu.Append("<li>");
        Menu.Append("<a href='Login.aspx'>");
        Menu.Append("<i class='icon-power'></i>");
        Menu.Append("<span class='title'>Salir</span>");
        Menu.Append("</a>");
        Menu.Append("</li>");
        Menu.Append("<li>");
        Menu.Append("<a href='Consolidado.aspx'>");
        Menu.Append("<i class='icon-login'></i>");
        Menu.Append("<span class='title'>Consolidado</span>");
        Menu.Append("</a>");
        Menu.Append("</li>");
        Menu.Append("<li>");
        Menu.Append("<a href='ListarDespacho.aspx'>");
        Menu.Append("<i class='icon-login'></i>");
        Menu.Append("<span class='title'>Despacho</span>");
        Menu.Append("</a>");
        Menu.Append("</li>");
        Menu.Append("<li>");
        Menu.Append("<a href='Desconsolidado.aspx'>");
        Menu.Append("<i class='icon-logout'></i>");
        Menu.Append("<span class='title'>Desconsolidado</span>");
        Menu.Append("</a>");
        Menu.Append("</li>");
        if (permiso.Equals("SuperAdmin"))
        {
            Menu.Append("<li>");
            Menu.Append("<a href='javascript:;'>");
            Menu.Append("<i class='icon-settings'></i>");
            Menu.Append("<span class='title'>Mantenedores</span>");
            Menu.Append("<span class='arrow'></span>");
            Menu.Append("</a>");
            Menu.Append("<ul class='sub-menu'>");
            Menu.Append("<li>");
            Menu.Append("<a href='TerminalesDesc.aspx'>");
            Menu.Append("Terminales </a>");
            Menu.Append("</li>");
            Menu.Append("<li>");
            Menu.Append("<a href='Bultos.aspx'>");
            Menu.Append("Bultos </a>");
            Menu.Append("</li>");
            Menu.Append("<li>");
            Menu.Append("<a href='ForwardersDesc.aspx'>");
            Menu.Append("Clientes </a>");
            Menu.Append("</li>");
            Menu.Append("<li>");
            Menu.Append("<a href='IsoDesc.aspx'>");
            Menu.Append("Iso </a>");
            Menu.Append("</li>");
            Menu.Append("<li>");
            Menu.Append("<a href='FuncionesDesc.aspx'>");
            Menu.Append("Funciones </a>");
            Menu.Append("</li>");
            Menu.Append("<li>");
            Menu.Append("<a href='GruasDesc.aspx'>");
            Menu.Append("Gruas </a>");
            Menu.Append("</li>");
            Menu.Append("<li>");
            Menu.Append("<a href='NavesDesc.aspx'>");
            Menu.Append("Naves </a>");
            Menu.Append("</li>");
            Menu.Append("<li>");
            Menu.Append("<a href='PersonasDesc.aspx'>");
            Menu.Append("Personas </a>");
            Menu.Append("</li>");
            Menu.Append("<li>");
            Menu.Append("<a href='PuertosDesc.aspx'>");
            Menu.Append("Puertos </a>");
            Menu.Append("</li>");
            Menu.Append("<li>");
            Menu.Append("<a href='TipoDocumento.aspx'>");
            Menu.Append("Tipo de Documento </a>");
            Menu.Append("</li>");
            Menu.Append("</ul>");
            Menu.Append("</li>");

        }
        Menu.Append("</ul>");
        tabla = Menu.ToString();
        lTabla.Text = tabla;

        pnlMenu.Controls.Add(lTabla);
        pnlMenu.Visible = true;
    }
}
