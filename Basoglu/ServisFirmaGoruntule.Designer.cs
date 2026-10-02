namespace Basoglu
{
    partial class ServisFirmaGoruntule
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
            this.dgvFirmalar = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFirmalar)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFirmalar
            // 
            this.dgvFirmalar.AllowUserToAddRows = false;
            this.dgvFirmalar.AllowUserToDeleteRows = false;
            this.dgvFirmalar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFirmalar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFirmalar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFirmalar.Location = new System.Drawing.Point(46, 27);
            this.dgvFirmalar.Name = "dgvFirmalar";
            this.dgvFirmalar.ReadOnly = true;
            this.dgvFirmalar.RowHeadersWidth = 51;
            this.dgvFirmalar.RowTemplate.Height = 24;
            this.dgvFirmalar.Size = new System.Drawing.Size(690, 491);
            this.dgvFirmalar.TabIndex = 1;
            // 
            // ServisFirmaGoruntule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.dgvFirmalar);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "ServisFirmaGoruntule";
            this.Text = "ServisFirmaGoruntule";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFirmalar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFirmalar;
    }
}