namespace Basoglu
{
    partial class YICihazlariGoster
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
            this.dgvServisler = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCihazlar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServisler)).BeginInit();
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
            this.dgvCihazlar.Location = new System.Drawing.Point(20, 20);
            this.dgvCihazlar.Margin = new System.Windows.Forms.Padding(20);
            this.dgvCihazlar.Name = "dgvCihazlar";
            this.dgvCihazlar.ReadOnly = true;
            this.dgvCihazlar.RowHeadersWidth = 51;
            this.dgvCihazlar.RowTemplate.Height = 24;
            this.dgvCihazlar.Size = new System.Drawing.Size(301, 442);
            this.dgvCihazlar.TabIndex = 0;
            this.dgvCihazlar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCihazlar_CellContentClick);
            this.dgvCihazlar.SelectionChanged += new System.EventHandler(this.dgvCihazlar_SelectionChanged);
            // 
            // dgvServisler
            // 
            this.dgvServisler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvServisler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvServisler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServisler.Location = new System.Drawing.Point(361, 20);
            this.dgvServisler.Margin = new System.Windows.Forms.Padding(20);
            this.dgvServisler.Name = "dgvServisler";
            this.dgvServisler.RowHeadersWidth = 51;
            this.dgvServisler.RowTemplate.Height = 24;
            this.dgvServisler.Size = new System.Drawing.Size(301, 442);
            this.dgvServisler.TabIndex = 1;
            this.dgvServisler.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServisler_CellContentClick);
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
            this.tableLayoutPanel1.Controls.Add(this.dgvServisler, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(46, 36);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(682, 482);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // YICihazlariGoster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "YICihazlariGoster";
            this.Text = "CihazlarıGoster";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCihazlar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServisler)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCihazlar;
        private System.Windows.Forms.DataGridView dgvServisler;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}