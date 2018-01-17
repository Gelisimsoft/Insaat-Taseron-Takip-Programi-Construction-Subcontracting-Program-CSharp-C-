namespace TaseronTakip
{
    partial class CariEkstresi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CariEkstresi));
            this.label2 = new System.Windows.Forms.Label();
            this.Tarih2box = new System.Windows.Forms.TextBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.tarih1box = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.Raporlabtn = new System.Windows.Forms.Button();
            this.CariKombo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(135, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 61;
            this.label2.Text = "-";
            // 
            // Tarih2box
            // 
            this.Tarih2box.Location = new System.Drawing.Point(182, 34);
            this.Tarih2box.Name = "Tarih2box";
            this.Tarih2box.ReadOnly = true;
            this.Tarih2box.Size = new System.Drawing.Size(65, 20);
            this.Tarih2box.TabIndex = 59;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(148, 34);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(36, 20);
            this.dateTimePicker2.TabIndex = 57;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // tarih1box
            // 
            this.tarih1box.Location = new System.Drawing.Point(64, 34);
            this.tarih1box.Name = "tarih1box";
            this.tarih1box.ReadOnly = true;
            this.tarih1box.Size = new System.Drawing.Size(65, 20);
            this.tarih1box.TabIndex = 60;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(30, 34);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(36, 20);
            this.dateTimePicker1.TabIndex = 58;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // Raporlabtn
            // 
            this.Raporlabtn.Location = new System.Drawing.Point(30, 60);
            this.Raporlabtn.Name = "Raporlabtn";
            this.Raporlabtn.Size = new System.Drawing.Size(217, 23);
            this.Raporlabtn.TabIndex = 56;
            this.Raporlabtn.Text = "Raporla";
            this.Raporlabtn.UseVisualStyleBackColor = true;
            this.Raporlabtn.Click += new System.EventHandler(this.Raporlabtn_Click);
            // 
            // CariKombo
            // 
            this.CariKombo.FormattingEnabled = true;
            this.CariKombo.Location = new System.Drawing.Point(30, 8);
            this.CariKombo.Name = "CariKombo";
            this.CariKombo.Size = new System.Drawing.Size(217, 21);
            this.CariKombo.TabIndex = 53;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-1, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 52;
            this.label3.Text = "Cari";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-1, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "Tarih";
            // 
            // CariEkstresi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 91);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Tarih2box);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.tarih1box);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.Raporlabtn);
            this.Controls.Add(this.CariKombo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CariEkstresi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cari Ekstresi";
            this.Load += new System.EventHandler(this.CariEkstresi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Tarih2box;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.TextBox tarih1box;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button Raporlabtn;
        private System.Windows.Forms.ComboBox CariKombo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;

    }
}