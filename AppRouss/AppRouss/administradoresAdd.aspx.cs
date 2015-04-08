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
                    txtUsuario.ReadOnly = true;
                    CargarDatosParaEditar((Administrador)Session["administradoActual"]);
                }
                else
                {
                    Session.Add("codigoOperacion",0);
                    txtUsuario.ReadOnly = false;
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
            if (validad())
            { 
                //si el codigoOperacion es Null es una edicion.
                if (Session["codigoOperacion"] == null)
                {
                    oAdministradorActual = (Administrador)Session["administradoActual"];
                    ControladorGeneral.InsertarActualizarAdministrador(oAdministradorActual.Codigo, txtUsuario.Text, txtContraseña.Text);
                }
                //si el codigoOperacion es != null hago un insert.
                else
                { 
                    ControladorGeneral.InsertarActualizarAdministrador(0, txtUsuario.Text, txtContraseña.Text); 
                }            
                Response.Redirect("administradores.aspx");
            }
        }

        private bool validad()
        {
            if (txtUsuario.Text == "")
            { lblUsuarioRequerido.Visible = true; lblContraseñaRequerida.Visible = false; return false; }
            else if (txtContraseña.Text == "")
            { lblContraseñaRequerida.Visible = true; lblUsuarioRequerido.Visible = false; return false; }
            else if (Session["codigoOperacion"] == null)
                return true;
            else if (!validoUsuarioUnico())
            { lblUsuarioRequerido.Visible = true; lblContraseñaRequerida.Visible = false; lblUsuarioRequerido.InnerText = " el usuario no se encuentra disponible para utilizar, ingreso otro nombre de usuario"; return false; }
            else return true;
        }

        private bool validoUsuarioUnico()
        {
            //busco si el usuario que se quiere crear no exista en la Base de Datos.            
            DataTable dtAdministradores = ControladorGeneral.RecuperarTodosAdministradores();
            int count = 0;
            for (int i = 0; i < dtAdministradores.Rows.Count; i++)
            {
                if (Convert.ToString(dtAdministradores.Rows[i]["usuario"]) == txtUsuario.Text)
                    count = count + 1;
            }
            if (count == 1)
                return false;
            else
                return true;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("administradores.aspx");
        }
    }
}