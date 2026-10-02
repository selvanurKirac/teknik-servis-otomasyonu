namespace Basoglu
{
    partial class Firma
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
            this.btnFirmaEkle = new System.Windows.Forms.Button();
            this.btnFirmaGüncelle = new System.Windows.Forms.Button();
            this.panelFirma = new System.Windows.Forms.Panel();
            this.btnFirmaGoruntule = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFirmaEkle
            // 
            this.btnFirmaEkle.Location = new System.Drawing.Point(10, 50);
            this.btnFirmaEkle.Margin = new System.Windows.Forms.Padding(10, 50, 10, 10);
            this.btnFirmaEkle.Name = "btnFirmaEkle";
            this.btnFirmaEkle.Size = new System.Drawing.Size(81, 53);
            this.btnFirmaEkle.TabIndex = 0;
            this.btnFirmaEkle.Text = "Firma Ekle";
            this.btnFirmaEkle.UseVisualStyleBackColor = true;
            this.btnFirmaEkle.Click += new System.EventHandler(this.btnFirmaEkle_Click);
            // 
            // btnFirmaGüncelle
            // 
            this.btnFirmaGüncelle.Location = new System.Drawing.Point(10, 216);
            this.btnFirmaGüncelle.Margin = new System.Windows.Forms.Padding(10, 50, 10, 10);
            this.btnFirmaGüncelle.Name = "btnFirmaGüncelle";
            this.btnFirmaGüncelle.Size = new System.Drawing.Size(81, 49);
            this.btnFirmaGüncelle.TabIndex = 1;
            this.btnFirmaGüncelle.Text = "Firma Güncelle";
            this.btnFirmaGüncelle.UseVisualStyleBackColor = true;
            this.btnFirmaGüncelle.Click += new System.EventHandler(this.btnFirmaGüncelle_Click);
            // 
            // panelFirma
            // 
            this.panelFirma.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFirma.Location = new System.Drawing.Point(123, 3);
            this.panelFirma.Name = "panelFirma";
            this.panelFirma.Size = new System.Drawing.Size(569, 500);
            this.panelFirma.TabIndex = 2;
            // 
            // btnFirmaGoruntule
            // 
            this.btnFirmaGoruntule.Location = new System.Drawing.Point(10, 382);
            this.btnFirmaGoruntule.Margin = new System.Windows.Forms.Padding(10, 50, 10, 10);
            this.btnFirmaGoruntule.Name = "btnFirmaGoruntule";
            this.btnFirmaGoruntule.Size = new System.Drawing.Size(81, 49);
            this.btnFirmaGoruntule.TabIndex = 3;
            this.btnFirmaGoruntule.Text = "Firma Görüntüle";
            this.btnFirmaGoruntule.UseVisualStyleBackColor = true;
            this.btnFirmaGoruntule.Click += new System.EventHandler(this.btnFirmaGoruntule_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.26619F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82.73381F));
            this.tableLayoutPanel1.Controls.Add(this.panelFirma, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(43, 23);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(695, 506);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.btnFirmaEkle, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnFirmaGoruntule, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnFirmaGüncelle, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(114, 500);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // Firma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Firma";
            this.Text = "Firma";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFirmaEkle;
        private System.Windows.Forms.Button btnFirmaGüncelle;
        private System.Windows.Forms.Panel panelFirma;
        private System.Windows.Forms.Button btnFirmaGoruntule;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}