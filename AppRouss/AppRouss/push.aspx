<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="push.aspx.cs" Inherits="AppRouss.push" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- BEGIN CONTENT -->
    <div class="page-content-wrapper">
        <div class="page-content">

            <!-- BEGIN PAGE HEADER-->
            <h3 class="page-title">Push Notification <small>crear & consultar push</small>
            </h3>
            <div class="page-bar">
                <ul class="page-breadcrumb">
                    <li>
                        <i class="fa fa-home"></i>
                        <a href="index.aspx">Inicio</a>
                        <i class="fa fa-angle-right"></i>
                    </li>
                    <li>
                        <a href="#">Push Notification</a>
                        <i class="fa fa-angle-right"></i>
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
                                        <span class="caption-subject bold uppercase font-green-haze">Push Notification</span>
                                        <span class="caption-helper">Listado de push.</span>
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
                                    <div id="chart_1" class="chart" style="height: auto;">
                                        <div class="portlet-body form">
                                            <!-- BEGIN FORM-->
                                            <div class="form-actions top">
                                                <div class="btn-set pull-left">
                                                    <asp:Button ID="btnNewPush" class="btn blue" runat="server" Text="Nuevo" OnClick="btnNewPush_Click" />
                                                </div>
                                            </div>
                                            <div class="form-body">
                                                <dx:ASPxGridView ID="gvPush" runat="server" KeyFieldName="codigoPush" Width="100%" Theme="Metropolis" AutoGenerateColumns="False">
                                                    <Columns>
                                                        <dx:GridViewDataTextColumn FieldName="codigoPush" ShowInCustomizationForm="True" Caption="Codigo" Visible="False" VisibleIndex="1"></dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataDateColumn FieldName="descripcion" VisibleIndex="2" Caption="Descripción">
                                                        </dx:GridViewDataDateColumn>
                                                        <dx:GridViewDataDateColumn FieldName="fechaHoraEnvio" VisibleIndex="3" Caption="Fecha Envío">
                                                        </dx:GridViewDataDateColumn>                                                        
                                                    </Columns>
                                                    <SettingsBehavior ColumnResizeMode="Control" AllowSort="false" />
                                                    <SettingsPager Mode="ShowAllRecords">
                                                    </SettingsPager>

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



    <dx:ASPxPopupControl ClientInstanceName="pcPush" Width="330px" Height="250px"
            MaxWidth="800px" MaxHeight="800px" MinHeight="150px" MinWidth="150px" CloseOnEscape="true" ID="pcPush"
            AllowDragging="True" PopupElementID="imgButton" HeaderText=""
            runat="server" EnableViewState="False" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter"
            EnableHierarchyRecreation="True" Modal="True" Theme="Metropolis" PopupAnimationType="Slide">
            <ContentCollection>
                <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                    <asp:Panel ID="Panel1" runat="server">
                        <div class="row">

                            <div class="col-md-12">
                                <div class="portlet box yellow">
                                    <div class="portlet-title">
                                        <div class="caption">
                                            <i class="fa fa-gift"></i>Push Notification
                                        </div>

                                    </div>
                                    <div class="portlet-body form">
                                        <!-- BEGIN FORM-->

                                        <div class="form-body">

                                            <div class="form-group">
                                               <%-- <label class="control-label">Descripción Push</label>--%>
                                                <label id="lblDescripcionPush" class="control-label" visible="true" runat="server">Descripción Push</label>
                                                <asp:TextBox ID="txtPush" runat="server"></asp:TextBox>
                                                <label id="lblPush" class="help-block" style="color: red" visible="false" runat="server"></label>
                                                <label id="lblInformacionPush" class="help-block" style="color: blue" visible="false" runat="server"></label>
                                            </div>


                                        </div>
                                        <div class="form-actions">
                                            <div class="btn-set pull-right">
                                                <asp:Button ID="btnConfirmar" class="btn blue" runat="server" Text="Confirmar" OnClick="btnConfirmar_Click" />
                                                <asp:Button ID="btnCancelar" class="btn red" runat="server" Text="Cancelar" AutoPostBack="False" OnClick="btnCancelar_Click" />
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
