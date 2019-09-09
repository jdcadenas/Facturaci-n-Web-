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

namespace SistemaFacturacionWeb
{
    public partial class BusquedaDetallesFactura : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        
        protected void Button1_Click(object sender, EventArgs e)
        {

            //Ini FacN
            string codigo = "";
            string s = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection conexion = new SqlConnection(s);
            conexion.Open();
            SqlCommand comando = new SqlCommand("select * FROM Ventas where Id = '" + this.TextBox1.Text + "'", conexion);
            SqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                codigo = registro["CustomerId"].ToString();
                SqlConnection cn = new SqlConnection("Data Source=DESKTOP-KH2KFO1;initial catalog=facturacion;integrated security=True");
                SqlCommand cmd = new SqlCommand("select OrderId,Articulo,ArticuloCodigo,Cantidad,Precio,Total,CustomerId from VentasDetalles WHERE CustomerId = '" + codigo +"'", cn);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataSourceID = null;
                GridView1.DataBind();
                cn.Close();

            }

            else
            {
                this.Label1.Text = "No existe Factura";

            }
            conexion.Close();

            //Fin Nfac





           
            
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}