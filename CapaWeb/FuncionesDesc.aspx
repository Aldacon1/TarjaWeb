<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.master" AutoEventWireup="true" CodeFile="FuncionesDesc.aspx.cs" Inherits="FuncionesDesc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cssReferences" runat="Server">
    <link rel="stylesheet" type="text/css" href="assets/global/plugins/select2/select2.css" />
    <link rel="stylesheet" type="text/css" href="assets/global/plugins/datatables/plugins/bootstrap/dataTables.bootstrap.css" />
    <script type="text/javascript">
        function eliminar(id) {
            var codigo = id;

            bootbox.confirm({
                size: 'small',
                message: "Esta seguro que desea eliminar el objeto seleccionado?",
                callback: function (result) { if (result) { eliminarBootbox(codigo); } else { location.href = "FuncionesDesc.aspx"; } }
            });
        }

        function eliminarBootbox(codigo) {
            $.ajax({
                type: "POST",
                url: "FuncionesDesc.aspx/eliminarFuncion",
                data: '{codigo: "' + codigo + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response.d);
                }
            });

            function OnSuccess(response) {

                if (response.d == 0) {
                    location.href = "FuncionesDesc.aspx";
                } else {
                    alerta('No puede eliminar esta funcion. \nAsegurese que no hay personas asociadas a esta funcion.');
                }
            }
        }

        function modificar(id) {
            var codigo = id;

            $.ajax({
                type: "POST",
                url: "FuncionesDesc.aspx/modificarFuncion",
                data: '{codigo: "' + codigo + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response.d);
                }
            });

            function OnSuccess(response) {
                var txtCod = document.getElementById("<%=txtCodMod.ClientID%>");
                var txtNombre = document.getElementById("<%=txtNomMod.ClientID%>");
                var ddlPerm = document.getElementById("<%=ddlPermisoMod.ClientID%>");


                txtCod.value = response.d.cod_funcion;
                txtNombre.value = response.d.gls_nombre_funcion;
                ddlPerm.value = response.d.cod_permiso;

                $('#modificable').modal('show');
                $('#modificable').on('hide.bs.modal', function (e) {
                    location.href = 'FuncionesDesc.aspx';
                });
            }
        }

    </script>
    <script type='text/javascript'>
        function alerta(msj) {
            bootbox.confirm(msj, function (result) {
                if (result == true) {
                    location.href = "FuncionesDesc.aspx";
                } else {
                    location.href = "FuncionesDesc.aspx";
                }
            });
        }
    </script>
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
            <asp:UpdatePanel runat="server" ID="UpdatePanel3">
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
                                Funciones
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
            <a class="btn default" data-toggle="modal" href="#responsive">Agregar Función </a>
        </div>
    </div>

    <!-- Modal Agregar -->
    <div id="responsive" class="modal fade bs-modal-lg" tabindex="-1" aria-hidden="true" style="display: none;">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <h4 class="modal-title">Nueva Funcion</h4>
                </div>
                <div class="modal-body">
                    <div class="slimScrollDiv">
                        <div class="scroller" data-always-visible="1" data-rail-visible1="1" data-initialized="1">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label>
                                                Codigo
                                            </label>
                                            <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:Label ID="lbl_mensaje_codigo" runat="server" ForeColor="Red" Text="Debe ingresar el codigo de la funcion."
                                                Visible="false"></asp:Label>
                                        </div>
                                        <div class="form-group">
                                            <label>
                                                Nombre</label>
                                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" onKeyUp="this.value=this.value.toUpperCase();"></asp:TextBox>
                                            <asp:Label ID="lbl_mensaje_nombre" runat="server" ForeColor="Red" Text="Debe ingresar un nombre"
                                                Visible="false"></asp:Label>
                                        </div>
                                        <div class="form-group">
                                            <label>
                                                Permiso</label>
                                            <asp:DropDownList ID="ddlPermisos" runat="server" CssClass="form-control">
                                            </asp:DropDownList>
                                            <asp:Label ID="lbl_mensaje_permiso" runat="server" ForeColor="Red" Text="Debe seleccionar unpermiso"
                                                Visible="false"></asp:Label>
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

    <!-- modal Modificar -->
    <div id="modificable" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"></button>
                    <h4 class="modal-title">Modificar Funcion</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-body">
                                <div class="form-group">
                                    <label>
                                        Codigo
                                    </label>
                                    <asp:TextBox ID="txtCodMod" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>
                                        Nombre</label>
                                    <asp:TextBox ID="txtNomMod" runat="server" CssClass="form-control" onKeyUp="this.value=this.value.toUpperCase();"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>
                                        Permiso</label>
                                    <asp:DropDownList ID="ddlPermisoMod" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
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

