using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using BibliotecaAppRouss.Controladores;

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
            try
            {
                DataTable tablaUsuario = new DataTable();
                tablaUsuario = ControladorGeneral.RecuperarLogueoUsuario(mail, contraseña);
                if (tablaUsuario.Rows.Count > 0)
                {
                    DataSet dsUsuario = new DataSet("dsUsuario");
                    dsUsuario.Tables.Add(tablaUsuario);
                    dsUsuario.Tables[0].TableName = "tablaUsuario";
                    return dsUsuario.GetXml();
                }
                else
                {
                    return "LogueoIncorrecto";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public int RecuperarPremio()
        {
            try
            {
                int codigoPremio = ControladorGeneral.RecuperarPremio();
                return codigoPremio;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
