<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="administradores.aspx.cs" Inherits="AppRouss.administradores" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- BEGIN CONTENT -->
    <div class="page-content-wrapper">
        <div class="page-content">

            <!-- BEGIN PAGE HEADER-->
            <h3 class="page-title">Administradores <small>alta, baja & modificación de administradores</small>
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
                        <a href="administradores.aspx">Administradores</a>
                    </li>
                </ul>


                <div class="page-toolbar">
                    <div class="btn-group pull-right">
                        <button type="button" class="btn btn-fit-height grey-salt dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-delay="1000" data-close-others="true">
                            Acciones <i class="fa fa-angle-down"></i>
                        </button>
                        <ul class="dropdown-menu pull-right" role="menu">
                            <li>
                                <a href="administradoresAdd.aspx">Nuevo Administrador</a>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
            <!-- END PAGE HEADER-->
            <!-- BEGIN PAGE CONTENT-->
            <%--<div class="row">
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
                            <div runat="server" id="NotificacionOK" class="alert alert-success" visible="false">
                                <strong>Success!</strong> El reloj se conecto correctamente.
                            </div>
                            <div id="NotificacionERROR" runat="server" class="alert alert-danger" visible="false">
                                <strong>Error!</strong> Conecte el Reloj.
                            </div>
                        </div>
                    </div>
                </div>
            </div>--%>
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
                                        <span class="caption-subject bold uppercase font-green-haze">Administradores</span>
                                        <span class="caption-helper">Listado de administradores del Back End.</span>
                                    </div>
                                    <div class="tools">
                                        <a href="javascript:;" class="collapse"></a>
                                        <%--<a href="#portlet-config" data-toggle="modal" class="config"></a>
                                        <a href="javascript:;" class="reload"></a>--%>
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
                                                    <asp:Button ID="btnNewAdministrador" class="btn blue" runat="server" Text="Nuevo" OnClick="btnNewAdministrador_Click" />
                                                    <asp:Button ID="btnEditarAdministrador" class="btn yellow" runat="server" Text="Editar" OnClick="btnEditarAdministrador_Click" />
                                                    <asp:Button ID="btnEliminarAdministrador" class="btn red" runat="server" Text="Eliminar" OnClick="btnEliminarAdministrador_Click" />
                                                </div>
                                            </div>
                                            <div class="form-body">

                                                <dx:ASPxGridView ID="gvAdministradores" KeyFieldName="idAdministrador" Width="100%" runat="server" Theme="Metropolis" AutoGenerateColumns="False">
                                                    <Columns>
                                                        <dx:GridViewDataTextColumn Caption="idAdministrador" FieldName="idAdministrador" Visible="False" VisibleIndex="1">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Usuario" FieldName="usuario" VisibleIndex="2" Visible="true">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Contraseña" FieldName="contraseña" VisibleIndex="3">
                                                        <PropertiesTextEdit Password="True">
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>
                                                    </Columns>
                                                    <SettingsBehavior AllowFocusedRow="True" />
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
                        <a href="#quick_sidebar_tab_1" data-toggle="tab">Users                         <a href="#" class="dropdown-toggle" data-toggle="dropdown">More<i class="fa fa-angle-down"></i>
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
                            </ul></li>
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
