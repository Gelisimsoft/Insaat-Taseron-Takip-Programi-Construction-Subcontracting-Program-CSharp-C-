namespace TaseronTakip
{
    partial class YeniNakitCikis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YeniNakitCikis));
            this.harcamakaydetbtn = new System.Windows.Forms.Button();
            this.Aciklama = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Tutar = new System.Windows.Forms.TextBox();
            this.YeniPersonel = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.harcamadate = new System.Windows.Forms.DateTimePicker();
            this.turucombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.personelbl = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Turulbl = new System.Windows.Forms.Label();
            this.YeniKasa = new System.Windows.Forms.Button();
            this.Giderkasacombo = new System.Windows.Forms.ComboBox();
            this.personelcombo = new System.Windows.Forms.ComboBox();
            this.Caricombo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.YeniCaribtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // harcamakaydetbtn
            // 
            this.harcamakaydetbtn.Location = new System.Drawing.Point(71, 256);
            this.harcamakaydetbtn.Name = "harcamakaydetbtn";
            this.harcamakaydetbtn.Size = new System.Drawing.Size(162, 26);
            this.harcamakaydetbtn.TabIndex = 48;
            this.harcamakaydetbtn.Text = "Kaydet";
            this.harcamakaydetbtn.UseVisualStyleBackColor = true;
            this.harcamakaydetbtn.Click += new System.EventHandler(this.harcamakaydetbtn_Click);
            // 
            // Aciklama
            // 
            this.Aciklama.Location = new System.Drawing.Point(71, 118);
            this.Aciklama.MaxLength = 100;
            this.Aciklama.Name = "Aciklama";
            this.Aciklama.Size = new System.Drawing.Size(162, 76);
            this.Aciklama.TabIndex = 49;
            this.Aciklama.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 233);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 45;
            this.label7.Text = "Tutar";
            // 
            // Tutar
            // 
            this.Tutar.Location = new System.Drawing.Point(71, 230);
            this.Tutar.Name = "Tutar";
            this.Tutar.Size = new System.Drawing.Size(162, 20);
            this.Tutar.TabIndex = 41;
            // 
            // YeniPersonel
            // 
            this.YeniPersonel.Location = new System.Drawing.Point(239, 62);
            this.YeniPersonel.Name = "YeniPersonel";
            this.YeniPersonel.Size = new System.Drawing.Size(39, 23);
            this.YeniPersonel.TabIndex = 55;
            this.YeniPersonel.Text = "Yeni";
            this.YeniPersonel.UseVisualStyleBackColor = true;
            this.YeniPersonel.Click += new System.EventHandler(this.YeniPersonel_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 121);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 44;
            this.label9.Text = "Açıklama";
            // 
            // harcamadate
            // 
            this.harcamadate.Location = new System.Drawing.Point(71, 203);
            this.harcamadate.Name = "harcamadate";
            this.harcamadate.Size = new System.Drawing.Size(162, 20);
            this.harcamadate.TabIndex = 47;
            // 
            // turucombo
            // 
            this.turucombo.FormattingEnabled = true;
            this.turucombo.Items.AddRange(new object[] {
            "Personel Avans",
            "Firma Harcama",
            "Cari Ödemesi"});
            this.turucombo.Location = new System.Drawing.Point(71, 36);
            this.turucombo.Name = "turucombo";
            this.turucombo.Size = new System.Drawing.Size(162, 21);
            this.turucombo.TabIndex = 54;
            this.turucombo.Text = "Lütfen Seçiniz";
            this.turucombo.SelectedIndexChanged += new System.EventHandler(this.turucombo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "Kasa Kodu";
            // 
            // personelbl
            // 
            this.personelbl.AutoSize = true;
            this.personelbl.Location = new System.Drawing.Point(6, 67);
            this.personelbl.Name = "personelbl";
            this.personelbl.Size = new System.Drawing.Size(48, 13);
            this.personelbl.TabIndex = 43;
            this.personelbl.Text = "Personel";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 209);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 46;
            this.label10.Text = "Tarih";
            // 
            // Turulbl
            // 
            this.Turulbl.AutoSize = true;
            this.Turulbl.Location = new System.Drawing.Point(6, 39);
            this.Turulbl.Name = "Turulbl";
            this.Turulbl.Size = new System.Drawing.Size(29, 13);
            this.Turulbl.TabIndex = 50;
            this.Turulbl.Text = "Türü";
            // 
            // YeniKasa
            // 
            this.YeniKasa.Location = new System.Drawing.Point(239, 7);
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
            this.Giderkasacombo.Location = new System.Drawing.Point(71, 9);
            this.Giderkasacombo.Name = "Giderkasacombo";
            this.Giderkasacombo.Size = new System.Drawing.Size(162, 21);
            this.Giderkasacombo.TabIndex = 52;
            // 
            // personelcombo
            // 
            this.personelcombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.personelcombo.FormattingEnabled = true;
            this.personelcombo.Location = new System.Drawing.Point(71, 64);
            this.personelcombo.Name = "personelcombo";
            this.personelcombo.Size = new System.Drawing.Size(162, 21);
            this.personelcombo.TabIndex = 42;
            // 
            // Caricombo
            // 
            this.Caricombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Caricombo.FormattingEnabled = true;
            this.Caricombo.Location = new System.Drawing.Point(71, 91);
            this.Caricombo.Name = "Caricombo";
            this.Caricombo.Size = new System.Drawing.Size(162, 21);
            this.Caricombo.TabIndex = 42;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "Cari";
            // 
            // YeniCaribtn
            // 
            this.YeniCaribtn.Location = new System.Drawing.Point(239, 89);
            this.YeniCaribtn.Name = "YeniCaribtn";
            this.YeniCaribtn.Size = new System.Drawing.Size(39, 23);
            this.YeniCaribtn.TabIndex = 55;
            this.YeniCaribtn.Text = "Yeni";
            this.YeniCaribtn.UseVisualStyleBackColor = true;
            this.YeniCaribtn.Click += new System.EventHandler(this.YeniCaribtn_Click);
            // 
            // YeniNakitCikis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(284, 287);
            this.Controls.Add(this.harcamakaydetbtn);
            this.Controls.Add(this.Aciklama);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Tutar);
            this.Controls.Add(this.YeniCaribtn);
            this.Controls.Add(this.YeniPersonel);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.harcamadate);
            this.Controls.Add(this.turucombo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.personelbl);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.Turulbl);
            this.Controls.Add(this.YeniKasa);
            this.Controls.Add(this.Giderkasacombo);
            this.Controls.Add(this.Caricombo);
            this.Controls.Add(this.personelcombo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "YeniNakitCikis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yeni Nakit Çıkış";
            this.Load += new System.EventHandler(this.YeniNakitCikis_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button harcamakaydetbtn;
        private System.Windows.Forms.RichTextBox Aciklama;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Tutar;
        private System.Windows.Forms.Button YeniPersonel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker harcamadate;
        private System.Windows.Forms.ComboBox turucombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label personelbl;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label Turulbl;
        private System.Windows.Forms.Button YeniKasa;
        private System.Windows.Forms.ComboBox Giderkasacombo;
        private System.Windows.Forms.ComboBox personelcombo;
        private System.Windows.Forms.ComboBox Caricombo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button YeniCaribtn;

    }
}