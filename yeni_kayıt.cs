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
    public partial class yeni_kayıt : Form
    {
        public yeni_kayıt()
        {
            InitializeComponent();
        }
        static SqlCommand cmd;
        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            string işlem = "insert into tbl_girisKontrol(kullanıcı_adı,şifre,yetki)values (@kullanıcı_adı,@şifre,@yetki)";
            cmd.Parameters.AddWithValue("@kullanıcı_adı", textBox1.Text);
            cmd.Parameters.AddWithValue("@şifre",veritabanı.md5sifreleme(textBox2.Text));
            cmd.Parameters.AddWithValue("@yetki", comboBox1.Text);
            veritabanı.komutyolla(işlem, cmd);
            pictureBox1.Visible = true;
        }
        private void yeni_kayıt_Load(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
        }
       
    }
}
