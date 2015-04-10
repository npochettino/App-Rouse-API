using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaAppRouss.Clases;
using BibliotecaAppRouss.Controladores;

namespace AppRouss
{
    public partial class premios : System.Web.UI.Page
    {
        Premio oPremioActual;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGridPremios();
            }
        }

        private void LoadGridPremios()
        {
            gvPremios.DataSource = ControladorGeneral.RecuperarTodosPremios();
            gvPremios.DataBind();
        }

        protected void btnEditarPremios_Click(object sender, EventArgs e)
        {
            Modificar();
            ShowPopUpPremios();
        }

        private void ShowPopUpPremios()
        {
            pcPremios.ShowOnPageLoad = true;
            txtDescripcion.ReadOnly = true;
            CargarDatosParaEditar((Premio)Session["premioActual"]);

        }

        private void CargarDatosParaEditar(Premio premio)
        {
            txtDescripcion.Text = premio.Descripcion;
            txtProbabilidad.Text = premio.Probabilidad.ToString();
        }

        private void Modificar()
        {
            Premio premioActual = new Premio();
            premioActual.Codigo = int.Parse(gvPremios.GetRowValues(gvPremios.FocusedRowIndex, "codigoPremio").ToString());
            premioActual.Descripcion = gvPremios.GetRowValues(gvPremios.FocusedRowIndex, "descripcion").ToString();
            premioActual.Probabilidad = int.Parse(gvPremios.GetRowValues(gvPremios.FocusedRowIndex, "probabilidad").ToString());
            Session.Add("premioActual", premioActual);
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                oPremioActual = (Premio)Session["premioActual"];
                ControladorGeneral.InsertarActualizarPremio(oPremioActual.Codigo, oPremioActual.Descripcion, int.Parse(txtProbabilidad.Text));

                pcPremios.ShowOnPageLoad = false;
                LoadGridPremios();
            }
            txtDescripcion.ReadOnly = true;
        }

        private bool validar()
        {
            int number;

            if (txtProbabilidad.Text == "")
            { lblProbabilidadRequerido.InnerText = " El campo es requerido"; lblProbabilidadRequerido.Visible = true; return false; }
            try
            {
                if (!(Int32.TryParse(txtProbabilidad.Text.ToString(), out number)))
                { lblProbabilidadRequerido.InnerText = " Se requiere un numero entero"; lblProbabilidadRequerido.Visible = true; return false; }
            }
            catch 
            { 
                lblProbabilidadRequerido.InnerText = " Se requiere un numero entero"; lblProbabilidadRequerido.Visible = true; return false; 
            }
            
            if (!(int.Parse(txtProbabilidad.Text) >= 0 && int.Parse(txtProbabilidad.Text) <= 100))
            { lblProbabilidadRequerido.InnerText = " Se requiere un numero entre 0 y 100"; lblProbabilidadRequerido.Visible = true; return false; }
            else return true;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            pcPremios.ShowOnPageLoad = false;
        }
    }
}