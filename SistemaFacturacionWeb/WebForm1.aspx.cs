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


namespace SistemaFacturacionWeb.Views.Presupuesto
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-27BQ3TN;initial catalog=facturacion;integrated security=True");
            SqlCommand cmd = new SqlCommand("select codigo,DescripcionArticulo,CantidadArticulo,FechaVencimiento from Articulo where codigo  LIKE '%" + TextBox1.Text + "%' or DescripcionArticulo  LIKE '%" + TextBox1.Text + "%'", cn);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            grilla.DataSource = dt;
            grilla.DataBind();
            cn.Close();
            Response.Write("Datos Cargados correctamente");

        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }


        public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grilla_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}