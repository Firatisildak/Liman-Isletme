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
    public partial class RaporGoruntule : Form
    {
        public RaporGoruntule()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;
        string sqlcon = veritabanı.sqlcon;
        private void reportDocument1_InitReport(object sender, EventArgs e)
        {

        }
        public void rapordoldur(string sql)
        {
            con = new SqlConnection(sqlcon);
            da = new SqlDataAdapter(sql, con);
            ds = new DataSet();

            con.Open();
            da.Fill(ds);
            kullanicirapor1.SetDataSource(ds.Tables[0]);
            crystalReportViewer1.ReportSource = kullanicirapor1;
            con.Close();
        }

        private void RaporGoruntule_Load(object sender, EventArgs e)
        {
            rapordoldur("select * from tbldepoda_kalan");
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
