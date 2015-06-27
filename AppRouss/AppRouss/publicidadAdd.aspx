<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="publicidadAdd.aspx.cs" Inherits="AppRouss.publicidadAdd" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxUploadControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!-- BEGIN CONTENT -->
    <div class="page-content-wrapper">
        <div class="page-content">
            <!-- BEGIN PAGE HEADER-->
            <h3 class="page-title">Publicidad <small>crear & consultar publicidad</small>
            </h3>
            <div class="page-bar">
                <ul class="page-breadcrumb">
                    <li>
                        <i class="fa fa-home"></i>
                        <a href="index.aspx">Inicio</a>
                        <i class="fa fa-angle-right"></i>
                    </li>
                    <li>
                        <a href="publicidad.aspx">Publicidad</a>
                        <i class="fa fa-angle-right"></i>
                    </li>
                </ul>


                <div class="page-toolbar">
                    <div class="btn-group pull-right">
                        <button type="button" class="btn btn-fit-height grey-salt dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-delay="1000" data-close-others="true">
                            Acciones <i class="fa fa-angle-down"></i>
                        </button>
                        <ul class="dropdown-menu pull-right" role="menu">
                            <li>
                                <a href="publicidad.aspx">Listado de Publicidades</a>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
            <!-- END PAGE HEADER-->
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
                                        <span class="caption-subject bold uppercase font-green-haze">Publicidad</span>
                                        <span class="caption-helper">Cargar nueva publicidad.</span>
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
                                                    <label class="control-label">Descripción</label>
                                                    <asp:TextBox type="text" class="form-control" ID="txtDescripcion" runat="server" placeholder="ingrese descripcion"></asp:TextBox>
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
                                                <label class="control-label">Imagen de publicidad</label>
                                                <div class="form-group">                                                    
                                                    <div class="col-lg-6">
                                                            <asp:FileUpload ID="fuImagen" runat="server" />                                                           
                                                    </div>
                                                    <div class="col-lg-6">
                                                            <p>
                                                                <label id="lblImagenCargada" class="control-label" runat="server"></label>
                                                            </p>
                                                    </div>
                                                    <label id="lblImagen" class="help-block" style="color: red" visible="false" runat="server"></label>
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

    <!-- END FOOTER -->

    <!-- Script para pop up fecha-->
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.6/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js" type="text/javascript"></script>

    <dx:ASPxPopupControl ClientInstanceName="pcPublicidad" Width="330px" Height="250px"
        MaxWidth="800px" MaxHeight="800px" MinHeight="150px" MinWidth="150px" CloseOnEscape="true" ID="pcPublicidad"
        AllowDragging="True" PopupElementID="imgButton" ShowHeader="false"
        runat="server" EnableViewState="False" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter"
        EnableHierarchyRecreation="True" Modal="True" Theme="Metropolis" PopupAnimationType="Slide">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                <asp:Panel ID="Panel1" runat="server">
                    <div class="row">

                        <div class="col-md-12">
                            <div class="portlet box blue">
                                <div class="portlet-title">
                                    <div class="caption">
                                        <i class="fa fa-gift"></i>Publicidad
                                    </div>
                                </div>
                                <div class="portlet-body form">
                                    <!-- BEGIN FORM-->

                                    <div class="form-body">

                                        <div class="form-group">
                                            <label class="control-label">
                                                <asp:Label ID="lblMensajeSorteo" runat="server" Text=""></asp:Label></label>
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


