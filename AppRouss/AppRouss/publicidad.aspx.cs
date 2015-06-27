using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaAppRouss.Clases;
using BibliotecaAppRouss.Controladores;

namespace AppRouss
{
    public partial class publicidad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGridPublicidad();
            }
            Session["publicidadActual"] = null;
            Session["codigoOperacion"] = null;
            Session["rutaImagen"] = null;
        }

        private void LoadGridPublicidad()
        {
            gvPublicidad.DataSource = ControladorGeneral.RecuperarTodasPublicidades();
            gvPublicidad.DataBind();
        }

        protected void btnNewPublicidad_Click(object sender, EventArgs e)
        {
            DataTable dtPublicidadActual = ControladorGeneral.RecuperarPublicidadActual();
            if (Convert.ToInt32(dtPublicidadActual.Rows[0]["codigoPublicidad"]) != 0)
            {
                pcAceptarPcMensajeNotificacion.ShowOnPageLoad = true;
                lblAceptarPcMensajeNotificacion.Text = "Actualmente se encuentra una publicidad en curso, no se puede crear una nueva publicidad. Intente nuevamente cuando finalice la publicidad vigente.";
            }
            else
            {
                Response.Redirect("publicidadAdd.aspx");
            }
        }

        protected void btnEditarPublicidad_Click(object sender, EventArgs e)
        {
            if(gvPublicidad.FocusedRowIndex != -1)
                Modificar();
        }

        private void Modificar()
        {

            Publicidad publicidadActual = new Publicidad();

            publicidadActual.Codigo = int.Parse(gvPublicidad.GetRowValues(gvPublicidad.FocusedRowIndex, "codigoPublicidad").ToString());
            publicidadActual.RutaImagen = gvPublicidad.GetRowValues(gvPublicidad.FocusedRowIndex, "rutaImagen").ToString();
            publicidadActual.FechaHoraInicio = DateTime.Parse(gvPublicidad.GetRowValues(gvPublicidad.FocusedRowIndex, "fechaHoraInicio").ToString());
            publicidadActual.FechaHoraFin = DateTime.Parse(gvPublicidad.GetRowValues(gvPublicidad.FocusedRowIndex, "fechaHoraFin").ToString());
            publicidadActual.Descripcion = gvPublicidad.GetRowValues(gvPublicidad.FocusedRowIndex, "descripcion").ToString();
            
            Session.Add("publicidadActual", publicidadActual);

            Response.Redirect("publicidadAdd.aspx");
        }

        protected void btnEliminarPublicidad_Click(object sender, EventArgs e)
        {
            lblMensajeEliminarPublicidad.Text = "¿Esta seguro que desea eliminar la publicidad?";
            
            pcPublicidad.ShowOnPageLoad = true;
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            ControladorGeneral.EliminarPublicidad(obtenerCodigoFilaSeleccionada());
            pcPublicidad.ShowOnPageLoad = false;
            LoadGridPublicidad();
        }

        private int obtenerCodigoFilaSeleccionada()
        {
            int codigo = 0;
            codigo = int.Parse(gvPublicidad.GetRowValues(gvPublicidad.FocusedRowIndex, "codigoPublicidad").ToString());
            return codigo;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            pcPublicidad.ShowOnPageLoad = false;
        }

        protected void btnAceptarPcMensajeNotificacion_Click(object sender, EventArgs e)
        {
            pcAceptarPcMensajeNotificacion.ShowOnPageLoad = false;
        }
    }
}