namespace TaseronTakip
{
    partial class NakitGiris
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NakitGiris));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.yeniKayıtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.güncelleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Tariharadate = new System.Windows.Forms.DateTimePicker();
            this.AramaKasakod = new System.Windows.Forms.ComboBox();
            this.tariharabtn = new System.Windows.Forms.Button();
            this.KasaArama = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TutarArabox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tutararabtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(5, 47);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(702, 424);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
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
            // Tariharadate
            // 
            this.Tariharadate.Location = new System.Drawing.Point(508, 19);
            this.Tariharadate.Name = "Tariharadate";
            this.Tariharadate.Size = new System.Drawing.Size(144, 20);
            this.Tariharadate.TabIndex = 6;
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
            // tariharabtn
            // 
            this.tariharabtn.Location = new System.Drawing.Point(658, 17);
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
            // TutarArabox
            // 
            this.TutarArabox.Location = new System.Drawing.Point(300, 19);
            this.TutarArabox.Name = "TutarArabox";
            this.TutarArabox.Size = new System.Drawing.Size(120, 20);
            this.TutarArabox.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(262, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Tutar";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.AramaKasakod);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tariharabtn);
            this.groupBox1.Controls.Add(this.TutarArabox);
            this.groupBox1.Controls.Add(this.Tariharadate);
            this.groupBox1.Controls.Add(this.KasaArama);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tutararabtn);
            this.groupBox1.Location = new System.Drawing.Point(5, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(714, 478);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sistemde Kayıtlı Bilgiler";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(471, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Tarih";
            // 
            // tutararabtn
            // 
            this.tutararabtn.Location = new System.Drawing.Point(426, 18);
            this.tutararabtn.Name = "tutararabtn";
            this.tutararabtn.Size = new System.Drawing.Size(39, 23);
            this.tutararabtn.TabIndex = 25;
            this.tutararabtn.Text = "Ara";
            this.tutararabtn.UseVisualStyleBackColor = true;
            this.tutararabtn.Click += new System.EventHandler(this.tutararabtn_Click);
            // 
            // NakitGiris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(724, 497);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "NakitGiris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nakit Giriş";
            this.Load += new System.EventHandler(this.NakitGiris_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NakitGiris_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem yeniKayıtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem güncelleToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker Tariharadate;
        private System.Windows.Forms.ComboBox AramaKasakod;
        private System.Windows.Forms.Button tariharabtn;
        private System.Windows.Forms.Button KasaArama;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TutarArabox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button tutararabtn;
        private System.Windows.Forms.Label label5;

    }
}