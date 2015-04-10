using System;
using System.Collections.Generic;
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
            }
            Session["idSorteo"] = null;
            Session["sorteoActual"] = null;
            Session["codigoOperacion"] = null;
        }

        private void LoadGridSorteos()
        {
            gvSorteos.DataSource = ControladorGeneral.RecuperarTodosSorteos();
            gvSorteos.DataBind();
        }

        protected void btnNewSorteo_Click(object sender, EventArgs e)
        {
            Response.Redirect("sorteosAdd.aspx");
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
            ControladorGeneral.EliminarSorteo(obtenerCodigoFilaSeleccionada());
            LoadGridSorteos();
        }

        private int obtenerCodigoFilaSeleccionada()
        {
            int codigo = 0;
            codigo = int.Parse(gvSorteos.GetRowValues(gvSorteos.FocusedRowIndex, "codigoSorteo").ToString());
            return codigo;
        }
    }
}