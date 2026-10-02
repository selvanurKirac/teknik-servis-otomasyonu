namespace Basoglu
{
    partial class YIUrunleriGuncelleMenu
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
            this.dgvYIUrunlerGuncelle = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvYIUrunlerGuncelle)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvYIUrunlerGuncelle
            // 
            this.dgvYIUrunlerGuncelle.AllowUserToAddRows = false;
            this.dgvYIUrunlerGuncelle.AllowUserToDeleteRows = false;
            this.dgvYIUrunlerGuncelle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvYIUrunlerGuncelle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvYIUrunlerGuncelle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvYIUrunlerGuncelle.Location = new System.Drawing.Point(32, 29);
            this.dgvYIUrunlerGuncelle.Name = "dgvYIUrunlerGuncelle";
            this.dgvYIUrunlerGuncelle.ReadOnly = true;
            this.dgvYIUrunlerGuncelle.RowHeadersWidth = 51;
            this.dgvYIUrunlerGuncelle.RowTemplate.Height = 24;
            this.dgvYIUrunlerGuncelle.Size = new System.Drawing.Size(715, 502);
            this.dgvYIUrunlerGuncelle.TabIndex = 0;
            // 
            // YIUrunleriGuncelleMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.dgvYIUrunlerGuncelle);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "YIUrunleriGuncelleMenu";
            this.Text = "YIUrunleriGuncelleMenu";
            ((System.ComponentModel.ISupportInitialize)(this.dgvYIUrunlerGuncelle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvYIUrunlerGuncelle;
    }
}