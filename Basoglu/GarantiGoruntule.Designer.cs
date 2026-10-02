namespace Basoglu
{
    partial class GarantiGoruntule
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
            this.dgvGaranti = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGaranti)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvGaranti
            // 
            this.dgvGaranti.AllowUserToAddRows = false;
            this.dgvGaranti.AllowUserToDeleteRows = false;
            this.dgvGaranti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGaranti.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGaranti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGaranti.Location = new System.Drawing.Point(25, 37);
            this.dgvGaranti.Name = "dgvGaranti";
            this.dgvGaranti.ReadOnly = true;
            this.dgvGaranti.RowHeadersWidth = 51;
            this.dgvGaranti.RowTemplate.Height = 24;
            this.dgvGaranti.Size = new System.Drawing.Size(727, 485);
            this.dgvGaranti.TabIndex = 0;
            // 
            // GarantiGoruntule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.dgvGaranti);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "GarantiGoruntule";
            this.Text = "GarantiGoruntule";
            ((System.ComponentModel.ISupportInitialize)(this.dgvGaranti)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGaranti;
    }
}