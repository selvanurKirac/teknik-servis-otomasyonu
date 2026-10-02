namespace Basoglu
{
    partial class YIUrunEkleMenu
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
            this.checkBoxStoktanEkle = new System.Windows.Forms.CheckBox();
            this.panelUrun = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // checkBoxStoktanEkle
            // 
            this.checkBoxStoktanEkle.AutoSize = true;
            this.checkBoxStoktanEkle.Location = new System.Drawing.Point(54, 20);
            this.checkBoxStoktanEkle.Name = "checkBoxStoktanEkle";
            this.checkBoxStoktanEkle.Size = new System.Drawing.Size(104, 20);
            this.checkBoxStoktanEkle.TabIndex = 1;
            this.checkBoxStoktanEkle.Text = "Stoktan Ekle";
            this.checkBoxStoktanEkle.UseVisualStyleBackColor = true;
            this.checkBoxStoktanEkle.CheckedChanged += new System.EventHandler(this.checkBoxStoktanEkle_CheckedChanged);
            // 
            // panelUrun
            // 
            this.panelUrun.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelUrun.Location = new System.Drawing.Point(32, 64);
            this.panelUrun.Name = "panelUrun";
            this.panelUrun.Size = new System.Drawing.Size(711, 442);
            this.panelUrun.TabIndex = 2;
            // 
            // YIUrunEkleMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.panelUrun);
            this.Controls.Add(this.checkBoxStoktanEkle);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "YIUrunEkleMenu";
            this.Text = "YIUrunEkleMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxStoktanEkle;
        private System.Windows.Forms.Panel panelUrun;
    }
}