using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Basoglu
{
    public partial class YIUrunleriGuncelleMenu : Form
    {
        private ContextMenuStrip contextMenu;
        private int clickedRowIndex = -1;
        private int yapilanIsId; // Dışarıdan verilecek

        public YIUrunleriGuncelleMenu(int isId)
        {
            InitializeComponent();
            yapilanIsId = isId;

            dgvYIUrunlerGuncelle.ReadOnly = true;
            dgvYIUrunlerGuncelle.AllowUserToAddRows = false;
            dgvYIUrunlerGuncelle.AllowUserToDeleteRows = false;
            dgvYIUrunlerGuncelle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvYIUrunlerGuncelle.MultiSelect = false;

            SetupContextMenu();
            dgvYIUrunlerGuncelle.CellMouseDown += dgvYIUrunlerGuncelle_CellMouseDown;
            dgvYIUrunlerGuncelle.CellClick += dgvYIUrunlerGuncelle_CellClick;

            UrunleriYukle();
        }

         public void UrunleriYukle()
        {
            try
            {
                string connStr = database.DbHelper.GetConnectionString();
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(
                        "SELECT * FROM YIUrunler WHERE Yapilan_is_id = @isId", conn);
                    da.SelectCommand.Parameters.AddWithValue("@isId", yapilanIsId);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvYIUrunlerGuncelle.DataSource = dt;

                    if (dgvYIUrunlerGuncelle.Columns.Contains("id"))
                        dgvYIUrunlerGuncelle.Columns["id"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veriler yüklenemedi: " + ex.Message);
            }
        }

        private void SetupContextMenu()
        {
            contextMenu = new ContextMenuStrip();
            ToolStripMenuItem silMenuItem = new ToolStripMenuItem("Seçili Ürünü Sil");
            silMenuItem.Click += SilMenuItem_Click;
            contextMenu.Items.Add(silMenuItem);
        }

        private void dgvYIUrunlerGuncelle_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                clickedRowIndex = e.RowIndex;
                dgvYIUrunlerGuncelle.ClearSelection();
                dgvYIUrunlerGuncelle.Rows[clickedRowIndex].Selected = true;
                contextMenu.Show(Cursor.Position);
            }
        }

        private void SilMenuItem_Click(object sender, EventArgs e)
        {
            if (clickedRowIndex >= 0 && clickedRowIndex < dgvYIUrunlerGuncelle.Rows.Count)
            {
                DataGridViewRow row = dgvYIUrunlerGuncelle.Rows[clickedRowIndex];
                int urunId = Convert.ToInt32(row.Cells["id"].Value);
                bool kaynak = Convert.ToBoolean(row.Cells["kaynak"].Value);
                int miktar = Convert.ToInt32(row.Cells["Miktar"].Value);
                string urunIsmi = row.Cells["Urun_ismi"].Value.ToString();
                string model = row.Cells["Model_numarasi"].Value?.ToString() ?? "Yok";
                string seri = row.Cells["Seri_no"].Value?.ToString() ?? "Yok";

                DialogResult result = MessageBox.Show(
                    $"'{urunIsmi}' adlı ürünü silmek istiyor musunuz?",
                    "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    string connStr = database.DbHelper.GetConnectionString();
                    using (SqlConnection conn = new SqlConnection(connStr))
                    {
                        conn.Open();
                        SqlTransaction trans = conn.BeginTransaction();
                        try
                        {
                            SqlCommand silCmd = new SqlCommand("DELETE FROM YIUrunler WHERE id=@id", conn, trans);
                            silCmd.Parameters.AddWithValue("@id", urunId);
                            silCmd.ExecuteNonQuery();

                            if (kaynak)
                            {
                                SqlCommand stokGuncelle = new SqlCommand(
                                    "UPDATE Urunler SET Miktar = Miktar + @fark WHERE Urun_ismi = @isim", conn, trans);
                                stokGuncelle.Parameters.AddWithValue("@fark", miktar);
                                stokGuncelle.Parameters.AddWithValue("@isim", urunIsmi);
                                stokGuncelle.ExecuteNonQuery();

                                // 🔍 Log: stok güncelleme
                                Helpers.Logger.Log("Stok Güncelleme", "Urunler",
                                    $"Ürün silindiği için stok geri artırıldı | Ürün: {urunIsmi}, Model: {model}, Seri: {seri}, Miktar: {miktar}");
                            }

                            // 🔍 Log: ürün silme
                            Helpers.Logger.Log("Silme", "YIUrunler",
                                $"YapılanIsId: {yapilanIsId} | Ürün silindi | Ürün: {urunIsmi}, Model: {model}, Seri: {seri}, Miktar: {miktar}, Kaynak: {(kaynak ? "Stok" : "Harici")}");

                            trans.Commit();
                            MessageBox.Show("Ürün silindi.");
                            UrunleriYukle();
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            MessageBox.Show("Silme hatası: " + ex.Message);
                        }
                    }
                }
            }
        }


        private void dgvYIUrunlerGuncelle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvYIUrunlerGuncelle.Rows[e.RowIndex];
                int urunId = Convert.ToInt32(row.Cells["id"].Value);
                bool kaynak = Convert.ToBoolean(row.Cells["kaynak"].Value);

                Form guncelleForm;

                if (kaynak)
                    guncelleForm = new StoktanUrunleriGuncelle(urunId, this);
                else
                    guncelleForm = new DisKaynakUrunGuncelle(urunId, this);

                guncelleForm.ShowDialog();


           
            }
        }
        
        
    }
}
