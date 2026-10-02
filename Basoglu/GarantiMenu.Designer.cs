namespace Basoglu
{
    partial class GarantiMenu
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnGarantiEkle = new System.Windows.Forms.Button();
            this.btnGarantiGoruntule = new System.Windows.Forms.Button();
            this.btnGarantiGuncelle = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.btnGarantiEkle, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnGarantiGoruntule, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnGarantiGuncelle, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(36, 38);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(700, 455);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnGarantiEkle
            // 
            this.btnGarantiEkle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGarantiEkle.Location = new System.Drawing.Point(283, 150);
            this.btnGarantiEkle.Margin = new System.Windows.Forms.Padding(50, 150, 50, 150);
            this.btnGarantiEkle.Name = "btnGarantiEkle";
            this.btnGarantiEkle.Size = new System.Drawing.Size(133, 155);
            this.btnGarantiEkle.TabIndex = 1;
            this.btnGarantiEkle.Text = "Garantiye Ekle";
            this.btnGarantiEkle.UseVisualStyleBackColor = true;
            this.btnGarantiEkle.Click += new System.EventHandler(this.btnGarantiEkle_Click);
            // 
            // btnGarantiGoruntule
            // 
            this.btnGarantiGoruntule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGarantiGoruntule.Location = new System.Drawing.Point(50, 150);
            this.btnGarantiGoruntule.Margin = new System.Windows.Forms.Padding(50, 150, 50, 150);
            this.btnGarantiGoruntule.Name = "btnGarantiGoruntule";
            this.btnGarantiGoruntule.Size = new System.Drawing.Size(133, 155);
            this.btnGarantiGoruntule.TabIndex = 0;
            this.btnGarantiGoruntule.Text = "Garantidekileri Görüntüle";
            this.btnGarantiGoruntule.UseVisualStyleBackColor = true;
            this.btnGarantiGoruntule.Click += new System.EventHandler(this.btnGarantiGoruntule_Click);
            // 
            // btnGarantiGuncelle
            // 
            this.btnGarantiGuncelle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGarantiGuncelle.Location = new System.Drawing.Point(516, 150);
            this.btnGarantiGuncelle.Margin = new System.Windows.Forms.Padding(50, 150, 50, 150);
            this.btnGarantiGuncelle.Name = "btnGarantiGuncelle";
            this.btnGarantiGuncelle.Size = new System.Drawing.Size(134, 155);
            this.btnGarantiGuncelle.TabIndex = 2;
            this.btnGarantiGuncelle.Text = "Garantidekileri Güncelle";
            this.btnGarantiGuncelle.UseVisualStyleBackColor = true;
            this.btnGarantiGuncelle.Click += new System.EventHandler(this.btnGarantiGuncelle_Click);
            // 
            // GarantiMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "GarantiMenu";
            this.Text = "GarantiMenu";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnGarantiGoruntule;
        private System.Windows.Forms.Button btnGarantiGuncelle;
        private System.Windows.Forms.Button btnGarantiEkle;
    }
}