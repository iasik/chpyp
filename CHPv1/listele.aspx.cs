using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Drawing;
namespace CHPv1
{
    public partial class listele : System.Web.UI.Page
    {

        int personID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["kadi"] == null)
            {
                Response.Redirect("login.aspx");
            }
            if (!IsPostBack)
            {
                ddl_mah_doldur();
                pnlGridView.Visible = false;


            }
            if (Request.QueryString["sandikNo"] != null)
            {
                grd_doldur(Convert.ToDouble(Request.QueryString["sandikNo"]));
                
            }
            pnl_update.Visible = false;
            


        }

        public void ddl_mah_doldur()
        {
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
        public void ddl_sandik_doldur()
        {
            DataSet ds_sandik = new DataSet();
            SqlConnection con = new SqlConnection("Data Source=.\\chp;Initial Catalog=chpyp;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select DISTINCT [Sandik No] From people where Mahalle='" + ddlMah.SelectedValue + "' ORDER BY [Sandik No] ASC", con);
            SqlDataAdapter da_sandik = new SqlDataAdapter(cmd);
            da_sandik.Fill(ds_sandik);
            con.Close();
            ddlSandikNo.DataTextField = "Sandik No";
            ddlSandikNo.DataValueField = "Sandik No";
            ddlSandikNo.DataSource = ds_sandik;
            ddlSandikNo.DataBind();
            ddlSandikNo.Items.Insert(0, new ListItem("Seçiniz", "0"));
        }

        public void partiDoldur()
        {
            DataSet ds_parti = new DataSet();
            SqlConnection con = new SqlConnection("Data Source=.\\chp;Initial Catalog=chpyp;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select PartiIsmi, PartiID from parti", con);
            SqlDataAdapter da_parti = new SqlDataAdapter(cmd);
            da_parti.Fill(ds_parti);
            con.Close();
            ddl_parti.DataTextField = "PartiIsmi";
            ddl_parti.DataValueField = "PartiID";
            ddl_parti.DataSource = ds_parti;
            ddl_parti.DataBind();

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
            SqlCommand cmd = new SqlCommand("select id, Adı, Soyadı, [Doğum Tarihi], [Cadde-Sokak], [Kapı No], [Daire No], Aciklama, PartiIsmi,ceptel From people, parti where people.PartiID = parti.PartiID AND [Sandik No]='" + sandikno + "' ", con);
            SqlDataAdapter da_grid = new SqlDataAdapter(cmd);
            da_grid.Fill(dt_grid);

            grdPeople.DataSource = dt_grid;
            grdPeople.DataBind();
            con.Close();
            pnlGridView.Visible = true;
        }



        protected void grdPeople_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdPeople.PageIndex = e.NewPageIndex;
            grdPeople.DataBind();
        }

        protected void grdPeople_SelectedIndexChanged(object sender, EventArgs e)
        {
            personID = Convert.ToInt32(grdPeople.SelectedValue);
            if (personID != null)
            {
                pnl_update.Visible = true;
            }
            fillperson(personID);
            partiDoldur();

        }

        public void fillperson(int selected_id)
        {

            SqlConnection con = new SqlConnection("Data Source=.\\chp;Initial Catalog=chpyp;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select Adı,Soyadı,Aciklama,CepTel from people where id=" + selected_id + "", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lbl_lname.Text = dr["Soyadı"].ToString();
                lbl_name.Text = dr["Adı"].ToString();
                txt_info.Text = dr["Aciklama"].ToString();
                txtCep.Text = dr["CepTel"].ToString();
            }
            con.Close();

        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            personID = Convert.ToInt32(grdPeople.SelectedValue);
            if (updatePerson(personID))
            {
                grd_doldur(Convert.ToDouble(Request.QueryString["sandikNo"]));
            }
            txt_info.Text = "";
            txtCep.Text = "";

        }

        public bool updatePerson(int id)
        {
            SqlConnection con = new SqlConnection("Data Source=.\\chp;Initial Catalog=chpyp;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("update people set PartiID = @PartiID,Aciklama=@Aciklama,ceptel=@ceptel where id=" + id + "", con);
            cmd.CommandType = CommandType.Text;
            {
                cmd.Parameters.AddWithValue("@PartiID", ddl_parti.SelectedValue);
                cmd.Parameters.AddWithValue("@Aciklama", txt_info.Text);
                cmd.Parameters.AddWithValue("@ceptel", txtCep.Text);
            }
            cmd.ExecuteNonQuery();
            con.Close();
            return true;


        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=SandikNo "+Convert.ToDouble(Request.QueryString["sandikNo"])+".xls");
            Response.Charset = "utf-8";
            Response.ContentType = "application/ms-excel";


            
            Response.ContentEncoding = System.Text.Encoding.Unicode;
            Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());

            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                grdPeople.AllowPaging = false;
                grd_doldur(Convert.ToDouble(Request.QueryString["sandikNo"]));

                grdPeople.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in grdPeople.HeaderRow.Cells)
                {
                    cell.BackColor = grdPeople.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in grdPeople.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = grdPeople.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = grdPeople.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                grdPeople.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }


        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }

    }
}