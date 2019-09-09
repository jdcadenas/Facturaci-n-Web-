using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaFacturacionWeb
{
    public partial class CambioClave : System.Web.UI.Page
    {
       

        protected void Page_Load(object sender, EventArgs e,string email)
        {
            
            string Label = email;
            if (email==null)
            {
                Label1.Text = "nulo";
                Console.WriteLine("1");
            }
            else
            {
                Label1.Text = "no null";

            }
        }
        public string Email(string email)
        {
            Label1.Text = "X";
            Console.WriteLine("2");
            return ("Y");
        }
    }
}