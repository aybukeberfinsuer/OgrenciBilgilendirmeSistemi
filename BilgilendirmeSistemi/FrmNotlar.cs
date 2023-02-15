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
using System.Media;

namespace BilgilendirmeSistemi
{
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }

        DataSet1TableAdapters.Tbl_NotlarTableAdapter ds = new DataSet1TableAdapters.Tbl_NotlarTableAdapter();
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-JKIESAIB\SQLEXPRESS;Initial Catalog=OkulBilgilendirme;Integrated Security=True");
        int notId;
        int sinav1, sinav2, proje, sinav3;
        double ortalama;
        string durum;

        
        private void btnara_Click(object sender, EventArgs e)
        {
            try
            {
                dgrid.DataSource = ds.GetData(int.Parse(txtid.Text));

            }
            catch
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("Girdiğiniz bilgilerde hata vardır.Lütfen kontrol ediniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FrmNotlar_Load(object sender, EventArgs e)
        {
           
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Tbl_Dersler", baglanti);
            SqlCommand komut2 = new SqlCommand("select * from Tbl_Notlar", baglanti);
            SqlDataAdapter da2 = new SqlDataAdapter(komut2);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dgrid.DataSource = dt2;
            da.Fill(dt);
            cmbders.DisplayMember = "DersAd";
            cmbders.ValueMember = "DersId";
            cmbders.DataSource = dt;
            baglanti.Close();

        }

        private void dgrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dgrid.SelectedCells[0].RowIndex;
            notId = int.Parse(dgrid.Rows[secilen].Cells[0].Value.ToString());
            txtid.Text = dgrid.Rows[secilen].Cells[2].Value.ToString();
            txtsinav1.Text = dgrid.Rows[secilen].Cells[3].Value.ToString();
            txtsinav2.Text = dgrid.Rows[secilen].Cells[4].Value.ToString();
            txtsinav3.Text = dgrid.Rows[secilen].Cells[5].Value.ToString();
            txtproje.Text = dgrid.Rows[secilen].Cells[6].Value.ToString();
            txtortalama.Text = dgrid.Rows[secilen].Cells[7].Value.ToString();
            txtdurum.Text = dgrid.Rows[secilen].Cells[8].Value.ToString();

        }

        private void btnhesapla_Click(object sender, EventArgs e)
        {
           
            //sınavlar %60 ı proje de %40 ı oluştrumaktadır.

            sinav1 = Convert.ToInt32(txtsinav1.Text);
            sinav2 = Convert.ToInt32(txtsinav2.Text);
            sinav3 = Convert.ToInt32(txtsinav3.Text);
            proje = Convert.ToInt32(txtproje.Text);
            ortalama=(sinav1*10)/100 + (sinav2*20)/100 +(sinav3* 30)/100 +(proje* 40)/100;
            txtortalama.Text = ortalama.ToString("0.00", System.Globalization.CultureInfo.GetCultureInfo("tr-TR"));
            //Yukardaki işlmei farklı şekillerde de yapabiliyoruz ben burada textboxın içine virgüllü sayı yazdırma yaptım.
            if (ortalama >= 55)
            {
               txtdurum.Text = "True";
            }
            else
            {
                txtdurum.Text = "False";
            }

        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            ds.guncelle(byte.Parse(cmbders.SelectedValue.ToString()),int.Parse(txtid.Text),byte.Parse(txtsinav1.Text), byte.Parse(txtsinav2.Text), byte.Parse(txtsinav3.Text), byte.Parse(proje.ToString()), decimal.Parse(ortalama.ToString()), bool.Parse(txtdurum.Text),notId);
        }
    }
}
