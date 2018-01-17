namespace TaseronTakip
{
    partial class YeniBankaGiris
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YeniBankaGiris));
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
            this.harcamakaydetbtn.Location = new System.Drawing.Point(66, 219);
            this.harcamakaydetbtn.Name = "harcamakaydetbtn";
            this.harcamakaydetbtn.Size = new System.Drawing.Size(162, 26);
            this.harcamakaydetbtn.TabIndex = 48;
            this.harcamakaydetbtn.Text = "Kaydet";
            this.harcamakaydetbtn.UseVisualStyleBackColor = true;
            this.harcamakaydetbtn.Click += new System.EventHandler(this.harcamakaydetbtn_Click);
            // 
            // Aciklama
            // 
            this.Aciklama.Location = new System.Drawing.Point(66, 34);
            this.Aciklama.MaxLength = 100;
            this.Aciklama.Name = "Aciklama";
            this.Aciklama.Size = new System.Drawing.Size(162, 126);
            this.Aciklama.TabIndex = 49;
            this.Aciklama.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1, 196);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 45;
            this.label7.Text = "Tutar";
            // 
            // Tutar
            // 
            this.Tutar.Location = new System.Drawing.Point(66, 193);
            this.Tutar.Name = "Tutar";
            this.Tutar.Size = new System.Drawing.Size(162, 20);
            this.Tutar.TabIndex = 41;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 44;
            this.label9.Text = "Açıklama";
            // 
            // harcamadate
            // 
            this.harcamadate.Location = new System.Drawing.Point(66, 166);
            this.harcamadate.Name = "harcamadate";
            this.harcamadate.Size = new System.Drawing.Size(162, 20);
            this.harcamadate.TabIndex = 47;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "Kasa Kodu";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1, 172);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 46;
            this.label10.Text = "Tarih";
            // 
            // YeniKasa
            // 
            this.YeniKasa.Location = new System.Drawing.Point(234, 5);
            this.YeniKasa.Name = "YeniKasa";
            this.YeniKasa.Size = new System.Drawing.Size(39, 23);
            this.YeniKasa.TabIndex = 53;
            this.YeniKasa.Text = "Yeni";
            this.YeniKasa.UseVisualStyleBackColor = true;
            this.YeniKasa.Click += new System.EventHandler(this.YeniKasa_Click);
            // 
            // Giderkasacombo
            // 
            this.Giderkasacombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Giderkasacombo.FormattingEnabled = true;
            this.Giderkasacombo.Location = new System.Drawing.Point(66, 7);
            this.Giderkasacombo.Name = "Giderkasacombo";
            this.Giderkasacombo.Size = new System.Drawing.Size(162, 21);
            this.Giderkasacombo.TabIndex = 52;
            // 
            // YeniBankaGiris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(274, 257);
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
            this.Name = "YeniBankaGiris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yeni Banka Giriş";
            this.Load += new System.EventHandler(this.YeniBankaGiris_Load);
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