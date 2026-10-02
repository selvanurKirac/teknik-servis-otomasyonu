namespace Basoglu
{
    partial class YIStoktanUrunEkle
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
            this.txtModel = new System.Windows.Forms.TextBox();
            this.txtUrunIsmi = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnUrunlereEkle = new System.Windows.Forms.Button();
            this.txtSeriNumarasi = new System.Windows.Forms.TextBox();
            this.lblSeriNo = new System.Windows.Forms.Label();
            this.txtStok = new System.Windows.Forms.TextBox();
            this.lblStok = new System.Windows.Forms.Label();
            this.lblUrunIsmi = new System.Windows.Forms.Label();
            this.lblModel = new System.Windows.Forms.Label();
            this.btnAra = new System.Windows.Forms.Button();
            this.btnYeniUrun = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtModel
            // 
            this.txtModel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtModel.Location = new System.Drawing.Point(134, 117);
            this.txtModel.Margin = new System.Windows.Forms.Padding(20);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(206, 22);
            this.txtModel.TabIndex = 31;
            // 
            // txtUrunIsmi
            // 
            this.txtUrunIsmi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUrunIsmi.Location = new System.Drawing.Point(134, 20);
            this.txtUrunIsmi.Margin = new System.Windows.Forms.Padding(20);
            this.txtUrunIsmi.Name = "txtUrunIsmi";
            this.txtUrunIsmi.Size = new System.Drawing.Size(206, 22);
            this.txtUrunIsmi.TabIndex = 30;
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
            this.dataGridView1.Location = new System.Drawing.Point(369, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(360, 391);
            this.dataGridView1.TabIndex = 29;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // btnUrunlereEkle
            // 
            this.btnUrunlereEkle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUrunlereEkle.Location = new System.Drawing.Point(396, 427);
            this.btnUrunlereEkle.Margin = new System.Windows.Forms.Padding(30);
            this.btnUrunlereEkle.Name = "btnUrunlereEkle";
            this.btnUrunlereEkle.Size = new System.Drawing.Size(306, 30);
            this.btnUrunlereEkle.TabIndex = 28;
            this.btnUrunlereEkle.Text = "Urunlere Ekle";
            this.btnUrunlereEkle.UseVisualStyleBackColor = true;
            this.btnUrunlereEkle.Click += new System.EventHandler(this.btnUrunlereEkle_Click);
            // 
            // txtSeriNumarasi
            // 
            this.txtSeriNumarasi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSeriNumarasi.Location = new System.Drawing.Point(134, 214);
            this.txtSeriNumarasi.Margin = new System.Windows.Forms.Padding(20);
            this.txtSeriNumarasi.Name = "txtSeriNumarasi";
            this.txtSeriNumarasi.Size = new System.Drawing.Size(206, 22);
            this.txtSeriNumarasi.TabIndex = 27;
            // 
            // lblSeriNo
            // 
            this.lblSeriNo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSeriNo.AutoSize = true;
            this.lblSeriNo.Location = new System.Drawing.Point(20, 214);
            this.lblSeriNo.Margin = new System.Windows.Forms.Padding(20);
            this.lblSeriNo.Name = "lblSeriNo";
            this.lblSeriNo.Size = new System.Drawing.Size(74, 57);
            this.lblSeriNo.TabIndex = 26;
            this.lblSeriNo.Text = "Seri Numarası:";
            // 
            // txtStok
            // 
            this.txtStok.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStok.Location = new System.Drawing.Point(200, 20);
            this.txtStok.Margin = new System.Windows.Forms.Padding(20);
            this.txtStok.Name = "txtStok";
            this.txtStok.Size = new System.Drawing.Size(140, 22);
            this.txtStok.TabIndex = 25;
            // 
            // lblStok
            // 
            this.lblStok.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStok.AutoSize = true;
            this.lblStok.Location = new System.Drawing.Point(20, 20);
            this.lblStok.Margin = new System.Windows.Forms.Padding(20);
            this.lblStok.Name = "lblStok";
            this.lblStok.Size = new System.Drawing.Size(140, 44);
            this.lblStok.TabIndex = 24;
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
            this.lblUrunIsmi.Size = new System.Drawing.Size(74, 57);
            this.lblUrunIsmi.TabIndex = 23;
            this.lblUrunIsmi.Text = "Ürün İsmi:";
            // 
            // lblModel
            // 
            this.lblModel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(20, 117);
            this.lblModel.Margin = new System.Windows.Forms.Padding(20);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(74, 57);
            this.lblModel.TabIndex = 22;
            this.lblModel.Text = "Model: ";
            // 
            // btnAra
            // 
            this.btnAra.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAra.Location = new System.Drawing.Point(134, 311);
            this.btnAra.Margin = new System.Windows.Forms.Padding(20);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(206, 60);
            this.btnAra.TabIndex = 33;
            this.btnAra.Text = "Search";
            this.btnAra.UseVisualStyleBackColor = true;
            // 
            // btnYeniUrun
            // 
            this.btnYeniUrun.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYeniUrun.Location = new System.Drawing.Point(20, 311);
            this.btnYeniUrun.Margin = new System.Windows.Forms.Padding(20);
            this.btnYeniUrun.Name = "btnYeniUrun";
            this.btnYeniUrun.Size = new System.Drawing.Size(74, 60);
            this.btnYeniUrun.TabIndex = 34;
            this.btnYeniUrun.Text = "Yeni Ürün";
            this.btnYeniUrun.UseVisualStyleBackColor = true;
            this.btnYeniUrun.Click += new System.EventHandler(this.btnYeniUrun_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.94444F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.05556F));
            this.tableLayoutPanel1.Controls.Add(this.lblUrunIsmi, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnYeniUrun, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnAra, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblModel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblSeriNo, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtUrunIsmi, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtSeriNumarasi, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtModel, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(360, 391);
            this.tableLayoutPanel1.TabIndex = 35;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnUrunlereEkle, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.dataGridView1, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(25, 33);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.51951F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.48049F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(732, 487);
            this.tableLayoutPanel2.TabIndex = 36;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.txtStok, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblStok, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 400);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(360, 84);
            this.tableLayoutPanel3.TabIndex = 37;
            // 
            // YIStoktanUrunEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.tableLayoutPanel2);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "YIStoktanUrunEkle";
            this.Text = "YIUrunEkle";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.TextBox txtUrunIsmi;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnUrunlereEkle;
        private System.Windows.Forms.TextBox txtSeriNumarasi;
        private System.Windows.Forms.Label lblSeriNo;
        private System.Windows.Forms.TextBox txtStok;
        private System.Windows.Forms.Label lblStok;
        private System.Windows.Forms.Label lblUrunIsmi;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.Button btnAra;
        private System.Windows.Forms.Button btnYeniUrun;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    }
}