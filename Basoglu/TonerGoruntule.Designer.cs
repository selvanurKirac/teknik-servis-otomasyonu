namespace Basoglu
{
    partial class TonerGoruntule
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
            this.dgvToner = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvToner)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvToner
            // 
            this.dgvToner.AllowUserToAddRows = false;
            this.dgvToner.AllowUserToDeleteRows = false;
            this.dgvToner.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvToner.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvToner.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvToner.Location = new System.Drawing.Point(41, 22);
            this.dgvToner.Name = "dgvToner";
            this.dgvToner.ReadOnly = true;
            this.dgvToner.RowHeadersWidth = 51;
            this.dgvToner.RowTemplate.Height = 24;
            this.dgvToner.Size = new System.Drawing.Size(700, 500);
            this.dgvToner.TabIndex = 0;
            // 
            // TonerGoruntule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.dgvToner);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "TonerGoruntule";
            this.Text = "TonerGoruntule";
            ((System.ComponentModel.ISupportInitialize)(this.dgvToner)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvToner;
    }
}