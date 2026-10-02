namespace Basoglu
{
    partial class UrunEkle
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.txtSeriNumarasi = new System.Windows.Forms.TextBox();
            this.lblSeriNo = new System.Windows.Forms.Label();
            this.txtStok = new System.Windows.Forms.TextBox();
            this.lblStok = new System.Windows.Forms.Label();
            this.lblUrunIsmi = new System.Windows.Forms.Label();
            this.lblModel = new System.Windows.Forms.Label();
            this.txtUrunIsmi = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(364, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(355, 396);
            this.dataGridView1.TabIndex = 19;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKaydet.Location = new System.Drawing.Point(337, 476);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(115, 31);
            this.btnKaydet.TabIndex = 18;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // txtSeriNumarasi
            // 
            this.txtSeriNumarasi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSeriNumarasi.Location = new System.Drawing.Point(155, 218);
            this.txtSeriNumarasi.Margin = new System.Windows.Forms.Padding(20);
            this.txtSeriNumarasi.Name = "txtSeriNumarasi";
            this.txtSeriNumarasi.Size = new System.Drawing.Size(180, 22);
            this.txtSeriNumarasi.TabIndex = 17;
            // 
            // lblSeriNo
            // 
            this.lblSeriNo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSeriNo.AutoSize = true;
            this.lblSeriNo.Location = new System.Drawing.Point(20, 218);
            this.lblSeriNo.Margin = new System.Windows.Forms.Padding(20);
            this.lblSeriNo.Name = "lblSeriNo";
            this.lblSeriNo.Size = new System.Drawing.Size(95, 59);
            this.lblSeriNo.TabIndex = 16;
            this.lblSeriNo.Text = "Seri Numarası:";
            // 
            // txtStok
            // 
            this.txtStok.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStok.Location = new System.Drawing.Point(155, 317);
            this.txtStok.Margin = new System.Windows.Forms.Padding(20);
            this.txtStok.Name = "txtStok";
            this.txtStok.Size = new System.Drawing.Size(180, 22);
            this.txtStok.TabIndex = 15;
            // 
            // lblStok
            // 
            this.lblStok.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStok.AutoSize = true;
            this.lblStok.Location = new System.Drawing.Point(20, 317);
            this.lblStok.Margin = new System.Windows.Forms.Padding(20);
            this.lblStok.Name = "lblStok";
            this.lblStok.Size = new System.Drawing.Size(95, 59);
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
            this.lblUrunIsmi.Size = new System.Drawing.Size(95, 59);
            this.lblUrunIsmi.TabIndex = 13;
            this.lblUrunIsmi.Text = "Ürün İsmi:";
            // 
            // lblModel
            // 
            this.lblModel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(20, 119);
            this.lblModel.Margin = new System.Windows.Forms.Padding(20);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(95, 59);
            this.lblModel.TabIndex = 12;
            this.lblModel.Text = "Model: ";
            // 
            // txtUrunIsmi
            // 
            this.txtUrunIsmi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUrunIsmi.Location = new System.Drawing.Point(155, 20);
            this.txtUrunIsmi.Margin = new System.Windows.Forms.Padding(20);
            this.txtUrunIsmi.Name = "txtUrunIsmi";
            this.txtUrunIsmi.Size = new System.Drawing.Size(180, 22);
            this.txtUrunIsmi.TabIndex = 20;
            // 
            // txtModel
            // 
            this.txtModel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtModel.Location = new System.Drawing.Point(155, 119);
            this.txtModel.Margin = new System.Windows.Forms.Padding(20);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(180, 22);
            this.txtModel.TabIndex = 21;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.02817F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.97183F));
            this.tableLayoutPanel1.Controls.Add(this.lblUrunIsmi, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtModel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtStok, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtSeriNumarasi, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblModel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtUrunIsmi, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblSeriNo, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblStok, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(355, 396);
            this.tableLayoutPanel1.TabIndex = 22;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.dataGridView1, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(32, 35);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(722, 402);
            this.tableLayoutPanel2.TabIndex = 23;
            // 
            // UrunEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.btnKaydet);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "UrunEkle";
            this.Text = "UrunEkle";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.TextBox txtSeriNumarasi;
        private System.Windows.Forms.Label lblSeriNo;
        private System.Windows.Forms.TextBox txtStok;
        private System.Windows.Forms.Label lblStok;
        private System.Windows.Forms.Label lblUrunIsmi;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.TextBox txtUrunIsmi;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}