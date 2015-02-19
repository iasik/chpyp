using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
namespace CHPv1
{
    public partial class main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            grafik();
            /*if (Session["kadi"] == null)
            {
                Response.Redirect("login.aspx");
            }*/
                       
        }

        protected void grafik()
        {
            SqlConnection con = new SqlConnection("Data Source=.\\chp;Initial Catalog=chpyp;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(PartiID) from people where PartiID = 1",con);
            con.Close();

        }
    }
}