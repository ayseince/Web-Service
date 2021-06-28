using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading;
using System.Web;
using System.Web.Services;

namespace webServis3
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

   
        [WebMethod]
        public DataTable Bagla(int ekipNum){
            SqlConnection cnn = new SqlConnection("Data Source=DESKTOP-INF3GAV\\AYSEM;Initial Catalog=isg;Integrated Security=True");
            SqlDataAdapter adp = new SqlDataAdapter("select * from ekipler where ekipNo="+ekipNum, cnn);
            DataTable dt = new DataTable("ekipler");
            adp.Fill(dt);
            Thread.Sleep(20000);

            return dt;
       
        }


        [WebMethod]
        public int KisiKaydet(string ad, string soyad, int ekipNo, int bolgeNo, string resim)

        {
            SqlConnection cnn = new SqlConnection("Data Source=DESKTOP-INF3GAV\\AYSEM;Initial Catalog=isg;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("INSERT INTO ekipler(ad,soyad,ekipNo,BolgeNo,resim) VALUES (@adi,@soyadi,@ekipNo,@bolgeNo,@resim)", cnn);
            
            cmd.Parameters.AddWithValue("@adi", ad);
            cmd.Parameters.AddWithValue("@soyadi", soyad);
            cmd.Parameters.AddWithValue("@ekipNo", ekipNo);
            cmd.Parameters.AddWithValue("@bolgeNo", bolgeNo);
            cmd.Parameters.AddWithValue("@resim", resim);
            cnn.Open();
            int etkilenen = cmd.ExecuteNonQuery();
            cnn.Close();
            return etkilenen;

        }


        [WebMethod]
        public int KisiSil(int id)
        {
            var con = new SqlConnection("Data Source=DESKTOP-INF3GAV\\AYSEM;Initial Catalog=isg;Integrated Security=True");
            var cmd = new SqlCommand("delete ekipler where id='" + id + "'", con);
            con.Open();
           int row = cmd.ExecuteNonQuery();
            con.Close();
            return row;

        }


        [WebMethod]
        public int Guncelle(int id, string ad, string soyad, int ekipNo, int bolgeNo, String resim)
        {
        var con = new SqlConnection("Data Source=DESKTOP-INF3GAV\\AYSEM;Initial Catalog=isg;Integrated Security=True");
        var cmd = new SqlCommand("update ekipler set ad='" + ad + "', soyad ='" + soyad + "', ekipNo ='" + ekipNo + "' , bolgeNo='" + bolgeNo + "', resim ='" + resim + "' where id='" + id + "'", con);
        con.Open();
        int row = cmd.ExecuteNonQuery();
        con.Close();
         return row;
        }

        [WebMethod]
        public DataTable Listele()
        {
            SqlConnection cnn = new SqlConnection("Data Source=DESKTOP-INF3GAV\\AYSEM;Initial Catalog=isg;Integrated Security=True");
            SqlDataAdapter adp = new SqlDataAdapter("select * from ekipler" , cnn);
            DataTable dt = new DataTable("ekipler");
            adp.Fill(dt);
            return dt;  }

    }
}
