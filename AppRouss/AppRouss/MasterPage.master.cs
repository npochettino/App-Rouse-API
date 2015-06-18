using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppRouss
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["logueado"] == null)
            {
                Session.Clear();
                Session.Abandon();
                Response.Redirect("login.aspx");
            }
            lblUsuario.Text = " " + Session["usuarioAdm"].ToString();
            
            if (Session["usuarioAdm"].ToString() != "sempait")
            {
                idPublicidad.Visible = false;
                idPush.Visible = false;
            }
        }
        protected void lnkSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("login.aspx");
        }
    }
}