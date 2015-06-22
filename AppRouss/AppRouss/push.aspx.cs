using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaAppRouss.Controladores;
using BibliotecaAppRouss.Clases;

namespace AppRouss
{
    public partial class push : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGridPush();
            }
        }

        private void LoadGridPush()
        {
            gvPush.DataSource = ControladorGeneral.RecuperarTodasPush();
            gvPush.DataBind();
        }

        protected void btnNewPush_Click(object sender, EventArgs e)
        {
            pcPush.ShowOnPageLoad = true;
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            enviarPush();
        }

        private void enviarPush()
        {
            if (validar())
            {
                Push pushActual = new Push();
                pushActual.Descripcion = txtPush.Text;
                pushActual.FechaHoraEnvio = DateTime.Now;

                ControladorGeneral.InsertarPush(0,txtPush.Text, DateTime.Now);

                lblDescripcionPush.Visible = false;
                txtPush.Visible = false;
                btnCancelar.Visible = false;
                btnConfirmar.Visible = false;
                lblPush.Visible = false;
                lblInformacionPush.Visible = true;
                lblInformacionPush.InnerText = "La Push se ha enviado correctamente.";

                LoadGridPush();
            }
            else
            {
                pcPush.ShowOnPageLoad = false;
            }
        }

        private bool validar()
        {
            if (txtPush.Text == "" || string.IsNullOrWhiteSpace(txtPush.Text) == true || string.IsNullOrEmpty(txtPush.Text) == true)
            { lblPush.InnerText = " El campo es requerido"; return false; }            
            
            return true;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            pcPush.ShowOnPageLoad = false;
        }
    }
}