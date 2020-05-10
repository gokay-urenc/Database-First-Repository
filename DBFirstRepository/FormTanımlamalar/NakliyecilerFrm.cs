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
    public partial class NakliyecilerFrm : Form
    {
        public NakliyecilerFrm()
        {
            InitializeComponent();
        }
        NakliyecilerRepository nakliyeciRep = new NakliyecilerRepository();

        private void NakliyecilerFrm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = nakliyeciRep.Listele();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Shipper yeniKat = new Shipper();
            yeniKat.CompanyName = txtCompanyName.Text;
            yeniKat.Phone = txtPhone.Text;
            nakliyeciRep.Ekle(yeniKat);
            dataGridView1.DataSource = nakliyeciRep.Listele();
        }

        int id;
        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            Shipper guncelKat = new Shipper();
            guncelKat.CompanyName = txtCompanyName.Text;
            guncelKat.Phone = txtPhone.Text;
            guncelKat.ShipperID = id;
            nakliyeciRep.Duzenle(guncelKat);
            dataGridView1.DataSource = nakliyeciRep.Listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            var sonuc = MessageBox.Show("Seçtiğiniz kategori silinecek. Emin misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sonuc == DialogResult.No)
            {
                return;
            }
            nakliyeciRep.Sil(id);
            dataGridView1.DataSource = nakliyeciRep.Listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
            {
                MessageBox.Show("Lütfen veri içeriği bulunana hücreleri seçiniz. Kolon ismi seçmeyiniz.");
                return;
            }
            id = (int)dataGridView1.Rows[e.RowIndex].Cells["ShipperID"].Value;
            Shipper bulunanKat = nakliyeciRep.Bul(id);
            txtCompanyName.Text = bulunanKat.CompanyName;
            txtPhone.Text = bulunanKat.Phone;
        }
    }
}