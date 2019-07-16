<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Menu.master" CodeFile="ForwardersDesc.aspx.cs"
    Inherits="ForwardersDesc" EnableEventValidation="false" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cssReferences" runat="server">
    <link rel="stylesheet" type="text/css" href="assets/global/plugins/select2/select2.css" />
    <link rel="stylesheet" type="text/css" href="assets/global/plugins/datatables/plugins/bootstrap/dataTables.bootstrap.css" />
    <script type="text/javascript">
        function eliminar(id) {
            var codigo = id;

            bootbox.confirm({
                size: 'small',
                message: "Esta seguro que desea eliminar el objeto seleccionado?",
                callback: function (result) { if (result) { eliminarBootbox(codigo); } else { location.href = "ForwardersDesc.aspx"; } }
            });
        }

        function eliminarBootbox(id) {
            var rut = id;
            $.ajax({
                type: "POST",
                url: "ForwardersDesc.aspx/eliminarCliente",
                data: '{rut: "' + rut + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response.d);
                }
            });

            function OnSuccess(response) {
                if (response.d == 0) {
                    location.href = "ForwardersDesc.aspx";
                } else {
                    alerta('No puede eliminar este Cliente. \n Asegurese que no hay tarjas asociadas a este Cliente.');
                }
            }

        }

        function modificar(id) {
            var rut = id;

            $.ajax({
                type: "POST",
                url: "ForwardersDesc.aspx/modificarCliente",
                data: '{rut: "' + rut + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response.d);
                }
            });

            function OnSuccess(response) {
                var txtRut = document.getElementById("<%=txtRutMod.ClientID%>");
                var txtRazon = document.getElementById("<%=txtRazMod.ClientID%>");
                var txtPass = document.getElementById("<%=txtPassMod.ClientID%>");
                var txtFono = document.getElementById("<%=txtFonoMod.ClientID%>");
                var txtEmail = document.getElementById("<%=txtEmailMod.ClientID%>");

                txtRut.value = response.d.Rut_cliente;
                txtRazon.value = response.d.gls_nombre_cliente;
                txtPass.value = response.d.gls_password;
                txtFono.value = response.d.fono;
                txtEmail.value = response.d.gls_mail;

                $('#modificable').modal('show');
                $('#modificable').on('hide.bs.modal', function (e) {
                    location.href = 'ForwardersDesc.aspx';
                });
            }
        }

    </script>
    <script type='text/javascript'>
        function alerta(msj) {
            bootbox.confirm(msj, function (result) {
                if (result == true) {
                    location.href = "ForwardersDesc.aspx";
                } else {
                    location.href = "ForwardersDesc.aspx";
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
                                Clientes
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
            <a class="btn default" data-toggle="modal" href="#responsive">Agregar Cliente </a>
        </div>
    </div>

    <!-- Modal Agregar -->
    <div id="responsive" class="modal fade bs-modal-lg" tabindex="-1" aria-hidden="true" style="display: none;">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <h4 class="modal-title">Nuevo Cliente</h4>
                </div>
                <div class="modal-body">
                    <div class="slimScrollDiv">
                        <div class="scroller" data-always-visible="1" data-rail-visible1="1" data-initialized="1">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-body">
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label>
                                                        Rut</label>
                                                    <asp:TextBox ID="txtRut" CssClass="form-control" runat="server" onkeydown="return jsDecimals(event);"></asp:TextBox>
                                                    <asp:Label ID="lbl_mensaje_rut" runat="server" ForeColor="Red" Text="El rut es obligatorio"
                                                        Visible="false"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label>
                                                        Razon Social</label>
                                                    <asp:TextBox ID="txtRazon" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <asp:Label ID="lbl_mensaje_Razon" runat="server" ForeColor="Red" Text="La razon social es obligatoria"
                                                        Visible="false"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label>
                                                        Password</label>
                                                    <div class="input-icon right">
                                                        <asp:TextBox ID="txtPass" runat="server" CssClass="form-control"></asp:TextBox>
                                                        <asp:Label ID="lbl_mensaje_pass" runat="server" ForeColor="Red" Text="La password es obligatoria"
                                                            Visible="false"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label>
                                                        Telefono</label>
                                                    <asp:TextBox ID="txtFono" runat="server" CssClass="form-control" onkeydown="return jsDecimals(event);"></asp:TextBox>
                                                    <asp:Label ID="lbl_mensaje_fono" runat="server" ForeColor="Red" Text="El telefono es obligatorio"
                                                        Visible="false"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label>
                                                        Email</label>
                                                    <asp:TextBox ID="txtMail" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <asp:Label ID="lbl_mensaje_email" runat="server" ForeColor="Red" Text="El email es obligatorio"
                                                        Visible="false"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:LinkButton runat="server" CssClass="btn btn-default" OnClick="btnGuardar_Click" ID="btnGuardar">Guardar</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal Modificar -->
    <div id="modificable" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"></button>
                    <h4 class="modal-title">Modificar Cliente</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-body">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>
                                                Rut</label>
                                            <asp:TextBox ID="txtRutMod" CssClass="form-control" runat="server" onkeydown="return jsDecimals(event);"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>
                                                Razon Social</label>
                                            <asp:TextBox ID="txtRazMod" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>
                                                Password</label>
                                            <div class="input-icon right">
                                                <asp:TextBox ID="txtPassMod" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>
                                                Telefono</label>
                                            <asp:TextBox ID="txtFonoMod" runat="server" CssClass="form-control" onkeydown="return jsDecimals(event);"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>
                                                Email</label>
                                            <asp:TextBox ID="txtEmailMod" runat="server" CssClass="form-control"></asp:TextBox>
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
