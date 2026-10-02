namespace Basoglu
{
    partial class YapılanIslerGuncelleMenu
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
            this.dgvYapilanIslerGuncelle = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvYapilanIslerGuncelle)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvYapilanIslerGuncelle
            // 
            this.dgvYapilanIslerGuncelle.AllowUserToAddRows = false;
            this.dgvYapilanIslerGuncelle.AllowUserToDeleteRows = false;
            this.dgvYapilanIslerGuncelle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvYapilanIslerGuncelle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvYapilanIslerGuncelle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvYapilanIslerGuncelle.Location = new System.Drawing.Point(22, 30);
            this.dgvYapilanIslerGuncelle.Name = "dgvYapilanIslerGuncelle";
            this.dgvYapilanIslerGuncelle.ReadOnly = true;
            this.dgvYapilanIslerGuncelle.RowHeadersWidth = 51;
            this.dgvYapilanIslerGuncelle.RowTemplate.Height = 24;
            this.dgvYapilanIslerGuncelle.Size = new System.Drawing.Size(736, 472);
            this.dgvYapilanIslerGuncelle.TabIndex = 0;
            this.dgvYapilanIslerGuncelle.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvYapilanIslerGuncelle_CellDoubleClick);
            // 
            // YapılanIslerGuncelleMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.dgvYapilanIslerGuncelle);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "YapılanIslerGuncelleMenu";
            this.Text = "YapılanIslerGuncelleMenu";
            ((System.ComponentModel.ISupportInitialize)(this.dgvYapilanIslerGuncelle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvYapilanIslerGuncelle;
    }
}