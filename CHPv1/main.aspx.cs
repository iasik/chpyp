using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;


namespace CHPv1
{
    public partial class main : System.Web.UI.Page
    {
        int chp, mhp, akp, diger;
        protected void Page_Load(object sender, EventArgs e)
        {
            

            /*if (Session["kadi"] == null)
            {
                Response.Redirect("login.aspx");
            }*/
            grafik();
            if (!IsPostBack)
            {
                ddl_ilce_doldur();
                pnlGrafik.Visible = false;
            }
            
        }

        public void ddl_ilce_doldur()
        {
            DataSet ds_ilce = new DataSet();
            SqlConnection con = new SqlConnection("Data Source=.\\chp;Initial Catalog=chpyp;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from ilce",con);
            SqlDataAdapter da_ilce = new SqlDataAdapter(cmd);
            da_ilce.Fill(ds_ilce);
            cmd.CommandType = CommandType.Text;
            ddlIlce.DataTextField = "ilceAd";
            ddlIlce.DataValueField = "id";
            ddlIlce.DataSource = ds_ilce;
            ddlIlce.DataBind();
            ddlIlce.Items.Insert(0, new ListItem("Seçiniz", "0"));
                       
            }
                       
        
        
        
        public void ddl_mah_doldur()
        {
            DataSet ds_mah = new DataSet();
            SqlConnection con = new SqlConnection("Data Source=.\\chp;Initial Catalog=chpyp;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * From mahalle where ilceID="+ddlIlce.SelectedValue+"", con);
            SqlDataAdapter da_mah = new SqlDataAdapter(cmd);
            da_mah.Fill(ds_mah);
            cmd.CommandType = CommandType.Text;

            ddlMah.DataTextField = "mahalleAd";
            ddlMah.DataValueField = "id";
            ddlMah.DataSource = ds_mah;
            ddlMah.DataBind();
            ddlMah.Items.Insert(0, new ListItem("Seçiniz", "0"));
        }

        public void ddl_sandik_doldur()
        {
            DataSet ds_sandik = new DataSet();
            SqlConnection con = new SqlConnection("Data Source=.\\chp;Initial Catalog=chpyp;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select DISTINCT [Sandik No] From people where mahalleID='" + ddlMah.SelectedValue + "' ORDER BY [Sandik No] ASC", con);
            SqlDataAdapter da_sandik = new SqlDataAdapter(cmd);
            da_sandik.Fill(ds_sandik);
            cmd.CommandType = CommandType.Text;

            ddlSandikNo.DataTextField = "Sandik No";
            ddlSandikNo.DataValueField = "Sandik No";
            ddlSandikNo.DataSource = ds_sandik;
            ddlSandikNo.DataBind();
            ddlSandikNo.Items.Insert(0, new ListItem("Seçiniz", "0"));

        }



        protected void grafik()
        {
            SqlConnection con = new SqlConnection("Data Source=.\\chp;Initial Catalog=chpyp;Integrated Security=True");
            con.Open();

            
            if (ddlIlce.SelectedValue!="0")
            {
                pnlGrafik.Visible = true;
                if (ddlMah.SelectedValue != "0")
                {
                    if (ddlSandikNo.SelectedValue != "0")
                    {
                        SqlCommand cmd = new SqlCommand("select count(*) from people where partiID=2 and [Sandik No]=" + ddlSandikNo.SelectedValue + "", con);
                        chp = Convert.ToInt32(cmd.ExecuteScalar());
                        SqlCommand cmd2 = new SqlCommand("select count(*) from people where partiID=3 and [Sandik No]=" + ddlSandikNo.SelectedValue + "", con);
                        mhp = Convert.ToInt32(cmd2.ExecuteScalar());
                        SqlCommand cmd3 = new SqlCommand("select count(*) from people where partiID=4 and [Sandik No]=" + ddlSandikNo.SelectedValue + "", con);
                        akp = Convert.ToInt32(cmd3.ExecuteScalar());
                        SqlCommand cmd4 = new SqlCommand("select count(*) from people where partiID=5 and [Sandik No]=" + ddlSandikNo.SelectedValue + "", con);
                        diger = Convert.ToInt32(cmd4.ExecuteScalar());
        }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("select count(*) from people where partiID=2 and mahalleID=" + ddlMah.SelectedValue + "", con);
                        chp = Convert.ToInt32(cmd.ExecuteScalar());
                        SqlCommand cmd2 = new SqlCommand("select count(*) from people where partiID=3 and mahalleID=" + ddlMah.SelectedValue + "", con);
                        mhp = Convert.ToInt32(cmd2.ExecuteScalar());
                        SqlCommand cmd3 = new SqlCommand("select count(*) from people where partiID=4 and mahalleID=" + ddlMah.SelectedValue + "", con);
                        akp = Convert.ToInt32(cmd3.ExecuteScalar());
                        SqlCommand cmd4 = new SqlCommand("select count(*) from people where partiID=5 and mahalleID=" + ddlMah.SelectedValue + "", con);
                        diger = Convert.ToInt32(cmd4.ExecuteScalar());
                    }
                }
                else
                {

                    SqlCommand cmd = new SqlCommand("select count(*) from people where partiID=2 and ilceID=" + ddlIlce.SelectedValue + "", con);
                    chp = Convert.ToInt32(cmd.ExecuteScalar());
                    SqlCommand cmd2 = new SqlCommand("select count(*) from people where partiID=3 and ilceID=" + ddlIlce.SelectedValue + "", con);
                    mhp = Convert.ToInt32(cmd2.ExecuteScalar());
                    SqlCommand cmd3 = new SqlCommand("select count(*) from people where partiID=4 and ilceID=" + ddlIlce.SelectedValue + "", con);
                    akp = Convert.ToInt32(cmd3.ExecuteScalar());
                    SqlCommand cmd4 = new SqlCommand("select count(*) from people where partiID=5 and ilceID=" + ddlIlce.SelectedValue + "", con);
                    diger = Convert.ToInt32(cmd4.ExecuteScalar());
                }
            }
            


            // Bölüm adlarını ve kontenjan bilgilerini diziye yazdık.
            string[] seriesBolumler = { "Chp", "Mhp", "Akp", "Diğer" };
            int[] seriesKontenjan = { chp, mhp, akp, diger };

            // Chart1 kontrolüne başlık atadık.
            this.Chart1.Titles.Add("Kontenjanikleri");
           
            //Series nesnesi oluşturarak bölüm adlarını ve kontenjan bilgilerini ekledik.
            for (int i = 0; i < seriesBolumler.Length; i++)
            {
                Series series = this.Chart1.Series.Add(seriesBolumler[i]);
           
                series.Points.Add(seriesKontenjan[i]);
            }
        }
            
        protected void ddlIlce_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_mah_doldur();
        }
           
        protected void ddlMah_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_sandik_doldur();
        }
    }
}