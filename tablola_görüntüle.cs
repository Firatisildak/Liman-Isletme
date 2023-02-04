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
    public partial class tablola_görüntüle : Form
    {
        public static string sqlsorgu = "";
        SqlCommand cmd;
        public tablola_görüntüle()
        {
            InitializeComponent();
        }
        private void tablola_görüntüle_Load(object sender, EventArgs e)
        {
            dataGridView1.RowHeadersVisible = false;
            veritabanı.griddoldur(dataGridView1, "select* from Tbl_login");
            dataGridView1.Columns[0].HeaderText = "Gemi İd";
            dataGridView1.Columns[1].HeaderText = "Gemi Adı";
            dataGridView1.Columns[2].HeaderText = "Plaka";
            dataGridView1.Columns[3].HeaderText = "Taşınan Yük";
            dataGridView1.Columns[4].HeaderText = "Gelinen Ülke";
            dataGridView1.Columns[5].HeaderText = "Limana Giriş Tarihi";
            dataGridView1.Columns[6].HeaderText = "limandan Çıkış Tarihi";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            string işlem = "update Tbl_login set  gemi_ad=@ad,yük_tipi=@yük,ülke=@ülke,liman_giriş = @giriş,liman_çıkış = @çıkış,plaka=@pl where perid=@id   ";
            cmd.Parameters.AddWithValue("@ad", textBox1.Text);
            cmd.Parameters.AddWithValue("@pl", textBox2.Text);
            cmd.Parameters.AddWithValue("@yük", textBox3.Text);
            cmd.Parameters.AddWithValue("@ülke", textBox4.Text);
            cmd.Parameters.AddWithValue("@id", textBox5.Text);
            cmd.Parameters.AddWithValue("@giriş", (dateTimePicker1.Value));
            cmd.Parameters.AddWithValue("@çıkış", (dateTimePicker2.Value));
            veritabanı.komutyolla(işlem, cmd);
            veritabanı.griddoldur(dataGridView1, "select* From Tbl_login");
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            string işlem = "Delete from Tbl_login where gemi_ad=@ad and plaka=@pl";
            cmd.Parameters.AddWithValue("@ad", textBox1.Text);
            cmd.Parameters.AddWithValue("@pl", textBox2.Text);
            cmd.Parameters.AddWithValue("@yük", textBox3.Text);
            cmd.Parameters.AddWithValue("@ülke", textBox4.Text);
            cmd.Parameters.AddWithValue("@giriş", (dateTimePicker1.Value));
            cmd.Parameters.AddWithValue("@çıkış", (dateTimePicker2.Value));
            veritabanı.komutyolla(işlem, cmd);
            veritabanı.griddoldur(dataGridView1, "select* From Tbl_login");
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            veritabanıbaglanti a = new veritabanıbaglanti();
            a.Show();
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            sqlsorgu = "select * from Tbl_login where gemi_ad like '%" + textBox6.Text + "%' order by gemi_ad ASC";
            veritabanı.griddoldur(dataGridView1, sqlsorgu);
        }
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            dateTimePicker2.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }
    }
}
