<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="AppRouss.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- BEGIN CONTENT -->
    <div class="page-content-wrapper">
        <div class="page-content">
            <!-- BEGIN PAGE HEADER-->
            <h3 class="page-title">Inicio <small>reportes & estadisticas</small>
            </h3>
            <div class="page-bar">
                <ul class="page-breadcrumb">
                    <li>
                        <i class="fa fa-home"></i>
                        <a href="index.aspx">Inicio</a>
                        <i class="fa fa-angle-right"></i>
                    </li>
                </ul>
                <%--<div class="page-toolbar">
                    <div id="dashboard-report-range" class="pull-right tooltips btn btn-fit-height grey-salt" data-placement="top" data-original-title="Cambiar rango de fecha del Dashboard">
                        <i class="icon-calendar"></i>&nbsp; <span class="thin uppercase visible-lg-inline-block"></span>&nbsp; <i class="fa fa-angle-down"></i>
                    </div>
                </div>--%>
            </div>
            <!-- END PAGE HEADER-->
            <!-- BEGIN DASHBOARD STATS -->
            <div class="row">
                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                    <div class="dashboard-stat blue-madison">
                        <div class="visual">
                            <i class="fa fa-chevron-circle-up"></i>
                        </div>
                        <div class="details">
                            <div class="number">
                                <asp:Label ID="lblCantidadDeSorteosTotales" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="desc">
                                Sorteos
                            </div>
                        </div>
                        <%--<a class="more" href="#">Ver más <i class="m-icon-swapright m-icon-white"></i>
                        </a>--%>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                    <div class="dashboard-stat red-intense">
                        <div class="visual">
                            <i class="fa fa-user <%--fa-bar-chart-o--%>"></i>
                        </div>
                        <div class="details">
                            <div class="number">
                                <asp:Label ID="lblCantidadDeUsuariosTotales" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="desc">
                                Usuarios
                            </div>
                        </div>
                        <%--<a class="more" href="#">Ver más <i class="m-icon-swapright m-icon-white"></i>
                        </a>--%>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                    <div class="dashboard-stat green-haze">
                        <div class="visual">
                            <i class="fa fa-gamepad<%-- fa-shopping-cart--%>"></i>
                        </div>
                        <div class="details">
                            <div class="number">
                                <asp:Label ID="lblCantidadDeJuegosTotales" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="desc">
                                Juegos
                            </div>
                        </div>
                        <%--<a class="more" href="#">Ver más <i class="m-icon-swapright m-icon-white"></i>
                        </a>--%>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                    <div class="dashboard-stat purple-plum">
                        <div class="visual">
                            <i class="fa fa-bar-chart-o"></i>
                        </div>
                        <div class="details">
                            <div class="number">
                                <asp:Label ID="lblCantidadDeGanadoresTotales" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="desc">
                                Ganadores
                            </div>
                        </div>
                        <%--<a class="more" href="#">Ver más <i class="m-icon-swapright m-icon-white"></i>
                        </a>--%>
                    </div>
                </div>
            </div>
            <!-- END DASHBOARD STATS -->
            <div class="clearfix">
            </div>

                <div class="tab-content">
                    <div class="tab-pane active">
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="portlet yellow-crusta box">
                                    <div class="portlet-title">
                                        <div class="caption">
                                            <i class="fa fa-android"></i>Ultimo sorteo
                                        </div>
                                        <div class="actions">
                                            <asp:Button ID="btnVerReporte" CssClass="btn btn-default btn-sm" runat="server" Text="ver reporte" OnClick="btnVerReporte_Click" />
                                        </div>
                                    </div>
                                    <div class="portlet-body">
                                        <div class="row static-info">
                                            <div class="col-md-5 name">
                                                Descripción:
                                            </div>
                                            <div class="col-md-7 value">
                                               <asp:Label ID="lblDescripcionSorteo" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row static-info">
                                            <div class="col-md-5 name">
                                                Fecha Desde & Fecha Hasta:
                                            </div>
                                            <div class="col-md-7 value">
                                                <asp:Label ID="lblFechaDesdeHasta" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row static-info">
                                            <div class="col-md-5 name">
                                                Estado del Sorteo:
                                            </div>
                                            <div class="col-md-7 value">
                                                <asp:Label ID="lblEstadoSorteo" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row static-info">
                                            <div class="col-md-5 name">
                                                Cantidad de Ganadores:
                                            </div>
                                            <div class="col-md-7 value">
                                                <asp:Label ID="lblCantidadGanadores" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row static-info">
                                            <div class="col-md-5 name">
                                                Cantidad de Participantes:
                                            </div>
                                            <div class="col-md-7 value">
                                                <asp:Label ID="lblCantidadParticipantes" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            <div class="row ">

                <div class="col-md-12 col-sm-12">

                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="fa fa-gift"></i>Accesos directos
                            </div>
                            <div class="tools">
                                <a href="javascript:;" class="collapse"></a>
                                <a href="javascript:;" class="remove"></a>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <a href="reporteUsuarios.aspx" class="icon-btn">
                                <i class="fa fa-group"></i>
                                <div>
                                    Usuarios
                                </div>
                            </a>

                            <a href="sorteos.aspx" class="icon-btn">
                                <i class="fa fa-bitcoin"></i>
                                <div>
                                    Sorteos
                                </div>
                            </a>
<%--                            <a href="#" class="icon-btn">
												<i class="fa fa-sitemap"></i>
												<div>
													 Categories
												</div>
												</a>
                            <a href="#" class="icon-btn">
                                <i class="fa fa-calendar"></i>
                                <div>
                                    Actualizar Registros
                                </div>
                                <span class="badge badge-success">
												4 </span>
                            </a>
                            <a href="#" class="icon-btn">
												<i class="fa fa-envelope"></i>
												<div>
													 Inbox
												</div>
												<span class="badge badge-info">
												12 </span>
												</a>--%>
												<a href="reporteParticipantes.aspx" class="icon-btn">
												<i class="fa fa-bullhorn"></i>
												<div>
													 Ganadores
												</div>
												</a>
												<%--<a href="#" class="icon-btn">
												<i class="fa fa-map-marker"></i>
												<div>
													 Locations
												</div>
												</a>
												<a href="#" class="icon-btn">
												<i class="fa fa-money"><i></i></i>
												<div>
													 Finance
												</div>
												</a>
												<a href="#" class="icon-btn">
												<i class="fa fa-plane"></i>
												<div>
													 Projects
												</div>
												<span class="badge badge-info">
												21 </span>
												</a>
												<a href="#" class="icon-btn">
												<i class="fa fa-thumbs-up"></i>
												<div>
													 Feedback
												</div>
												<span class="badge badge-info">
												2 </span>
												</a>
												<a href="#" class="icon-btn">
												<i class="fa fa-cloud"></i>
												<div>
													 Servers
												</div>
												<span class="badge badge-danger">
												2 </span>
												</a>
												<a href="#" class="icon-btn">
												<i class="fa fa-globe"></i>
												<div>
													 Regions
												</div>
												</a>
												<a href="#" class="icon-btn">
												<i class="fa fa-heart-o"></i>
												<div>
													 Popularity
												</div>
												<span class="badge badge-info">
												221 </span>
												</a>--%>
                        </div>
                    </div>
                    <!-- BEGIN BLOCK BUTTONS PORTLET-->

                </div>
            </div>
            <div class="clearfix">
            </div>
        </div>
        <!-- END CONTENT -->

</asp:Content>
