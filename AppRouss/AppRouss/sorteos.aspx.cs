using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaAppRouss.Clases;
using BibliotecaAppRouss.Controladores;
using DevExpress.Web.ASPxGridView;
namespace AppRouss
{
    public partial class sorteos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {
                LoadGridSorteos();
                //LoadNotificaciones();
            }
            Session["idSorteo"] = null;
            Session["sorteoActual"] = null;
            Session["codigoOperacion"] = null;
        }

        private void LoadNotificaciones()
        {
            DataTable dtSorteoActual = ControladorGeneral.RecuperarSorteoActual();
            if (Convert.ToInt32(dtSorteoActual.Rows[0]["codigoSorteo"]) != 0)
            {
                //NotificacionSorteoEnCurso.Visible = true;
                //NotificacionSinSorteoEnCurso.Visible = false;
                btnNewSorteo.Visible = false;
            }
            else
            {
                //NotificacionSorteoEnCurso.Visible = false;
                //NotificacionSinSorteoEnCurso.Visible = true;
                btnNewSorteo.Visible = true;    
            }            
        }

        private void LoadGridSorteos()
        {
            gvSorteos.DataSource = ControladorGeneral.RecuperarTodosSorteos();
            gvSorteos.DataBind();
        }

        protected void btnNewSorteo_Click(object sender, EventArgs e)
        {
            DataTable dtSorteoActual = ControladorGeneral.RecuperarSorteoActual();
            if (Convert.ToInt32(dtSorteoActual.Rows[0]["codigoSorteo"]) != 0)
            {
                pcAceptarPcMensajeNotificacion.ShowOnPageLoad = true;
                lblAceptarPcMensajeNotificacion.Text = "Actualmente se encuentra un sorteo en curso, no se puede crear un nuevo sorteo. Intente nuevamente cuando finalice el sorteo vigente.";
            }
            else
            {
                Response.Redirect("sorteosAdd.aspx");
            }
        }

        protected void btnEditarSorteo_Click(object sender, EventArgs e)
        {
            Modificar();
        }

        private void Modificar()
        {

            Sorteo sorteoActual = new Sorteo();

            sorteoActual.Codigo = int.Parse(gvSorteos.GetRowValues(gvSorteos.FocusedRowIndex, "codigoSorteo").ToString());
            sorteoActual.FechaDesde = DateTime.Parse(gvSorteos.GetRowValues(gvSorteos.FocusedRowIndex, "fechaDesde").ToString());
            sorteoActual.FechaHasta = DateTime.Parse(gvSorteos.GetRowValues(gvSorteos.FocusedRowIndex, "fechaHasta").ToString());
            sorteoActual.Descripcion = gvSorteos.GetRowValues(gvSorteos.FocusedRowIndex, "descripcion").ToString();
            sorteoActual.CantidadTirosPorUsuario = int.Parse(gvSorteos.GetRowValues(gvSorteos.FocusedRowIndex, "cantidadTirosPorUsuario").ToString());
            sorteoActual.CantidadPremiosPorUsuario = int.Parse(gvSorteos.GetRowValues(gvSorteos.FocusedRowIndex, "cantidadPremiosPorUsuario").ToString());
            sorteoActual.CantidadPremiosTotales = int.Parse(gvSorteos.GetRowValues(gvSorteos.FocusedRowIndex, "cantidadPremiosTotales").ToString());
            
            Session.Add("sorteoActual", sorteoActual);

            Response.Redirect("sorteosAdd.aspx");
        }

        protected void btnEliminarSorteo_Click(object sender, EventArgs e)
        {
            DataTable dtParticipantesPorSorteo = ControladorGeneral.RecuperarParticipantesPorSorteo(obtenerCodigoFilaSeleccionada());
            
            if (dtParticipantesPorSorteo.Rows.Count != 0)
            {
                lblMensajeEliminarSorteo.Text = "Adevertencia, El sorteo que quiere elimina posee usuario que ya han participado. Precione ACEPTAR si desea continuar y eliminar todos los juegos del mismo o precione CANCELAR para volver.";
            }
            else
            {
                lblMensajeEliminarSorteo.Text = "¿Esta seguro que desea eliminar el sorteo?";
            }
            pcSorteos.ShowOnPageLoad = true;
        }

        private int obtenerCodigoFilaSeleccionada()
        {
            int codigo = 0;
            codigo = int.Parse(gvSorteos.GetRowValues(gvSorteos.FocusedRowIndex, "codigoSorteo").ToString());
            return codigo;
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {            
            ControladorGeneral.EliminarSorteo(obtenerCodigoFilaSeleccionada());
            pcSorteos.ShowOnPageLoad = false;
            Response.Redirect("sorteos.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            pcSorteos.ShowOnPageLoad = false;
        }

        protected void btnAceptarPcMensajeNotificacion_Click(object sender, EventArgs e)
        {
            pcAceptarPcMensajeNotificacion.ShowOnPageLoad = false;
        }
    }
}