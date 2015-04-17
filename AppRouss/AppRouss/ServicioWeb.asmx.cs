using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using BibliotecaAppRouss.Controladores;
using Newtonsoft.Json;
using System.Net.Mail;
using System.Web;
using System.Web.UI;

namespace AppRouss
{
    /// <summary>
    /// Descripción breve de ServicioWeb
    /// </summary>
    [WebService(Namespace = "http://sempait.com.ar/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class ServicioWeb : System.Web.Services.WebService
    {
        [WebMethod]
        public string LoginUsuario(string mail, string contraseña)
        {
            try
            {
                DataTable tablaUsuario = new DataTable();
                tablaUsuario = ControladorGeneral.RecuperarLogueoUsuario(mail, contraseña);
                return JsonConvert.SerializeObject(tablaUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public string RecuperarSorteoYPremio(int codigoUsuario)
        {
            try
            {
                DataTable tablaSorteoYPremio = ControladorGeneral.RecuperarSorteoActual();
                tablaSorteoYPremio.Columns.Add("codigoPremio");
                int codigoSorteo = Convert.ToInt32(tablaSorteoYPremio.Rows[0]["codigoSorteo"]);

                if (codigoSorteo != 0)
                {
                    int cantidadPremiosTotales = Convert.ToInt32(tablaSorteoYPremio.Rows[0]["cantidadPremiosTotales"]);
                    int cantidadTirosPorUsuario = Convert.ToInt32(tablaSorteoYPremio.Rows[0]["cantidadTirosPorUsuario"]);
                    int cantidadPremiosPorUsuario = Convert.ToInt32(tablaSorteoYPremio.Rows[0]["cantidadPremiosPorUsuario"]);

                    DataTable tablaParticipantes = ControladorGeneral.RecuperarParticipantesPorSorteo(codigoSorteo);
                    int cantidadDePremiosPorSorteo = (from r in tablaParticipantes.AsEnumerable() where Convert.ToInt32(r["codigoPremio"]) != 4 select r).Count();
                    if (cantidadPremiosTotales > cantidadDePremiosPorSorteo)
                    {
                        int cantidadTirosReales = (from r in tablaParticipantes.AsEnumerable() where Convert.ToInt32(r["codigoUsuario"]) == codigoUsuario select r).Count();
                        int cantidadPremiosReales = (from r in tablaParticipantes.AsEnumerable() where Convert.ToInt32(r["codigoUsuario"]) == codigoUsuario && Convert.ToInt32(r["codigoPremio"]) != 4 select r).Count();


                        if (cantidadTirosPorUsuario > cantidadTirosReales)
                        {
                            if (cantidadPremiosPorUsuario > cantidadPremiosReales)
                            {
                                int codigoPremio = ControladorGeneral.RecuperarCodigoPremio();
                                tablaSorteoYPremio.Rows[0]["codigoPremio"] = codigoPremio;
                            }
                            else
                            {
                                tablaSorteoYPremio.Rows[0]["codigoPremio"] = 7; //ya acumulo mas de los premios permitidos
                            }
                        }
                        else
                        {
                            tablaSorteoYPremio.Rows[0]["codigoPremio"] = 8; //ya realizo mas de los tiros permitidos
                        }
                    }
                    else
                    {
                        tablaSorteoYPremio.Rows[0]["codigoPremio"] = 9; //ya se entregaron todos los premios
                    }
                }
                else
                {
                    tablaSorteoYPremio.Rows[0]["codigoPremio"] = 10; //no existe sorteo
                }

                return JsonConvert.SerializeObject(tablaSorteoYPremio);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public string InsertarParticipante(int codigoUsuario, int codigoSorteo, int codigoPremio)
        {
            try
            {
                ControladorGeneral.InsertarParticipante(codigoUsuario, codigoSorteo, codigoPremio);
                return "ok";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public string InsertarActualizarUsuario(int codigoUsuario, string nombre, string apellido, string dni, string mail, string contraseña, string telefono)
        {
            try
            {
                ControladorGeneral.InsertarActualizarUsuario(codigoUsuario, nombre, apellido, dni, mail, contraseña, telefono);
                if (codigoUsuario == 0)
                    EnviarEmailNewRegistro(nombre,apellido,mail);
                return "ok";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
                
        [WebMethod]
        public string RecuperarPremiosPorUsuario(int codigoUsuario)
        {
            try
            {
                DataTable tablaPremios = ControladorGeneral.RecuperarPremiosPorUsuario(codigoUsuario);
                return JsonConvert.SerializeObject(tablaPremios);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public string RecuperarContraseña(string mail)
        {
            try
            {
                DataTable tablaUsuario = ControladorGeneral.RecuperarContraseña(mail);
                
                if (tablaUsuario.Rows.Count > 0)
                {
                    //ControladorGeneral.EnviarMail();                    
                    EnviarEmailRecuperarContraseña(tablaUsuario.Rows[0]["nombre"].ToString(), tablaUsuario.Rows[0]["apellido"].ToString(), tablaUsuario.Rows[0]["contraseña"].ToString(), tablaUsuario.Rows[0]["mail"].ToString());
                    return "ok";
                }
                else
                {
                    return "UsuarioInexistente";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void EnviarEmailNewRegistro(string nombre, string apellido, string email)
        {
            string HTMLRecuperarContraseña = "";

            HTMLRecuperarContraseña = File.ReadAllText(Server.MapPath("/rouss/emailRegistro/index.html"));
            HTMLRecuperarContraseña = HTMLRecuperarContraseña.Replace("varNombre", nombre);
            HTMLRecuperarContraseña = HTMLRecuperarContraseña.Replace("varApellido", apellido);
            
            //Envio el mail
            MailMessage mail = new MailMessage();

            mail.To.Add(email);

            mail.From = new MailAddress("info@sempait.com.ar", "Bienvenido a AppRous");
            //email's subject
            mail.Subject = "Bienvenido a AppRous";
            //email's body, this is going to be html. note that we attach the image as using cid
            mail.Body = HTMLRecuperarContraseña;
            //set email's body to html
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.Normal;
            //client.EnableSsl = true; 
            SmtpClient smtp = new SmtpClient();
            smtp.Host = System.Configuration.ConfigurationManager.AppSettings["SMTP_SERVER"].ToString();
            try
            {
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void EnviarEmailRecuperarContraseña(string nombre, string apellido, string contraseña, string email)
        {
            string HTMLRecuperarContraseña = "";

            HTMLRecuperarContraseña = File.ReadAllText(Server.MapPath("/rouss/emailPassword/index.html"));
            HTMLRecuperarContraseña = HTMLRecuperarContraseña.Replace("varNombre", nombre);
            HTMLRecuperarContraseña = HTMLRecuperarContraseña.Replace("varApellido", apellido);
            HTMLRecuperarContraseña = HTMLRecuperarContraseña.Replace("varContraseña", contraseña);

            //Envio el mail
            MailMessage mail = new MailMessage();

            mail.To.Add(email);
            
            mail.From = new MailAddress("info@sempait.com.ar", "Cambio de Contraseña");
            //email's subject
            mail.Subject = "Cambio de Contraseña";
            //email's body, this is going to be html. note that we attach the image as using cid
            mail.Body = HTMLRecuperarContraseña;
            //set email's body to html
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.Normal;
            //client.EnableSsl = true; 
            SmtpClient smtp = new SmtpClient();
            smtp.Host = System.Configuration.ConfigurationManager.AppSettings["SMTP_SERVER"].ToString();
            try
            {
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
