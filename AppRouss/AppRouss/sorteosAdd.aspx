<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="sorteosAdd.aspx.cs" Inherits="AppRouss.sorteosAdd" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

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
                        <a href="sorteos.aspx">Sorteos</a>
                    </li>
                </ul>


                <div class="page-toolbar">
                    <div class="btn-group pull-right">
                        <button type="button" class="btn btn-fit-height grey-salt dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-delay="1000" data-close-others="true">
                            Acciones <i class="fa fa-angle-down"></i>
                        </button>
                        <ul class="dropdown-menu pull-right" role="menu">
                            <li>
                                <a href="sorteos.aspx">Listado de Sorteos</a>
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
                                <a href="javascript:;" class="remove"></a>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div id="NotificacionERROR" runat="server" class="alert alert-danger">
                                <strong>Error!</strong> No se pueden crear nuevos sorteos ya que hay uno vigente.
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
                                        <span class="caption-helper">Cargar nuevo sorteo.</span>
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
                                                <div class="form-group">
                                                    <label class="control-label">Descripción del sorteo</label>
                                                    <asp:TextBox type="text" class="form-control" ID="txtDescripcionSorteo" runat="server" placeholder="ingrese descripcion"></asp:TextBox>
                                                    <label id="lblDescripcion" class="help-block" style="color: red" visible="false" runat="server"></label>
                                                </div>

                                                <div class="form-group">
                                                    <label class="control-label">Fecha Desde</label>
                                                    <dx:ASPxDateEdit ID="deFechaDesde" runat="server" EditFormatString="dd/MM/yyyy HH:mm:ss" Theme="Metropolis" class="form-control" Width="100%" EditFormat="Custom">
                                                        <TimeSectionProperties Visible="true">
                                                            <TimeEditProperties EditFormatString="HH:mm:ss" />
                                                            <TimeEditProperties DisplayFormatString="dd/MM/yyyy" />
                                                        </TimeSectionProperties>
                                                    </dx:ASPxDateEdit>
                                                    <label id="lblFechaDesde" class="help-block" style="color: red" visible="false" runat="server"></label>
                                                </div>
                                                <div class="form-group">
                                                    <label class="control-label">Fecha Hasta</label>
                                                    <dx:ASPxDateEdit ID="deFechaHasta" runat="server" EditFormatString="dd/MM/yyyy HH:mm:ss" Theme="Metropolis" class="form-control" Width="100%">
                                                        <TimeSectionProperties Visible="true">
                                                            <TimeEditProperties EditFormatString="HH:mm:ss" />
                                                            <TimeEditProperties DisplayFormatString="dd/MM/yyyy" />
                                                        </TimeSectionProperties>
                                                    </dx:ASPxDateEdit>
                                                    <label id="lblFechaHasta" class="help-block" style="color: red" visible="false" runat="server"></label>
                                                </div>
                                                <div class="form-group">
                                                    <label class="control-label">Cantidad de Oportunidades por Usuario</label>
                                                    <asp:TextBox type="text" class="form-control" ID="txtCantidadOportunidades" Text="1" runat="server"></asp:TextBox>
                                                    <label id="lblCantidadOportunidades" class="help-block" style="color: red" visible="false" runat="server"></label>
                                                </div>
                                                <div class="form-group">
                                                    <label class="control-label">Cantidad de veces que puede ganar un usuario</label>
                                                    <asp:TextBox type="text" class="form-control" ID="txtCantidadVictorias" Text="1" runat="server"></asp:TextBox>
                                                    <label id="lblCantidadVictorias" class="help-block" style="color: red" visible="false" runat="server"></label>
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
                        </div>
                        <!-- END CHART PORTLET-->
                    </div>
                </div>
            </div>
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

    <!-- Script para pop up fecha-->
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.6/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js" type="text/javascript"></script>
    <%--<script type="text/javascript">
        $(function () {
            $("[id$=txtFechaDesde]").datepicker({
            });           

        });
    </script>
    <script type="text/javascript">
        $(function () {
            $("[id$=txtFechaHasta]").datepicker({
            });
            $("[id$=txtFechaHasta]").datepicker.parseDate("yy-mm-dd", "2007-01-26");
        });
    </script>--%>


    <!-- END JAVASCRIPTS -->




</asp:Content>


