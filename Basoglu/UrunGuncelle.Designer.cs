namespace Basoglu
{
    partial class UrunGuncelle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvUrunler = new System.Windows.Forms.DataGridView();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.txtSeriNo = new System.Windows.Forms.TextBox();
            this.lblSeriNo = new System.Windows.Forms.Label();
            this.txtMiktar = new System.Windows.Forms.TextBox();
            this.lblStok = new System.Windows.Forms.Label();
            this.lblUrunIsmi = new System.Windows.Forms.Label();
            this.lblModel = new System.Windows.Forms.Label();
            this.cmbUrunIsmi = new System.Windows.Forms.ComboBox();
            this.cmbModel = new System.Windows.Forms.ComboBox();
            this.btnAra = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUrunler)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvUrunler
            // 
            this.dgvUrunler.AllowUserToAddRows = false;
            this.dgvUrunler.AllowUserToDeleteRows = false;
            this.dgvUrunler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUrunler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUrunler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUrunler.Location = new System.Drawing.Point(330, 3);
            this.dgvUrunler.Name = "dgvUrunler";
            this.dgvUrunler.ReadOnly = true;
            this.dgvUrunler.RowHeadersWidth = 51;
            this.dgvUrunler.RowTemplate.Height = 24;
            this.dgvUrunler.Size = new System.Drawing.Size(402, 483);
            this.dgvUrunler.TabIndex = 19;
            this.dgvUrunler.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUrunler_CellClick);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuncelle.Location = new System.Drawing.Point(133, 404);
            this.btnGuncelle.Margin = new System.Windows.Forms.Padding(20);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(168, 59);
            this.btnGuncelle.TabIndex = 18;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // txtSeriNo
            // 
            this.txtSeriNo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSeriNo.Location = new System.Drawing.Point(133, 212);
            this.txtSeriNo.Margin = new System.Windows.Forms.Padding(20);
            this.txtSeriNo.Name = "txtSeriNo";
            this.txtSeriNo.Size = new System.Drawing.Size(168, 22);
            this.txtSeriNo.TabIndex = 17;
            // 
            // lblSeriNo
            // 
            this.lblSeriNo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSeriNo.AutoSize = true;
            this.lblSeriNo.Location = new System.Drawing.Point(20, 212);
            this.lblSeriNo.Margin = new System.Windows.Forms.Padding(20);
            this.lblSeriNo.Name = "lblSeriNo";
            this.lblSeriNo.Size = new System.Drawing.Size(73, 56);
            this.lblSeriNo.TabIndex = 16;
            this.lblSeriNo.Text = "Seri Numarası:";
            // 
            // txtMiktar
            // 
            this.txtMiktar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMiktar.Location = new System.Drawing.Point(133, 308);
            this.txtMiktar.Margin = new System.Windows.Forms.Padding(20);
            this.txtMiktar.Name = "txtMiktar";
            this.txtMiktar.Size = new System.Drawing.Size(168, 22);
            this.txtMiktar.TabIndex = 15;
            // 
            // lblStok
            // 
            this.lblStok.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStok.AutoSize = true;
            this.lblStok.Location = new System.Drawing.Point(20, 308);
            this.lblStok.Margin = new System.Windows.Forms.Padding(20);
            this.lblStok.Name = "lblStok";
            this.lblStok.Size = new System.Drawing.Size(73, 56);
            this.lblStok.TabIndex = 14;
            this.lblStok.Text = "Stok:";
            // 
            // lblUrunIsmi
            // 
            this.lblUrunIsmi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUrunIsmi.AutoSize = true;
            this.lblUrunIsmi.Location = new System.Drawing.Point(20, 20);
            this.lblUrunIsmi.Margin = new System.Windows.Forms.Padding(20);
            this.lblUrunIsmi.Name = "lblUrunIsmi";
            this.lblUrunIsmi.Size = new System.Drawing.Size(73, 56);
            this.lblUrunIsmi.TabIndex = 13;
            this.lblUrunIsmi.Text = "Ürün İsmi:";
            // 
            // lblModel
            // 
            this.lblModel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(20, 116);
            this.lblModel.Margin = new System.Windows.Forms.Padding(20);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(73, 56);
            this.lblModel.TabIndex = 12;
            this.lblModel.Text = "Model: ";
            // 
            // cmbUrunIsmi
            // 
            this.cmbUrunIsmi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbUrunIsmi.FormattingEnabled = true;
            this.cmbUrunIsmi.Location = new System.Drawing.Point(133, 20);
            this.cmbUrunIsmi.Margin = new System.Windows.Forms.Padding(20);
            this.cmbUrunIsmi.Name = "cmbUrunIsmi";
            this.cmbUrunIsmi.Size = new System.Drawing.Size(168, 24);
            this.cmbUrunIsmi.TabIndex = 22;
            // 
            // cmbModel
            // 
            this.cmbModel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbModel.FormattingEnabled = true;
            this.cmbModel.Location = new System.Drawing.Point(133, 116);
            this.cmbModel.Margin = new System.Windows.Forms.Padding(20);
            this.cmbModel.Name = "cmbModel";
            this.cmbModel.Size = new System.Drawing.Size(168, 24);
            this.cmbModel.TabIndex = 23;
            // 
            // btnAra
            // 
            this.btnAra.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAra.Location = new System.Drawing.Point(20, 404);
            this.btnAra.Margin = new System.Windows.Forms.Padding(20);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(73, 59);
            this.btnAra.TabIndex = 24;
            this.btnAra.Text = "Search";
            this.btnAra.UseVisualStyleBackColor = true;
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.45707F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.54294F));
            this.tableLayoutPanel1.Controls.Add(this.lblUrunIsmi, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnGuncelle, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnAra, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblModel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbModel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtMiktar, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtSeriNo, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblSeriNo, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmbUrunIsmi, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblStok, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(321, 483);
            this.tableLayoutPanel1.TabIndex = 25;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.4898F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.5102F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.dgvUrunler, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(27, 28);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(735, 489);
            this.tableLayoutPanel2.TabIndex = 26;
            // 
            // UrunGuncelle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.tableLayoutPanel2);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "UrunGuncelle";
            this.Text = "UrunGuncelle";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUrunler)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUrunler;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.TextBox txtSeriNo;
        private System.Windows.Forms.Label lblSeriNo;
        private System.Windows.Forms.TextBox txtMiktar;
        private System.Windows.Forms.Label lblStok;
        private System.Windows.Forms.Label lblUrunIsmi;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.ComboBox cmbUrunIsmi;
        private System.Windows.Forms.ComboBox cmbModel;
        private System.Windows.Forms.Button btnAra;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}