using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Security.Cryptography;
namespace liman_işletme_otomasyonu
{
    class veritabanı
    {
        public static string yetki1="";
        static SqlConnection con;
        static SqlCommand cmd;
        static SqlDataAdapter da;
        static SqlDataReader dr;
        static DataSet ds;
        public static string sqlcon="Data Source=localhost;Initial Catalog = 'c# otomasyon'; Integrated Security = True";
          public static DataGridView griddoldur(DataGridView gridim,string selectsorgu)
          {
              con = new SqlConnection(sqlcon);
              ds = new DataSet();
              da = new SqlDataAdapter(selectsorgu, con);
              con.Open();
              da.Fill(ds, selectsorgu);
              gridim.DataSource = ds.Tables[selectsorgu];
              con.Close();
              return gridim;
          }
        public static void komutyolla(string sql,SqlCommand cmd)
        {
            con = new SqlConnection(sqlcon);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
        }
       public static string md5sifreleme(string sifrelenecekmetin)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            Byte[] dizi = Encoding.UTF8.GetBytes(sifrelenecekmetin);
            dizi = md5.ComputeHash(dizi);
            StringBuilder sb = new StringBuilder();
            foreach (byte item in dizi)
                sb.Append(item.ToString("X2").ToLower());
            return sb.ToString();
        }
        public static bool girişkontrol(string kullanıcı_adı, string şifre)
        {
            veritabanı.md5sifreleme(şifre);
            string sorgu = "select * from tbl_girisKontrol where kullanıcı_adı=@user and şifre=@pasword";
            con = new SqlConnection(sqlcon);
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@user", kullanıcı_adı);
            cmd.Parameters.AddWithValue("@pasword", veritabanı.md5sifreleme(şifre));
            con.Open();
            dr = cmd.ExecuteReader();
            //eğer veri girdiyse
            if (dr.Read())
            {
                
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }
        }
        public static void yukgetir(string sorgu,Label txt)
        {
            string sql = "Select COUNT(*) From Tbl_login where yük_tipi='"+sorgu+"'";
            con = new SqlConnection(veritabanı.sqlcon);
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txt.Text = dr[0].ToString();
            }
            con.Close();
        }
        public static void ulkegetir(string sorgu, Label txt)
        {
            string sql = "Select COUNT(*) From Tbl_login where ülke='" + sorgu + "'";
            con = new SqlConnection(veritabanı.sqlcon);
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txt.Text = dr[0].ToString();
            }
            con.Close();
        }
    }

}
