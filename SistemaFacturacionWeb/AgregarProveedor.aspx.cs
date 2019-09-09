using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.IO;
using System.Text;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using SistemaFacturacionWeb.Models;
using CrystalDecisions.CrystalReports.Engine;

namespace SistemaFacturacionWeb
{
    public partial class AgregarProveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == ("") || TextBox2.Text == ("") || TextBox3.Text == ("") || TextBox4.Text == ("") || TextBox5.Text == ("") || TextBox6.Text == (""))
            {
                Label7.Text = ("Debe llenar todos los campos Vacios");
            }
            else
            {
                SqlConnection cn = new SqlConnection("Data Source=DESKTOP-KH2KFO1;initial catalog=facturacion;integrated security=True");
                cn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO proveedor(RazonSocialProveedor,RifProveedor,TelefonoProveedor,DireccionProveedor,DetallesProveedor,NombreContactoProveedor,SitioWebProveedor) VALUES('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "')", cn);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                cmd.Parameters.AddWithValue("RazonSocialProveedor", TextBox1.Text);
                cmd.Parameters.AddWithValue("RifProveedor", TextBox2.Text);
                cmd.Parameters.AddWithValue("TelefonoProveedor", TextBox3.Text);
                cmd.Parameters.AddWithValue("DireccionProveedor", TextBox4.Text);
                cmd.Parameters.AddWithValue("DetallesProveedor", TextBox5.Text);
                cmd.Parameters.AddWithValue("NombreContactoProveedor", TextBox6.Text);
                cmd.Parameters.AddWithValue("SitioWebProveedor", TextBox7.Text);
                cmd.ExecuteNonQuery();

                cn.Close();

                TextBox1.Text = ("");
                TextBox2.Text = ("");
                TextBox3.Text = ("");
                TextBox4.Text = ("");
                TextBox5.Text = ("");
                TextBox6.Text = ("");
                TextBox7.Text = ("");

                Label7.Text = ("Datos Ingresados Correptamente");


            }


        }
    }
}