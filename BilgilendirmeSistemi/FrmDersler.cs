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
    public partial class FrmDersler : Form
    {
        public FrmDersler()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-JKIESAIB\SQLEXPRESS;Initial Catalog=OkulBilgilendirme;Integrated Security=True");

        private void listele()
        {
            //listeleme için
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Select * from Tbl_Dersler order by DersId",baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            datagrid1.DataSource = dt;
            baglanti.Close();
        }

        private void ekle()
        {
            //eklemek için
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("insert into Tbl_Dersler (DersAd) values (@p1)", baglanti);
            komut2.Parameters.AddWithValue("@p1", txtdersad.Text);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            listele();
            MessageBox.Show("Ders Eklenmiştir", "Bilgi");
        }      

        private void FrmDersler_Load(object sender, EventArgs e){
            listele();
        }

        private void btnekle_Click(object sender, EventArgs e) {
            ekle();
            
        }

        private void btnlistele_Click(object sender, EventArgs e) {
            listele();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("delete from Tbl_Dersler where DersId=@d1", baglanti);
            komut3.Parameters.AddWithValue("@d1", textBox1.Text);
            komut3.ExecuteNonQuery();
            baglanti.Close();
            listele();
            MessageBox.Show("Ders Silinmiştir", "Bilgi");
           
        }

        private void datagrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = datagrid1.SelectedCells[0].RowIndex;
            textBox1.Text = datagrid1.Rows[secilen].Cells[0].Value.ToString();
            txtdersad.Text = datagrid1.Rows[secilen].Cells[1].Value.ToString();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("update Tbl_Dersler set  DersAd=@u1 where DersId=@u2", baglanti);
            komut4.Parameters.AddWithValue("@u1", txtdersad.Text);
            komut4.Parameters.AddWithValue("@u2", textBox1.Text);
            komut4.ExecuteNonQuery();
            baglanti.Close();
            listele();
            MessageBox.Show("Ders adı güncellenmiştir", "Bilgi");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
