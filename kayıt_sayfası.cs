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
    public partial class kayıt_sayfası : Form
    {
        public kayıt_sayfası()
        {
            InitializeComponent();
        }
        SqlCommand cmd;
        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            string işlem= "insert into Tbl_login(gemi_ad,plaka,yük_tipi,ülke,liman_giriş,liman_çıkış)values (@ad,@pl,@yük,@ülke,@giriş,@çıkış)";
            cmd.Parameters.AddWithValue("@ad", textBox1.Text);
            cmd.Parameters.AddWithValue("@pl", textBox2.Text);
            cmd.Parameters.AddWithValue("@yük", comboBox1.Text);
            cmd.Parameters.AddWithValue("@ülke", comboBox2.Text);
            cmd.Parameters.AddWithValue("@giriş", (dateTimePicker1.Value));
            cmd.Parameters.AddWithValue("@çıkış", (dateTimePicker2.Value));
            veritabanı.komutyolla(işlem,cmd);
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            textBox1.Clear();
            textBox2.Clear();
            MessageBox.Show("kayıt gerçekleşti.");
        }

        private void şifreGüncellemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            şifre_güncelleme a = new şifre_güncelleme();
            a.ShowDialog();
        }
        private void kalanAlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            limandakalan_alan b = new limandakalan_alan();
            b.Show();
        }

        private void kayıt_sayfası_Load(object sender, EventArgs e)
        {

        }
    }
}
