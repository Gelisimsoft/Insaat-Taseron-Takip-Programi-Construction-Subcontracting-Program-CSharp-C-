namespace TaseronTakip
{
    partial class YeniPersonel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YeniPersonel));
            this.Temizlebtn = new System.Windows.Forms.Button();
            this.Kaydetbtn = new System.Windows.Forms.Button();
            this.isegiris = new System.Windows.Forms.DateTimePicker();
            this.evtlf = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ceptlf = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.adres = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.maasbox = new System.Windows.Forms.TextBox();
            this.tcno = new System.Windows.Forms.TextBox();
            this.adsoyad = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.yolcheck = new System.Windows.Forms.CheckBox();
            this.YolYardimibox = new System.Windows.Forms.TextBox();
            this.yemekbox = new System.Windows.Forms.TextBox();
            this.yemekcheck = new System.Windows.Forms.CheckBox();
            this.gorevbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Temizlebtn
            // 
            this.Temizlebtn.Location = new System.Drawing.Point(180, 325);
            this.Temizlebtn.Name = "Temizlebtn";
            this.Temizlebtn.Size = new System.Drawing.Size(79, 23);
            this.Temizlebtn.TabIndex = 51;
            this.Temizlebtn.Text = "Temizle";
            this.Temizlebtn.UseVisualStyleBackColor = true;
            this.Temizlebtn.Click += new System.EventHandler(this.Temizlebtn_Click);
            // 
            // Kaydetbtn
            // 
            this.Kaydetbtn.Location = new System.Drawing.Point(97, 325);
            this.Kaydetbtn.Name = "Kaydetbtn";
            this.Kaydetbtn.Size = new System.Drawing.Size(79, 23);
            this.Kaydetbtn.TabIndex = 50;
            this.Kaydetbtn.Text = "Kaydet";
            this.Kaydetbtn.UseVisualStyleBackColor = true;
            this.Kaydetbtn.Click += new System.EventHandler(this.Kaydetbtn_Click);
            // 
            // isegiris
            // 
            this.isegiris.Location = new System.Drawing.Point(97, 220);
            this.isegiris.Name = "isegiris";
            this.isegiris.Size = new System.Drawing.Size(162, 20);
            this.isegiris.TabIndex = 40;
            // 
            // evtlf
            // 
            this.evtlf.BackColor = System.Drawing.SystemColors.Control;
            this.evtlf.Location = new System.Drawing.Point(97, 194);
            this.evtlf.Mask = "(999) 000-0000";
            this.evtlf.Name = "evtlf";
            this.evtlf.Size = new System.Drawing.Size(162, 20);
            this.evtlf.TabIndex = 39;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(2, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 44;
            this.label4.Text = "Maaş";
            // 
            // ceptlf
            // 
            this.ceptlf.BackColor = System.Drawing.SystemColors.Control;
            this.ceptlf.Location = new System.Drawing.Point(97, 168);
            this.ceptlf.Mask = "(999) 000-0000";
            this.ceptlf.Name = "ceptlf";
            this.ceptlf.Size = new System.Drawing.Size(162, 20);
            this.ceptlf.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(2, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Ad Soyad";
            // 
            // adres
            // 
            this.adres.BackColor = System.Drawing.SystemColors.Control;
            this.adres.Location = new System.Drawing.Point(97, 83);
            this.adres.MaxLength = 100;
            this.adres.Name = "adres";
            this.adres.Size = new System.Drawing.Size(162, 76);
            this.adres.TabIndex = 37;
            this.adres.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(2, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 43;
            this.label7.Text = "Tc Kimlik No";
            // 
            // maasbox
            // 
            this.maasbox.BackColor = System.Drawing.SystemColors.Control;
            this.maasbox.Location = new System.Drawing.Point(97, 246);
            this.maasbox.Name = "maasbox";
            this.maasbox.Size = new System.Drawing.Size(162, 20);
            this.maasbox.TabIndex = 41;
            // 
            // tcno
            // 
            this.tcno.BackColor = System.Drawing.SystemColors.Control;
            this.tcno.Location = new System.Drawing.Point(97, 57);
            this.tcno.Name = "tcno";
            this.tcno.Size = new System.Drawing.Size(162, 20);
            this.tcno.TabIndex = 36;
            // 
            // adsoyad
            // 
            this.adsoyad.BackColor = System.Drawing.SystemColors.Control;
            this.adsoyad.Location = new System.Drawing.Point(97, 6);
            this.adsoyad.Name = "adsoyad";
            this.adsoyad.Size = new System.Drawing.Size(162, 20);
            this.adsoyad.TabIndex = 35;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(2, 226);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 13);
            this.label9.TabIndex = 48;
            this.label9.Text = "İşe Giriş Tarihi";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(2, 197);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 47;
            this.label8.Text = "Ev Tlf";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(2, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 46;
            this.label6.Text = "Cep Tlf";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(2, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 45;
            this.label5.Text = "Adres";
            // 
            // yolcheck
            // 
            this.yolcheck.AutoSize = true;
            this.yolcheck.Location = new System.Drawing.Point(97, 272);
            this.yolcheck.Name = "yolcheck";
            this.yolcheck.Size = new System.Drawing.Size(78, 17);
            this.yolcheck.TabIndex = 52;
            this.yolcheck.Text = "Yol Yardımı";
            this.yolcheck.UseVisualStyleBackColor = true;
            this.yolcheck.CheckedChanged += new System.EventHandler(this.yolcheck_CheckedChanged);
            // 
            // YolYardimibox
            // 
            this.YolYardimibox.BackColor = System.Drawing.SystemColors.Control;
            this.YolYardimibox.Location = new System.Drawing.Point(199, 269);
            this.YolYardimibox.Name = "YolYardimibox";
            this.YolYardimibox.Size = new System.Drawing.Size(60, 20);
            this.YolYardimibox.TabIndex = 41;
            this.YolYardimibox.Text = "0";
            this.YolYardimibox.Visible = false;
            // 
            // yemekbox
            // 
            this.yemekbox.BackColor = System.Drawing.SystemColors.Control;
            this.yemekbox.Location = new System.Drawing.Point(199, 299);
            this.yemekbox.Name = "yemekbox";
            this.yemekbox.Size = new System.Drawing.Size(60, 20);
            this.yemekbox.TabIndex = 41;
            this.yemekbox.Text = "0";
            this.yemekbox.Visible = false;
            // 
            // yemekcheck
            // 
            this.yemekcheck.AutoSize = true;
            this.yemekcheck.Location = new System.Drawing.Point(97, 299);
            this.yemekcheck.Name = "yemekcheck";
            this.yemekcheck.Size = new System.Drawing.Size(96, 17);
            this.yemekcheck.TabIndex = 52;
            this.yemekcheck.Text = "Yemek Yardımı";
            this.yemekcheck.UseVisualStyleBackColor = true;
            this.yemekcheck.CheckedChanged += new System.EventHandler(this.yemekcheck_CheckedChanged);
            // 
            // gorevbox
            // 
            this.gorevbox.BackColor = System.Drawing.SystemColors.Control;
            this.gorevbox.Location = new System.Drawing.Point(97, 32);
            this.gorevbox.Name = "gorevbox";
            this.gorevbox.Size = new System.Drawing.Size(162, 20);
            this.gorevbox.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(2, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "Görevi";
            // 
            // YeniPersonel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(264, 352);
            this.Controls.Add(this.yemekcheck);
            this.Controls.Add(this.yolcheck);
            this.Controls.Add(this.Temizlebtn);
            this.Controls.Add(this.Kaydetbtn);
            this.Controls.Add(this.isegiris);
            this.Controls.Add(this.evtlf);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ceptlf);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.adres);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.yemekbox);
            this.Controls.Add(this.YolYardimibox);
            this.Controls.Add(this.maasbox);
            this.Controls.Add(this.gorevbox);
            this.Controls.Add(this.tcno);
            this.Controls.Add(this.adsoyad);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "YeniPersonel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yeni Personel Kayıt";
            this.Load += new System.EventHandler(this.YeniPersonel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Temizlebtn;
        private System.Windows.Forms.Button Kaydetbtn;
        private System.Windows.Forms.DateTimePicker isegiris;
        private System.Windows.Forms.MaskedTextBox evtlf;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox ceptlf;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox adres;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox maasbox;
        private System.Windows.Forms.TextBox tcno;
        private System.Windows.Forms.TextBox adsoyad;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox yolcheck;
        private System.Windows.Forms.TextBox YolYardimibox;
        private System.Windows.Forms.TextBox yemekbox;
        private System.Windows.Forms.CheckBox yemekcheck;
        private System.Windows.Forms.TextBox gorevbox;
        private System.Windows.Forms.Label label2;
    }
}