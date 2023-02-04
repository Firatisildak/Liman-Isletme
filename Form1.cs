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
    public partial class Form1 : Form
    {
        int sayaç = 0;
        public int sonuç = 0;
        public static string kullanicimSession = ""; 
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            caphaoluşturma();
             label4.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        SqlConnection con;
        SqlDataReader dr;
        SqlCommand cmd;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Equals(sonuç.ToString()))
            {
                if (veritabanı.girişkontrol(textBox1.Text,textBox2.Text))
                {
                    string sql = "Select (yetki) From tbl_girisKontrol where kullanıcı_adı='" + textBox1.Text + "'";
                    con = new SqlConnection(veritabanı.sqlcon);
                    cmd = new SqlCommand(sql, con);
                    con.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        label4.Text = dr[0].ToString();
                    }
                    con.Close();

                    if (label4.Text == "Yönetici")
                    {
                        MessageBox.Show("yönetici girişi başarılı ");

                        kullanicimSession = textBox1.Text;
                        veritabanıbaglanti b = new veritabanıbaglanti();
                        b.Show();
                        this.Hide();

                    }

                    else
                    {
                        MessageBox.Show("kullanıcı girişi başarılı ");

                        kullanicimSession = textBox1.Text;// kullanıcı adını tutar.
                        kayıt_sayfası c = new kayıt_sayfası();
                        c.Show();
                        this.Hide();
                    }

                }
                else
                {
                    sayaç++;
                    if (sayaç == 1)
                    {
                        MessageBox.Show(" hatalı tuşlama yaptınız");
                    }
                }
            }
            else
            {
                label5.Text = "captcha hatalı";
                caphaoluşturma();
            }
        }
        public void caphaoluşturma()
        {
            Random r = new Random();
            int ilk = r.Next(0, 50);
            int ikinci = r.Next(0, 50);
            sonuç = ilk + ikinci;
            label2.Text = ilk.ToString() + "+" + ikinci.ToString() + "=";
            textBox4.Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
