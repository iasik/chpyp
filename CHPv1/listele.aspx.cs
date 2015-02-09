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
    public partial class listele : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["kadi"] == null)
            //{
            //    Response.Redirect("login.aspx");
            //}

            ddl_mah_doldur();
            ddl_sandik_doldur();
            

        }

        public void ddl_mah_doldur() {
            SqlConnection conn = new SqlConnection("Data Source=.\\chp;Initial Catalog=chpyp;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select distinct Mahalle From people", conn);
            DataSet ds_mah = new DataSet();

            SqlDataAdapter da_mah = new SqlDataAdapter(cmd);

            da_mah.Fill(ds_mah);

            ddlMah.Items.Insert(0, new ListItem("seçiniz", "0"));
            cmd.CommandType = CommandType.Text;

            ddlMah.DataTextField = "Mahalle";
            ddlMah.DataValueField = "Mahalle";
            ddlMah.DataSource = ds_mah;
            ddlMah.DataBind();
        }
        public void ddl_sandik_doldur() {
            DataSet ds_sandik = new DataSet();
            SqlConnection con = new SqlConnection("Data Source=.\\chp;Initial Catalog=chpyp;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select DISTINCT [Sandik No] From people where Mahalle='" + ddlMah.SelectedValue +"' ORDER BY [Sandik No] ASC", con);
            SqlDataAdapter da_sandik = new SqlDataAdapter(cmd);
            da_sandik.Fill(ds_sandik);
            con.Close();
            ddlSandikNo.DataTextField = "Sandik No";
            ddlSandikNo.DataValueField = "Sandik No";
            ddlSandikNo.DataSource = ds_sandik;
            ddlSandikNo.DataBind();
        }
    }
}