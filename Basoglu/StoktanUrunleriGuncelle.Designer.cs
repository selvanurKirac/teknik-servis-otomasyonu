namespace Basoglu
{
    partial class StoktanUrunleriGuncelle
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
            this.btnStoktanUrunGuncelle = new System.Windows.Forms.Button();
            this.txtStok = new System.Windows.Forms.TextBox();
            this.lblMiktar = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStoktanUrunGuncelle
            // 
            this.btnStoktanUrunGuncelle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStoktanUrunGuncelle.Location = new System.Drawing.Point(300, 384);
            this.btnStoktanUrunGuncelle.Name = "btnStoktanUrunGuncelle";
            this.btnStoktanUrunGuncelle.Size = new System.Drawing.Size(115, 61);
            this.btnStoktanUrunGuncelle.TabIndex = 31;
            this.btnStoktanUrunGuncelle.Text = "Güncelle";
            this.btnStoktanUrunGuncelle.UseVisualStyleBackColor = true;
            this.btnStoktanUrunGuncelle.Click += new System.EventHandler(this.btnStoktanUrunGuncelle_Click);
            // 
            // txtStok
            // 
            this.txtStok.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStok.Location = new System.Drawing.Point(231, 100);
            this.txtStok.Margin = new System.Windows.Forms.Padding(50, 100, 50, 100);
            this.txtStok.Name = "txtStok";
            this.txtStok.Size = new System.Drawing.Size(394, 22);
            this.txtStok.TabIndex = 30;
            // 
            // lblMiktar
            // 
            this.lblMiktar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMiktar.AutoSize = true;
            this.lblMiktar.Location = new System.Drawing.Point(50, 100);
            this.lblMiktar.Margin = new System.Windows.Forms.Padding(50, 100, 50, 100);
            this.lblMiktar.Name = "lblMiktar";
            this.lblMiktar.Size = new System.Drawing.Size(81, 38);
            this.lblMiktar.TabIndex = 29;
            this.lblMiktar.Text = "Miktar:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.81482F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.18519F));
            this.tableLayoutPanel1.Controls.Add(this.lblMiktar, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtStok, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(60, 106);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(675, 238);
            this.tableLayoutPanel1.TabIndex = 32;
            // 
            // StoktanUrunleriGuncelle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnStoktanUrunGuncelle);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "StoktanUrunleriGuncelle";
            this.Text = "StoktanUrunleriGuncelle";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStoktanUrunGuncelle;
        private System.Windows.Forms.TextBox txtStok;
        private System.Windows.Forms.Label lblMiktar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}