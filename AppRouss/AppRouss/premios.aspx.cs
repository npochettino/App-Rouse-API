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
            //Modificar();
            ShowPopUpPremios();
        }

        private void ShowPopUpPremios()
        {
            pcPremios.ShowOnPageLoad = true;
            CargarDatosParaEditar();

        }

        private void CargarDatosParaEditar()
        {
            DataTable dtPremios = ControladorGeneral.RecuperarTodosPremios();
            for (int i = 0; i < dtPremios.Rows.Count; i++)
            {
                if (i == 0)
                    txtTrago.Text = dtPremios.Rows[i]["probabilidad"].ToString();
                if (i == 1)
                    txtDescuento.Text = dtPremios.Rows[i]["probabilidad"].ToString();
                if (i == 2)
                    txtChampagne.Text = dtPremios.Rows[i]["probabilidad"].ToString();
                if (i == 3)
                    txtSigueParticipando.Text = dtPremios.Rows[i]["probabilidad"].ToString();
                if (i == 4)
                    txtEntrada.Text = dtPremios.Rows[i]["probabilidad"].ToString();
                if (i == 5)
                    txt2x1.Text = dtPremios.Rows[i]["probabilidad"].ToString();
            }
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
                DataTable dtPremios = ControladorGeneral.RecuperarTodosPremios();
                for (int i = 0; i < dtPremios.Rows.Count; i++)
                {
                    if (i == 0)
                        ControladorGeneral.InsertarActualizarPremio(1, dtPremios.Rows[i]["descripcion"].ToString(), int.Parse(txtTrago.Text));
                        
                    if (i == 1)
                        ControladorGeneral.InsertarActualizarPremio(2, dtPremios.Rows[i]["descripcion"].ToString(), int.Parse(txtDescuento.Text));
                    if (i == 2)
                        ControladorGeneral.InsertarActualizarPremio(3, dtPremios.Rows[i]["descripcion"].ToString(), int.Parse(txtChampagne.Text));
                    if (i == 3)
                        ControladorGeneral.InsertarActualizarPremio(4, dtPremios.Rows[i]["descripcion"].ToString(), int.Parse(txtSigueParticipando.Text));
                    if (i == 4)
                        ControladorGeneral.InsertarActualizarPremio(5, dtPremios.Rows[i]["descripcion"].ToString(), int.Parse(txtEntrada.Text));
                    if (i == 5)
                        ControladorGeneral.InsertarActualizarPremio(6, dtPremios.Rows[i]["descripcion"].ToString(), int.Parse(txt2x1.Text));
                }
               
                pcPremios.ShowOnPageLoad = false;
                LoadGridPremios();
            }
            
        }

        private bool validar()
        {
            int number;
            number = int.Parse(txt2x1.Text) + int.Parse(txtChampagne.Text) + int.Parse(txtDescuento.Text) + int.Parse(txtEntrada.Text) + int.Parse(txtSigueParticipando.Text) + int.Parse(txtTrago.Text);
            if (number != 100)
            { lblProbabilidadRequerido.InnerText = " Error. La sumatoria de las probabilidades debe ser igual a 100."; lblProbabilidadRequerido.Visible = true; return false; }
           
            return true;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            pcPremios.ShowOnPageLoad = false;
        }
    }
}