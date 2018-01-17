namespace TaseronTakip
{
    partial class NakitRaporlari
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NakitRaporlari));
            this.Raporlabtn = new System.Windows.Forms.Button();
            this.kasacombo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.IlkTarihDateTime = new System.Windows.Forms.DateTimePicker();
            this.tarih1box = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.IkinciTarihDateTime = new System.Windows.Forms.DateTimePicker();
            this.Tarih2box = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Raporlabtn
            // 
            this.Raporlabtn.Location = new System.Drawing.Point(41, 58);
            this.Raporlabtn.Name = "Raporlabtn";
            this.Raporlabtn.Size = new System.Drawing.Size(217, 23);
            this.Raporlabtn.TabIndex = 14;
            this.Raporlabtn.Text = "Raporla";
            this.Raporlabtn.UseVisualStyleBackColor = true;
            this.Raporlabtn.Click += new System.EventHandler(this.Raporlabtn_Click);
            // 
            // kasacombo
            // 
            this.kasacombo.FormattingEnabled = true;
            this.kasacombo.Location = new System.Drawing.Point(41, 8);
            this.kasacombo.Name = "kasacombo";
            this.kasacombo.Size = new System.Drawing.Size(217, 21);
            this.kasacombo.TabIndex = 11;
            this.kasacombo.Text = "Lütfen Kasa Seçiniz";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Kasa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Tarih";
            // 
            // IlkTarihDateTime
            // 
            this.IlkTarihDateTime.Location = new System.Drawing.Point(41, 34);
            this.IlkTarihDateTime.Name = "IlkTarihDateTime";
            this.IlkTarihDateTime.Size = new System.Drawing.Size(36, 20);
            this.IlkTarihDateTime.TabIndex = 15;
            this.IlkTarihDateTime.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // tarih1box
            // 
            this.tarih1box.Location = new System.Drawing.Point(75, 34);
            this.tarih1box.Name = "tarih1box";
            this.tarih1box.ReadOnly = true;
            this.tarih1box.Size = new System.Drawing.Size(65, 20);
            this.tarih1box.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(146, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "-";
            // 
            // IkinciTarihDateTime
            // 
            this.IkinciTarihDateTime.Location = new System.Drawing.Point(159, 34);
            this.IkinciTarihDateTime.Name = "IkinciTarihDateTime";
            this.IkinciTarihDateTime.Size = new System.Drawing.Size(36, 20);
            this.IkinciTarihDateTime.TabIndex = 15;
            this.IkinciTarihDateTime.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // Tarih2box
            // 
            this.Tarih2box.Location = new System.Drawing.Point(193, 34);
            this.Tarih2box.Name = "Tarih2box";
            this.Tarih2box.ReadOnly = true;
            this.Tarih2box.Size = new System.Drawing.Size(65, 20);
            this.Tarih2box.TabIndex = 16;
            // 
            // NakitRaporlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 91);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Tarih2box);
            this.Controls.Add(this.IkinciTarihDateTime);
            this.Controls.Add(this.tarih1box);
            this.Controls.Add(this.IlkTarihDateTime);
            this.Controls.Add(this.Raporlabtn);
            this.Controls.Add(this.kasacombo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NakitRaporlari";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kasa Nakit Raporları";
            this.Load += new System.EventHandler(this.NakitRaporlari_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Raporlabtn;
        private System.Windows.Forms.ComboBox kasacombo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker IlkTarihDateTime;
        private System.Windows.Forms.TextBox tarih1box;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker IkinciTarihDateTime;
        private System.Windows.Forms.TextBox Tarih2box;
    }
}