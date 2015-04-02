using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaAppRouss.Controladores;
using BibliotecaAppRouss.Clases;

namespace AppRouss
{
    public partial class administradoresAdd : System.Web.UI.Page
    {
        private int codigoOperacion;
        Administrador oAdministradorActual;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {             
                //Cargo el form para editar
                if ((Administrador)Session["administradoActual"] != null)
                {

                    CargarDatosParaEditar((Administrador)Session["administradoActual"]);
                }
                else
                {
                    Session.Add("codigoOperacion",0);
                }

           }
        }

        private void CargarDatosParaEditar(Administrador oAdministradorActual)
        {
            codigoOperacion = oAdministradorActual.Codigo;
            txtUsuario.Text = oAdministradorActual.NombreUsuario;
            txtContraseña.Text = oAdministradorActual.Contraseña;
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Session["codigoOperacion"] == null)
            {
                oAdministradorActual = (Administrador)Session["administradoActual"];
                ControladorGeneral.InsertarActualizarAdministrador(oAdministradorActual.Codigo, txtUsuario.Text, txtContraseña.Text);
            }
            else
            { 
                ControladorGeneral.InsertarActualizarAdministrador(0, txtUsuario.Text, txtContraseña.Text); 
            }            
            Response.Redirect("administradores.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("administradores.aspx");
        }

    }
}