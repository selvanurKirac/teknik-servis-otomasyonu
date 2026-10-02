namespace Basoglu
{
    partial class Login
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnVeriTabani = new System.Windows.Forms.Button();
            this.lblSifre = new System.Windows.Forms.Label();
            this.lblKullaniciAdi = new System.Windows.Forms.Label();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtKullaniciAdi = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // btnVeriTabani
            // 
            this.btnVeriTabani.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVeriTabani.Location = new System.Drawing.Point(505, 489);
            this.btnVeriTabani.Name = "btnVeriTabani";
            this.btnVeriTabani.Size = new System.Drawing.Size(237, 36);
            this.btnVeriTabani.TabIndex = 7;
            this.btnVeriTabani.Text = "Veri Tabanı Ayarlarına Gir";
            this.btnVeriTabani.UseVisualStyleBackColor = true;
            this.btnVeriTabani.Click += new System.EventHandler(this.btnVeriTabani_Click);
            // 
            // lblSifre
            // 
            this.lblSifre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSifre.AutoSize = true;
            this.lblSifre.Location = new System.Drawing.Point(50, 222);
            this.lblSifre.Margin = new System.Windows.Forms.Padding(50);
            this.lblSifre.Name = "lblSifre";
            this.lblSifre.Size = new System.Drawing.Size(250, 16);
            this.lblSifre.TabIndex = 12;
            this.lblSifre.Text = "Şifre:";
            // 
            // lblKullaniciAdi
            // 
            this.lblKullaniciAdi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKullaniciAdi.AutoSize = true;
            this.lblKullaniciAdi.Location = new System.Drawing.Point(50, 50);
            this.lblKullaniciAdi.Margin = new System.Windows.Forms.Padding(50);
            this.lblKullaniciAdi.Name = "lblKullaniciAdi";
            this.lblKullaniciAdi.Size = new System.Drawing.Size(250, 16);
            this.lblKullaniciAdi.TabIndex = 11;
            this.lblKullaniciAdi.Text = "Kullanıcı Adı:";
            // 
            // txtSifre
            // 
            this.txtSifre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSifre.Location = new System.Drawing.Point(400, 222);
            this.txtSifre.Margin = new System.Windows.Forms.Padding(50);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Size = new System.Drawing.Size(250, 22);
            this.txtSifre.TabIndex = 10;
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnLogin.Location = new System.Drawing.Point(310, 403);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(161, 58);
            this.btnLogin.TabIndex = 9;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKullaniciAdi.Location = new System.Drawing.Point(400, 50);
            this.txtKullaniciAdi.Margin = new System.Windows.Forms.Padding(50);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(250, 22);
            this.txtKullaniciAdi.TabIndex = 8;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblKullaniciAdi, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblSifre, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtSifre, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtKullaniciAdi, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(42, 32);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(700, 344);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnVeriTabani);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Login";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btnVeriTabani;
        private System.Windows.Forms.Label lblSifre;
        private System.Windows.Forms.Label lblKullaniciAdi;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtKullaniciAdi;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}