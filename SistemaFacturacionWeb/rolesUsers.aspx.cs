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
    public partial class rolesUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-KH2KFO1;initial catalog=facturacion;integrated security=True");
            SqlCommand cmd = new SqlCommand("select Email,Id from AspNetUsers where Email  LIKE '%" + TextBox1.Text + "%' or UserName  LIKE '%" + TextBox1.Text + "%'", cn);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            cn.Close();
            Response.Write("Datos Cargados correctamente");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-KH2KFO1;initial catalog=facturacion;integrated security=True");
            cn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO AspNetUserRoles(UserId,RoleId) VALUES('" + TextBox2.Text + "',1)", cn);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            cmd.Parameters.AddWithValue("UserId", TextBox2.Text);
            cmd.Parameters.AddWithValue("RoleId", "1");

            cmd.ExecuteNonQuery();

            cn.Close();
            Response.Write("Rol Cargado con Exito");
        }
        private facturacionEntities db = new facturacionEntities();
        protected void Button3_Click(object sender, EventArgs e)
        {
           

            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-KH2KFO1;initial catalog=facturacion;integrated security=True");
            cn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO AspNetUserRoles(UserId,RoleId) VALUES('" + TextBox2.Text + "',2)", cn);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            cmd.Parameters.AddWithValue("UserId", TextBox2.Text);
            cmd.Parameters.AddWithValue("RoleId", "2");
            
            cmd.ExecuteNonQuery();

            cn.Close();
            Response.Write("Rol Cargado con Exito");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-KH2KFO1;initial catalog=facturacion;integrated security=True");
            SqlCommand cmd = new SqlCommand("SELECT dbo.AspNetUsers.Email, dbo.AspNetUsers.Id, dbo.AspNetUserRoles.RoleId, dbo.AspNetRoles.Name FROM dbo.AspNetRoles INNER JOIN dbo.AspNetUserRoles ON dbo.AspNetRoles.Id = dbo.AspNetUserRoles.RoleId INNER JOIN dbo.AspNetUsers ON dbo.AspNetUserRoles.UserId = dbo.AspNetUsers.Id WHERE dbo.AspNetUsers.Email LIKE '%" + TextBox1.Text + "%' or dbo.AspNetUsers.UserName  LIKE '%" + TextBox1.Text + "%'", cn);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            cn.Close();
            Response.Write("Datos Cargados correctamente");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {

            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-KH2KFO1;initial catalog=facturacion;integrated security=True");
            cn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM AspNetUserRoles WHERE UserId='"+ TextBox2.Text + "'", cn);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            cmd.Parameters.AddWithValue("UserId", TextBox2.Text);
            cmd.ExecuteNonQuery();

            cn.Close();
            Response.Write("Rol Cargado con Exito");

        }
    }
}