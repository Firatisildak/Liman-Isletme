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
    public partial class kullanıcı_silme : Form
    {
        public kullanıcı_silme()
        {
            InitializeComponent();
        }
        private void kullanıcı_silme_Load(object sender, EventArgs e)
        {
            veritabanı.griddoldur(dataGridView1, "select * from tbl_girisKontrol");
            dataGridView1.Columns[0].Width = 230;
            dataGridView1.Columns[1].Width = 230;
            dataGridView1.Columns[2].Width = 230;
            dataGridView1.Columns[3].Width = 230;
            dataGridView1.RowHeadersVisible = false;
        }
        SqlCommand cmd;
        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            string işlem = "Delete from tbl_girisKontrol where kullanıcı_adı= @ad and şifre= @şifre";
            cmd.Parameters.AddWithValue("@ad", textBox1.Text);
            cmd.Parameters.AddWithValue("@şifre", textBox2.Text);
            cmd.Parameters.AddWithValue("@yetki", comboBox1.Text);
            cmd.Parameters.AddWithValue("@id", textBox4.Text);
            veritabanı.komutyolla(işlem, cmd);
            veritabanı.griddoldur(dataGridView1, "select* From tbl_girisKontrol");
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            string işlem = "update tbl_girisKontrol set  kullanıcı_adı=@ad,şifre=@şifre,yetki=@yetki where perid=@id   ";
            cmd.Parameters.AddWithValue("@ad", textBox1.Text);
            cmd.Parameters.AddWithValue("@şifre", textBox2.Text);
            cmd.Parameters.AddWithValue("@yetki", comboBox1.Text);
            cmd.Parameters.AddWithValue("@id", textBox4.Text);
            veritabanı.komutyolla(işlem, cmd);
            veritabanı.griddoldur(dataGridView1, "select* From tbl_girisKontrol");
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            veritabanıbaglanti a = new veritabanıbaglanti();
            a.Show();
        }
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }
    }
}
