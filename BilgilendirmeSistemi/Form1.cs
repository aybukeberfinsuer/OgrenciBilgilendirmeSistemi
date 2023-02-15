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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //bağlantı kodu aşağıda
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-JKIESAIB\SQLEXPRESS;Initial Catalog=OkulBilgilendirme;Integrated Security=True");

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OgrenciNotlar frm = new OgrenciNotlar();
            frm.numara = textBox1.Text;
            frm.Show();
           

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmOgretmen frmogretmen = new FrmOgretmen();
            frmogretmen.Show();
            this.Hide();
        }
    }
}
