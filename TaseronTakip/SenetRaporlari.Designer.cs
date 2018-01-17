namespace TaseronTakip
{
    partial class SenetRaporlari
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SenetRaporlari));
            this.Tcombo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Senetnobox = new System.Windows.Forms.TextBox();
            this.tarih1box = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.RaporlaSenetBtn = new System.Windows.Forms.Button();
            this.Raporlabtn = new System.Windows.Forms.Button();
            this.kasacombo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RaporlaTedBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Tcombo
            // 
            this.Tcombo.FormattingEnabled = true;
            this.Tcombo.Location = new System.Drawing.Point(81, 129);
            this.Tcombo.Name = "Tcombo";
            this.Tcombo.Size = new System.Drawing.Size(159, 21);
            this.Tcombo.TabIndex = 61;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 60;
            this.label6.Text = "Tedarikçi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 58;
            this.label4.Text = "Senet No";
            // 
            // Senetnobox
            // 
            this.Senetnobox.Location = new System.Drawing.Point(81, 106);
            this.Senetnobox.Name = "Senetnobox";
            this.Senetnobox.Size = new System.Drawing.Size(159, 20);
            this.Senetnobox.TabIndex = 55;
            // 
            // tarih1box
            // 
            this.tarih1box.Location = new System.Drawing.Point(115, 30);
            this.tarih1box.Name = "tarih1box";
            this.tarih1box.ReadOnly = true;
            this.tarih1box.Size = new System.Drawing.Size(125, 20);
            this.tarih1box.TabIndex = 56;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(81, 30);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(36, 20);
            this.dateTimePicker1.TabIndex = 52;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // RaporlaSenetBtn
            // 
            this.RaporlaSenetBtn.Location = new System.Drawing.Point(246, 104);
            this.RaporlaSenetBtn.Name = "RaporlaSenetBtn";
            this.RaporlaSenetBtn.Size = new System.Drawing.Size(94, 23);
            this.RaporlaSenetBtn.TabIndex = 49;
            this.RaporlaSenetBtn.Text = "Raporla";
            this.RaporlaSenetBtn.UseVisualStyleBackColor = true;
            this.RaporlaSenetBtn.Click += new System.EventHandler(this.RaporlaSenetBtn_Click);
            // 
            // Raporlabtn
            // 
            this.Raporlabtn.Location = new System.Drawing.Point(81, 54);
            this.Raporlabtn.Name = "Raporlabtn";
            this.Raporlabtn.Size = new System.Drawing.Size(159, 23);
            this.Raporlabtn.TabIndex = 50;
            this.Raporlabtn.Text = "Raporla";
            this.Raporlabtn.UseVisualStyleBackColor = true;
            this.Raporlabtn.Click += new System.EventHandler(this.Raporlabtn_Click);
            // 
            // kasacombo
            // 
            this.kasacombo.FormattingEnabled = true;
            this.kasacombo.Location = new System.Drawing.Point(81, 4);
            this.kasacombo.Name = "kasacombo";
            this.kasacombo.Size = new System.Drawing.Size(159, 21);
            this.kasacombo.TabIndex = 46;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 45;
            this.label3.Text = "Kasa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "Vade Tarihi";
            // 
            // RaporlaTedBtn
            // 
            this.RaporlaTedBtn.Location = new System.Drawing.Point(246, 127);
            this.RaporlaTedBtn.Name = "RaporlaTedBtn";
            this.RaporlaTedBtn.Size = new System.Drawing.Size(94, 23);
            this.RaporlaTedBtn.TabIndex = 49;
            this.RaporlaTedBtn.Text = "Raporla";
            this.RaporlaTedBtn.UseVisualStyleBackColor = true;
            this.RaporlaTedBtn.Click += new System.EventHandler(this.RaporlaTedBtn_Click);
            // 
            // SenetRaporlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 162);
            this.Controls.Add(this.Tcombo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Senetnobox);
            this.Controls.Add(this.tarih1box);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.RaporlaTedBtn);
            this.Controls.Add(this.RaporlaSenetBtn);
            this.Controls.Add(this.Raporlabtn);
            this.Controls.Add(this.kasacombo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SenetRaporlari";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kasa Senet Raporları";
            this.Load += new System.EventHandler(this.SenetRaporlari_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Tcombo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Senetnobox;
        private System.Windows.Forms.TextBox tarih1box;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button RaporlaSenetBtn;
        private System.Windows.Forms.Button Raporlabtn;
        private System.Windows.Forms.ComboBox kasacombo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button RaporlaTedBtn;
    }
}