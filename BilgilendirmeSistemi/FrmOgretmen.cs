using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BilgilendirmeSistemi
{
    public partial class FrmOgretmen : Form
    {
        public FrmOgretmen()
        {
            InitializeComponent();
        }

        private void btnders_Click(object sender, EventArgs e)
        {
            FrmDersler frmdersler = new FrmDersler();
            frmdersler.Show();
           
        }

        private void btnkulup_Click(object sender, EventArgs e)
        {
            FrmKulup frmkulup = new FrmKulup();
            frmkulup.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnogretmen_Click(object sender, EventArgs e)
        {
            FrmOgretmenDetay frmogretmendetay = new FrmOgretmenDetay();
            frmogretmendetay.Show();
        }

        private void btnogrenci_Click(object sender, EventArgs e)
        {
            FrmOgrenciDetay frmogrdetay = new FrmOgrenciDetay();
            frmogrdetay.Show();
        }

        private void btnnotlar_Click(object sender, EventArgs e)
        {
            FrmNotlar frmnotlar = new FrmNotlar();
            frmnotlar.Show();
        }
    }
}
