using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppRouss
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            msjErrorLogin.Visible = false;
        }

       
        protected void btnConfirmar_Click(object sender, EventArgs e)
        {

        }

        protected void txtLogin_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Trim() == "admin" && txtContraseña.Text.Trim() == "admin")
            {
                //Session.Add("IDAdministrados", oUsuarioActual.ID);
                Session.Add("logueado", true);
                Response.Redirect("index.aspx");
            }
            else
            {
                msjErrorLogin.Visible = true;
            }
        }


    }
}