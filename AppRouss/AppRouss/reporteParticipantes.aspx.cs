using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaAppRouss.Controladores;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;

namespace AppRouss
{
    public partial class reporteParticipantes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDdlSorteo();
            }
        }

        private void LoadDdlSorteo()
        {
            DataTable dtSorteos = ControladorGeneral.RecuperarTodosSorteos();
            ddlSorteos.DataSource = dtSorteos;
            ddlSorteos.DataTextField = "descripcion";
            ddlSorteos.DataValueField = "codigoSorteo";
            ddlSorteos.DataBind();
            ddlSorteos.Items.Insert(0, new ListItem("--Seleccione un sorteo--", "0"));
            ddlSorteos.SelectedIndex = ddlSorteos.Items.IndexOf(ddlSorteos.Items.FindByText("--Seleccione un sorteo--"));
        }

        protected void btnPdfExport_Click(object sender, EventArgs e)
        {
            LoadGrillaParticipante();
            gvExporter.ReportHeader = "Reporte de Participantes para el Sorteo: " + ddlSorteos.SelectedItem.Text.ToString();
            gvExporter.ExportedRowType = DevExpress.Web.ASPxGridView.Export.GridViewExportedRowType.All;
            gvExporter.WritePdfToResponse();
        }

        protected void btnXlsxExport_Click(object sender, EventArgs e)
        {
            LoadGrillaParticipante();
            gvExporter.ReportHeader = "Reporte de Participantes para el Sorteo: " + ddlSorteos.SelectedItem.Text.ToString();
            gvExporter.ExportedRowType = DevExpress.Web.ASPxGridView.Export.GridViewExportedRowType.All;
            gvExporter.WriteXlsxToResponse();
        }

        protected void btnCargarReporteParticipante_Click(object sender, EventArgs e)
        {
            int test = int.Parse(ddlSorteos.SelectedValue);
            LoadGrillaParticipante();
        }

        private void LoadGrillaParticipante()
        {
            gvParticipantes.DataSource = ControladorGeneral.RecuperarParticipantesPorSorteo(int.Parse(ddlSorteos.SelectedValue));
            gvParticipantes.DataBind();
        }

        protected void ddlSorteos_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGrillaParticipante();
        }
    }
}