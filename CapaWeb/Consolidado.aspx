<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.master" AutoEventWireup="true" CodeFile="Consolidado.aspx.cs" Inherits="Consolidado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cssReferences" runat="Server">
    <link href="assets/global/plugins/bootstrap-datepicker/css/bootstrap-datepicker.css" rel="stylesheet" />
    <link href="assets/global/plugins/bootstrap-timepicker/css/bootstrap-timepicker.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="assets/global/plugins/select2/select2.css" />
    <link rel="stylesheet" type="text/css" href="assets/global/plugins/datatables/plugins/bootstrap/dataTables.bootstrap.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-md-12">
            <asp:UpdatePanel runat="server" ID="upErrorFFWW">
                <ContentTemplate>
                    <div class="alert alert-danger display-hide" id="mensajeError" runat="server" style="display: none">
                        <button class="close" data-close="alert">
                        </button>
                        <asp:Label runat="server" ID="cv_Resultado" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:UpdatePanel runat="server" ID="upSuccess">
                <ContentTemplate>
                    <div class="alert alert-success display-hide" id="mensajeSuccess" runat="server" style="display: none">
                        <button class="close" data-close="alert">
                        </button>
                        <asp:Label runat="server" ID="lblSuccess" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="row">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div class="col-md-12">
                    <div class="portlet box blue-steel">
                        <div class="portlet-title">
                            <div class="caption">
                                Consolidado
                            </div>
                        </div>
                        <div class="portlet-body">
                            <table class='table table-striped table-hover table-bordered dataTable no-footer' id="sample_2">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:Panel runat="server" ID="pnlTablaVideos">
                                            <asp:PlaceHolder ID="pHolderVideos" runat="server"></asp:PlaceHolder>
                                        </asp:Panel>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </table>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="row">
        <div class="col-md-6">
            <a class="btn default" data-toggle="modal" href="#responsive">Agregar Planificación </a>
        </div>
    </div>

    <!-- Modal Agregar -->
    <div id="responsive" class="modal fade" tabindex="-1" aria-hidden="true" style="display: none;">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <%--<button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>--%>
                    <h4 class="modal-title">Nueva Planificación</h4>
                </div>
                <div class="modal-body">
                    <div class="slimScrollDiv">
                        <div class="scroller" data-always-visible="1" data-rail-visible1="1" data-initialized="1">
                            <div class="col-md-12">
                                <div class="portlet box blue-steel">
                                    <div class="portlet-title">
                                    </div>
                                    <div class="portlet-body form">
                                        <div class="form-body" id="DivMdlEncabezado">
                                            <div class="form-group">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="lblNroTarja" runat="server" Visible="false"></asp:Label>
                                                        <label class="control-label">
                                                            Cliente<span class="required">*</span>
                                                        </label>
                                                        <asp:DropDownList ID="ddlCliente" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="">Seleccione</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:Label ID="lbl_mensaje_Cliente" runat="server" ForeColor="Red" Text="Seleccione un cliente"
                                                            Visible="false"></asp:Label>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <label class="control-label">
                                                            Fecha<span class="required">*</span></label>
                                                        <asp:TextBox runat="server" ID="txtFecha" CssClass="form-control date-picker" />
                                                        <asp:Label ID="lbl_mensaje_fecha" runat="server" ForeColor="Red" Text="La fecha ingresada debe ser desde hoy en adelante"
                                                            Visible="false"></asp:Label>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <label class="control-label">
                                                            Reserva<span class="required">*</span>
                                                        </label>
                                                        <asp:TextBox ID="txtReserva" runat="server" CssClass="form-control" onKeyUp="this.value=this.value.toUpperCase();">
                                                        </asp:TextBox>
                                                        <asp:Label ID="lbl_mensaje_reserva" runat="server" ForeColor="Red" Text="Reserva es obligatoria"
                                                            Visible="false"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <label class="control-label">
                                                            Destino<span class="required">*</span>
                                                        </label>
                                                        <asp:DropDownList ID="ddlDestino" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="">Seleccione</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:Label ID="lbl_mensaje_destino" runat="server" ForeColor="Red" Text="Debe seleccionar un destino"
                                                            Visible="false"></asp:Label>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <label class="control-label">
                                                            Origen<span class="required">*</span>
                                                        </label>
                                                        <asp:DropDownList ID="ddlOrigen" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="">Seleccione</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:Label ID="lbl_mensaje_origen" runat="server" ForeColor="Red" Text="Debe seleccionar un origen"
                                                            Visible="false"></asp:Label>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <label class="control-label">
                                                            Estado Viaje<span class="required">*</span>
                                                        </label>
                                                        <asp:TextBox ID="txtViaje" runat="server" CssClass="form-control" onkeydown="return jsDecimals(event);"></asp:TextBox>
                                                        <asp:Label ID="lbl_mensaje_estado" runat="server" ForeColor="Red" Text="Debe Seleccionar el estado del viaje"
                                                            Visible="false"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="row">
                                                    <div class="col-md-3">
                                                        <label class="control-label">
                                                            Nave<span class="required">*</span>
                                                        </label>
                                                        <asp:DropDownList ID="ddlNaves" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="">Seleccione</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:Label ID="lbl_mensaje_nave" runat="server" ForeColor="Red" Text="Debe seleccionar una nave"
                                                            Visible="false"></asp:Label>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <label class="control-label">
                                                            Codigo ISO<span class="required">*</span>
                                                        </label>
                                                        <asp:DropDownList ID="ddlISO" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="">Seleccione</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:Label ID="lbl_mensaje_iso" runat="server" ForeColor="Red" Text="Seleccione un codigo ISO"
                                                            Visible="false"></asp:Label>
                                                    </div>
                                                    <div class="col-md-5">
                                                        <label class="col-md-12 control-label">
                                                            Contenedor<span class="required">*</span></label>
                                                        <div class="col-md-4">
                                                            <asp:TextBox runat="server" ID="txtContenedor" CssClass="form-control" onKeyUp="this.value=this.value.toUpperCase();" MaxLength="4" />
                                                        </div>
                                                        <div class="col-md-5">
                                                            <asp:TextBox ID="txtContenedorNum" runat="server" CssClass="form-control" onkeydown="return jsDecimals(event);" MaxLength="6"></asp:TextBox>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <asp:TextBox ID="txtContenedorDV" runat="server" CssClass="form-control" onkeydown="return jsDecimals(event);" MaxLength="1"></asp:TextBox><br />
                                                        </div>

                                                        <asp:Label ID="lbl_mensaje_contenedor" runat="server" ForeColor="Red" Text="Debe ingresar el codigo del contenedor"
                                                            Visible="false"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <label class="control-label">
                                                            Capacidad(m3)<span class="required">*</span>
                                                        </label>
                                                        <asp:TextBox ID="txtCapacidad" runat="server" CssClass="form-control" onkeydown="return jsDecimals(event);">
                                                        </asp:TextBox>
                                                        <asp:Label ID="lbl_mensaje_capacidad" runat="server" ForeColor="Red" Text="Ingrese la capacidad del contenedor"
                                                            Visible="false"></asp:Label>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <label class="control-label">
                                                            Sello<span class="required">*</span>
                                                        </label>
                                                        <asp:TextBox ID="txtSello" runat="server" CssClass="form-control" onKeyUp="this.value=this.value.toUpperCase();"></asp:TextBox>
                                                        <asp:Label ID="lbl_mensaje_sello" runat="server" ForeColor="Red" Text="Debe ingresar el sello del contenedor"
                                                            Visible="false"></asp:Label>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <label class="control-label">
                                                            Tarjador<span class="required">*</span>
                                                        </label>
                                                        <asp:DropDownList ID="ddlTarjador" runat="server" CssClass="form-control"></asp:DropDownList>
                                                        <asp:Label ID="lbl_mensaje_tarjador" runat="server" ForeColor="Red" Text="Debe seleccionar un tarjador"
                                                            Visible="false"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label class="control-label">
                                                                Terminal<span class="required">*</span>
                                                            </label>
                                                            <asp:DropDownList ID="ddlTerminal" runat="server" CssClass="form-control">
                                                            </asp:DropDownList><br />
                                                            <asp:Label ID="lbl_mensaje_Terminal" runat="server" ForeColor="Red" Text="Terminal es obligatorio"
                                                                Visible="false"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="row">
                                                    <div class="col-md-8">
                                                        <div class="col-md-9">
                                                            <br />
                                                            <asp:LinkButton runat="server" CssClass="btn blue" CausesValidation="False" OnClick="btn_GrabarPlanificacion">Grabar</asp:LinkButton>
                                                            <asp:LinkButton runat="server" CssClass="btn blue" CausesValidation="False" OnClick="btn_InicializarPlanificacion">Agregar</asp:LinkButton>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="portlet box blue-steel">
                                    <div class="portlet-body form">
                                        <div class="form-body" id="DivMdlDocumento">
                                            <div class="form-group">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <label class="control-label">
                                                            Documento<span class="required">*</span>
                                                        </label>
                                                        <asp:DropDownList ID="ddlDocumento" runat="server" CssClass="form-control" disabled>
                                                            <asp:ListItem Value="">Seleccione</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:Label ID="lbl_mensaje_doc" runat="server" ForeColor="Red" Text="Debe seleccionar un tipo de documento"
                                                            Visible="false"></asp:Label>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <label class="control-label">
                                                            Numero<span class="required">*</span>
                                                        </label>
                                                        <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control" disabled></asp:TextBox>
                                                        <asp:Label ID="lbl_mensaje_numero" runat="server" ForeColor="Red" Text="Debe ingresar el numero del documento"
                                                            Visible="false"></asp:Label>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <label class="col-md-12 control-label">
                                                            DRES
                                                        </label>
                                                        <div class="col-md-6">
                                                            <asp:TextBox ID="txtDRESfecha" runat="server" CssClass="form-control" onkewdown="return jsDecimals(event);" MaxLength="4" disabled></asp:TextBox>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <asp:TextBox ID="txtDREScorr" runat="server" CssClass="form-control" onkewdown="return jsDecimals(event);" MaxLength="7" disabled></asp:TextBox>
                                                        </div>
                                                        <asp:Label ID="lbl_mensaje_dres" runat="server" ForeColor="Red" Text="Debe ingresar el DRES"
                                                            Visible="false"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <label class="control-label">
                                                            Consignante
                                                        </label>
                                                        <asp:TextBox ID="txtConsignante" runat="server" CssClass="form-control" onKeyUp="this.value=this.value.toUpperCase();" disabled></asp:TextBox>
                                                        <asp:Label ID="lbl_mensaje_consignante" runat="server" ForeColor="Red" Text="Debe ingresar el consignante"
                                                            Visible="false"></asp:Label>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <label class="control-label">
                                                            Consignatario
                                                        </label>
                                                        <asp:TextBox ID="txtConsignatario" runat="server" CssClass="form-control" onKeyUp="this.value=this.value.toUpperCase();" disabled></asp:TextBox>
                                                        <asp:Label ID="lbl_consignatario" runat="server" ForeColor="Red" Text="Debe ingresar el consignatario"
                                                            Visible="false"></asp:Label>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <label class="control-label">
                                                            Despachante
                                                        </label>
                                                        <asp:TextBox ID="txtDespachante" runat="server" CssClass="form-control" onKeyUp="this.value=this.value.toUpperCase();" disabled></asp:TextBox>
                                                        <asp:Label ID="lbl_mensaje_despachante" runat="server" ForeColor="Red" Text="Debe ingresar el Despachante"
                                                            Visible="false"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="row">
                                                    <div class="col-md-8">
                                                        <div class="col-md-9">
                                                            <br />
                                                            <asp:LinkButton ID="grabarDoc" runat="server" CssClass="btn blue" CausesValidation="False" Enabled="false" disabled PostBack="false">Grabar</asp:LinkButton>
                                                            <asp:LinkButton ID="modificarDoc" runat="server" CssClass="btn blue" CausesValidation="False" Enabled="false" disabled PostBack="false">Modificar</asp:LinkButton>
                                                            <asp:LinkButton ID="borrarDoc" runat="server" CssClass="btn blue" CausesValidation="False" Enabled="false" disabled PostBack="false">Borrar</asp:LinkButton>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <br />
                                                            <asp:LinkButton ID="inicializarDoc" runat="server" CssClass="btn blue" CausesValidation="False" Enabled="false" disabled PostBack="false">Agregar</asp:LinkButton>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <div class="portlet box blue-steel">
                                            <div class="portlet-title">
                                                <div class="caption">
                                                    Listado Documentos
                                                </div>
                                            </div>
                                            <div class="portlet-body form">
                                                <table class='table table-striped table-hover table-bordered dataTable no-footer' id="gvDocumentos">
                                                    <thead>
                                                        <tr class="bg-blue-steel">
                                                            <th>NRO DOC</th>
                                                            <th>CONSIGNANTE</th>
                                                            <th>CONSIGNATARIO</th>
                                                            <th>DESPACHANTE</th>
                                                        </tr>
                                                    </thead>
                                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <asp:Panel runat="server" ID="Panel1">
                                                                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                                                            </asp:Panel>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </table>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <%--<asp:LinkButton runat="server" CssClass="btn btn-default" OnClick="btnGuardar_Click" ID="btnGuardar">Guardar</asp:LinkButton>--%>
            </div>
        </div>
    </div>

    <!-- Modal Modificar -->
    <div id="modificable" class="modal fade" role="dialog">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" onclick="location.href= 'Desconsolidado.aspx';"></button>
                    <h4 class="modal-title">Modificar Cliente</h4>
                </div>
                <div class="modal-body">
                    <div class="slimScrollDiv">
                        <div class="scroller" data-always-visible="1" data-rail-visible1="1" data-initialized="1">
                            <div class="form-body">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label">
                                                BL
                                            </label>
                                            <asp:TextBox ID="txtBlMod" runat="server" CssClass="form-control" onKeyUp="this.value=this.value.toUpperCase();">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label">
                                                Mano de Trabajo
                                            </label>
                                            <asp:TextBox ID="txtManoMod" runat="server" CssClass="form-control" onKeyUp="this.value=this.value.toUpperCase();">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label">
                                                Terminal<span class="required">*</span>
                                            </label>
                                            <asp:DropDownList ID="ddlTermMod" runat="server" CssClass="form-control">
                                            </asp:DropDownList><br />
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="col-md-3 control-label">
                                                Nave<span class="required">*</span>
                                            </label>
                                            <asp:DropDownList ID="ddlNaveMod" runat="server" CssClass="form-control">
                                            </asp:DropDownList><br />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label">
                                                Viaje<span class="required">*</span>
                                            </label>
                                            <asp:TextBox ID="txtViajeMod" runat="server" CssClass="form-control" onkeydown="return jsDecimals(event);">
                                            </asp:TextBox><br />
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label">
                                                Puerto Origen<span class="required">*</span>
                                            </label>
                                            <asp:DropDownList ID="ddlPueOrMod" runat="server" CssClass="form-control">
                                            </asp:DropDownList><br />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label">
                                                Puerto Destino<span class="required">*</span>
                                            </label>
                                            <asp:DropDownList ID="ddlPueDesMod" runat="server" CssClass="form-control">
                                            </asp:DropDownList><br />
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label">
                                                Cliente<span class="required">*</span>
                                            </label>
                                            <asp:DropDownList ID="ddlClienteMod" runat="server" CssClass="form-control">
                                            </asp:DropDownList><br />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group" id="contenedorDIV2">
                                            <label class="control-label">
                                                Contenedor<span class="required">*</span>
                                            </label>
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <asp:TextBox ID="txtNumContMod" CssClass="form-control" runat="server" onKeyUp="this.value=this.value.toUpperCase();" onkeypress="return isNumberKey(event);" MaxLength="4" ClientIDMode="Static"></asp:TextBox>
                                                </div>
                                                <div class="col-md-5">
                                                    <asp:TextBox ID="txtSiglaContMod" CssClass="form-control" runat="server" onkeydown="return jsDecimals(event);" MaxLength="6" ClientIDMode="Static"></asp:TextBox>
                                                </div>
                                                <div class="col-md-3">
                                                    <asp:TextBox ID="txtDvContMod" CssClass="form-control" runat="server" onkeydown="return jsDecimals(event);" MaxLength="1" ClientIDMode="Static"></asp:TextBox><br />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label">
                                                ISO<span class="required">*</span>
                                            </label>
                                            <asp:DropDownList ID="ddlIsoMod" runat="server" CssClass="form-control">
                                            </asp:DropDownList><br />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label">
                                                Sello1<span class="required">*</span>
                                            </label>
                                            <asp:TextBox ID="txtSello1Mod" runat="server" CssClass="form-control" onKeyUp="this.value=this.value.toUpperCase();"></asp:TextBox><br />
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label">
                                                Sello 2
                                            </label>
                                            <asp:TextBox ID="txtSello2Mod" runat="server" CssClass="form-control" onKeyUp="this.value=this.value.toUpperCase();">       
                                            </asp:TextBox><br />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label">
                                                Sello 3
                                            </label>
                                            <asp:TextBox ID="txtSello3Mod" runat="server" CssClass="form-control" onKeyUp="this.value=this.value.toUpperCase();">
                                            </asp:TextBox><br />
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label">
                                                Fecha<span class="required">*</span>
                                            </label>
                                            <asp:TextBox runat="server" ID="txtFechaMod" CssClass="form-control date-picker" placeholder="Fecha Obligatoria" /><br />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label">
                                                Hora Inicio<span class="required">*</span>
                                            </label>
                                            <asp:TextBox runat="server" ID="txtHoraIMod" CssClass="form-control timepicker timepicker-tarja" /><br />
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label">
                                                Hora termino<span class="required">*</span>
                                            </label>
                                            <asp:TextBox runat="server" ID="txtHoraTMod" CssClass="form-control timepicker timepicker-tarja" /><br />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label">
                                                Tarjador<span class="required">*</span>
                                            </label>
                                            <asp:DropDownList runat="server" ID="ddlTarjadorMod" CssClass="form-control"></asp:DropDownList><br />
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:TextBox ID="corrPlan" Style="display: none;" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <%--<asp:LinkButton runat="server" CssClass="btn btn-default" OnClick="btnModificar_Click" ID="btnModificar">Guardar</asp:LinkButton>--%>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="jsReferences" runat="Server">
    <script type="text/javascript" src="assets/global/plugins/select2/select2.min.js"></script>
    <script type="text/javascript" src="assets/global/plugins/datatables/media/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="assets/global/plugins/datatables/plugins/bootstrap/dataTables.bootstrap.js"></script>
    <script type="text/javascript" src="assets/admin/pages/scripts/table-managed.js"></script>
    <script src="assets/global/plugins/bootstrap-datepicker/js/bootstrap-datepicker.js" type="text/javascript"></script>
    <script src="assets/global/plugins/bootstrap-timepicker/js/bootstrap-timepicker.js" type="text/javascript"></script>
    <script src="assets/global/plugins/bootbox/bootbox.min.js" type="text/javascript"></script>
    <script src="js/Fecha.js" type="text/javascript"></script>
    <script src="js/Hora.js" type="text/javascript"></script>
    <script src="js/Consolidado.js" type="text/javascript"></script>


    <script type="text/javascript">
        jQuery(document).ready(function () {
            Consolidado.init();
        });
    </script>
</asp:Content>

