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
    public partial class istatislik : Form
    {
        public istatislik()
        {
            InitializeComponent();
        }
        private void istatislik_Load(object sender, EventArgs e)
        {
            string sorgu = "erzak";
            string sorgu1 = "cephane";
            string sorgu2 = "tıbbi malzeme";
            string sorgu3 = "teknolojik alet";
            string sorgu4 = "kimyasal madde";
            string sorgu5 = "tarımsal ürün";
            string sorgu6 = "rusya";
            string sorgu7 = "ukranya";
            string sorgu8 = "bulgaristan";
            string sorgu9 = "gürcistan";
            string sorgu10 = "romanya";
            veritabanı.yukgetir(sorgu, lberzak);
            veritabanı.yukgetir(sorgu1, lbcephane);
            veritabanı.yukgetir(sorgu2, lbtıbbi);
            veritabanı.yukgetir(sorgu3, lbteknoloji);
            veritabanı.yukgetir(sorgu4, lbkimyasal);
            veritabanı.yukgetir(sorgu5, lbtarım);
            veritabanı.ulkegetir(sorgu6, lbrusya);
            veritabanı.ulkegetir(sorgu7, lbukranya);
            veritabanı.ulkegetir(sorgu8, lbbulgaristan);
            veritabanı.ulkegetir(sorgu9, lbgürcistan);
            veritabanı.ulkegetir(sorgu10, lbromanya);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            veritabanıbaglanti a = new veritabanıbaglanti();
            a.Show();
        }
    }
}
