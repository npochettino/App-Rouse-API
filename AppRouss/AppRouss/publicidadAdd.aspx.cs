using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaAppRouss.Clases;
using BibliotecaAppRouss.Controladores;

namespace AppRouss
{
    public partial class publicidadAdd : System.Web.UI.Page
    {
        private int codigoOperacion;
        Publicidad oPublicidadActual;
        string sImagen = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Cargo el form para editar
                if ((Publicidad)Session["publicidadActual"] != null)
                {
                    CargarDatosParaEditar((Publicidad)Session["publicidadActual"]);
                }
                else
                {
                    Session.Add("codigoOperacion", 0);
                    deFechaDesde.Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, int.Parse("00"), int.Parse("00"), int.Parse("00"));
                    deFechaHasta.Date = deFechaDesde.Date.AddDays(1);
                }
            }
        }

        private void CargarDatosParaEditar(Publicidad oPublicidadActual)
        {
            codigoOperacion = oPublicidadActual.Codigo;
            txtDescripcion.Text = oPublicidadActual.Descripcion;

            Session.Add("rutaImagen", oPublicidadActual.RutaImagen);
            //sImagen = Session["rutaImagen"].ToString();
            deFechaDesde.Date = oPublicidadActual.FechaHoraInicio;
            deFechaHasta.Date = oPublicidadActual.FechaHoraFin;
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                //si el codigoOperacion es Null es una edicion.
                if (Session["codigoOperacion"] == null)
                {
                    //sImagen = Session["rutaImagen"].ToString();
                    if (fuImagen.FileName != "")// && Session["rutaImagen"].ToString() != fuImagen.FileName)
                        Session.Add("rutaImagen",fuImagen.FileName);

                    oPublicidadActual = (Publicidad)Session["publicidadActual"];
                    ControladorGeneral.InsertarActualizarPublicidad(oPublicidadActual.Codigo, Session["rutaImagen"].ToString(), txtDescripcion.Text, deFechaDesde.Date, deFechaHasta.Date);
                    lblMensajeSorteo.Text = "La publicidad se modificó correctamente.";
                    pcPublicidad.ShowOnPageLoad = true;
                }
                //si el codigoOperacion es != null hago un insert.
                else
                {
                    ControladorGeneral.InsertarActualizarPublicidad(0, Session["rutaImagen"].ToString(), txtDescripcion.Text, DateTime.Parse(deFechaDesde.Text), DateTime.Parse(deFechaHasta.Text));
                    lblMensajeSorteo.Text = "La publicidad se ha creado correctamente.";
                    pcPublicidad.ShowOnPageLoad = true;
                }
            }
        }

        private bool validar()
        {
            //2048 x 1536
            if (Session["rutaImagen"] == null)
            {
                if (fuImagen.HasFile)
                {
                    if (fuImagen.PostedFile.ContentType == "image/png")
                    {
                        string path = Server.MapPath(".") + "\\assets\\rouss\\publicidad\\" + fuImagen.FileName;
                        fuImagen.PostedFile.SaveAs(path);
                        StreamReader reader = new StreamReader(fuImagen.FileContent);
                        string text = reader.ReadToEnd();
                        //lblImagenCargada.InnerText = fuImagen.FileName;
                        //sImagen = fuImagen.FileName;
                        Session.Add("rutaImagen",fuImagen.FileName);
                        return true;
                    }                    
                }
                else { lblImagen.InnerText = "Debe cargar una imagen valida"; lblImagen.Visible = true; return false; } //Debe cargar una imagen valida
            }
            else {return true;}
            //Valido Fechas
            if (!validarFechas2())
            { lblFechaDesde.InnerText = " El rango de Fecha se corresponde con las fechas de una publicidad existente. Pruebe con otra fecha. "; lblFechaDesde.Visible = true; lblFechaHasta.Visible = false;  return false; }
            else return true;
        }

        private bool validarFechas2()
        {
             DataTable dtPublicidades = ControladorGeneral.RecuperarTodasPublicidades();
             for (int i = 0; i < dtPublicidades.Rows.Count; i++)
             {
                 DateTime iFechaDesde = Convert.ToDateTime(dtPublicidades.Rows[i]["fechaHoraInicio"]);
                 DateTime iFechaHasta = Convert.ToDateTime(dtPublicidades.Rows[i]["fechaHoraFin"]);
                 if (deFechaDesde.Date < iFechaDesde && deFechaHasta.Date > iFechaHasta)
                     return false;
                 if (Session["codigoOperacion"] == null) //es una edicion
                 {
                     if ((iFechaDesde <= deFechaDesde.Date && deFechaDesde.Date <= iFechaHasta) || (iFechaDesde <= deFechaHasta.Date && deFechaHasta.Date <= iFechaHasta))
                     {
                         //return false;
                         if (Session["codigoOperacion"] == null)
                         {
                             oPublicidadActual = (Publicidad)Session["publicidadActual"];
                             if (oPublicidadActual.Codigo == Convert.ToInt32(dtPublicidades.Rows[i]["codigoPublicidad"]))
                                 return true;
                         }
                     }
                 }
                 if ((iFechaDesde <= deFechaDesde.Date && deFechaDesde.Date <= iFechaHasta) || (iFechaDesde <= deFechaHasta.Date && deFechaHasta.Date <= iFechaHasta))
                 {
                     return false;
                 }
             }
             return true;
        }
        
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("publicidad.aspx");
        }

        protected void btnAceptarMensaje_Click(object sender, EventArgs e)
        {
            pcPublicidad.ShowOnPageLoad = false;
            Response.Redirect("publicidad.aspx");
        }
    }
}