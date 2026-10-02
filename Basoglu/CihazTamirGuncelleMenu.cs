using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Basoglu
{
    public partial class CihazTamirGuncelleMenu : Form
    {
        private int yapilanIsId;
        private ContextMenuStrip contextMenuCihaz;
        private int clickedCihazRowIndex = -1;
        private ContextMenuStrip servisContextMenu;
        private int clickedServisRowIndex = -1;



        public CihazTamirGuncelleMenu(int yapilanIsId)
        {
            InitializeComponent();
            this.yapilanIsId = yapilanIsId;

            dgvCihazlar.CellDoubleClick += dgvCihazlar_CellDoubleClick;
            dgvServisFirmalari.CellDoubleClick += dgvServisFirmalari_CellDoubleClick;

            dgvCihazlar.CellMouseDown += dgvCihazlar_CellMouseDown;
            dgvCihazlar.ReadOnly = true;
            dgvCihazlar.AllowUserToAddRows = false;
            dgvCihazlar.AllowUserToDeleteRows = false;
            dgvCihazlar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCihazlar.MultiSelect = false;
            dgvServisFirmalari.ReadOnly = true;
            dgvServisFirmalari.AllowUserToAddRows = false;
            dgvServisFirmalari.AllowUserToDeleteRows = false;
            dgvServisFirmalari.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvServisFirmalari.MultiSelect = false;

            SetupCihazContextMenu();
            SetupContextMenuServis();

            CihazlariYukle();

        }

        public void CihazlariYukle()
        {
            try
            {
                string connStr = database.DbHelper.GetConnectionString();
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    // Sadece Cihaz_Tamir tablosunda bu Yapilan_is_id'ye ait olan cihazları getir
                    string query = @"
                SELECT * FROM YICihaz 
                WHERE id IN (
                    SELECT Cihaz_id 
                    FROM Cihaz_Tamir 
                    WHERE Yapilan_is_id = @id
                )";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@id", yapilanIsId);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvCihazlar.DataSource = dt;

                    if (dgvCihazlar.Columns.Contains("id"))
                        dgvCihazlar.Columns["id"].Visible = false;

                    dgvCihazlar.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cihazlar yüklenemedi: " + ex.Message);
            }
        }


        public void ServisFirmalariGetir(int cihazId)
        {
            try
            {
                string connStr = database.DbHelper.GetConnectionString();
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(@"
                SELECT 
                    ct.id, 
                    sf.Firma_ismi AS [Servis Firma], 
                    ct.Alim_tarihi AS [Alım Tarihi], 
                    ct.Teslim_tarihi AS [Teslim Tarihi]
                FROM 
                    Cihaz_Tamir ct
                JOIN 
                    Servis_Firma sf ON ct.Servis_firma_id = sf.id
                WHERE 
                    ct.Cihaz_id = @cihazId", conn);

                    da.SelectCommand.Parameters.AddWithValue("@cihazId", cihazId);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvServisFirmalari.DataSource = dt;

                    if (dgvServisFirmalari.Columns.Contains("id"))
                        dgvServisFirmalari.Columns["id"].Visible = false;

                    dgvServisFirmalari.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Servis firmaları yüklenemedi: " + ex.Message);
            }
        }

        private void dgvCihazlar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int cihazId = Convert.ToInt32(dgvCihazlar.Rows[e.RowIndex].Cells["id"].Value);

                // Orta grid: Servis firmalarını getir
                ServisFirmalariGetir(cihazId);
                Form form = new CihazTamirGuncelle(cihazId, this);
                form.ShowDialog();

                
            }
        }
        private void ServisSilItem_Click(object sender, EventArgs e)
        {
            if (clickedServisRowIndex >= 0 && clickedServisRowIndex < dgvServisFirmalari.Rows.Count)
            {
                int cihazTamirId = Convert.ToInt32(dgvServisFirmalari.Rows[clickedServisRowIndex].Cells["id"].Value);

                DialogResult result = MessageBox.Show("Seçili servis firmasını silmek istediğinize emin misiniz?",
                    "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    string connStr = database.DbHelper.GetConnectionString();
                    using (SqlConnection conn = new SqlConnection(connStr))
                    {
                        conn.Open();
                        SqlTransaction trans = conn.BeginTransaction();

                        try
                        {
                            // 1. Cihaz_id'yi alalım önce
                            SqlCommand getCihazIdCmd = new SqlCommand("SELECT Cihaz_id FROM Cihaz_Tamir WHERE id = @id", conn, trans);
                            getCihazIdCmd.Parameters.AddWithValue("@id", cihazTamirId);
                            int cihazId = Convert.ToInt32(getCihazIdCmd.ExecuteScalar());

                            // 2. Sil: Cihaz_Tamir tablosundan
                            SqlCommand deleteCmd = new SqlCommand("DELETE FROM Cihaz_Tamir WHERE id = @id", conn, trans);
                            deleteCmd.Parameters.AddWithValue("@id", cihazTamirId);
                            deleteCmd.ExecuteNonQuery();

                            // 3. Bu cihaz_id'ye sahip başka servis firması kaldı mı kontrol et
                            SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Cihaz_Tamir WHERE Cihaz_id = @cihazId", conn, trans);
                            checkCmd.Parameters.AddWithValue("@cihazId", cihazId);
                            int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                            if (count == 0)
                            {
                                // 4. YICihaz'dan da sil
                                SqlCommand cihazSil = new SqlCommand("DELETE FROM YICihaz WHERE id = @cihazId", conn, trans);
                                cihazSil.Parameters.AddWithValue("@cihazId", cihazId);
                                cihazSil.ExecuteNonQuery();

                                trans.Commit();

                                MessageBox.Show("Servis firması silindi. Cihaza ait başka servis firması kalmadığı için cihaz da silindi.");
                                CihazlariYukle();
                                dgvServisFirmalari.DataSource = null;
                                
                            }
                            else
                            {
                                trans.Commit();

                                MessageBox.Show("Servis firması silindi.");
                                ServisFirmalariGetir(cihazId);
                            }

                            clickedServisRowIndex = -1;
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            MessageBox.Show("Silme işlemi başarısız: " + ex.Message);
                        }
                    }
                }
            }
        }



        private void dgvServisFirmalari_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int cihazTamirId = Convert.ToInt32(dgvServisFirmalari.Rows[e.RowIndex].Cells["id"].Value);

                // Sağ panel: Servis firması bilgilerini düzenleme formu aç
                Form form = new CihazServisFirmaGuncelle(cihazTamirId, this);
                form.ShowDialog();
            }
        }

       
        private void SetupContextMenuServis()
        {
            servisContextMenu = new ContextMenuStrip();
            ToolStripMenuItem silItem = new ToolStripMenuItem("Seçili Servis Firmasını Sil");
            silItem.Click += ServisSilItem_Click;
            servisContextMenu.Items.Add(silItem);

            dgvServisFirmalari.CellMouseDown += dgvServisFirmalari_CellMouseDown;
        }
        private void dgvServisFirmalari_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                clickedServisRowIndex = e.RowIndex;
                dgvServisFirmalari.ClearSelection();
                dgvServisFirmalari.Rows[e.RowIndex].Selected = true;
                servisContextMenu.Show(Cursor.Position);
            }
        }









        private void dgvCihazlar_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                clickedCihazRowIndex = e.RowIndex;
                dgvCihazlar.ClearSelection();
                dgvCihazlar.Rows[e.RowIndex].Selected = true;
                contextMenuCihaz.Show(Cursor.Position);
            }
        }


        private void SetupCihazContextMenu()
        {
            contextMenuCihaz = new ContextMenuStrip();
            ToolStripMenuItem silMenuItem = new ToolStripMenuItem("Seçili Cihazı Sil");
            silMenuItem.Click += SilCihaz_Click;
            contextMenuCihaz.Items.Add(silMenuItem);
        }


        private void SilCihaz_Click(object sender, EventArgs e)
        {
            if (clickedCihazRowIndex < 0) return;

            int cihazId = Convert.ToInt32(dgvCihazlar.Rows[clickedCihazRowIndex].Cells["id"].Value);

            DialogResult dr = MessageBox.Show("Bu cihazı ve bağlı servis kayıtlarını silmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr != DialogResult.Yes) return;

            try
            {
                string connStr = database.DbHelper.GetConnectionString();
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction();

                    // 1. Cihaz_Tamir'den sil
                    SqlCommand silTamir = new SqlCommand("DELETE FROM Cihaz_Tamir WHERE Cihaz_id = @cihazId", conn, trans);
                    silTamir.Parameters.AddWithValue("@cihazId", cihazId);
                    silTamir.ExecuteNonQuery();

                    // 2. YICihaz'dan sil
                    SqlCommand silCihaz = new SqlCommand("DELETE FROM YICihaz WHERE id = @cihazId", conn, trans);
                    silCihaz.Parameters.AddWithValue("@cihazId", cihazId);
                    silCihaz.ExecuteNonQuery();

                    trans.Commit();
                    MessageBox.Show("Cihaz başarıyla silindi.");

                    CihazlariYukle(); // güncelle
                    dgvServisFirmalari.DataSource = null; // orta grid temizlenebilir
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }

            clickedCihazRowIndex = -1;
        }


    }
}
