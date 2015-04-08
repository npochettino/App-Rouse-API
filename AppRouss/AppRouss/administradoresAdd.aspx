<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="administradoresAdd.aspx.cs" Inherits="AppRouss.administradoresAdd" %>

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
								<a href="administradores.aspx">Listado de Administradores</a>
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
                                        <span class="caption-subject bold uppercase font-green-haze">Nuevo Administrador</span>
                                        <span class="caption-helper">Cargar nuevo administrador del Back End</span>
                                    </div>
                                    <div class="tools">
                                        <a href="javascript:;" class="collapse"></a>
                                        <a href="javascript:;" class="fullscreen"></a>
                                        <a href="javascript:;" class="remove"></a>
                                    </div>
                                </div>
                                 <div class="portlet-body">
                                    <div id="chart_1" class="chart" style="height: 100%;">
                                        <div class="portlet-body form">
                                            <!-- BEGIN FORM-->
                                            <%--<div class="form-actions top">
                                                <div class="btn-set pull-left">
                                                    <button type="submit" class="btn green">Submit</button>
                                                    <button type="button" class="btn blue">Other Action</button>
                                                </div>
                                                <div class="btn-set pull-right">
                                                    <button type="button" class="btn default">Action 1</button>
                                                    <button type="button" class="btn red">Action 2</button>
                                                    <button type="button" class="btn yellow">Action 3</button>
                                                </div>
                                            </div>--%>
                                            <div class="form-body">
                                                <div class="form-grour">
                                                    <label class="control-label">Usuario</label>
                                                    <asp:TextBox class="form-control" type="text" autocomplete="off" placeholder="ingrese usuario" name="username" ID="txtUsuario" runat="server"></asp:TextBox>                                                       
                                                    <label id="lblUsuarioRequerido" class="help-block" style="color:red" visible="false" runat="server"> usuario requerido</label>

<%--                                                    <label id="lblUsuarioUnico" class="help-block" style="color:red" visible="false" runat="server"> el usuario debe ser único</label>--%>
                                                </div>
                                                
                                                <div class="form-group">
                                                    <label class="control-label">Contraseña</label>
                                                    <%--<div class="input-group">--%>
                                                        <asp:TextBox class="form-control" type="password" autocomplete="off" placeholder="ingrese contraseña" name="password" ID="txtContraseña" runat="server"></asp:TextBox>
                                                        <%--<span class="input-group-addon">
                                                            <i class="fa fa-user"></i>
                                                        </span>--%>
                                                        <label id="lblContraseñaRequerida" class="help-block" style="color:red" visible="false" runat="server"> contraseña requerido</label>
                                                    <%--</div>--%>
                                                </div>
                                                
                                            </div>
                                            <div class="form-actions">
                                                <div class="btn-set pull-right">
                                                    <asp:Button ID="btnConfirmar" class="btn blue" runat="server" Text="Confirmar" OnClick="btnConfirmar_Click" />
                                                    <asp:Button ID="btnCancelar" class="btn red" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                                                </div>
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
