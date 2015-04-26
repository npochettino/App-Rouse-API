<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="reporteParticipantes.aspx.cs" Inherits="AppRouss.reporteParticipantes" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>


<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!-- BEGIN CONTENT -->
    <div class="page-content-wrapper">
        <div class="page-content">

            <!-- BEGIN PAGE HEADER-->
            <h3 class="page-title">Reporte Participantes <small>reportes & estadisticas</small>
            </h3>
            <div class="page-bar">
                <ul class="page-breadcrumb">
                    <li>
                        <i class="fa fa-home"></i>
                        <a href="index.aspx">Inicio</a>
                        <i class="fa fa-angle-right"></i>
                    </li>
                    <li>
                        <a href="#">Reportes</a>
                        <i class="fa fa-angle-right"></i>
                    </li>
                    <li>
                        <a href="reporteParticiantes.aspx">Reporte Participantes</a>
                    </li>
                </ul>
            </div>
            <!-- END PAGE HEADER-->
            <!-- BEGIN PAGE CONTENT-->
            <div class="row">
                <div class="col-md-12">

                    <!-- BEGIN ROW -->
                    <div class="row">
                        <div class="col-md-12">
                            <!-- BEGIN CHART PORTLET-->
                            <div class="portlet light bordered">
                                <div class="portlet-title">
                                    <div class="caption">
                                        <i class="icon-bar-chart font-green-haze"></i>
                                        <span class="caption-subject bold uppercase font-green-haze">Reporte de Participantes</span>
                                        <span class="caption-helper">Listado de Participantes por sorteo.</span>
                                    </div>
                                    <div class="tools">
                                        <a href="javascript:;" class="collapse"></a>
                                        <a href="javascript:;" class="fullscreen"></a>
                                        <a href="javascript:;" class="remove"></a>
                                    </div>
                                </div>

                                <div class="portlet light bg-inverse">
                                    <div class="portlet-title">
                                        <div class="caption">
                                            <i class="icon-equalizer font-red-sunglo"></i>
                                            <span class="caption-subject font-red-sunglo bold uppercase">Parametros del Reporte</span>
                                            <span class="caption-helper">seleccione...</span>
                                        </div>
                                        <div class="tools">
                                            <a href="#" class="collapse"></a>
                                            <a href="#portlet-config" data-toggle="modal" class="config"></a>
                                            <a href="#" class="reload"></a>
                                            <a href="#" class="remove"></a>
                                        </div>
                                    </div>
                                    <div class="portlet-body form">
                                        <!-- BEGIN FORM-->
                                        <form action="#" class="horizontal-form">
                                            <div class="form-body">
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <label class="control-label">Sorteo</label>
                                                            <%--<select class="form-control">
                                                                <option value="">1</option>
                                                                <option value="">2</option>
                                                            </select>--%>
                                                            <asp:DropDownList ID="ddlSorteos" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSorteos_SelectedIndexChanged"></asp:DropDownList>
                                                            <%--<span class="help-block">Selecciones un sorteo </span>--%>
                                                        </div>
                                                    </div>
                                                    <!--/span-->
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <label class="control-label">Ganador</label>
                                                            <div class="radio-list">
                                                                <label class="radio-inline">
                                                                    <asp:RadioButton type="radio" ID="rbTodos" AutoPostBack="true" GroupName="optionsRadios" Checked="true" runat="server" OnCheckedChanged="rbTodos_CheckedChanged" />
                                                                    <%--<input type="radio" name="optionsRadios" id="Radio3" value="option1" checked>--%>
                                                                    Todos
                                                                </label>
                                                                <label class="radio-inline">
                                                                    <asp:RadioButton type="radio" ID="rbGanador" AutoPostBack="true" GroupName="optionsRadios" runat="server" OnCheckedChanged="rbGanador_CheckedChanged" />
                                                                    <%--<input type="radio" name="optionsRadios" id="Radio1" value="option1" checked>--%>
                                                                    Ganador
                                                                </label>
                                                                <label class="radio-inline">
                                                                    <asp:RadioButton type="radio" ID="rbSeguiParticipando" AutoPostBack="true" GroupName="optionsRadios" runat="server" OnCheckedChanged="rbSeguiParticipando_CheckedChanged" />
                                                                    <%--<input type="radio" name="optionsRadios" id="Radio2" value="option2">--%>
                                                                    Segui Participando
                                                                </label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!--/span-->
                                                </div>
                                            </div>
                                            <%--<div class="form-actions left">
                                                <dx:ASPxButton ID="btnCargarReporteParticipante" runat="server" Text="Cargar" UseSubmitBehavior="False"
                                                    OnClick="btnCargarReporteParticipante_Click" Theme="Metropolis" />

                                            </div>--%>
                                        </form>
                                        <!-- END FORM-->
                                    </div>
                                </div>

                                <div class="portlet-body">
                                    <div id="chart_1" class="chart" style="height: auto;">
                                        <div class="portlet-body form">
                                            <table class="BottomMargin">
                                                <tr>
                                                    <td style="padding-right: 4px">
                                                        <dx:ASPxButton ID="btnPdfExport" runat="server" Text="Export to PDF" UseSubmitBehavior="False"
                                                            OnClick="btnPdfExport_Click" Theme="Metropolis" />
                                                    </td>
                                                    <td style="padding-right: 4px">
                                                        <dx:ASPxButton ID="btnXlsxExport" runat="server" Text="Export to XLSX" UseSubmitBehavior="False"
                                                            OnClick="btnXlsxExport_Click" Theme="Metropolis" />
                                                    </td>

                                                </tr>
                                            </table>

                                            <dx:ASPxGridView ID="gvParticipantes"  Settings-HorizontalScrollBarMode="Auto" runat="server" KeyFieldName="codigoParticipante" Width="100%" Theme="Metropolis" AutoGenerateColumns="False" OnCustomCallback="gvParticipantes_CustomCallback">
                                                <Columns>
                                                    <dx:GridViewDataTextColumn Caption="idUsuario" FieldName="codigoParticipante" Visible="False" VisibleIndex="1">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="Fecha Participacion" Width="20%" FieldName="fechaParticipacion" VisibleIndex="2" Visible="true">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="Codigo Usuario" FieldName="codigoUsuario" VisibleIndex="3" Visible="false">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="DNI" Width="10%" FieldName="dniUsuario" VisibleIndex="4">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="Apellido" Width="20%" FieldName="apellidoUsuario" VisibleIndex="5">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="Nombre" Width="20%" FieldName="nombreUsuario" VisibleIndex="6">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="Teléfono" FieldName="telefonoUsuario" Width="15%" VisibleIndex="7">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="Mail" FieldName="mailUsuario" Width="20%" VisibleIndex="8" Visible="false">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="Codigo Premio" FieldName="codigoPremio" VisibleIndex="9" Visible="false">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="Premio" Width="18%" FieldName="descripcionPremio" VisibleIndex="10">
                                                    </dx:GridViewDataTextColumn>
                                                </Columns>
                                                <SettingsBehavior ColumnResizeMode="Control" AllowSort ="false"/>
                                                <SettingsPager Mode="ShowAllRecords">
                                                </SettingsPager>

