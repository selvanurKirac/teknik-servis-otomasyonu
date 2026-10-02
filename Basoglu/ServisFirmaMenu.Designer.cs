namespace Basoglu
{
    partial class ServisFirmaMenu
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
            this.btnFirmaGoruntule = new System.Windows.Forms.Button();
            this.btnFirmaGüncelle = new System.Windows.Forms.Button();
            this.btnFirmaEkle = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFirmaGoruntule
            // 
            this.btnFirmaGoruntule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFirmaGoruntule.Location = new System.Drawing.Point(500, 150);
            this.btnFirmaGoruntule.Margin = new System.Windows.Forms.Padding(50, 150, 50, 150);
            this.btnFirmaGoruntule.Name = "btnFirmaGoruntule";
            this.btnFirmaGoruntule.Size = new System.Drawing.Size(126, 105);
            this.btnFirmaGoruntule.TabIndex = 7;
            this.btnFirmaGoruntule.Text = "Firma Görüntüle";
            this.btnFirmaGoruntule.UseVisualStyleBackColor = true;
            this.btnFirmaGoruntule.Click += new System.EventHandler(this.btnFirmaGoruntule_Click);
            // 
            // btnFirmaGüncelle
            // 
            this.btnFirmaGüncelle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFirmaGüncelle.Location = new System.Drawing.Point(275, 150);
            this.btnFirmaGüncelle.Margin = new System.Windows.Forms.Padding(50, 150, 50, 150);
            this.btnFirmaGüncelle.Name = "btnFirmaGüncelle";
            this.btnFirmaGüncelle.Size = new System.Drawing.Size(125, 105);
            this.btnFirmaGüncelle.TabIndex = 5;
            this.btnFirmaGüncelle.Text = "Firma Güncelle";
            this.btnFirmaGüncelle.UseVisualStyleBackColor = true;
            this.btnFirmaGüncelle.Click += new System.EventHandler(this.btnFirmaGüncelle_Click);
            // 
            // btnFirmaEkle
            // 
            this.btnFirmaEkle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFirmaEkle.Location = new System.Drawing.Point(50, 150);
            this.btnFirmaEkle.Margin = new System.Windows.Forms.Padding(50, 150, 50, 150);
            this.btnFirmaEkle.Name = "btnFirmaEkle";
            this.btnFirmaEkle.Size = new System.Drawing.Size(125, 105);
            this.btnFirmaEkle.TabIndex = 4;
            this.btnFirmaEkle.Text = "Firma Ekle";
            this.btnFirmaEkle.UseVisualStyleBackColor = true;
            this.btnFirmaEkle.Click += new System.EventHandler(this.btnFirmaEkle_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.btnFirmaEkle, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnFirmaGoruntule, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnFirmaGüncelle, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(59, 80);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(676, 405);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // ServisFirmaMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "ServisFirmaMenu";
            this.Text = "ServisFirmaMenu";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFirmaGoruntule;
        private System.Windows.Forms.Button btnFirmaGüncelle;
        private System.Windows.Forms.Button btnFirmaEkle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}