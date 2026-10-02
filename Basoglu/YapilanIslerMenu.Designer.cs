namespace Basoglu
{
    partial class YapilanIslerMenu
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
            this.btnYapilanIslerEkle = new System.Windows.Forms.Button();
            this.btnYapılanIsleriGuncelle = new System.Windows.Forms.Button();
            this.btnYapilanIsleriGoster = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnYapilanIslerEkle
            // 
            this.btnYapilanIslerEkle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYapilanIslerEkle.Location = new System.Drawing.Point(50, 150);
            this.btnYapilanIslerEkle.Margin = new System.Windows.Forms.Padding(50, 150, 50, 150);
            this.btnYapilanIslerEkle.Name = "btnYapilanIslerEkle";
            this.btnYapilanIslerEkle.Size = new System.Drawing.Size(132, 131);
            this.btnYapilanIslerEkle.TabIndex = 0;
            this.btnYapilanIslerEkle.Text = "Yapılan İşlere Ekle";
            this.btnYapilanIslerEkle.UseVisualStyleBackColor = true;
            this.btnYapilanIslerEkle.Click += new System.EventHandler(this.btnYapilanIslerEkle_Click);
            // 
            // btnYapılanIsleriGuncelle
            // 
            this.btnYapılanIsleriGuncelle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYapılanIsleriGuncelle.Location = new System.Drawing.Point(282, 150);
            this.btnYapılanIsleriGuncelle.Margin = new System.Windows.Forms.Padding(50, 150, 50, 150);
            this.btnYapılanIsleriGuncelle.Name = "btnYapılanIsleriGuncelle";
            this.btnYapılanIsleriGuncelle.Size = new System.Drawing.Size(132, 131);
            this.btnYapılanIsleriGuncelle.TabIndex = 1;
            this.btnYapılanIsleriGuncelle.Text = "Yapılan İşleri Güncelle";
            this.btnYapılanIsleriGuncelle.UseVisualStyleBackColor = true;
            this.btnYapılanIsleriGuncelle.Click += new System.EventHandler(this.btnYapılanIsleriGuncelle_Click);
            // 
            // btnYapilanIsleriGoster
            // 
            this.btnYapilanIsleriGoster.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYapilanIsleriGoster.Location = new System.Drawing.Point(514, 150);
            this.btnYapilanIsleriGoster.Margin = new System.Windows.Forms.Padding(50, 150, 50, 150);
            this.btnYapilanIsleriGoster.Name = "btnYapilanIsleriGoster";
            this.btnYapilanIsleriGoster.Size = new System.Drawing.Size(133, 131);
            this.btnYapilanIsleriGoster.TabIndex = 3;
            this.btnYapilanIsleriGoster.Text = "Yapılan İşleri Göster";
            this.btnYapilanIsleriGoster.UseVisualStyleBackColor = true;
            this.btnYapilanIsleriGoster.Click += new System.EventHandler(this.btnYapilanIsleriGoster_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.btnYapilanIsleriGoster, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnYapilanIslerEkle, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnYapılanIsleriGuncelle, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(39, 55);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(697, 431);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // YapilanIslerMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "YapilanIslerMenu";
            this.Text = "YapılanIslerMenu";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnYapilanIslerEkle;
        private System.Windows.Forms.Button btnYapılanIsleriGuncelle;
        private System.Windows.Forms.Button btnYapilanIsleriGoster;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}