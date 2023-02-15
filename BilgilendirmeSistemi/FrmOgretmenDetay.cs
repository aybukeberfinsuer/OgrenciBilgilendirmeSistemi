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

namespace BilgilendirmeSistemi
{
    public partial class FrmOgretmenDetay : Form
    {
        public FrmOgretmenDetay()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.Tbl_OgretmenTableAdapter ds = new DataSet1TableAdapters.Tbl_OgretmenTableAdapter();

        private void FrmOgretmenDetay_Load(object sender, EventArgs e)
        {
            datagrid1.DataSource = ds.listele();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            try
            {
                ds.ekle(byte.Parse(txtbrans.Text), txtogrtad.Text);
            }
            catch
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("Girdiğiniz BranşId hatalıdır. Lütfen değerleri kontrol ederek tekrar giriniz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }
        private void btnlistele_Click(object sender, EventArgs e)
        {
            datagrid1.DataSource = ds.listele();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            ds.sil(byte.Parse(txtid.Text));

        }

        private void datagrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = datagrid1.SelectedCells[0].RowIndex;
            txtid.Text = datagrid1.Rows[secilen].Cells[0].Value.ToString();
            txtbrans.Text = datagrid1.Rows[secilen].Cells[1].Value.ToString();
            txtogrtad.Text = datagrid1.Rows[secilen].Cells[2].Value.ToString();

        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            ds.guncelle(byte.Parse(txtbrans.Text), txtogrtad.Text, byte.Parse(txtid.Text));
        }

    }
}
