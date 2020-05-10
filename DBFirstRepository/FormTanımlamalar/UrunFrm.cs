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
    public partial class UrunFrm : Form
    {
        public UrunFrm()
        {
            InitializeComponent();
        }
        UrunRepository urunRep = new UrunRepository();
        KategoriRepository katRep = new KategoriRepository();

        private void UrunFrm_Load(object sender, EventArgs e)
        {
            List<Category> katListesi = katRep.Listele();
            cmbKategori.DataSource = katListesi;
            cmbKategori.DisplayMember = "CategoryName"; //  ComboBox'ın görselde göstereceği kolon adıdır.
            cmbKategori.ValueMember = "CategoryID"; // ComboBox'ın seçilme anından seçilen nesnenin kolon adıdır.
            dataGridView1.DataSource = urunRep.Listele();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Product yeniUrun = new Product();
            yeniUrun.ProductName = txtAdi.Text;
            yeniUrun.UnitPrice = nmdFiyat.Value;
            yeniUrun.UnitsInStock = (short)nmdStok.Value;
            // CategoryID yi alabilmek için combobox'tan seçilen kategoriyi Category veritipinde cast yaparak yakalıyoruz. 
            Category secilenKat = (Category)cmbKategori.SelectedItem;
            yeniUrun.CategoryID = secilenKat.CategoryID;
            urunRep.Ekle(yeniUrun);
            dataGridView1.DataSource = urunRep.Listele();
        }

        int id;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = (int)dataGridView1.Rows[e.RowIndex].Cells["ProductID"].Value;
            Product secilenUrun = urunRep.Bul(id);
            txtAdi.Text = secilenUrun.ProductName;
            nmdFiyat.Value = secilenUrun.UnitPrice.Value;
            nmdStok.Value = Convert.ToInt16(secilenUrun.UnitsInStock);
            cmbKategori.SelectedValue = secilenUrun.CategoryID; // Kategorileri combobox datasource displaymember ve valuemember tuttuğumuz için seçilen ürünün kategorisinini bu şekilde atıyoruz.
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            var sonuc = MessageBox.Show("Seçtiğiniz kategori silinecek. Emin misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sonuc == DialogResult.No)
            {
                return;
            }
            urunRep.Sil(id);
            dataGridView1.DataSource = urunRep.Listele();
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            Product guncelKat = new Product();
            guncelKat.ProductID = id;
            guncelKat.ProductName = txtAdi.Text;
            guncelKat.CategoryID = (int)cmbKategori.SelectedValue;
            guncelKat.UnitPrice = nmdFiyat.Value;
            guncelKat.UnitsInStock = (short)nmdStok.Value;
            urunRep.Duzenle(guncelKat);
            dataGridView1.DataSource = urunRep.Listele();
        }
    }
}