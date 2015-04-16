using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;

namespace AppRouss
{
    public partial class test : System.Web.UI.Page
    {
        string Html = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarHTML();
            enviaEmail("info@sempait.com.ar","nico.pochettino@gmail.com","Cambio de Contraseña",Html);
        }
        
        private void enviaEmail(string from, string to, string subject, string mensaje)
        {
            //create the message
            MailMessage mail = new MailMessage();

            mail.To.Add(to);
            //mail.Bcc.Add("" + emailSempait + "," + direccionEmail + "");

            mail.From = new MailAddress(from, "Cambio de Contraseña");
            //email's subject
            mail.Subject = subject;
            //email's body, this is going to be html. note that we attach the image as using cid
            mail.Body = mensaje;
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

        private void cargarHTML()
        {
            //string textHTML = File.ReadAllText(@"C:\Users\Nicolas\SempaIT\approuss\AppRouss\AppRouss\emailPassword\index.html");
            string textHTML = File.ReadAllText(Server.MapPath("/rouss/emailPassword/index.html"));

            textHTML = textHTML.Replace("varNombre", "Nicolas");
            textHTML = textHTML.Replace("varApellido", "Pochettino");
            textHTML = textHTML.Replace("varContraseña", "123asdasd");

            Html = textHTML;
        }
    }
}