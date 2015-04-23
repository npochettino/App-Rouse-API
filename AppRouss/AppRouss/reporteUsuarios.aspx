<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="reporteUsuarios.aspx.cs" Inherits="AppRouss.reporteUsuarios" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxUploadControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!-- BEGIN CONTENT -->
    <div class="page-content-wrapper">
        <div class="page-content">

            <!-- BEGIN PAGE HEADER-->
            <h3 class="page-title">Reporte de Usuarios <small>reportes & estadisticas</small>
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
                        <a href="reporteUsuarios.aspx">Reporte de Usuarios</a>
                    </li>
                </ul>
            </div>
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
                                        <span class="caption-subject bold uppercase font-green-haze">Reporte de Usuarios</span>
                                        <span class="caption-helper">Listado de usuarios registrados en la App.</span>
                                    </div>
                                    <div class="tools">
                                        <a href="javascript:;" class="collapse"></a>
                                        <a href="javascript:;" class="fullscreen"></a>
                                        <a href="javascript:;" class="remove"></a>
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
                                            <dx:ASPxGridView ID="gvUsuarios" runat="server" KeyFieldName="idUsuario" Width="100%" Theme="Metropolis">
                                                <Columns>
                                                    <dx:GridViewDataTextColumn Caption="idUsuario" FieldName="idUsuario" Visible="False" VisibleIndex="1">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="Nombre" FieldName="nombre" VisibleIndex="2" Visible="true">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="Apellido" FieldName="apellido" VisibleIndex="3">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="DNI" FieldName="dni" VisibleIndex="3">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="Mail" FieldName="mail" VisibleIndex="3">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="Contraseña" Visible="false" FieldName="contraseña" VisibleIndex="3">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="Telefono" FieldName="telefono" VisibleIndex="3">
                                                    </dx:GridViewDataTextColumn>
                                                </Columns>
                                                <SettingsBehavior ColumnResizeMode="Control" AllowSort ="false"/>
                                            </dx:ASPxGridView>
                                            <dx:ASPxGridViewExporter ID="gridExport" ExportedRowType="All" runat="server" GridViewID="gvUsuarios" PaperKind="A4" ReportFooter="{\rtf1\ansi\ansicpg1252\deff0\deflang3082{\fonttbl{\f0\fnil\fcharset0 Calibri;}{\f1\fnil\fcharset0 Times New Roman;}}
\viewkind4\uc1\pard\lang11274\f0\fs20 AppRouss\lang3082\f1\par
}
"
                                                ReportHeader="{\rtf1\ansi\ansicpg1252\deff0\deflang3082{\fonttbl{\f0\fnil\fcharset0 Times New Roman;}}
\viewkind4\uc1\pard\qc\lang11274\b\f0\fs28 Reporte Usuarios\lang3082\b0\fs20\par
}
">
                                            </dx:ASPxGridViewExporter>
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


