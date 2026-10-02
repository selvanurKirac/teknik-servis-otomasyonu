namespace Basoglu
{
    partial class Urunler
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
            this.btnUrunEkle = new System.Windows.Forms.Button();
            this.btnUrunGuncelle = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnUrunGoruntule = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUrunEkle
            // 
            this.btnUrunEkle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUrunEkle.Location = new System.Drawing.Point(50, 150);
            this.btnUrunEkle.Margin = new System.Windows.Forms.Padding(50, 150, 50, 150);
            this.btnUrunEkle.Name = "btnUrunEkle";
            this.btnUrunEkle.Size = new System.Drawing.Size(117, 124);
            this.btnUrunEkle.TabIndex = 0;
            this.btnUrunEkle.Text = "Ürün Ekle";
            this.btnUrunEkle.UseVisualStyleBackColor = true;
            this.btnUrunEkle.Click += new System.EventHandler(this.btnUrunEkle_Click);
            // 
            // btnUrunGuncelle
            // 
            this.btnUrunGuncelle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUrunGuncelle.Location = new System.Drawing.Point(484, 150);
            this.btnUrunGuncelle.Margin = new System.Windows.Forms.Padding(50, 150, 50, 150);
            this.btnUrunGuncelle.Name = "btnUrunGuncelle";
            this.btnUrunGuncelle.Size = new System.Drawing.Size(117, 124);
            this.btnUrunGuncelle.TabIndex = 1;
            this.btnUrunGuncelle.Text = "Ürün Güncelle";
            this.btnUrunGuncelle.UseVisualStyleBackColor = true;
            this.btnUrunGuncelle.Click += new System.EventHandler(this.btnStokEkle_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.btnUrunGoruntule, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnUrunGuncelle, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnUrunEkle, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(59, 65);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(50, 150, 50, 150);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(651, 424);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // btnUrunGoruntule
            // 
            this.btnUrunGoruntule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUrunGoruntule.Location = new System.Drawing.Point(267, 150);
            this.btnUrunGoruntule.Margin = new System.Windows.Forms.Padding(50, 150, 50, 150);
            this.btnUrunGoruntule.Name = "btnUrunGoruntule";
            this.btnUrunGoruntule.Size = new System.Drawing.Size(117, 124);
            this.btnUrunGoruntule.TabIndex = 3;
            this.btnUrunGoruntule.Text = "Ürün Görüntüle";
            this.btnUrunGoruntule.UseVisualStyleBackColor = true;
            this.btnUrunGoruntule.Click += new System.EventHandler(this.btnUrunGoruntule_Click);
            // 
            // Urunler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Urunler";
            this.Text = "Urunler";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUrunEkle;
        private System.Windows.Forms.Button btnUrunGuncelle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnUrunGoruntule;
    }
}