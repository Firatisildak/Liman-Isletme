using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace liman_işletme_otomasyonu
{
    public partial class şifre_güncelleme : Form
    {
        static SqlConnection con;
        static SqlCommand cmd;
        static SqlDataAdapter da;
        static SqlDataReader dr;
        public int sonuç = 0;
        string sqlcon = veritabanı.sqlcon;
        public şifre_güncelleme()
        {
            InitializeComponent();
        }
        public void eskişifrekontrol()
        {
            string sorgu = "select şifre from tbl_girisKontrol where kullanıcı_adı=@user and şifre=@pasword";
            con = new SqlConnection(sqlcon);
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@user", Form1.kullanicimSession);
            cmd.Parameters.AddWithValue("@pasword", veritabanı.md5sifreleme(textBox_eskişfre.Text));
            con.Open();
            dr = cmd.ExecuteReader();
            //eğer veri girdiyse
            if (dr.Read())
            {
                string sql = "update tbl_girisKontrol set şifre='" + veritabanı.md5sifreleme(textBox_yenişifre.Text)+ "'where kullanıcı_adı='"+Form1.kullanicimSession+"'";
                veritabanı.komutyolla(sql,cmd);
                MessageBox.Show("şifre değiştirme işlemi başarılı.");
            }
            else
            {
                label5.Text= "eski şifreniz hatalı";
                caphaoluşturma();
            }
            con.Close();
        }
        public void caphaoluşturma()
        {
            Random r = new Random();
            int ilk = r.Next(0, 50);
            int ikinci = r.Next(0, 50);
            sonuç = ilk + ikinci;
            label_capha.Text = ilk.ToString() + "+" + ikinci.ToString() + "=";
            textBox_capha.Clear();
        }
        private void şifre_güncelleme_Load(object sender, EventArgs e)
        {
            caphaoluşturma();
            label5.Text ="";
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox_capha.Text.Equals(sonuç.ToString()))
            {
                label5.Text = "";
                if (textBox_yenişifre.Text == textBox_yenişifreonay.Text)
                {
                    eskişifrekontrol();
                }
                else
                {
                    label5.Text = "yeni şifre tekrarıyla uyuşmuyor";
                }
            }
            else
            {
                label5.Text = "captcha hatalı";
                caphaoluşturma();
            }
        }
    }
}
