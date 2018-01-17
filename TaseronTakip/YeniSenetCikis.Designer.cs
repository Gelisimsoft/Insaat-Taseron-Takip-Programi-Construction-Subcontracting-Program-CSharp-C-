namespace TaseronTakip
{
    partial class YeniSenetCikis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YeniSenetCikis));
            this.SenetAciklama = new System.Windows.Forms.RichTextBox();
            this.YeniTedarikciCek = new System.Windows.Forms.Button();
            this.TedarikcicomboSenet = new System.Windows.Forms.ComboBox();
            this.SenetKaydet = new System.Windows.Forms.Button();
            this.Senettutar = new System.Windows.Forms.TextBox();
            this.Senetnumarasi = new System.Windows.Forms.TextBox();
            this.Senetvadetarihi = new System.Windows.Forms.DateTimePicker();
            this.SenetDuzenleme = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.yenikasabtn = new System.Windows.Forms.Button();
            this.GeliKasaCombo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SenetAciklama
            // 
            this.SenetAciklama.Location = new System.Drawing.Point(96, 87);
            this.SenetAciklama.MaxLength = 100;
            this.SenetAciklama.Name = "SenetAciklama";
            this.SenetAciklama.Size = new System.Drawing.Size(167, 82);
            this.SenetAciklama.TabIndex = 94;
            this.SenetAciklama.Text = "";
            // 
            // YeniTedarikciCek
            // 
            this.YeniTedarikciCek.Location = new System.Drawing.Point(267, 63);
            this.YeniTedarikciCek.Name = "YeniTedarikciCek";
            this.YeniTedarikciCek.Size = new System.Drawing.Size(39, 23);
            this.YeniTedarikciCek.TabIndex = 113;
            this.YeniTedarikciCek.Text = "Yeni";
            this.YeniTedarikciCek.UseVisualStyleBackColor = true;
            this.YeniTedarikciCek.Click += new System.EventHandler(this.YeniTedarikciCek_Click);
            // 
            // TedarikcicomboSenet
            // 
            this.TedarikcicomboSenet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TedarikcicomboSenet.FormattingEnabled = true;
            this.TedarikcicomboSenet.Location = new System.Drawing.Point(96, 63);
            this.TedarikcicomboSenet.Name = "TedarikcicomboSenet";
            this.TedarikcicomboSenet.Size = new System.Drawing.Size(169, 21);
            this.TedarikcicomboSenet.TabIndex = 93;
            // 
            // SenetKaydet
            // 
            this.SenetKaydet.Location = new System.Drawing.Point(96, 253);
            this.SenetKaydet.Name = "SenetKaydet";
            this.SenetKaydet.Size = new System.Drawing.Size(167, 23);
            this.SenetKaydet.TabIndex = 101;
            this.SenetKaydet.Text = "Kaydet";
            this.SenetKaydet.UseVisualStyleBackColor = true;
            this.SenetKaydet.Click += new System.EventHandler(this.CekKaydet_Click);
            // 
            // Senettutar
            // 
            this.Senettutar.Location = new System.Drawing.Point(96, 227);
            this.Senettutar.Name = "Senettutar";
            this.Senettutar.Size = new System.Drawing.Size(167, 20);
            this.Senettutar.TabIndex = 100;
            // 
            // Senetnumarasi
            // 
            this.Senetnumarasi.Location = new System.Drawing.Point(96, 175);
            this.Senetnumarasi.Name = "Senetnumarasi";
            this.Senetnumarasi.Size = new System.Drawing.Size(167, 20);
            this.Senetnumarasi.TabIndex = 95;
            // 
            // Senetvadetarihi
            // 
            this.Senetvadetarihi.Location = new System.Drawing.Point(96, 201);
            this.Senetvadetarihi.Name = "Senetvadetarihi";
            this.Senetvadetarihi.Size = new System.Drawing.Size(167, 20);
            this.Senetvadetarihi.TabIndex = 99;
            // 
            // SenetDuzenleme
            // 
            this.SenetDuzenleme.Location = new System.Drawing.Point(96, 36);
            this.SenetDuzenleme.Name = "SenetDuzenleme";
            this.SenetDuzenleme.Size = new System.Drawing.Size(168, 20);
            this.SenetDuzenleme.TabIndex = 92;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1, 222);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 107;
            this.label10.Text = "Tutar";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1, 198);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 108;
            this.label9.Text = "Vade Tarihi";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 111;
            this.label5.Text = "Senet Numarası";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 112;
            this.label1.Text = "Açıklama";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 110;
            this.label3.Text = "Cari";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 109;
            this.label2.Text = "Düzenleme Tarihi";
            // 
            // yenikasabtn
            // 
            this.yenikasabtn.Location = new System.Drawing.Point(267, 5);
            this.yenikasabtn.Name = "yenikasabtn";
            this.yenikasabtn.Size = new System.Drawing.Size(37, 23);
            this.yenikasabtn.TabIndex = 103;
            this.yenikasabtn.Text = "Yeni";
            this.yenikasabtn.UseVisualStyleBackColor = true;
            this.yenikasabtn.Click += new System.EventHandler(this.yenikasabtn_Click);
            // 
            // GeliKasaCombo
            // 
            this.GeliKasaCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GeliKasaCombo.FormattingEnabled = true;
            this.GeliKasaCombo.Location = new System.Drawing.Point(96, 7);
            this.GeliKasaCombo.Name = "GeliKasaCombo";
            this.GeliKasaCombo.Size = new System.Drawing.Size(167, 21);
            this.GeliKasaCombo.TabIndex = 91;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 102;
            this.label4.Text = "Kasa Kodu";
            // 
            // YeniSenetCikis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(309, 282);
            this.Controls.Add(this.SenetAciklama);
            this.Controls.Add(this.YeniTedarikciCek);
            this.Controls.Add(this.TedarikcicomboSenet);
            this.Controls.Add(this.SenetKaydet);
            this.Controls.Add(this.Senettutar);
            this.Controls.Add(this.Senetnumarasi);
            this.Controls.Add(this.Senetvadetarihi);
            this.Controls.Add(this.SenetDuzenleme);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.yenikasabtn);
            this.Controls.Add(this.GeliKasaCombo);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "YeniSenetCikis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yeni Senet Çıkış";
            this.Load += new System.EventHandler(this.YeniSenetCikis_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox SenetAciklama;
        private System.Windows.Forms.Button YeniTedarikciCek;
        private System.Windows.Forms.ComboBox TedarikcicomboSenet;
        private System.Windows.Forms.Button SenetKaydet;
        private System.Windows.Forms.TextBox Senettutar;
        private System.Windows.Forms.TextBox Senetnumarasi;
        private System.Windows.Forms.DateTimePicker Senetvadetarihi;
        private System.Windows.Forms.DateTimePicker SenetDuzenleme;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button yenikasabtn;
        private System.Windows.Forms.ComboBox GeliKasaCombo;
        private System.Windows.Forms.Label label4;
    }
}