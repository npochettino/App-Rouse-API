﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaAppRouss.Controladores;

namespace AppRouss
{
    public partial class premios : System.Web.UI.Page
    {
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

    }
}