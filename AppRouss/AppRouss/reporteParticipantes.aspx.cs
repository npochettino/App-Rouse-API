using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaAppRouss.Controladores;
using DevExpress.Data;
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
            if (rbTodos.Checked == true)
                LoadGrillaParticipante(1);
            else if (rbGanador.Checked == true)
                LoadGrillaParticipante(2);
            else
                LoadGrillaParticipante(3);

            gvExporter.ReportHeader = "Reporte de Participantes para el Sorteo: " + ddlSorteos.SelectedItem.Text.ToString();
            gvExporter.ExportedRowType = DevExpress.Web.ASPxGridView.Export.GridViewExportedRowType.All;
            gvExporter.WritePdfToResponse();
        }

        protected void btnXlsxExport_Click(object sender, EventArgs e)
        {
            if (rbTodos.Checked == true)
                LoadGrillaParticipante(1);
            else if (rbGanador.Checked == true)
                LoadGrillaParticipante(2);
            else
                LoadGrillaParticipante(3);

            gvExporter.ReportHeader = "Reporte de Participantes para el Sorteo: " + ddlSorteos.SelectedItem.Text.ToString();
            gvExporter.ExportedRowType = DevExpress.Web.ASPxGridView.Export.GridViewExportedRowType.All;
            gvExporter.WriteXlsxToResponse();
        }

        private void LoadGrillaParticipante(int opcion)
        {
            if (opcion == 1)//Muestro todos
            {
                gvParticipantes.DataSource = ControladorGeneral.RecuperarParticipantesPorSorteo(int.Parse(ddlSorteos.SelectedValue));
                gvParticipantes.GroupBy(gvParticipantes.Columns["descripcionPremio"]);
                gvParticipantes.ExpandAll();
                gvParticipantes.DataBind();
            }
            else if (opcion == 2)//Muestro Ganadores
            {
                gvParticipantes.DataSource = ControladorGeneral.RecuperarParticipantesPorSorteoGanadorONo(int.Parse(ddlSorteos.SelectedValue), true);
                gvParticipantes.GroupBy(gvParticipantes.Columns["descripcionPremio"]);
                gvParticipantes.ExpandAll();
                gvParticipantes.DataBind();
            }
            else
            {   //Muestro Segui Participando
                gvParticipantes.DataSource = ControladorGeneral.RecuperarParticipantesPorSorteoGanadorONo(int.Parse(ddlSorteos.SelectedValue), false);
                gvParticipantes.GroupBy(gvParticipantes.Columns["descripcionPremio"]);
                gvParticipantes.ExpandAll();
                gvParticipantes.DataBind();
            }
        }

        protected void ddlSorteos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbTodos.Checked == true)
                LoadGrillaParticipante(1);
            else if (rbGanador.Checked == true)
                LoadGrillaParticipante(2);
            else
                LoadGrillaParticipante(3);
        }

        protected void rbTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTodos.Checked == true)
                LoadGrillaParticipante(1);
        }

        protected void rbGanador_CheckedChanged(object sender, EventArgs e)
        {
            if (rbGanador.Checked == true)
                LoadGrillaParticipante(2);                
        }

        protected void rbSeguiParticipando_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSeguiParticipando.Checked == true)
                LoadGrillaParticipante(3);
        }

               
    }
}