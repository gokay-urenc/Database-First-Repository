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
    public partial class TedarikcilerFrm : Form
    {
        public TedarikcilerFrm()
        {
            InitializeComponent();
        }
        TedarikcilerRepository tedarikciRep = new TedarikcilerRepository();

        private void TedarikcilerFrm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = tedarikciRep.Listele();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Supplier yeniKat = new Supplier();
            yeniKat.CompanyName = txtCompanyName.Text;
            yeniKat.ContactName = txtContactName.Text;
            yeniKat.ContactTitle = txtContactTitle.Text;
            yeniKat.City = txtCity.Text;
            yeniKat.Country = txtCountry.Text;
            yeniKat.Address = txtAdress.Text;
            tedarikciRep.Ekle(yeniKat);
            dataGridView1.DataSource = tedarikciRep.Listele();
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            Supplier guncelKat = new Supplier();
            guncelKat.CompanyName = txtCompanyName.Text;
            guncelKat.ContactName = txtContactName.Text;
            guncelKat.ContactTitle = txtContactTitle.Text;
            guncelKat.City = txtCity.Text;
            guncelKat.Country = txtCountry.Text;
            guncelKat.Address = txtAdress.Text;
            guncelKat.SupplierID = id;
            tedarikciRep.Duzenle(guncelKat);
            dataGridView1.DataSource = tedarikciRep.Listele();
        }

        int id;
        private void btnSil_Click(object sender, EventArgs e)
        {
            var sonuc = MessageBox.Show("Seçtiğiniz kategori silinecek. Emin misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sonuc == DialogResult.No)
            {
                return;
            }
            tedarikciRep.Sil(id);
            dataGridView1.DataSource = tedarikciRep.Listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
            {
                MessageBox.Show("Lütfen veri içeriği bulunana hücreleri seçiniz. Kolon ismi seçmeyiniz.");
                return;
            }
            id = (int)dataGridView1.Rows[e.RowIndex].Cells["SupplierID"].Value;
            Supplier bulunanKat = tedarikciRep.Bul(id);
            txtCompanyName.Text = bulunanKat.CompanyName;
            txtContactName.Text = bulunanKat.ContactName;
            txtContactTitle.Text = bulunanKat.ContactTitle;
            txtCity.Text = bulunanKat.City;
            txtCountry.Text = bulunanKat.Country;
            txtAdress.Text = bulunanKat.Address;
        }
    }
}