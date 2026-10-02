namespace Basoglu
{
    partial class CihazTamirGuncelleMenu
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
            this.dgvCihazlar = new System.Windows.Forms.DataGridView();
            this.dgvServisFirmalari = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCihazlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServisFirmalari)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCihazlar
            // 
            this.dgvCihazlar.AllowUserToAddRows = false;
            this.dgvCihazlar.AllowUserToDeleteRows = false;
            this.dgvCihazlar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCihazlar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCihazlar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCihazlar.Location = new System.Drawing.Point(3, 3);
            this.dgvCihazlar.Name = "dgvCihazlar";
            this.dgvCihazlar.ReadOnly = true;
            this.dgvCihazlar.RowHeadersWidth = 51;
            this.dgvCihazlar.RowTemplate.Height = 24;
            this.dgvCihazlar.Size = new System.Drawing.Size(360, 503);
            this.dgvCihazlar.TabIndex = 1;
            // 
            // dgvServisFirmalari
            // 
            this.dgvServisFirmalari.AllowUserToAddRows = false;
            this.dgvServisFirmalari.AllowUserToDeleteRows = false;
            this.dgvServisFirmalari.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvServisFirmalari.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvServisFirmalari.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServisFirmalari.Location = new System.Drawing.Point(369, 3);
            this.dgvServisFirmalari.Name = "dgvServisFirmalari";
            this.dgvServisFirmalari.ReadOnly = true;
            this.dgvServisFirmalari.RowHeadersWidth = 51;
            this.dgvServisFirmalari.RowTemplate.Height = 24;
            this.dgvServisFirmalari.Size = new System.Drawing.Size(361, 503);
            this.dgvServisFirmalari.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dgvCihazlar, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvServisFirmalari, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(21, 21);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(733, 509);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // CihazTamirGuncelleMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "CihazTamirGuncelleMenu";
            this.Text = "CihazTamirGuncelleMenu";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCihazlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServisFirmalari)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCihazlar;
        private System.Windows.Forms.DataGridView dgvServisFirmalari;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}