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
    public partial class OgrenciNotlar : Form
    {
        public OgrenciNotlar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-JKIESAIB\SQLEXPRESS;Initial Catalog=OkulBilgilendirme;Integrated Security=True");
        public string numara;
        private void OgrenciNotlar_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select DersAd,Sinav1,Sinav2,Sinav3,Proje,Ortalama,Durum from Tbl_Notlar inner join Tbl_Dersler on Tbl_Notlar.DersId = Tbl_Dersler.DersId where OgrId = @p1", baglanti);
            komut.Parameters.AddWithValue("@p1", numara);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
           

            //Burada Ogrenci formundaki sayfanın adını öğrenci adı soyadı yapıyoruz.
           
            SqlCommand komut2 = new SqlCommand("select OgrAd,OgrSoyad from Tbl_Ogrenciler inner join Tbl_Notlar on Tbl_Notlar.OgrId=Tbl_Ogrenciler.OgrId where Tbl_Ogrenciler.OgrId=@p2", baglanti);
            komut2.Parameters.AddWithValue("@p2", numara);
            SqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                this.Text = dr[0] + " "+dr[1];
            }
            baglanti.Close();
        }
    }
}
