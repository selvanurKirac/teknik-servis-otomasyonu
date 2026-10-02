namespace Basoglu
{
    partial class TonerMenu
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
            this.btnTonerGuncelle = new System.Windows.Forms.Button();
            this.btnTonerEkle = new System.Windows.Forms.Button();
            this.btnTonerGoruntule = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTonerGuncelle
            // 
            this.btnTonerGuncelle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTonerGuncelle.Location = new System.Drawing.Point(526, 150);
            this.btnTonerGuncelle.Margin = new System.Windows.Forms.Padding(50, 150, 50, 150);
            this.btnTonerGuncelle.Name = "btnTonerGuncelle";
            this.btnTonerGuncelle.Size = new System.Drawing.Size(138, 143);
            this.btnTonerGuncelle.TabIndex = 6;
            this.btnTonerGuncelle.Text = "Toner Güncelle";
            this.btnTonerGuncelle.UseVisualStyleBackColor = true;
            this.btnTonerGuncelle.Click += new System.EventHandler(this.btnTonerGuncelle_Click);
            // 
            // btnTonerEkle
            // 
            this.btnTonerEkle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTonerEkle.Location = new System.Drawing.Point(50, 150);
            this.btnTonerEkle.Margin = new System.Windows.Forms.Padding(50, 150, 50, 150);
            this.btnTonerEkle.Name = "btnTonerEkle";
            this.btnTonerEkle.Size = new System.Drawing.Size(138, 143);
            this.btnTonerEkle.TabIndex = 5;
            this.btnTonerEkle.Text = "Toner Ekle";
            this.btnTonerEkle.UseVisualStyleBackColor = true;
            this.btnTonerEkle.Click += new System.EventHandler(this.btnTonerEkle_Click);
            // 
            // btnTonerGoruntule
            // 
            this.btnTonerGoruntule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTonerGoruntule.Location = new System.Drawing.Point(288, 150);
            this.btnTonerGoruntule.Margin = new System.Windows.Forms.Padding(50, 150, 50, 150);
            this.btnTonerGoruntule.Name = "btnTonerGoruntule";
            this.btnTonerGoruntule.Size = new System.Drawing.Size(138, 143);
            this.btnTonerGoruntule.TabIndex = 4;
            this.btnTonerGoruntule.Text = "Tonerleri Görüntüle";
            this.btnTonerGoruntule.UseVisualStyleBackColor = true;
            this.btnTonerGoruntule.Click += new System.EventHandler(this.btnTonerGoruntule_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.btnTonerEkle, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnTonerGuncelle, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnTonerGoruntule, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(32, 51);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(714, 443);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // TonerMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "TonerMenu";
            this.Text = "TonerMenu";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnTonerGuncelle;
        private System.Windows.Forms.Button btnTonerEkle;
        private System.Windows.Forms.Button btnTonerGoruntule;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}