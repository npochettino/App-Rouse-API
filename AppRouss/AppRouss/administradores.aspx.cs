using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaAppRouss.Controladores;

namespace AppRouss
{
    public partial class administradores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrillaAdministradores();
            }
        }

        private void LoadGrillaAdministradores()
        {
            gvAdministradores.DataSource = ControladorGeneral.RecuperarTodosAdministradores();
        }

        protected void btnNewAdministrador_Click(object sender, EventArgs e)
        {
            Response.Redirect("administradoresAdd.aspx");
        }
        protected void btnEditarAdministrador_Click(object sender, EventArgs e)
        {

        }
        protected void btnEliminarAdministrador_Click(object sender, EventArgs e)
        {

        }
    }
}