﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaAppRouss.Controladores;

namespace AppRouss
{
    public partial class sorteos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGridSorteos();
            }
        }

        private void LoadGridSorteos()
        {
            gvSorteos.DataSource = ControladorGeneral.RecuperarTodosSorteos();
        }

        protected void btnNewSorteo_Click(object sender, EventArgs e)
        {
            Response.Redirect("sorteosAdd.aspx");
        }
    }
}