namespace TaseronTakip
{
    partial class YeniNakitGiris
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YeniNakitGiris));
            this.harcamakaydetbtn = new System.Windows.Forms.Button();
            this.Aciklama = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Tutar = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.harcamadate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.YeniKasa = new System.Windows.Forms.Button();
            this.Giderkasacombo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // harcamakaydetbtn
            // 
            this.harcamakaydetbtn.Location = new System.Drawing.Point(71, 225);
            this.harcamakaydetbtn.Name = "harcamakaydetbtn";
            this.harcamakaydetbtn.Size = new System.Drawing.Size(162, 26);
            this.harcamakaydetbtn.TabIndex = 59;
            this.harcamakaydetbtn.Text = "Kaydet";
            this.harcamakaydetbtn.UseVisualStyleBackColor = true;
            this.harcamakaydetbtn.Click += new System.EventHandler(this.harcamakaydetbtn_Click);
            // 
            // Aciklama
            // 
            this.Aciklama.Location = new System.Drawing.Point(71, 40);
            this.Aciklama.MaxLength = 100;
            this.Aciklama.Name = "Aciklama";
            this.Aciklama.Size = new System.Drawing.Size(162, 126);
            this.Aciklama.TabIndex = 60;
            this.Aciklama.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 202);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 56;
            this.label7.Text = "Tutar";
            // 
            // Tutar
            // 
            this.Tutar.Location = new System.Drawing.Point(71, 199);
            this.Tutar.Name = "Tutar";
            this.Tutar.Size = new System.Drawing.Size(162, 20);
            this.Tutar.TabIndex = 54;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 55;
            this.label9.Text = "Açıklama";
            // 
            // harcamadate
            // 
            this.harcamadate.Location = new System.Drawing.Point(71, 172);
            this.harcamadate.Name = "harcamadate";
            this.harcamadate.Size = new System.Drawing.Size(162, 20);
            this.harcamadate.TabIndex = 58;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 61;
            this.label1.Text = "Kasa Kodu";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 178);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 57;
            this.label10.Text = "Tarih";
            // 
            // YeniKasa
            // 
            this.YeniKasa.Location = new System.Drawing.Point(239, 11);
            this.YeniKasa.Name = "YeniKasa";
            this.YeniKasa.Size = new System.Drawing.Size(39, 23);
            this.YeniKasa.TabIndex = 63;
            this.YeniKasa.Text = "Yeni";
            this.YeniKasa.UseVisualStyleBackColor = true;
            this.YeniKasa.Click += new System.EventHandler(this.YeniKasa_Click);
            // 
            // Giderkasacombo
            // 
            this.Giderkasacombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Giderkasacombo.FormattingEnabled = true;
            this.Giderkasacombo.Location = new System.Drawing.Point(71, 13);
            this.Giderkasacombo.Name = "Giderkasacombo";
            this.Giderkasacombo.Size = new System.Drawing.Size(162, 21);
            this.Giderkasacombo.TabIndex = 62;
            // 
            // YeniNakitGiris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.harcamakaydetbtn);
            this.Controls.Add(this.Aciklama);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Tutar);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.harcamadate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.YeniKasa);
            this.Controls.Add(this.Giderkasacombo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "YeniNakitGiris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yeni Nakit Giriş";
            this.Load += new System.EventHandler(this.YeniNakitGiris_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button harcamakaydetbtn;
        private System.Windows.Forms.RichTextBox Aciklama;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Tutar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker harcamadate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button YeniKasa;
        private System.Windows.Forms.ComboBox Giderkasacombo;

    }
}