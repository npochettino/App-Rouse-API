using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaAppRouss.Controladores;
using DevExpress.Web.ASPxGridView.Export.Helper;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;

namespace AppRouss
{
    public partial class reporteUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrillaUsuarios();
            }
        }

        private void LoadGrillaUsuarios()
        {
            gvUsuarios.DataSource = ControladorGeneral.RecuperarTodosUsuarios();
            gvUsuarios.DataBind();
        }

        protected void btnPdfExport_Click(object sender, EventArgs e)
        {
            LoadGrillaUsuarios();
            gridExport.ExportedRowType = DevExpress.Web.ASPxGridView.Export.GridViewExportedRowType.All;            
            gridExport.WritePdfToResponse();
        }

        protected void btnXlsxExport_Click(object sender, EventArgs e)
        {
            LoadGrillaUsuarios();
            gridExport.ExportedRowType = DevExpress.Web.ASPxGridView.Export.GridViewExportedRowType.All;
            gridExport.WriteXlsxToResponse();
            //gridExport.WriteXlsxToResponse(new XlsxExportOptionsEx { ExportType = ExportType.WYSIWYG });
        }
    }
}