<Settings HorizontalScrollBarMode="Auto"></Settings>
                                            </dx:ASPxGridView>
                                            <dx:ASPxGridViewExporter ID="gvExporter" GridViewID="gvParticipantes" ExportedRowType="All" PaperKind="A4" FileName="ReporteParticipantes" runat="server">
                                                <PageHeader Right="[Date Printed] - [Time Printed]">
                                                </PageHeader>
                                                <PageFooter Left="2015 © App Rouss " Right="[Page # of Pages #]">
                                                </PageFooter>
                                            </dx:ASPxGridViewExporter>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- END CHART PORTLET-->
                    </div>
                </div>
                <!-- END ROW -->

            </div>
        </div>
        <!-- END PAGE CONTENT-->
    </div>
    <!-- END CONTENT -->
    <!-- END FOOTER -->

    <script>
        jQuery(document).ready(function () {
            Metronic.init(); // init metronic core componets
            Layout.init(); // init layout
            QuickSidebar.init(); // init quick sidebar
            Demo.init(); // init demo features 
            Index.init();
            Index.initDashboardDaterange();
            Index.initJQVMAP(); // init index page's custom scripts
            Index.initCalendar(); // init index page's custom scripts
            Index.initCharts(); // init index page's custom scripts
            Index.initChat();
            Index.initMiniCharts();
            Tasks.initDashboardWidget();
        });
    </script>
    <!-- END JAVASCRIPTS -->

</asp:Content>

