using DBFirstRepository.BLL;
using DBFirstRepository.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBFirstRepository.FormTanımlamalar
{
    public partial class KategoriFrm : Form
    {
        public KategoriFrm()
        {
            InitializeComponent();
        }
        
        KategoriRepository katRep = new KategoriRepository();
        private void KategoriFrm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = katRep.Listele();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Category yeniKat = new Category();
            yeniKat.CategoryName = txtKatAdi.Text;
            yeniKat.Description = txtAciklama.Text;
            katRep.Ekle(yeniKat);
            dataGridView1.DataSource = katRep.Listele();
        }

        int id;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
            {
                MessageBox.Show("Lütfen veri içeriği bulunana hücreleri seçiniz. Kolon ismi seçmeyiniz.");
                return;
            }
            id = (int)dataGridView1.Rows[e.RowIndex].Cells["CategoryID"].Value;
            Category bulunanKat = katRep.Bul(id);
            txtKatAdi.Text = bulunanKat.CategoryName;
            txtAciklama.Text = bulunanKat.Description;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            var sonuc = MessageBox.Show("Seçtiğiniz kategori silinecek. Emin misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sonuc == DialogResult.No)
            {
                return;
            }
            katRep.Sil(id);
            dataGridView1.DataSource = katRep.Listele();
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            Category guncelKat = new Category();
            guncelKat.CategoryName = txtKatAdi.Text;
            guncelKat.Description = txtAciklama.Text;
            guncelKat.CategoryID = id;
            katRep.Duzenle(guncelKat);
            dataGridView1.DataSource = katRep.Listele();
        }
    }
}