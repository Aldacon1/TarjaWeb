<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Menu.master" CodeFile="Desconsolidado.aspx.cs"
    Inherits="Desconsolidado" EnableEventValidation="false" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cssReferences" runat="server">
    <link href="assets/global/plugins/bootstrap-datepicker/css/bootstrap-datepicker.css" rel="stylesheet" />
    <link href="assets/global/plugins/bootstrap-timepicker/css/bootstrap-timepicker.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="assets/global/plugins/select2/select2.css" />
    <link rel="stylesheet" type="text/css" href="assets/global/plugins/datatables/plugins/bootstrap/dataTables.bootstrap.css" />
    <%-- 
        var txtFecha = document.getElementById("<%=txtFechaMod.ClientID%>"); 
        txtFecha.value = response.d.fecha;
        $('#modificable').on('hide.bs.modal', function (e) {
                    location.href = 'Desconsolidado.aspx';
                });
    --%>
    <script type="text/javascript">
        function eliminar(id) {
            var codigo = id;

            bootbox.confirm({
                size: 'small',
                message: "Esta seguro que desea eliminar el objeto seleccionado?",
                callback: function (result) { if (result) { eliminarBootbox(codigo); } else { location.href = "Desconsolidado.aspx"; } }
            });
        }

        function eliminarBootbox(id) {
            var corr = id;
            $.ajax({
                type: "POST",
                url: "Desconsolidado.aspx/eliminarPlanDesc",
                data: '{corr_plan: "' + corr + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response.d);
                }
            });

            function OnSuccess(response) {
                if (response.d == 0) {
                    location.href = "Desconsolidado.aspx";
                } else {
                    alerta('No puede eliminar esta Planificación. \n Asegurese que no hay tarjas asociadas.');
                }
            }
        }

        function modificar(id) {
            var corr = id;

            $.ajax({
                type: "POST",
                url: "Desconsolidado.aspx/modificarPlanDesc",
                data: '{corr_plan: "' + corr + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response.d);
                }
            });

            function OnSuccess(response) {
                var corrPlan = document.getElementById("<%=corrPlan.ClientID%>");
                var txtBl = document.getElementById("<%=txtBlMod.ClientID%>");
                var ddlpueO = document.getElementById("<%=ddlPueOrMod.ClientID%>");
                var ddlpueD = document.getElementById("<%=ddlPueDesMod.ClientID%>");
                var txtNumCont = document.getElementById("<%=txtNumContMod.ClientID%>");
                var txtSiglaCont = document.getElementById("<%=txtSiglaContMod.ClientID%>");
                var txtDvCont = document.getElementById("<%=txtDvContMod.ClientID%>");
                var ddlIso = document.getElementById("<%=ddlIsoMod.ClientID%>");
                var txtSello1 = document.getElementById("<%=txtSello1Mod.ClientID%>");
                var txtSello2 = document.getElementById("<%=txtSello2Mod.ClientID%>");
                var txtSello3 = document.getElementById("<%=txtSello3Mod.ClientID%>");
                var ddlCliente = document.getElementById("<%=ddlClienteMod.ClientID%>");

                var txtHoraI = document.getElementById("<%=txtHoraIMod.ClientID%>");
                var txtHoraT = document.getElementById("<%=txtHoraTMod.ClientID%>");
                var txtMano = document.getElementById("<%=txtManoMod.ClientID%>");
                var ddlNave = document.getElementById("<%=ddlNaveMod.ClientID%>");
                var txtViaje = document.getElementById("<%=txtViajeMod.ClientID%>");
                var ddlTerminal = document.getElementById("<%=ddlTermMod.ClientID%>");
                var ddlTarjador = document.getElementById("<%=ddlTarjadorMod.ClientID%>");

                corrPlan.value = response.d.corr_planificacion;
                txtBl.value = response.d.gls_bl;
                ddlpueO.value = response.d.cod_puerto_or;
                ddlpueD.value = response.d.cod_puerto_dest;
                txtNumCont.value = response.d.numcont;
                txtSiglaCont.value = response.d.siglacont;
                txtDvCont.value = response.d.dvCont;
                ddlIso.value = response.d.cod_iso;
                txtSello1.value = response.d.gls_sello1;
                txtSello2.value = response.d.gls_sello2;
                txtSello3.value = response.d.gls_sello3;
                ddlCliente.value = response.d.rut_cliente;

                txtHoraI.value = response.d.horaI;
                txtHoraT.value = response.d.horaT;
                txtMano.value = response.d.mano_trabajo;
                ddlNave.value = response.d.cod_nave;
                txtViaje.value = response.d.n_viaje;
                ddlTerminal.value = response.d.cod_terminal;
                ddlTarjador.value = response.d.rut_tarjador;

                $('#modificable').modal('show');

                $('#modificable').on('hidden.bs.modal', function () {
                    location.href = "Desconsolidado.aspx";
                });

            }
        }
    </script>
    <script type='text/javascript'>
        function alerta(msj) {
            bootbox.confirm(msj, function (result) {
                if (result == true) {
                    location.href = "Desconsolidado.aspx";
                } else {
                    location.href = "Desconsolidado.aspx";
                }
            });
        }
    </script>
    <script type="text/javascript">
        function jsDecimals(e) {

            var evt = (e) ? e : window.event;
            var key = (evt.keyCode) ? evt.keyCode : evt.which;
            if (key != null) {
                key = parseInt(key, 10);
                if ((key < 48 || key > 57) && (key < 96 || key > 105)) {
                    //Aca tenemos que reemplazar "Decimals" por "NoDecimals" si queremos que no se permitan decimales
                    if (!jsIsUserFriendlyChar(key, "Decimals")) {
                        return false;
                    }
                }
                else {
                    if (evt.shiftKey) {
                        return false;
                    }
                }
            }
            return true;
        }

        // Función para las teclas especiales
        //------------------------------------------
        function jsIsUserFriendlyChar(val, step) {
            // Backspace, Tab, Enter, Insert, y Delete
            if (val == 8 || val == 9 || val == 13 || val == 45 || val == 46) {
                return true;
            }
            // Ctrl, Alt, CapsLock, Home, End, y flechas
            if ((val > 16 && val < 21) || (val > 34 && val < 41)) {
                return true;
            }
            if (step == "Decimals") {
                if (val == 190 || val == 110) {  //Check dot key code should be allowed
                    return true;
                }
            }
            // The rest
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                                Desconsolidado
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
                    <h4 class="modal-title">Planificacion</h4>
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
                                            <asp:TextBox ID="txtBL" runat="server" CssClass="form-control" onKeyUp="this.value=this.value.toUpperCase();">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label">
                                                Mano de Trabajo
                                            </label>
                                            <asp:TextBox ID="txtMddt" runat="server" CssClass="form-control" onKeyUp="this.value=this.value.toUpperCase();">
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
                                            <asp:DropDownList ID="ddlTerminal" runat="server" CssClass="form-control">
                                            </asp:DropDownList><br />
                                            <asp:Label ID="lbl_mensaje_Terminal" runat="server" ForeColor="Red" Text="Terminal es obligatorio"
                                                Visible="false"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="col-md-3 control-label">
                                                Nave<span class="required">*</span>
                                            </label>
                                            <asp:DropDownList ID="ddlNaves" runat="server" CssClass="form-control">
                                            </asp:DropDownList><br />
                                            <asp:Label ID="lbl_mensaje_Nave" runat="server" ForeColor="Red" Text="Nave es obligatorio"
                                                Visible="false"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label">
                                                Viaje<span class="required">*</span>
                                            </label>
                                            <asp:TextBox ID="txtViaje" runat="server" CssClass="form-control" onkeydown="return jsDecimals(event);">
                                            </asp:TextBox><br />
                                            <asp:Label ID="lbl_mensaje_viaje" runat="server" ForeColor="Red" Text="Ingrese el estado del viaje de la nave"
                                                Visible="false"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label">
                                                Puerto Origen<span class="required">*</span>
                                            </label>
                                            <asp:DropDownList ID="ddlOrigen" runat="server" CssClass="form-control">
                                            </asp:DropDownList><br />
                                            <asp:Label ID="lbl_mensaje_puertoO" runat="server" ForeColor="Red" Text="Puerto de origen es obligatorio"
                                                Visible="false"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label">
                                                Puerto Destino<span class="required">*</span>
                                            </label>
                                            <asp:DropDownList ID="ddlDestino" runat="server" CssClass="form-control">
                                            </asp:DropDownList><br />
                                            <asp:Label ID="lbl_mensaje_puertoD" runat="server" ForeColor="Red" Text="Puerto de Destino es obligatorio"
                                                Visible="false"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label">
                                                Cliente<span class="required">*</span>
                                            </label>
                                            <asp:DropDownList ID="ddlCliente" runat="server" CssClass="form-control">
                                            </asp:DropDownList><br />
                                            <asp:Label ID="lbl_mensaje_cliente" runat="server" ForeColor="Red" Text="Debe ingresar el cliente"
                                                Visible="false"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group" id="contenedorDIV">
                                            <label class="control-label">
                                                Contenedor<span class="required">*</span>
                                            </label>
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <asp:TextBox ID="txtContenedor" CssClass="form-control" runat="server" onKeyUp="this.value=this.value.toUpperCase();" onkeypress="return isNumberKey(event);" MaxLength="4" ClientIDMode="Static"></asp:TextBox>
                                                </div>
                                                <div class="col-md-5">
                                                    <asp:TextBox ID="txtContenedorNum" CssClass="form-control" runat="server" onkeydown="return jsDecimals(event);" MaxLength="6" ClientIDMode="Static"></asp:TextBox>
                                                </div>
                                                <div class="col-md-3">
                                                    <asp:TextBox ID="txtContenedorDV" CssClass="form-control" runat="server" onkeydown="return jsDecimals(event);" MaxLength="1" ClientIDMode="Static"></asp:TextBox><br />
                                                    <asp:Label ID="lbl_mensaje_contenedor" runat="server" ForeColor="Red" Text="El contenedor es obligatorio" ClientIDMode="Static"
                                                        Visible="false"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label">
                                                ISO<span class="required">*</span>
                                            </label>
                                            <asp:DropDownList ID="ddlISO" runat="server" CssClass="form-control">
                                            </asp:DropDownList><br />
                                            <asp:Label ID="lbl_mensaje_iso" runat="server" ForeColor="Red" Text="EL codigo Iso es obligatorio"
                                                Visible="false"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label">
                                                Sello1<span class="required">*</span>
                                            </label>
                                            <asp:TextBox ID="txtSello1" runat="server" CssClass="form-control" onKeyUp="this.value=this.value.toUpperCase();"></asp:TextBox><br />
                                            <asp:Label ID="lbl_mensaje_sello" runat="server" ForeColor="Red" Text="Debe ingresar al menos el sello1"
                                                Visible="false"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label">
                                                Sello 2
                                            </label>
                                            <asp:TextBox ID="txtSello2" runat="server" CssClass="form-control" onKeyUp="this.value=this.value.toUpperCase();">                                    
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
                                            <asp:TextBox ID="txtSello3" runat="server" CssClass="form-control" onKeyUp="this.value=this.value.toUpperCase();">                                    
                                            </asp:TextBox><br />
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label">
                                                Fecha<span class="required">*</span>
                                            </label>
                                            <asp:TextBox runat="server" ID="txtFecha" CssClass="form-control date-picker" placeholder="Fecha Obligatoria" /><br />
                                            <asp:Label ID="lbl_mensaje_fecha" runat="server" ForeColor="Red" Text="La fecha ingresada debe ser desde hoy en adelante"
                                                Visible="false"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label">
                                                Hora Inicio<span class="required">*</span>
                                            </label>
                                            <asp:TextBox runat="server" ID="txtHoraI" CssClass="form-control timepicker timepicker-tarja" /><br />
                                            <asp:Label ID="lbl_mensaje_horai" runat="server" ForeColor="Red" Text="L a hora de inicio es obligatoria"
                                                Visible="false"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label">
                                                Hora termino<span class="required">*</span>
                                            </label>
                                            <asp:TextBox runat="server" ID="txtHoraT" CssClass="form-control timepicker timepicker-tarja" /><br />
                                            <asp:Label ID="lbl_mensaje_horat" runat="server" ForeColor="Red" Text="La hora de termino debe ser posterior a la de inicio."
                                                Visible="false"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="control-label">
                                                Tarjador<span class="required">*</span>
                                            </label>
                                            <asp:DropDownList runat="server" ID="ddlTarjador" CssClass="form-control"></asp:DropDownList><br />
                                            <asp:Label ID="lbl_mensaje_tarjador" runat="server" ForeColor="Red" Text="Debe asignar un tarjador para la tarja."
                                                Visible="false"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:LinkButton runat="server" CssClass="btn btn-default" OnClick="btnGuardar_Click" ID="btnGuardar" PostBack="false">Guardar</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>


    <!-- Modal Modificar -->
    <div id="modificable" class="modal fade" role="dialog">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" onclick="location.href= 'Desconsolidado.aspx';"></button>
                    <h4 class="modal-title">Modificar Planificacion</h4>
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
                    <asp:LinkButton runat="server" CssClass="btn btn-default" OnClick="btnModificar_Click" ID="btnModificar">Guardar</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="jsReferences" runat="server">
    <script type="text/javascript" src="assets/global/plugins/select2/select2.min.js"></script>
    <script type="text/javascript" src="assets/global/plugins/datatables/media/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="assets/global/plugins/datatables/plugins/bootstrap/dataTables.bootstrap.js"></script>
    <script type="text/javascript" src="assets/admin/pages/scripts/table-managed.js"></script>
    <script src="assets/global/plugins/bootstrap-datepicker/js/bootstrap-datepicker.js" type="text/javascript"></script>
    <script src="assets/global/plugins/bootstrap-timepicker/js/bootstrap-timepicker.js" type="text/javascript"></script>
    <script src="assets/global/plugins/bootbox/bootbox.min.js" type="text/javascript"></script>
    <script src="js/Fecha.js" type="text/javascript"></script>
    <script src="js/Hora.js" type="text/javascript"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            Fecha.init();
            Hora.init();
        });

        function pageLoad(sender, args) {
            if (args.get_isPartialLoad()) {
                Fecha.init();
                Hora.init();
            }
        };
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#sample_2').dataTable({
                "lengthMenu": [
                [5, 15, 20, -1],
                [5, 15, 20, "All"] // change per page values here
                ],
                // set the initial value
                "pageLength": 5,
                "language": {
                    "search": "Buscar: _INPUT_",
                    "lengthMenu": "_MENU_ registros",
                    "info": "Mostrando _END_ de _TOTAL_ registros",
                    "zeroRecords": "No se encontraron registros relacionados",
                    "infoEmpty": "Monstrando 0 registros",
                    "infoFiltered": "(filtrados de _MAX_ registros)"
                }
            });
        });
    </script>
</asp:Content>
