<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="usuariosAdd.aspx.cs" Inherits="AppRouss.usuariosAdd" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- BEGIN CONTENT -->
    <div class="page-content-wrapper">
        <div class="page-content">

            <!-- BEGIN PAGE HEADER-->
            <h3 class="page-title">Usuarios <small>alta, baja & modificación de Usuarios</small>
            </h3>
            <div class="page-bar">
                <ul class="page-breadcrumb">
                    <li>
                        <i class="fa fa-home"></i>
                        <a href="index.aspx">Inicio</a>
                        <i class="fa fa-angle-right"></i>
                    </li>
                    <li>
                        <a>ABM</a>
                        <i class="fa fa-angle-right"></i>
                    </li>
                    <li>
                        <a href="usuarios.aspx">Usuarios</a>
                    </li>
                </ul>


                <div class="page-toolbar">
                    <div class="btn-group pull-right">
                        <button type="button" class="btn btn-fit-height grey-salt dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-delay="1000" data-close-others="true">
                            Acciones <i class="fa fa-angle-down"></i>
                        </button>
                        <ul class="dropdown-menu pull-right" role="menu">
                            <li>
                                <a href="usuarios.aspx">Listado de Usuarios</a>
                            </li>
                        </ul>
                    </div>
                </div>
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
                                        <span class="caption-subject bold uppercase font-green-haze">Nuevo Usuario</span>
                                        <span class="caption-helper">Cargar nuevo usuario de la aplicación móvil</span>
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
                                            <div class="form-body">
                                                
                                                <div class="form-grour">
                                                    <label class="control-label">Nombre</label>
                                                    <asp:TextBox class="form-control" type="text" autocomplete="off" placeholder="ingrese nombre" name="nombre" ID="txtNombre" runat="server"></asp:TextBox>
                                                    <label id="lblNombreRequerido" class="help-block" style="color: red" visible="false" runat="server">nombre requerido</label>
                                                </div>
                                                <div class="form-grour">
                                                    <label class="control-label">Apellido</label>
                                                    <asp:TextBox class="form-control" type="text" autocomplete="off" placeholder="ingrese apellido" name="apellido" ID="txtApellido" runat="server"></asp:TextBox>
                                                    <label id="lblApellidoRequerido" class="help-block" style="color: red" visible="false" runat="server">apellido requerido</label>
                                                </div>
                                                <div class="form-grour">
                                                    <label class="control-label">Mail</label>
                                                    <asp:TextBox class="form-control" type="text" autocomplete="off" placeholder="ingrese mail" name="mail" ID="txtMail" runat="server"></asp:TextBox>
                                                    <label id="lblMailRequerido" class="help-block" style="color: red" visible="false" runat="server">mail requerido</label>
                                                </div>
                                                <div class="form-grour">
                                                    <label class="control-label">Teléfono</label>
                                                    <asp:TextBox class="form-control" type="text" autocomplete="off" placeholder="ingrese telefono" name="telefono" ID="txtTelefono" runat="server"></asp:TextBox>
                                                    <label id="lblTelefonoRequerido" class="help-block" style="color: red" visible="false" runat="server">teléfono requerido</label>
                                                </div>
                                                <div class="form-grour">
                                                    <label class="control-label">DNI</label>
                                                    <asp:TextBox MaxLength="8" class="form-control" type="text" autocomplete="off" placeholder="ingrese dni" name="dni" ID="txtDNI" runat="server"></asp:TextBox>
                                                    <label id="lblDniRequerido" class="help-block" style="color: red" visible="false" runat="server">DNI requerido</label>
                                                </div>
                                                <div class="form-group">
                                                    <label class="control-label">Contraseña</label>
                                                    <asp:TextBox class="form-control" type="password" autocomplete="off" placeholder="ingrese contraseña" name="password" ID="txtContraseña" runat="server"></asp:TextBox>
                                                    <label id="lblContraseñaRequerida" class="help-block" style="color: red" visible="false" runat="server">contraseña requerido</label>
                                                    
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
    
    <dx:ASPxPopupControl ClientInstanceName="pcUsuario" Width="330px" Height="250px"
            MaxWidth="800px" MaxHeight="800px" MinHeight="150px" MinWidth="150px" CloseOnEscape="true" ID="pcUsuario"
            AllowDragging="True" PopupElementID="imgButton" ShowHeader="false"
            runat="server" EnableViewState="False" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter"
            EnableHierarchyRecreation="True" Modal="True" Theme="Metropolis" PopupAnimationType="Slide">
            <ContentCollection>
                <dx:PopupControlContentControl runat="server">
                    <asp:Panel ID="Panel1" runat="server">
                        <div class="row">

                            <div class="col-md-12">
                                <div class="portlet box blue">
                                    <div class="portlet-title">
                                        <div class="caption">
                                            <i class="fa fa-gift"></i>Usuario
                                        </div>
                                    </div>
                                    <div class="portlet-body form">
                                        <!-- BEGIN FORM-->

                                        <div class="form-body">

                                            <div class="form-group">
                                                <label class="control-label">
                                                    <asp:Label ID="lblMensajeUsuario" runat="server" Text=""></asp:Label></label>
                                            </div>
                                        </div>
                                        <div class="form-actions">
                                            <div class="btn-set pull-right">
                                                <asp:Button ID="btnAceptarMensaje" class="btn blue" runat="server" Text="Aceptar" OnClick="btnAceptarMensaje_Click" />
                                            </div>
                                        </div>
                                        <!-- END FORM-->
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </dx:PopupControlContentControl>
            </ContentCollection>
        </dx:ASPxPopupControl>

</asp:Content>
