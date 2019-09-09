using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Net;
using System.Web.Mvc;
using SistemaFacturacionWeb.Models;
using System.Configuration;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;



namespace SistemaFacturacionWeb
{
    public partial class AlertaMinStock : System.Web.UI.Page
    {

        private SqlConnection con;
        private void Conectar()
        {


           // string constr = ConfigurationManager.ConnectionStrings["facturacionConnectionString"].ToString();
           // con = new SqlConnection(constr);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            Conectar();
            //select Codigo from dbo.articulo where Codigo = 'JAR';
            SqlCommand comando = new SqlCommand("SELECT  NombreArticulo,Codigo,StockMinArticulo, CantidadArticulo, FechaVencimiento, DescripcionArticulo, UnidadMedidaArticulo FROM dbo.articulo WHERE(CAST(CantidadArticulo as decimal) <= StockMinArticulo)", con);
            //comando.Parameters.Add("@codigo", SqlDbType.Int);
            //con.Open();
            //SqlDataReader registros = comando.ExecuteReader();

            //if (registros.Read())
            //{
             //   Response.Redirect("ReporteStockMin.aspx");
            //}
            //else

              //  con.Close();




        }
    }
}