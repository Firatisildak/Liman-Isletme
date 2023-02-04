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
    public partial class limandakalan_alan : Form
    {
        static SqlConnection con;
        static SqlCommand cmd;
        static SqlDataAdapter da;
        static SqlDataReader dr;
        static DataSet ds;
        static string sqlcon = veritabanı.sqlcon;
        public static DataGridView griddoldurstorprosedur(DataGridView gridim, string deger)
        {
            con = new SqlConnection(sqlcon);
            cmd = new SqlCommand("tablolari_birlestir", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("gemiad", SqlDbType.NVarChar, 50).Value = "%" + deger + "%";
            ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            con.Open();
            da.Fill(ds);
            gridim.DataSource = ds.Tables[0];
            con.Close();
            return gridim;
        }
        public static string sqlsorgu = "";
        public limandakalan_alan()
        {
            InitializeComponent();
        }
        private void limandakalan_alan_Load(object sender, EventArgs e)
        {
            
            sqlsorgu = "select Tbl_login.*,tbldepoda_kalan.* from  Tbl_login INNER JOIN tbldepoda_kalan ON Tbl_login.perid=tbldepoda_kalan.perid ";
            dataGridView1.RowHeadersVisible = false;
            limandakalan_alan.griddoldurstorprosedur(dataGridView1, textBox1.Text);
            dataGridView1.Columns[10].Visible = false;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            sqlsorgu = "select Tbl_login.*,tbldepoda_kalan.* from  Tbl_login INNER JOIN tbldepoda_kalan ON Tbl_login.perid=tbldepoda_kalan.perid  where Tbl_login.gemi_ad like '%" + textBox1.Text + "%'";
            dataGridView1.RowHeadersVisible = false;
            limandakalan_alan.griddoldurstorprosedur(dataGridView1, textBox1.Text);
        }
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            kayıt_sayfası a = new kayıt_sayfası();
            a.Show();
        }
    }
}
