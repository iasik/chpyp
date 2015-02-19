using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Data.SqlClient;
using System.Data;


namespace CHPv1
{
    public partial class main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            /*if (Session["kadi"] == null)
            {
                Response.Redirect("login.aspx");
            }*/
            grafik();

        }

        protected void grafik()
        {
            // Bölüm adlarını ve kontenjan bilgilerini diziye yazdık.
            string[] seriesBolumler = { "Bilgisayar Müh", "Elektronik Müh", "Makine Müh", "Endüstri Müh" };
            int[] seriesKontenjan = { 77, 66, 500, 80 };

            // Chart1 kontrolüne başlık atadık.
            this.Chart1.Titles.Add("Kontenjanikleri");

            //Series nesnesi oluşturarak bölüm adlarını ve kontenjan bilgilerini ekledik.
            for (int i = 0; i < seriesBolumler.Length; i++)
            {
                Series series = this.Chart1.Series.Add(seriesBolumler[i]);

                series.Points.Add(seriesKontenjan[i]);
            }
        }
    }
}