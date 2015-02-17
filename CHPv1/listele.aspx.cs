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
            if (Session["kadi"] == null)
           {
              Response.Redirect("login.aspx");
            }
            if (!IsPostBack)
            {
                ddl_mah_doldur();
                 
            }
            if(Request.QueryString["sandikNo"]!=null)
            {
                grd_doldur(Convert.ToDouble(Request.QueryString["sandikNo"]));
            }

        }

        public void ddl_mah_doldur() {
            SqlConnection conn = new SqlConnection("Data Source=.\\chp;Initial Catalog=chpyp;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select distinct Mahalle From people", conn);
            DataSet ds_mah = new DataSet();

            SqlDataAdapter da_mah = new SqlDataAdapter(cmd);

            da_mah.Fill(ds_mah);

            cmd.CommandType = CommandType.Text;

            ddlMah.DataTextField = "Mahalle";
            ddlMah.DataValueField = "Mahalle";
            ddlMah.DataSource = ds_mah;
            ddlMah.DataBind();
            ddlMah.Items.Insert(0, new ListItem("Seçiniz", "0"));
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
            ddlSandikNo.Items.Insert(0,new ListItem("Seçiniz","0"));
        }

        protected void ddlMah_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_sandik_doldur();
        }

        protected void ddlSandikNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("listele.aspx?sandikNo=" + ddlSandikNo.SelectedValue);
        }

        protected void grd_doldur(double sandikno)
        {
            DataTable dt_grid = new DataTable();
            SqlConnection con = new SqlConnection("Data Source=.\\chp;Initial Catalog=chpyp;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select Adı, Soyadı, [Doğum Tarihi], [Cadde-Sokak], [Kapı No], [Daire No], Aciklama, PartiIsmi  From people, parti where people.PartiID = parti.PartiID AND [Sandik No]='" + sandikno + "' ", con);
            SqlDataAdapter da_grid = new SqlDataAdapter(cmd);
            da_grid.Fill(dt_grid);
            con.Close();
            grdPeople.DataSource = dt_grid;
            grdPeople.DataBind();


        }

        protected void RowUpdate(object sender, GridViewEditEventArgs e)
        {
            // Edit click

            grdPeople.EditIndex = e.NewEditIndex;
            grdPeople.DataBind();
            grd_doldur(Convert.ToDouble(Request.QueryString["sandikNo"]));

        }

        protected void RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //// Update click
            ////string cnct = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["grid"].ConnectionString;
            //SqlConnection con = new SqlConnection("Data Source=.\\chp;Initial Catalog=chpyp;Integrated Security=True");
            //if (con.State == ConnectionState.Closed)
            //    con.Open();
            //int id = e.RowIndex;
            ////string tcnogrid = grdPeople.DataKeys[e.RowIndex].Value.ToString();
            ////TextBox gridtcno = (TextBox)grdPeople.Rows[id].FindControl("Textbox1"); ////Güncelleme için Gridview deki EditItemTemplatefield alanında bulunan Textbox a yazılan yeni değeri alıyoruz.
            ////TextBox gridadi = (TextBox)grdPeople.Rows[id].FindControl("Textbox2");
            ////TextBox gridsoyadi = (TextBox)grdPeople.Rows[id].FindControl("Textbox3");
            ////TextBox griddgtarh = (TextBox)grdPeople.Rows[id].FindControl("Textbox5");
            ///////////

            ////SqlCommand comd = new SqlCommand();
            ////comd.Connection = con;
            ////comd.CommandType = CommandType.StoredProcedure;
            ////comd.CommandText = "usr_update";
            ////comd.Parameters.AddWithValue("@tcno", tcnogrid);
            ////comd.Parameters.AddWithValue("@updttcno", gridtcno.Text);
            ////comd.Parameters.AddWithValue("@adi", gridadi.Text);
            ////comd.Parameters.AddWithValue("@soyadi", gridsoyadi.Text);
            ////comd.Parameters.AddWithValue("@dtarih", griddgtarh.Text);
            //comd.ExecuteNonQuery();
            //grd_doldur(Convert.ToDouble(Request.QueryString["sandikNo"]));
            //grdPeople.EditIndex = -1;
            //grdPeople.DataBind();

            //SqlConnection con = new SqlConnection("Data Source=.\\chp;Initial Catalog=chpyp;Integrated Security=True");
            //if (con.State == ConnectionState.Closed)
            //{
            //    con.Open();
            //}
            //int id = e.RowIndex;
            ////int userid = Convert.ToInt32(grdPeople.DataKeys[e.RowIndex].Value.ToString());
            //GridViewRow row = (GridViewRow)grdPeople.Rows[e.RowIndex];
            ////row.Cells[0].Controls[0];
            //TextBox gridAdi = (TextBox)row.Cells[0].Controls[0];
            //TextBox gridSoyadi = (TextBox)grdPeople.Rows[id].FindControl("Textbox2");
            //TextBox gridDogTar = (TextBox)row.Cells[0].Controls[0];
            //TextBox gridCaddeSokak = (TextBox)row.Cells[0].Controls[0];
            //TextBox gridKapiNo = (TextBox)row.Cells[0].Controls[0];
            //TextBox gridDaireNo = (TextBox)row.Cells[0].Controls[0];
            //TextBox gridAciklama = (TextBox)row.Cells[0].Controls[0];
            //// DropDownList gridParti = (DropDownList)grdPeople.Rows[id].FindControl("DropDownList1");


            //SqlCommand comd = new SqlCommand();
            //comd.Connection = con;
            ////comd.CommandType = CommandType.StoredProcedure;
            ////comd.CommandText = "usr_update";
            //comd.Parameters.AddWithValue("@Adı", gridAdi);
            //comd.Parameters.AddWithValue("@Soyadı", gridSoyadi);
            //comd.Parameters.AddWithValue("@[Doğum Tarihi]", gridDogTar);
            //comd.Parameters.AddWithValue("@[Cadde-Sokak]", gridCaddeSokak);
            //comd.Parameters.AddWithValue("@[Kapı No]", gridKapiNo);
            //comd.Parameters.AddWithValue("@[Daire No]", gridDaireNo);
            //comd.Parameters.AddWithValue("@Aciklama", gridAciklama);

            //comd.ExecuteNonQuery();
            //grd_doldur(Convert.ToDouble(Request.QueryString["sandikNo"]));
            //grdPeople.EditIndex = -1;
            //grdPeople.DataBind();
        }

        protected void RowCancelling(object sender, GridViewCancelEditEventArgs e)
        {
            // Cancel click
            grdPeople.EditIndex = -1;
            grdPeople.DataBind();
            grd_doldur(Convert.ToDouble(Request.QueryString["sandikNo"]));

        }

        protected void RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Delete click
        }

       

       

        
    }
}