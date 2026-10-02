using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using Basoglu.Helpers;

namespace Basoglu
{
    public partial class YIUrunleriGoster : Form
    {
        private ContextMenuStrip contextMenu;
        private int clickedRowIndex = -1;
        private int eskiMiktar = -1;

        public YIUrunleriGoster()
        {
            InitializeComponent();
            SetupContextMenu();
            ListeYenile();
            dataGridView1.CellBeginEdit += dataGridView1_CellBeginEdit;
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
            dataGridView1.CellMouseDown += dataGridView1_CellMouseDown;
            dataGridView1.DataError += dataGridView1_DataError;
        }

        private void YIUrunleriGoster_Load(object sender, EventArgs e)
        {
            ListeYenile();
        }

        public void ListeYenile()
        {
            dataGridView1.EndEdit();
            dataGridView1.CurrentCell = null;
            dataGridView1.DataSource = null;

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            var bindingList = new BindingList<YIUrun>(YIUrunler.Urunler);
            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.ReadOnly = true;
            }

            if (dataGridView1.Columns.Contains("Miktar"))
                dataGridView1.Columns["Miktar"].ReadOnly = false;

            if (dataGridView1.Columns.Contains("UrunIsmi"))
                dataGridView1.Columns["UrunIsmi"].HeaderText = "Ürün İsmi";
            if (dataGridView1.Columns.Contains("ModelNumarasi"))
                dataGridView1.Columns["ModelNumarasi"].HeaderText = "Model No";
            if (dataGridView1.Columns.Contains("SeriNo"))
                dataGridView1.Columns["SeriNo"].HeaderText = "Seri No";
            if (dataGridView1.Columns.Contains("Kaynak"))
                dataGridView1.Columns["Kaynak"].HeaderText = "Stoktan mı?";
        }

        private void SetupContextMenu()
        {
            contextMenu = new ContextMenuStrip();
            ToolStripMenuItem silMenuItem = new ToolStripMenuItem("Seçili Ürünü Sil");
            silMenuItem.Click += SilMenuItem_Click;
            contextMenu.Items.Add(silMenuItem);
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right &&
                e.RowIndex >= 0 &&
                e.RowIndex < dataGridView1.Rows.Count)
            {
                clickedRowIndex = e.RowIndex;
                dataGridView1.ClearSelection();
                dataGridView1.Rows[e.RowIndex].Selected = true;
                contextMenu.Show(Cursor.Position);
            }
        }

        private void SilMenuItem_Click(object sender, EventArgs e)
        {
            if (clickedRowIndex >= 0 && clickedRowIndex < YIUrunler.Urunler.Count)
            {
                DialogResult result = MessageBox.Show(
                    "Seçili ürünü silmek istediğinize emin misiniz?",
                    "Onay",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    var urun = YIUrunler.Urunler[clickedRowIndex];

                    Logger.Log("Silme", "YIUrunler",
                        $"Ürün silindi | Ürün: {urun.UrunIsmi}, Model: {urun.ModelNumarasi ?? "Yok"}, Seri: {urun.SeriNo ?? "Yok"}, Miktar: {urun.Miktar}, Kaynak: {(urun.Kaynak ? "Stok" : "Harici")}");

                    YIUrunler.Urunler.RemoveAt(clickedRowIndex);
                    clickedRowIndex = -1;
                    ListeYenile();
                }

            }
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= YIUrunler.Urunler.Count)
                return;

            if (dataGridView1.Columns[e.ColumnIndex].Name == "Miktar")
            {
                eskiMiktar = YIUrunler.Urunler[e.RowIndex].Miktar;
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= YIUrunler.Urunler.Count)
                return;

            if (dataGridView1.Columns[e.ColumnIndex].Name != "Miktar")
                return;

            var urun = YIUrunler.Urunler[e.RowIndex];

            string yeniDegerStr = dataGridView1.Rows[e.RowIndex].Cells["Miktar"].Value?.ToString();
            if (!int.TryParse(yeniDegerStr, out int yeniMiktar))
            {
                MessageBox.Show("Lütfen miktar hücresine geçerli bir sayı girin.");
                urun.Miktar = eskiMiktar;
                ListeYenile();
                return;
            }

            string connStr = database.DbHelper.GetConnectionString();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                SqlCommand stokCmd = new SqlCommand(@"
            SELECT Miktar FROM Urunler 
            WHERE Urun_ismi = @isim 
            AND (
                (Model_numarasi = @model) 
                OR (Model_numarasi IS NULL AND @model IS NULL) 
                OR (Model_numarasi = '' AND @model = '')
            ) 
            AND (
                (seri_no = @seri) 
                OR (seri_no IS NULL AND @seri IS NULL) 
                OR (seri_no = '' AND @seri = '')
            )", conn);

                object modelParam = string.IsNullOrWhiteSpace(urun.ModelNumarasi) ? DBNull.Value : (object)urun.ModelNumarasi.Trim();
                object seriParam = string.IsNullOrWhiteSpace(urun.SeriNo) ? DBNull.Value : (object)urun.SeriNo.Trim();

                stokCmd.Parameters.AddWithValue("@isim", urun.UrunIsmi);
                stokCmd.Parameters.AddWithValue("@model", modelParam);
                stokCmd.Parameters.AddWithValue("@seri", seriParam);

                object result = stokCmd.ExecuteScalar();

                if (result == null || result == DBNull.Value)
                {
                    MessageBox.Show("Stok bilgisi alınamadı. Değişiklik iptal edildi.");
                    urun.Miktar = eskiMiktar;
                    ListeYenile();
                    return;
                }

                int sqlStok = Convert.ToInt32(result);

                if (yeniMiktar > sqlStok)
                {
                    MessageBox.Show($"Miktar stoktan fazla olamaz. (Stok: {sqlStok})");
                    urun.Miktar = eskiMiktar;
                    ListeYenile();
                    return;
                }

                if (eskiMiktar != yeniMiktar)
                {
                    Helpers.Logger.Log("Güncelleme", "YIUrunler",
                        $"Ürün miktarı değiştirildi | Ürün: {urun.UrunIsmi}, Model: {urun.ModelNumarasi ?? "Yok"}, Seri: {urun.SeriNo ?? "Yok"}, Eski: {eskiMiktar}, Yeni: {yeniMiktar}");
                }

                urun.Miktar = yeniMiktar;
                ListeYenile();
            }
        }


        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.ColumnIndex >= dataGridView1.Columns.Count)
                return;

            if (dataGridView1.Columns[e.ColumnIndex].Name == "Miktar")
            {
                MessageBox.Show("Miktar alanına sadece sayısal değer girilmelidir.", "Geçersiz Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.ThrowException = false;
                e.Cancel = true;
            }
        }
    }
}
