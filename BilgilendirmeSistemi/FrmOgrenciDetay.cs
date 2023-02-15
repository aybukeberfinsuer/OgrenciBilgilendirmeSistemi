using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Data.SqlClient;


namespace BilgilendirmeSistemi
{
    public partial class FrmOgrenciDetay : Form
    {
        public FrmOgrenciDetay()
        {
            InitializeComponent();
        }

        DataSet1TableAdapters.Tbl_OgrenciTableAdapter ds = new DataSet1TableAdapters.Tbl_OgrenciTableAdapter();
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-JKIESAIB\SQLEXPRESS;Initial Catalog=OkulBilgilendirme;Integrated Security=True");
       public string numara;
        private void FrmOgrenciDetay_Load(object sender, EventArgs e)
        {
            
            dataGridView1.DataSource = ds.listele();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Tbl_Kulupler", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbkulup.DisplayMember = "KulupAd";
            cmbkulup.ValueMember = "KulupId";
            cmbkulup.DataSource = dt;
            baglanti.Close();

            
        }


        private void btnekle_Click(object sender, EventArgs e)
        {
            string c = "";
            if (radioerkek.Checked == true)
            {
                c = "Erkek";
            }
            if (radiokadin.Checked == true)
            {
                c = "Kadın";
            }
            try
            {
                ds.ekle(txtad.Text, txtsoyad.Text, byte.Parse(cmbkulup.SelectedValue.ToString()), c);
                MessageBox.Show("Öğrenci Kaydı Başarıyla Yapılmıştır.");
            }
            catch
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("Girdiğiniz bilgilerde hata vardır.Lütfen kontrol ediniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.listele();
        }

        private void cmbkulup_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtkulupid.Text = cmbkulup.SelectedValue.ToString();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();

        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            ds.sil(int.Parse(txtid.Text));
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            string cinsiyet = "";
            if (radioerkek.Checked == true)
            {
                cinsiyet = "Erkek";
            }
            if (radiokadin.Checked == true)
            {
                cinsiyet = "Kadın";
            }
            ds.guncelle(txtad.Text, txtsoyad.Text, cinsiyet, byte.Parse(cmbkulup.SelectedValue.ToString()), int.Parse(txtid.Text));
        }

        private void btnara_Click(object sender, EventArgs e)
        {
           dataGridView1.DataSource = ds.ara(txtara.Text);

        }
    }
}
