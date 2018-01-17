namespace TaseronTakip
{
    partial class NakitGirisGuncelle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NakitGirisGuncelle));
            this.harcamaAciklama = new System.Windows.Forms.RichTextBox();
            this.YeniKasa = new System.Windows.Forms.Button();
            this.Silbtn = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.harcamadate = new System.Windows.Forms.DateTimePicker();
            this.guncellebtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Giderkasacombo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.HarcamaTutar = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // harcamaAciklama
            // 
            this.harcamaAciklama.Location = new System.Drawing.Point(73, 30);
            this.harcamaAciklama.MaxLength = 100;
            this.harcamaAciklama.Name = "harcamaAciklama";
            this.harcamaAciklama.Size = new System.Drawing.Size(179, 76);
            this.harcamaAciklama.TabIndex = 8;
            this.harcamaAciklama.Text = "";
            // 
            // YeniKasa
            // 
            this.YeniKasa.Location = new System.Drawing.Point(213, 6);
            this.YeniKasa.Name = "YeniKasa";
            this.YeniKasa.Size = new System.Drawing.Size(39, 23);
            this.YeniKasa.TabIndex = 22;
            this.YeniKasa.Text = "Yeni";
            this.YeniKasa.UseVisualStyleBackColor = true;
            this.YeniKasa.Click += new System.EventHandler(this.YeniKasa_Click);
            // 
            // Silbtn
            // 
            this.Silbtn.Location = new System.Drawing.Point(166, 165);
            this.Silbtn.Name = "Silbtn";
            this.Silbtn.Size = new System.Drawing.Size(86, 26);
            this.Silbtn.TabIndex = 7;
            this.Silbtn.Text = "Sil";
            this.Silbtn.UseVisualStyleBackColor = true;
            this.Silbtn.Click += new System.EventHandler(this.Silbtn_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 118);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Tarih";
            // 
            // harcamadate
            // 
            this.harcamadate.Location = new System.Drawing.Point(73, 112);
            this.harcamadate.Name = "harcamadate";
            this.harcamadate.Size = new System.Drawing.Size(179, 20);
            this.harcamadate.TabIndex = 6;
            // 
            // guncellebtn
            // 
            this.guncellebtn.Location = new System.Drawing.Point(73, 165);
            this.guncellebtn.Name = "guncellebtn";
            this.guncellebtn.Size = new System.Drawing.Size(86, 26);
            this.guncellebtn.TabIndex = 7;
            this.guncellebtn.Text = "Güncelle";
            this.guncellebtn.UseVisualStyleBackColor = true;
            this.guncellebtn.Click += new System.EventHandler(this.guncellebtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Kasa Kodu";
            // 
            // Giderkasacombo
            // 
            this.Giderkasacombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Giderkasacombo.FormattingEnabled = true;
            this.Giderkasacombo.Location = new System.Drawing.Point(73, 6);
            this.Giderkasacombo.Name = "Giderkasacombo";
            this.Giderkasacombo.Size = new System.Drawing.Size(134, 21);
            this.Giderkasacombo.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Tutar";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Açıklama";
            // 
            // HarcamaTutar
            // 
            this.HarcamaTutar.Location = new System.Drawing.Point(73, 139);
            this.HarcamaTutar.Name = "HarcamaTutar";
            this.HarcamaTutar.Size = new System.Drawing.Size(179, 20);
            this.HarcamaTutar.TabIndex = 1;
            // 
            // NakitGirisGuncelle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(264, 197);
            this.Controls.Add(this.harcamaAciklama);
            this.Controls.Add(this.Silbtn);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.YeniKasa);
            this.Controls.Add(this.harcamadate);
            this.Controls.Add(this.guncellebtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Giderkasacombo);
            this.Controls.Add(this.HarcamaTutar);
            this.Controls.Add(this.label9);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "NakitGirisGuncelle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nakit Giriş Güncelle";
            this.Load += new System.EventHandler(this.NakitGirisGuncelle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox harcamaAciklama;
        private System.Windows.Forms.Button YeniKasa;
        private System.Windows.Forms.Button Silbtn;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker harcamadate;
        private System.Windows.Forms.Button guncellebtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Giderkasacombo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox HarcamaTutar;
    }
}