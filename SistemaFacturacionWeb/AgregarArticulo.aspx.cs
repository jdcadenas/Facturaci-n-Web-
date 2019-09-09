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
    public partial class AgregarArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            
                //Inicia Validacion Stock

                if (TextBox1.Text == ("") || TextBox2.Text == ("") || TextBox3.Text == ("") || TextBox4.Text == ("") || TextBox6.Text == ("") || TextBox7.Text == (""))
                {
                    Label11.Text = ("No puede haber campos  Vacios");
                }
                else
                {

                int Min = Int32.Parse(TextBox2.Text);
                int Max = Int32.Parse(TextBox3.Text);

                if (Min <= Max)
                {



                    string s = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                    SqlConnection conexion = new SqlConnection(s);
                    conexion.Open();
                    SqlCommand comando = new SqlCommand("select * from articulo  where Codigo ='" + this.TextBox4.Text + "'", conexion);
                    SqlDataReader registro = comando.ExecuteReader();
                    if (registro.Read())
                    {
                        this.Label11.Text = "El codigo del Articulo ya Existe dentro de la Base de Datos ";
                    }

                    else
                    {

                        SqlConnection cn = new SqlConnection("Data Source=DESKTOP-KH2KFO1;initial catalog=facturacion;integrated security=True");
                        cn.Open();
                        SqlCommand cmd = new SqlCommand("INSERT INTO articulo(NombreArticulo,StockMinArticulo,StockMaxArticulo,Codigo,CantidadArticulo,FechaVencimiento,UnidadMedidaArticulo,PrecioPromedioArticulo,DescripcionArticulo) VALUES('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "','" + DropDownList1.Text + "','0','0')", cn);
                        SqlDataAdapter ad = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        cmd.Parameters.AddWithValue("NombreArticulo", TextBox1.Text);
                        cmd.Parameters.AddWithValue("StockMinArticulo", TextBox2.Text);
                        cmd.Parameters.AddWithValue("StockMaxArticulo", TextBox3.Text);
                        cmd.Parameters.AddWithValue("Codigo", TextBox4.Text);
                        cmd.Parameters.AddWithValue("CantidadArticulo", TextBox6.Text);
                        cmd.Parameters.AddWithValue("FechaVencimiento", TextBox7.Text);
                        cmd.Parameters.AddWithValue("UnidadMedidaArticulo", DropDownList1.Text);
                        cmd.ExecuteNonQuery();

                        cn.Close();

                        TextBox1.Text = ("");
                        TextBox2.Text = ("");
                        TextBox3.Text = ("");
                        TextBox4.Text = ("");
                        TextBox6.Text = ("");
                        TextBox7.Text = ("");
                        Label11.Text = ("Información Guardada Con Exito");
                    }

                    conexion.Close();

                }
                else
                {
                    Label11.Text = ("La Cantidad Minima del Stock no puede Sobrepasar al Maximo Corrija");
                }
            }


                //Finaliza Validacion Stock
            






           
                
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
           


        }
    }
}