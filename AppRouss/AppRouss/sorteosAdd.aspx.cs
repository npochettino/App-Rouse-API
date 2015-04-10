﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaAppRouss.Clases;
using BibliotecaAppRouss.Controladores;
using DevExpress.Utils;

namespace AppRouss
{
    public partial class sorteosAdd : System.Web.UI.Page
    {
        private int codigoOperacion;
        Sorteo oSorteoActual;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Cargo el form para editar
                if ((Sorteo)Session["sorteoActual"] != null)
                {
                    CargarDatosParaEditar((Sorteo)Session["sorteoActual"]);
                }
                else
                {
                    Session.Add("codigoOperacion", 0);
                    deFechaDesde.Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, int.Parse("00"), int.Parse("00"), int.Parse("00"));
                    deFechaHasta.Date = deFechaDesde.Date.AddDays(1);
                }
            }
        }

        private void CargarDatosParaEditar(Sorteo oSorteoActual)
        {
            codigoOperacion = oSorteoActual.Codigo;
            txtDescripcionSorteo.Text = oSorteoActual.Descripcion;
            txtCantidadOportunidades.Text = oSorteoActual.CantidadTirosPorUsuario.ToString();
            txtCantidadVictorias.Text = oSorteoActual.CantidadPremiosPorUsuario.ToString();
            txtCantidadTotalPremios.Text = oSorteoActual.CantidadPremiosTotales.ToString();
            deFechaDesde.Date = oSorteoActual.FechaDesde;
            deFechaHasta.Date = oSorteoActual.FechaHasta;
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                //si el codigoOperacion es Null es una edicion.
                if (Session["codigoOperacion"] == null)
                {
                    oSorteoActual = (Sorteo)Session["sorteoActual"];
                    ControladorGeneral.InsertarActualizarSorteo(oSorteoActual.Codigo,deFechaDesde.Date,deFechaHasta.Date,txtDescripcionSorteo.Text,int.Parse(txtCantidadOportunidades.Text),int.Parse(txtCantidadVictorias.Text), int.Parse(txtCantidadTotalPremios.Text));
                }
                //si el codigoOperacion es != null hago un insert.
                else
                {
                    ControladorGeneral.InsertarActualizarSorteo(0, DateTime.Parse(deFechaDesde.Text), DateTime.Parse(deFechaHasta.Text), txtDescripcionSorteo.Text, int.Parse(txtCantidadOportunidades.Text), int.Parse(txtCantidadVictorias.Text), int.Parse(txtCantidadTotalPremios.Text));
                }
                Response.Redirect("sorteos.aspx");
            }
        }

        private bool validar()
        {
            Int32 CantidadTotalPremios = 0;
                 
            if (Convert.ToString(deFechaDesde.Date) == "01/01/0001 0:00:00" || deFechaDesde.Date == null)
            { lblFechaDesde.InnerText = " El campo es requerido"; lblFechaDesde.Visible = true; lblFechaHasta.Visible = false; return false; }
            if (Convert.ToString(deFechaHasta.Date) == "01/01/0001 0:00:00" || deFechaHasta.Date == null)
            { lblFechaHasta.InnerText = " El campo es requerido"; lblFechaHasta.Visible = true; lblFechaDesde.Visible = false; return false; }            
            if ( DateTime.Compare(deFechaDesde.Date, deFechaHasta.Date) >= 0)
            { lblFechaDesde.InnerText = " La Fecha Desde debe ser menor que la Fecha Fin del sorteo."; lblFechaDesde.Visible = true; lblFechaHasta.Visible = false; return false; }
            if (txtCantidadOportunidades.Text == "")
            { lblCantidadOportunidades.InnerText = " El campo es requerido"; lblCantidadOportunidades.Visible = true; lblFechaDesde.Visible = false; lblFechaHasta.Visible = false; lblCantidadVictorias.Visible = false; return false; }
            if (txtCantidadVictorias.Text == "")
            { lblCantidadVictorias.InnerText = " El campo es requerido"; lblCantidadVictorias.Visible = true; lblFechaDesde.Visible = false; lblFechaHasta.Visible = false; lblCantidadOportunidades.Visible = false; return false; }
            if (txtCantidadTotalPremios.Text == "")
            { lblCantidadTotalPremios.InnerText = " El campo es requerido"; lblCantidadTotalPremios.Visible = true; lblFechaDesde.Visible = false; lblFechaHasta.Visible = false; lblCantidadOportunidades.Visible = false; return false; }
            if ((Int32.TryParse(txtCantidadTotalPremios.Text.Trim(), out CantidadTotalPremios)) == false)
            { lblCantidadTotalPremios.InnerText = " El campo debe ser un numero."; lblCantidadTotalPremios.Visible = true; lblFechaDesde.Visible = false; lblFechaHasta.Visible = false; lblCantidadOportunidades.Visible = false; return false; }
            if (!char.IsNumber(char.Parse(txtCantidadVictorias.Text)))
            { lblCantidadVictorias.InnerText = " El campo debe ser un numero."; lblCantidadVictorias.Visible = true; lblFechaDesde.Visible = false; lblFechaHasta.Visible = false; lblCantidadOportunidades.Visible = false; return false; }
            else if (!char.IsNumber(char.Parse(txtCantidadOportunidades.Text)))
            { lblCantidadOportunidades.InnerText = " El campo debe ser un numero"; lblCantidadOportunidades.Visible = true; lblFechaDesde.Visible = false; lblFechaHasta.Visible = false; lblCantidadVictorias.Visible = false; return false; }                
            else return true;
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("sorteos.aspx");
        }
    }
}