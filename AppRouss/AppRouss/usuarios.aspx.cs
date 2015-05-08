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
    public partial class usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrillaUsuarios();
            }
            Session["idUsuario"] = null;
            Session["usuarioActual"] = null;
            Session["codigoOperacion"] = null;
        }

        private void LoadGrillaUsuarios()
        {
            gvUsuario.DataSource = ControladorGeneral.RecuperarTodosUsuarios();
            gvUsuario.DataBind();
        }

        protected void btnNewUsuario_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void Nuevo()
        {
            Response.Redirect("usuariosAdd.aspx");
        }

        protected void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            Modificar();
        }

        private void Modificar()
        {
            Usuario usuarioActual = new Usuario();

            usuarioActual.Codigo = int.Parse(gvUsuario.GetRowValues(gvUsuario.FocusedRowIndex, "idUsuario").ToString());
            usuarioActual.Nombre = gvUsuario.GetRowValues(gvUsuario.FocusedRowIndex, "nombre").ToString();
            usuarioActual.Apellido = gvUsuario.GetRowValues(gvUsuario.FocusedRowIndex, "apellido").ToString();
            usuarioActual.Telefono = gvUsuario.GetRowValues(gvUsuario.FocusedRowIndex, "telefono").ToString();
            usuarioActual.Dni = gvUsuario.GetRowValues(gvUsuario.FocusedRowIndex, "dni").ToString();
            usuarioActual.Mail = gvUsuario.GetRowValues(gvUsuario.FocusedRowIndex, "mail").ToString();
            usuarioActual.Contraseña = gvUsuario.GetRowValues(gvUsuario.FocusedRowIndex, "contraseña").ToString();

            Session.Add("usuarioActual", usuarioActual);

            Response.Redirect("usuariosAdd.aspx");
        }

        private int obtenerCodigoFilaSeleccionada()
        {
            int codigo = 0;
            codigo = int.Parse(gvUsuario.GetRowValues(gvUsuario.FocusedRowIndex, "idUsuario").ToString());
            return codigo;
        }

        protected void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            lblMensajeEliminarUsuario.Text = "¿Esta seguro que desea eliminar el usuario?";
            pcUsuario.ShowOnPageLoad = true;
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            ControladorGeneral.EliminarUsuario(obtenerCodigoFilaSeleccionada());
            pcUsuario.ShowOnPageLoad = false;
            Response.Redirect("usuarios.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            pcUsuario.ShowOnPageLoad = false;
        }
    }
}