using DBFirstRepository.DAL;
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
    public partial class CalisanlarFrm : Form
    {
        public CalisanlarFrm()
        {
            InitializeComponent();
        }
        CalisanlarRepository calisanRep = new CalisanlarRepository();

        private void CalisanlarFrm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = calisanRep.Listele();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Employee yeniKat = new Employee();
            yeniKat.FirstName = txtFirstName.Text;
            yeniKat.LastName = txtLastName.Text;
            yeniKat.Title = txtTitle.Text;
            yeniKat.City = txtCity.Text;
            yeniKat.Country = txtCountry.Text;
            yeniKat.Address = txtAdress.Text;
            calisanRep.Ekle(yeniKat);
            dataGridView1.DataSource = calisanRep.Listele();
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            Employee guncelKat = new Employee();
            guncelKat.FirstName = txtFirstName.Text;
            guncelKat.LastName = txtLastName.Text;
            guncelKat.Title = txtTitle.Text;
            guncelKat.City = txtCity.Text;
            guncelKat.Country = txtCountry.Text;
            guncelKat.Address = txtAdress.Text;
            guncelKat.EmployeeID = id;
            calisanRep.Duzenle(guncelKat);
            dataGridView1.DataSource = calisanRep.Listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            var sonuc = MessageBox.Show("Seçtiğiniz kategori silinecek. Emin misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sonuc == DialogResult.No)
            {
                return;
            }
            calisanRep.Sil(id);
            dataGridView1.DataSource = calisanRep.Listele();
        }

        int id;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
            {
                MessageBox.Show("Lütfen veri içeriği bulunana hücreleri seçiniz. Kolon ismi seçmeyiniz.");
                return;
            }
            id = (int)dataGridView1.Rows[e.RowIndex].Cells["EmployeeID"].Value;
            Employee bulunanKat = calisanRep.Bul(id);
            txtFirstName.Text = bulunanKat.FirstName;
            txtLastName.Text = bulunanKat.LastName;
            txtTitle.Text = bulunanKat.Title;
            txtCity.Text = bulunanKat.City;
            txtCountry.Text = bulunanKat.Country;
            txtAdress.Text = bulunanKat.Address;
        }
    }
}