using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Data;
using System.Data.Entity;
using System.Web.Mvc;
using SistemaFacturacionWeb.Models;
using System.Configuration;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace SistemaFacturacionWeb
{
    public partial class RecuperarContrasena : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //rescata correo del cliente
            string s = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection conexion = new SqlConnection(s);
            conexion.Open();
            SqlCommand comando = new SqlCommand("select * from AspNetUsers  where Email ='" + this.TextBox1.Text + "'", conexion);
            SqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                string SecurityStamp = registro["SecurityStamp"].ToString();

                //inicia envio mail factura
                MailMessage m = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                string password = "gloger1301";
                string from = "gloria.calo2013@gmail.com";
                string to = TextBox1.Text;
                string mensaje = "Bienvenido al Sistema de Facturación Virtual\r\n\r\n\r\n " +
                    "" +
                    " El presente Correo es para ayudarle con su solicitud de Cambio de Contraseña \r\n  " +
                    "La cual Puede acceder a travez del siguiente enlace  \r\n" +
                    "http://localhost:50463/CambioClave.aspx?email="+ TextBox1.Text + "&code="+ SecurityStamp +"";
                m.From = new MailAddress(from);
                m.To.Add(new MailAddress(to));
                m.Body = mensaje;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential(from, password);
                smtp.EnableSsl = true;
                smtp.Send(m);
                Label2.Text = "Confirmacion de Cambio de Contraseña Enviada Satisfactoriamente.";
                //termina envio de mail
            }
            else
            {
                Label2.Text = "Confirmacion de Cambio de Contraseña Enviada Satisfactoriamente";
            }
            conexion.Close();





            //cierra consulta



        }

        public void enviarcorreo() {
            string to = TextBox1.Text;
            string msn = "Recuperacion de Correo";
            new Email().enviarcorreo(to, msn);


        }
    }
}