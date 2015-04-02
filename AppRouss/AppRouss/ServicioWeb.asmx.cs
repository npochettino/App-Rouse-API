using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace AppRouss
{
    /// <summary>
    /// Descripción breve de ServicioWeb
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ServicioWeb : System.Web.Services.WebService
    {
        [WebMethod]
        public string LoginUsuario(string mail, string contraseña)
        {
            return "ok";
            //DataTable tablaUsuario = new DataTable("tablaUsuario");
            //tablaUsuario = ControladorGeneral.RecuperarLogueoUsuario(mail, contraseña);
            //DataSet dsUsuario = new DataSet("dsUsuario");
            //dsUsuario.Tables.Add(tablaUsuario);
            //return dsUsuario.GetXml();
        }
    }
}
