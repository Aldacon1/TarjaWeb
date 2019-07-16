<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.master" AutoEventWireup="true" CodeFile="ListarDesconsolidado.aspx.cs" Inherits="ListarDesconsolidado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cssReferences" runat="Server">
    <link rel="stylesheet" type="text/css" href="assets/global/plugins/select2/select2.css" />
    <link rel="stylesheet" type="text/css" href="assets/global/plugins/datatables/plugins/bootstrap/dataTables.bootstrap.css" />
    <script type="text/javascript">
        function eliminar(id) {
            var manifiesto = id;
            var btn = document.getElementById(id);
            var td = btn.parentNode;
            var tr = td.parentNode;
            var estadoTarja = tr.cells[8].innerHTML;

            if (estadoTarja != "Cerradas") {
                $.ajax({
                    type: "POST",
                    url: "ListarDesconsolidado.aspx/eliminarProgramacion",
                    data: '{manifiesto: "' + manifiesto + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccess,
                    failure: function (response) {
                        alert(response.d);
                    }
                });

                function OnSuccess(response) {
                    location.href = "ListarDesconsolidado.aspx";
                }
            } else {
                alert("La programación no puede ser eliminada,\nporque tiene una tarja asociada.");
                location.href = "ListarDesconsolidado.aspx";
            }

        }

        function modificar(id) {
            var manifiesto = id;
            var btn = document.getElementById(id);
            var td = btn.parentNode;
            var tr = td.parentNode;
            var bl = tr.cells[2].innerHTML;

            $.ajax({
                type: "POST",
                url: "ListarDesconsolidado.aspx/modificarDesc",
                data: '{bl: "' + bl + '", manifiesto: "' + manifiesto + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response.d);
                }
            });

            function OnSuccess(response) {
                location.href = "Modificadores/modDesconsolidado.aspx";
            }
        }

        function exportar(manifiesto) {
            window.open("Cliente/Pdf.aspx?manifiesto=" + manifiesto);
            location.href = "ListarDesconsolidado.aspx";
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h3 class="page-title">Planificación Desconsolidado
    </h3>
    <div class="page-bar">
        <ul class="page-breadcrumb">
            <li><i class="fa fa-home"></i><a href="principal.aspx">Planificación</a> <i class="fa fa-angle-right"></i></li>
            <li><a href="#">Desconsolidado</a> <i class="fa  fa-database"></i></li>
        </ul>
    </div>
    <div class="row">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div class="col-md-12">
                    <div class="portlet box blue-steel">
                        <div class="portlet-title">
                            <div class="caption">
                                Tarjas Programadas
                            </div>
                        </div>
                        <div class="portlet-body">
                            <table class='table table-striped table-bordered table-hover' id="sample_2">
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
                    <div class="row">
                        <div class="col-md-4">
                            <button class="btn blue" id="btnAgregar" onclick="location.href = 'Desconsolidado.aspx';">Agregar Programación</button>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="jsReferences" runat="Server">
    <script type="text/javascript" src="assets/global/plugins/select2/select2.min.js"></script>
    <script type="text/javascript" src="assets/global/plugins/datatables/media/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="assets/global/plugins/datatables/plugins/bootstrap/dataTables.bootstrap.js"></script>
    <script type="text/javascript" src="assets/admin/pages/scripts/table-managed.js"></script>
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

