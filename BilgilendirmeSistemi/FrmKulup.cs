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

namespace BilgilendirmeSistemi
{
    public partial class FrmKulup : Form
    {
        public FrmKulup()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-JKIESAIB\SQLEXPRESS;Initial Catalog=OkulBilgilendirme;Integrated Security=True");
        private void listele()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from Tbl_Kulupler", baglanti);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(dt);
            datagrid1.DataSource = dt;
            baglanti.Close();
        }
        private void ekle()
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand(" insert into Tbl_KUlupler (KulupAd) values (@p1)", baglanti);
            komut2.Parameters.AddWithValue("@p1", txtdersad.Text); // textbox ın adını değiştitmemiştim sayfalar aynı mantıkta olduğu için copy-paste yaptım.
            komut2.ExecuteNonQuery();
            baglanti.Close();
            listele();
            MessageBox.Show("Kulüp eklenmiştir", "Bilgi");
        }
        
        private void sil()
        {
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Delete Tbl_Kulupler where KulupId=@d1", baglanti);
            komut3.Parameters.AddWithValue("@d1", textBox1.Text);
            komut3.ExecuteNonQuery();
            baglanti.Close();
            listele();
            MessageBox.Show("Kulüp silinmiştir.", "Bilgi");
        }

        private void guncelle()
        {
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("update Tbl_Kulupler set  KulupAd=@u1 where KulupId=@u2", baglanti);
            komut4.Parameters.AddWithValue("@u1", txtdersad.Text);
            komut4.Parameters.AddWithValue("@u2", textBox1.Text);
            komut4.ExecuteNonQuery();
            baglanti.Close();
            listele();
            MessageBox.Show("Kulüp adı güncellenmiştir", "Bilgi");
        }


        private void FrmKulup_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            ekle();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            sil();
        }

        private void datagrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = datagrid1.SelectedCells[0].RowIndex;
            textBox1.Text = datagrid1.Rows[secilen].Cells[0].Value.ToString();
            txtdersad.Text = datagrid1.Rows[secilen].Cells[1].Value.ToString();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            guncelle();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
