using DBFirstRepository.FormTanımlamalar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBFirstRepository
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void kategorileriListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KategoriFrm katForm = new KategoriFrm();
            katForm.ShowDialog();
        }

        private void ürünleriListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UrunFrm frm = new UrunFrm();
            frm.ShowDialog();
        }

        private void çalışanlarıListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CalisanlarFrm calisanlarForm = new CalisanlarFrm();
            calisanlarForm.ShowDialog();
        }

        private void tedarikçileriListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TedarikcilerFrm tedarikcilerForm = new TedarikcilerFrm();
            tedarikcilerForm.ShowDialog();
        }

        private void nakliyecileriListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NakliyecilerFrm nakliyecilerForm = new NakliyecilerFrm();
            nakliyecilerForm.ShowDialog();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}