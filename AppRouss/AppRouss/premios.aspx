<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="premios.aspx.cs" Inherits="AppRouss.premios" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>


<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!-- BEGIN CONTENT -->
    <div class="page-content-wrapper">
        <div class="page-content">

            <!-- BEGIN PAGE HEADER-->
            <h3 class="page-title">Premios <small>listado de premios </small>
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
                        <a href="premios.aspx">Premios</a>
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
                                        <span class="caption-subject bold uppercase font-green-haze">Premios</span>
                                        <span class="caption-helper">premios que se entregan a través de la App</span>
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
                                                    <asp:Button ID="btnEditarPremios" class="btn yellow" runat="server" Text="Editar" OnClick="btnEditarPremios_Click" />
                                                </div>
                                            </div>
                                            <div class="form-body">

                                                <dx:ASPxGridView ID="gvPremios" Width="100%" runat="server" Theme="Metropolis" AutoGenerateColumns="False" KeyFieldName="codigoPremio">
                                                    <Columns>
                                                        <dx:GridViewDataTextColumn Caption="codigoPremio" FieldName="codigoPremio" Visible="False" VisibleIndex="0">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Descripcion" FieldName="descripcion" VisibleIndex="1">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Probabilidad" FieldName="probabilidad" VisibleIndex="2">
                                                        </dx:GridViewDataTextColumn>
                                                    </Columns>
                                                </dx:ASPxGridView>

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
        </div>

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

        <dx:ASPxPopupControl ClientInstanceName="pcPremios" Width="330px" Height="250px"
            MaxWidth="800px" MaxHeight="800px" MinHeight="150px" MinWidth="150px" CloseOnEscape="true" ID="pcPremios"
            AllowDragging="True" PopupElementID="imgButton" HeaderText="Edición de Premios"
            runat="server" EnableViewState="False" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter"
            EnableHierarchyRecreation="True" Modal="True" Theme="Metropolis" PopupAnimationType="Slide">
            <ContentCollection>
                <dx:PopupControlContentControl runat="server">
                    <asp:Panel ID="Panel1" runat="server">
                        <div class="row">

                            <div class="col-md-12">
                                <div class="portlet box yellow">
                                    <div class="portlet-title">
                                        <div class="caption">
                                            <i class="fa fa-gift"></i>Premio
                                        </div>

                                    </div>
                                    <div class="portlet-body form">
                                        <!-- BEGIN FORM-->

                                        <div class="form-body">

                                            <div class="form-group">
                                                <label class="control-label">Probabilidad Trago</label>
                                                <dx:ASPxSpinEdit ID="txtTrago" MinValue="0" MaxValue="100" runat="server" class="form-control" type="text" autocomplete="off" placeholder="ingrese probabilidad" ></dx:ASPxSpinEdit>
                                                <label id="lblProbabilidadRequerido" class="help-block" style="color: red" visible="false" runat="server"></label>
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label">Probabilidad Descuento</label>
                                                <dx:ASPxSpinEdit ID="txtDescuento" MinValue="0" MaxValue="100" runat="server" class="form-control" type="text" autocomplete="off" placeholder="ingrese probabilidad" >
                                            </dx:ASPxSpinEdit>
                                            </div>
                                            
                                            <div class="form-group">
                                                <label class="control-label">Probabilidad Champagne</label>
                                                <dx:ASPxSpinEdit ID="txtChampagne" MinValue="0" MaxValue="100" runat="server" class="form-control" type="text" autocomplete="off" placeholder="ingrese probabilidad" ></dx:ASPxSpinEdit>
                                                <label id="Label1" class="help-block" style="color: red" visible="false" runat="server"></label>
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label">Probabilidad Segui Participando</label>
                                                <dx:ASPxSpinEdit ID="txtSigueParticipando" MinValue="0" MaxValue="100" runat="server" class="form-control" type="text" autocomplete="off" placeholder="ingrese probabilidad" ></dx:ASPxSpinEdit>
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label">Probabilidad Entrada</label>
                                                <dx:ASPxSpinEdit ID="txtEntrada" MinValue="0" MaxValue="100" runat="server" class="form-control" type="text" autocomplete="off" placeholder="ingrese probabilidad" ></dx:ASPxSpinEdit>
                                                <label id="Label2" class="help-block" style="color: red" visible="false" runat="server"></label>
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label">Probabilidad 2 x 1</label>
                                                <dx:ASPxSpinEdit ID="txt2x1" MinValue="0" MaxValue="100" runat="server" class="form-control" type="text" autocomplete="off" placeholder="ingrese probabilidad" ></dx:ASPxSpinEdit>
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
                    </asp:Panel>
                </dx:PopupControlContentControl>
            </ContentCollection>
        </dx:ASPxPopupControl>
</asp:Content>
