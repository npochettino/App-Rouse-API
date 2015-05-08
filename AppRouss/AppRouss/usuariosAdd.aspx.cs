using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaAppRouss.Clases;
using BibliotecaAppRouss.Controladores;

namespace AppRouss
{
    public partial class usuariosAdd : System.Web.UI.Page
    {
        private int codigoOperacion;
        Usuario oUsuarioActual;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Cargo el form para editar
                if ((Usuario)Session["usuarioActual"] != null)
                {
                    //txtUsuario.ReadOnly = true;
                    CargarDatosParaEditar((Usuario)Session["usuarioActual"]);
                }
                else
                {
                    Session.Add("codigoOperacion", 0);
                    //txtUsuario.ReadOnly = false;
                }
            }
        }

        private void CargarDatosParaEditar(Usuario oUsuarioActual)
        {
            codigoOperacion = oUsuarioActual.Codigo;
            txtNombre.Text = oUsuarioActual.Nombre;
            txtApellido.Text = oUsuarioActual.Apellido;
            txtMail.Text = oUsuarioActual.Mail;
            txtTelefono.Text = oUsuarioActual.Telefono;
            txtDNI.Text = oUsuarioActual.Dni;
            txtContraseña.Text = oUsuarioActual.Contraseña;
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (validad())
            {
                //si el codigoOperacion es Null es una edicion.
                if (Session["codigoOperacion"] == null)
                {
                    oUsuarioActual = (Usuario)Session["usuarioActual"];
                    ControladorGeneral.InsertarActualizarUsuario(oUsuarioActual.Codigo, txtNombre.Text, txtApellido.Text,txtDNI.Text, txtMail.Text, txtContraseña.Text, txtTelefono.Text);
                    lblMensajeUsuario.Text = "El usuario se ha modificado correctamente.";
                    pcUsuario.ShowOnPageLoad = true;
                }
                //si el codigoOperacion es != null hago un insert.
                else
                {
                    //ControladorGeneral.InsertarActualizarAdministrador(0, txtUsuario.Text, txtContraseña.Text);
                }
                //Response.Redirect("usuarios.aspx");
            }
        }

        private bool validad()
        {
            if (txtNombre.Text == "")
            { lblNombreRequerido.Visible = true; return false; }
            else if (txtApellido.Text == "")
            { lblApellidoRequerido.Visible = true; lblNombreRequerido.Visible = false; return false; }
            if (txtDNI.Text == "")
            { lblDniRequerido.Visible = true; lblNombreRequerido.Visible = false; lblApellidoRequerido.Visible = false; return false; }
            else if (txtMail.Text == "")
            { lblMailRequerido.Visible = true; lblDniRequerido.Visible = false; lblNombreRequerido.Visible = false; lblApellidoRequerido.Visible = false; return false; }
            if (txtTelefono.Text == "")
            { lblTelefonoRequerido.Visible = true; lblMailRequerido.Visible = false; lblDniRequerido.Visible = false; lblNombreRequerido.Visible = false; lblApellidoRequerido.Visible = false; return false; }
            if (txtContraseña.Text == "")
            { lblContraseñaRequerida.Visible = true; lblTelefonoRequerido.Visible = false; lblMailRequerido.Visible = false; lblDniRequerido.Visible = false; lblNombreRequerido.Visible = false; lblApellidoRequerido.Visible = false; return false; }
            else if (!IsValidEmail(txtMail.Text))
            { lblMailRequerido.Visible = true; lblMailRequerido.InnerText = "El mail no posee el formato correcto"; lblTelefonoRequerido.Visible = false; lblDniRequerido.Visible = false; lblNombreRequerido.Visible = false; lblApellidoRequerido.Visible = false; return false; }
            if (!validoDNIUnico())
            { lblDniRequerido.Visible = true; lblDniRequerido.InnerText = "El dni ya existe"; lblMailRequerido.Visible = false; lblNombreRequerido.Visible = false; lblApellidoRequerido.Visible = false; lblTelefonoRequerido.Visible = false; return false; }
            else if (!validoMailUnico())
            { lblMailRequerido.Visible = true; lblMailRequerido.InnerText = "El mail ya existe"; lblDniRequerido.Visible = false; lblNombreRequerido.Visible = false; lblApellidoRequerido.Visible = false; lblTelefonoRequerido.Visible = false; return false; }
            else return true;
        }

        private bool IsValidEmail(string strMailAddress)
        {
            // Return true if strIn is in valid e-mail format.
            return Regex.IsMatch(strMailAddress, @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
        }

        private bool validoDNIUnico()
        {
            //busco si el usuario que se quiere crear no exista en la Base de Datos.            
            DataTable dtUsuarios = ControladorGeneral.RecuperarTodosUsuarios();
            int count = 0;
            for (int i = 0; i < dtUsuarios.Rows.Count; i++)
            {
                if (Convert.ToString(dtUsuarios.Rows[i]["dni"]) == txtDNI.Text)
                    count = count + 1;
            }
            if (count > 1)
                return false;
            else
                return true;
        }

        private bool validoMailUnico()
        {
            //busco si el usuario que se quiere crear no exista en la Base de Datos.            
            DataTable dtUsuarios = ControladorGeneral.RecuperarTodosUsuarios();
            int count = 0;
            for (int i = 0; i < dtUsuarios.Rows.Count; i++)
            {
                if (Convert.ToString(dtUsuarios.Rows[i]["mail"]) == txtMail.Text)
                    count = count + 1;
            }
            if (count > 1)
                return false;
            else
                return true;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("usuarios.aspx");
        }

        protected void btnAceptarMensaje_Click(object sender, EventArgs e)
        {
            pcUsuario.ShowOnPageLoad = false;
            Response.Redirect("usuarios.aspx");
        }
    }
}