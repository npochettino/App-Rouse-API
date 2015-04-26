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
    public partial class index : System.Web.UI.Page
    {
        int CantidadParticipantes = 0;
        int CantidadGanadores = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDatosUltimosorteo();
                LoadCantidadDeUsuarios();
                LoadCantidadDeJuegosYGanadores();
            }
        }

        private void LoadCantidadDeJuegosYGanadores()
        {
            DataTable dtParticipantes = ControladorGeneral.RecuperarTodosParticipantes();
            lblCantidadDeJuegosTotales.Text = dtParticipantes.Rows.Count.ToString();
            int CantidadTotalDeGanadores = 0;
            for (int i = 0; i < dtParticipantes.Rows.Count; i++)
            {
                if (int.Parse(dtParticipantes.Rows[i]["codigoPremio"].ToString()) != 4)
                    CantidadTotalDeGanadores = CantidadTotalDeGanadores + 1;
            }
            lblCantidadDeGanadoresTotales.Text = CantidadTotalDeGanadores.ToString();
        }

        private void LoadCantidadDeUsuarios()
        {
            DataTable dtUsuarios = ControladorGeneral.RecuperarTodosUsuarios();
            lblCantidadDeUsuariosTotales.Text = dtUsuarios.Rows.Count.ToString();
        }

        private void LoadDatosUltimosorteo()
        {
            DataTable dtSorteoAnterios = ControladorGeneral.RecuperarTodosSorteos();
            lblCantidadDeSorteosTotales.Text = dtSorteoAnterios.Rows.Count.ToString();
            DataTable dtSorteo = ControladorGeneral.RecuperarSorteoActual();

            if (Convert.ToInt32(dtSorteo.Rows[0]["codigoSorteo"]) != 0)
            {
                lblDescripcionSorteo.Text = dtSorteo.Rows[0]["descripcion"].ToString();
                lblEstadoSorteo.Text = "En Curso";
                lblEstadoSorteo.CssClass = "label label-success";
                lblFechaDesdeHasta.Text = dtSorteo.Rows[0]["fechaDesde"].ToString() + " - " + dtSorteo.Rows[0]["fechaHasta"].ToString();
                findCantidadDeParticipantesYGanadores(int.Parse(dtSorteo.Rows[0]["codigoSorteo"].ToString()));
                lblCantidadParticipantes.Text = CantidadParticipantes.ToString();
                lblCantidadGanadores.Text = CantidadGanadores.ToString();
            }
            else
            {
                //Si no hay un Sorteo Actual. Busco el ultimo sorteo.
                //DataTable dtSorteoAnterios = ControladorGeneral.RecuperarTodosSorteos();
                int codigoUltimoSorteo = 0;
                DateTime ultimaFechaFinSorteo = new DateTime();

                for (int i = 0; i < dtSorteoAnterios.Rows.Count; i++)
                {
                    if (DateTime.Parse(dtSorteoAnterios.Rows[i]["fechaHasta"].ToString()) > ultimaFechaFinSorteo && DateTime.Parse(dtSorteoAnterios.Rows[i]["fechaHasta"].ToString()) < DateTime.Now)
                    {
                        ultimaFechaFinSorteo = DateTime.Parse(dtSorteoAnterios.Rows[i]["fechaHasta"].ToString());
                        codigoUltimoSorteo = int.Parse(dtSorteoAnterios.Rows[i]["codigoSorteo"].ToString());
                    }
                }

                for (int i = 0; i < dtSorteoAnterios.Rows.Count; i++)
                {
                    if (int.Parse(dtSorteoAnterios.Rows[i]["codigoSorteo"].ToString()) == codigoUltimoSorteo)
                    {
                        lblFechaDesdeHasta.Text = dtSorteoAnterios.Rows[i]["fechaDesde"].ToString() + " - " + dtSorteoAnterios.Rows[i]["fechaHasta"].ToString();
                        lblDescripcionSorteo.Text = dtSorteoAnterios.Rows[i]["descripcion"].ToString();
                        findCantidadDeParticipantesYGanadores(int.Parse(dtSorteoAnterios.Rows[i]["codigoSorteo"].ToString()));
                        lblCantidadParticipantes.Text = CantidadParticipantes.ToString();
                        lblCantidadGanadores.Text = CantidadGanadores.ToString();
                    }
                }

                lblEstadoSorteo.Text = "Cerrado";
                lblEstadoSorteo.CssClass = "label label-danger";
            }
        }

        private void findCantidadDeParticipantesYGanadores(int codigoSorteo)
        {
            DataTable dtParticipantesPorSorteo = ControladorGeneral.RecuperarParticipantesPorSorteo(codigoSorteo);
            CantidadParticipantes = dtParticipantesPorSorteo.Rows.Count;
            for (int i = 0; i < dtParticipantesPorSorteo.Rows.Count; i++)
            {
                if (int.Parse(dtParticipantesPorSorteo.Rows[i]["codigoPremio"].ToString()) != 4)
                    CantidadGanadores = CantidadGanadores + 1;
            }
        }

        protected void btnVerReporte_Click(object sender, EventArgs e)
        {

            Response.Redirect("reporteParticipantes.aspx");
        }
    }
}