namespace TaseronTakip
{
    partial class BankaGiris
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BankaGiris));
            this.AramaKasakod = new System.Windows.Forms.ComboBox();
            this.Tariharadate = new System.Windows.Forms.DateTimePicker();
            this.tariharabtn = new System.Windows.Forms.Button();
            this.KasaArama = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TutarArabox = new System.Windows.Forms.TextBox();
            this.tutararabtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.yeniKayıtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.güncelleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AramaKasakod
            // 
            this.AramaKasakod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AramaKasakod.FormattingEnabled = true;
            this.AramaKasakod.Location = new System.Drawing.Point(72, 19);
            this.AramaKasakod.Name = "AramaKasakod";
            this.AramaKasakod.Size = new System.Drawing.Size(137, 21);
            this.AramaKasakod.TabIndex = 20;
            // 
            // Tariharadate
            // 
            this.Tariharadate.Location = new System.Drawing.Point(523, 18);
            this.Tariharadate.Name = "Tariharadate";
            this.Tariharadate.Size = new System.Drawing.Size(144, 20);
            this.Tariharadate.TabIndex = 6;
            // 
            // tariharabtn
            // 
            this.tariharabtn.Location = new System.Drawing.Point(675, 17);
            this.tariharabtn.Name = "tariharabtn";
            this.tariharabtn.Size = new System.Drawing.Size(39, 23);
            this.tariharabtn.TabIndex = 22;
            this.tariharabtn.Text = "Ara";
            this.tariharabtn.UseVisualStyleBackColor = true;
            this.tariharabtn.Click += new System.EventHandler(this.tariharabtn_Click);
            // 
            // KasaArama
            // 
            this.KasaArama.Location = new System.Drawing.Point(215, 17);
            this.KasaArama.Name = "KasaArama";
            this.KasaArama.Size = new System.Drawing.Size(39, 23);
            this.KasaArama.TabIndex = 22;
            this.KasaArama.Text = "Ara";
            this.KasaArama.UseVisualStyleBackColor = true;
            this.KasaArama.Click += new System.EventHandler(this.KasaArama_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Kasa Kodu";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(270, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Tutar";
            // 
            // TutarArabox
            // 
            this.TutarArabox.Location = new System.Drawing.Point(318, 18);
            this.TutarArabox.Name = "TutarArabox";
            this.TutarArabox.Size = new System.Drawing.Size(120, 20);
            this.TutarArabox.TabIndex = 1;
            // 
            // tutararabtn
            // 
            this.tutararabtn.Location = new System.Drawing.Point(441, 16);
            this.tutararabtn.Name = "tutararabtn";
            this.tutararabtn.Size = new System.Drawing.Size(39, 23);
            this.tutararabtn.TabIndex = 25;
            this.tutararabtn.Text = "Ara";
            this.tutararabtn.UseVisualStyleBackColor = true;
            this.tutararabtn.Click += new System.EventHandler(this.tutararabtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(486, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Tarih";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yeniKayıtToolStripMenuItem,
            this.güncelleToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(127, 48);
            // 
            // yeniKayıtToolStripMenuItem
            // 
            this.yeniKayıtToolStripMenuItem.Image = global::TaseronTakip.Properties.Resources.Bank;
            this.yeniKayıtToolStripMenuItem.Name = "yeniKayıtToolStripMenuItem";
            this.yeniKayıtToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.yeniKayıtToolStripMenuItem.Text = "Yeni Kayıt";
            this.yeniKayıtToolStripMenuItem.Click += new System.EventHandler(this.yeniKayıtToolStripMenuItem_Click);
            // 
            // güncelleToolStripMenuItem
            // 
            this.güncelleToolStripMenuItem.Image = global::TaseronTakip.Properties.Resources.guncelle;
            this.güncelleToolStripMenuItem.Name = "güncelleToolStripMenuItem";
            this.güncelleToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.güncelleToolStripMenuItem.Text = "Güncelle";
            this.güncelleToolStripMenuItem.Click += new System.EventHandler(this.güncelleToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(6, 46);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(708, 425);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.AramaKasakod);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.Tariharadate);
            this.groupBox1.Controls.Add(this.TutarArabox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.KasaArama);
            this.groupBox1.Controls.Add(this.tariharabtn);
            this.groupBox1.Controls.Add(this.tutararabtn);
            this.groupBox1.Location = new System.Drawing.Point(5, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(720, 477);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sistemde Kayıtlı Bilgiler";
            // 
            // BankaGiris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(729, 497);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "BankaGiris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Banka Giriş";
            this.Load += new System.EventHandler(this.BankaGiris_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BankaGiris_KeyDown);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox AramaKasakod;
        private System.Windows.Forms.DateTimePicker Tariharadate;
        private System.Windows.Forms.Button tariharabtn;
        private System.Windows.Forms.Button KasaArama;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem güncelleToolStripMenuItem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TutarArabox;
        private System.Windows.Forms.ToolStripMenuItem yeniKayıtToolStripMenuItem;
        private System.Windows.Forms.Button tutararabtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}