<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="sorteos.aspx.cs" Inherits="AppRouss.sorteos" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>


    <!-- BEGIN CONTENT -->
    <div class="page-content-wrapper">
        <div class="page-content">

            <!-- BEGIN PAGE HEADER-->
            <h3 class="page-title">Sorteos <small>crear & consultar sorteos</small>
            </h3>
            <div class="page-bar">
                <ul class="page-breadcrumb">
                    <li>
                        <i class="fa fa-home"></i>
                        <a href="index.aspx">Inicio</a>
                        <i class="fa fa-angle-right"></i>
                    </li>
                    <li>
                        <a href="#">ABM</a>
                        <i class="fa fa-angle-right"></i>
                    </li>
                    <li>
                        <a href="#">Sorteos</a>
                    </li>
                </ul>


                <div class="page-toolbar">
                    <div class="btn-group pull-right">
                        <button type="button" class="btn btn-fit-height grey-salt dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-delay="1000" data-close-others="true">
                            Acciones <i class="fa fa-angle-down"></i>
                        </button>
                        <ul class="dropdown-menu pull-right" role="menu">
                            <li>
                                <a href="sorteosAdd.aspx">Nuevo Sorteo</a>
                            </li>

                        </ul>
                    </div>
                </div>
            </div>
            <!-- END PAGE HEADER-->
            <!-- BEGIN PAGE CONTENT-->
            <div class="row">
                <div class="col-md-12">
                    <!-- BEGIN ALERTS PORTLET-->
                    <div class="portlet purple box">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="fa fa-cogs"></i>Notificaciones
                            </div>
                            <div class="tools">
                                <a href="javascript:;" class="collapse"></a>
                                <a href="#portlet-config" data-toggle="modal" class="config"></a>
                                <a href="javascript:;" class="reload"></a>
                                <a href="javascript:;" class="remove"></a>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div runat="server" id="Notificacion1" class="alert alert-success">
                                <strong>Sorteo en Curso!</strong> Un sorteo se encuentra vigente.
                            </div>
                        </div>
                    </div>
                </div>
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
                                        <span class="caption-subject bold uppercase font-green-haze">Sorteos</span>
                                        <span class="caption-helper">Listado de sorteos.</span>
                                    </div>
                                    <div class="tools">
                                        <a href="javascript:;" class="collapse"></a>
                                        <a href="#portlet-config" data-toggle="modal" class="config"></a>
                                        <a href="javascript:;" class="reload"></a>
                                        <a href="javascript:;" class="fullscreen"></a>
                                        <a href="javascript:;" class="remove"></a>
                                    </div>
                                </div>
                                <div class="portlet-body">
                                    <div id="chart_1" class="chart" style="height: 500px;">

                                        <div class="portlet-body form">
                                            <!-- BEGIN FORM-->
                                            <div class="form-actions top">
                                                <div class="btn-set pull-left">
                                                    <asp:Button ID="btnNewSorteo" class="btn blue" runat="server" Text="Nuevo" OnClick="btnNewSorteo_Click" />
                                                    <asp:Button ID="btnEditarSorteo" class="btn yellow" runat="server" Text="Editar" OnClick="btnEditarSorteo_Click" />
                                                    <asp:Button ID="btnEliminarSorteo" class="btn red" runat="server" Text="Eliminar" OnClick="btnEliminarSorteo_Click" />
                                                </div>
                                            </div>
                                            <div class="form-body">
                                                <dx:ASPxGridView ID="gvSorteos" runat="server" KeyFieldName="codigoSorteo" Width="100%" Theme="Metropolis" AutoGenerateColumns="False">
                                                    <Columns>
                                                        <dx:GridViewDataTextColumn FieldName="codigoSorteo" ShowInCustomizationForm="True" Caption="Codigo" Visible="False" VisibleIndex="1"></dx:GridViewDataTextColumn>

                                                        <dx:GridViewDataDateColumn FieldName="fechaDesde" VisibleIndex="2" Caption="Fecha Desde" PropertiesDateEdit-DisplayFormatString="dd/MM/yyyy HH:mm:ss" PropertiesDateEdit-EditFormat="DateTime">
                                                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy HH:mm:ss" EditFormatString="dd/MM/yyyy HH:mm:ss">
                                                            </PropertiesDateEdit>
                                                        </dx:GridViewDataDateColumn>
                                                        <dx:GridViewDataDateColumn FieldName="fechaHasta" VisibleIndex="3" Caption="Fecha Hasta">
                                                            <PropertiesDateEdit DisplayFormatString="f" UseMaskBehavior="true" EditFormat="DateTime"></PropertiesDateEdit>
                                                        </dx:GridViewDataDateColumn>
                                                        <dx:GridViewDataTextColumn FieldName="descripcion" ShowInCustomizationForm="True" Caption="Descripcion" VisibleIndex="4"></dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="cantidadTirosPorUsuario" ShowInCustomizationForm="True" Caption="Cantidad Juegos x Usuario" VisibleIndex="5"></dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="cantidadPremiosPorUsuario" ShowInCustomizationForm="True" Caption="Cantidad Premios x Usuario" VisibleIndex="6"></dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="cantidadPremiosTotales" ShowInCustomizationForm="True" Caption="Cantidad Premios Totales" VisibleIndex="7"></dx:GridViewDataTextColumn>
                                                    </Columns>
                                                    <SettingsBehavior AllowFocusedRow="True" />
                                                    <Settings ShowFilterRow="True" />
                                                </dx:ASPxGridView>
                                            </div>

                                            <!-- END FORM-->
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
    <!-- BEGIN QUICK SIDEBAR -->
    <a href="javascript:;" class="page-quick-sidebar-toggler"><i class="icon-close"></i></a>
    <div class="page-quick-sidebar-wrapper">
        <div class="page-quick-sidebar">
            <div class="nav-justified">
                <ul class="nav nav-tabs nav-justified">
                    <li class="active">
                        <a href="#quick_sidebar_tab_1" data-toggle="tab">Users <span class="badge badge-danger">2</span>
                        </a>
                    </li>
                    <li>
                        <a href="#quick_sidebar_tab_2" data-toggle="tab">Alerts <span class="badge badge-success">7</span>
                        </a>
                    </li>
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown">More<i class="fa fa-angle-down"></i>
                        </a>
                        <ul class="dropdown-menu pull-right" role="menu">
                            <li>
                                <a href="#quick_sidebar_tab_3" data-toggle="tab">
                                    <i class="icon-bell"></i>Alerts </a>
                            </li>
                            <li>
                                <a href="#quick_sidebar_tab_3" data-toggle="tab">
                                    <i class="icon-info"></i>Notifications </a>
                            </li>
                            <li>
                                <a href="#quick_sidebar_tab_3" data-toggle="tab">
                                    <i class="icon-speech"></i>Activities </a>
                            </li>
                            <li class="divider"></li>
                            <li>
                                <a href="#quick_sidebar_tab_3" data-toggle="tab">
                                    <i class="icon-settings"></i>Settings </a>
                            </li>
                        </ul>
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <!-- END QUICK SIDEBAR -->
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
