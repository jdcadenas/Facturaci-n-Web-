using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace SistemaFacturacionWeb
{
    public class Email
    {
       

        public bool enviarcorreo(string to, string mensaje){
            try
            {

                MailMessage m = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                string password = "gloger1301";
                string from = "gloria.calo2013@gmail.com";
                string to2 = "gloria.calo2013@gmail.com";
                string mensaje2 = "Bienvenido al Sistema de Facturación Virtual\r\n\r\n\r\n " +
                    "" +
                    " El presente Correo es para notificarle la clave Provicional para ingresar al sistema virtual de Facturacion \r\n\r\n  " +
                    "La contraseña Provicional es:  ProvicionalXLP2018*  \r\n" +
                    "Se recomienda Cambiar en lo mas pronto Posible la Clave \r\n" +
                    "Para Completar el Proceso dar clip en el siguiente enlace \r\n" +
                    "http://localhost:50463/RecuperarContrasena.aspx";

                m.From = new MailAddress(from);
                m.To.Add(new MailAddress(to2));
                m.Body = mensaje2;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential(from, password);
                smtp.EnableSsl = true;
                smtp.Send(m);
                //m.IsBodyHtml = true;
                //     return true;
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
        }





    }
}