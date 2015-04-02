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
    public partial class administradores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrillaAdministradores();
            }
            Session["idAdministrador"] = null;
            Session["administradoActual"] = null;
            Session["codigoOperacion"] = null;
        }

        private void LoadGrillaAdministradores()
        {
            gvAdministradores.DataSource = ControladorGeneral.RecuperarTodosAdministradores();
            gvAdministradores.DataBind();
        }

        protected void btnNewAdministrador_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void Nuevo()
        {
            Response.Redirect("administradoresAdd.aspx");
        }
        protected void btnEditarAdministrador_Click(object sender, EventArgs e)
        {
            Modificar();
        }

        private void Modificar()
        {
            Administrador administradorActual = new Administrador();

            administradorActual.Codigo = int.Parse(gvAdministradores.GetRowValues(gvAdministradores.FocusedRowIndex, "idAdministrador").ToString());
            administradorActual.NombreUsuario = gvAdministradores.GetRowValues(gvAdministradores.FocusedRowIndex, "usuario").ToString();
            administradorActual.Contraseña = gvAdministradores.GetRowValues(gvAdministradores.FocusedRowIndex, "contraseña").ToString();

            Session.Add("administradoActual", administradorActual);

            Response.Redirect("administradoresAdd.aspx");
        }

        private int obtenerCodigoFilaSeleccionada()
        {
            int codigo = 0;
            codigo = int.Parse(gvAdministradores.GetRowValues(gvAdministradores.FocusedRowIndex, "idAdministrador").ToString());
            return codigo;
        }
        protected void btnEliminarAdministrador_Click(object sender, EventArgs e)
        {
            ControladorGeneral.EliminarAdministrador(obtenerCodigoFilaSeleccionada());
        }
    }
}