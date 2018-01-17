namespace TaseronTakip
{
    partial class BankaCikis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BankaCikis));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.yeniKayıtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.güncelleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.CaricomboAra = new System.Windows.Forms.ComboBox();
            this.KasaArama = new System.Windows.Forms.Button();
            this.tariharabtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.PersonelArama = new System.Windows.Forms.ComboBox();
            this.Tariharadate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.tedarikciarabtn = new System.Windows.Forms.Button();
            this.AramaKasakod = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Personelarabtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.CaricomboAra);
            this.groupBox1.Controls.Add(this.KasaArama);
            this.groupBox1.Controls.Add(this.tariharabtn);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.PersonelArama);
            this.groupBox1.Controls.Add(this.Tariharadate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tedarikciarabtn);
            this.groupBox1.Controls.Add(this.AramaKasakod);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.Personelarabtn);
            this.groupBox1.Location = new System.Drawing.Point(8, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(722, 477);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sistemde Kayıtlı Bilgiler";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(8, 70);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(708, 401);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Kasa Kodu";
            // 
            // CaricomboAra
            // 
            this.CaricomboAra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CaricomboAra.FormattingEnabled = true;
            this.CaricomboAra.Location = new System.Drawing.Point(500, 41);
            this.CaricomboAra.Name = "CaricomboAra";
            this.CaricomboAra.Size = new System.Drawing.Size(162, 21);
            this.CaricomboAra.TabIndex = 59;
            // 
            // KasaArama
            // 
            this.KasaArama.Location = new System.Drawing.Point(214, 14);
            this.KasaArama.Name = "KasaArama";
            this.KasaArama.Size = new System.Drawing.Size(39, 23);
            this.KasaArama.TabIndex = 22;
            this.KasaArama.Text = "Ara";
            this.KasaArama.UseVisualStyleBackColor = true;
            this.KasaArama.Click += new System.EventHandler(this.KasaArama_Click);
            // 
            // tariharabtn
            // 
            this.tariharabtn.Location = new System.Drawing.Point(677, 14);
            this.tariharabtn.Name = "tariharabtn";
            this.tariharabtn.Size = new System.Drawing.Size(39, 23);
            this.tariharabtn.TabIndex = 22;
            this.tariharabtn.Text = "Ara";
            this.tariharabtn.UseVisualStyleBackColor = true;
            this.tariharabtn.Click += new System.EventHandler(this.tariharabtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(442, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 13);
            this.label6.TabIndex = 57;
            this.label6.Text = "Cari";
            // 
            // PersonelArama
            // 
            this.PersonelArama.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PersonelArama.FormattingEnabled = true;
            this.PersonelArama.Location = new System.Drawing.Point(71, 43);
            this.PersonelArama.Name = "PersonelArama";
            this.PersonelArama.Size = new System.Drawing.Size(137, 21);
            this.PersonelArama.TabIndex = 4;
            // 
            // Tariharadate
            // 
            this.Tariharadate.Location = new System.Drawing.Point(500, 16);
            this.Tariharadate.Name = "Tariharadate";
            this.Tariharadate.Size = new System.Drawing.Size(162, 20);
            this.Tariharadate.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Personel";
            // 
            // tedarikciarabtn
            // 
            this.tedarikciarabtn.Location = new System.Drawing.Point(677, 39);
            this.tedarikciarabtn.Name = "tedarikciarabtn";
            this.tedarikciarabtn.Size = new System.Drawing.Size(39, 23);
            this.tedarikciarabtn.TabIndex = 58;
            this.tedarikciarabtn.Text = "Ara";
            this.tedarikciarabtn.UseVisualStyleBackColor = true;
            this.tedarikciarabtn.Click += new System.EventHandler(this.tedarikciarabtn_Click);
            // 
            // AramaKasakod
            // 
            this.AramaKasakod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AramaKasakod.FormattingEnabled = true;
            this.AramaKasakod.Location = new System.Drawing.Point(71, 16);
            this.AramaKasakod.Name = "AramaKasakod";
            this.AramaKasakod.Size = new System.Drawing.Size(137, 21);
            this.AramaKasakod.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(442, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Tarih";
            // 
            // Personelarabtn
            // 
            this.Personelarabtn.Location = new System.Drawing.Point(214, 41);
            this.Personelarabtn.Name = "Personelarabtn";
            this.Personelarabtn.Size = new System.Drawing.Size(39, 23);
            this.Personelarabtn.TabIndex = 25;
            this.Personelarabtn.Text = "Ara";
            this.Personelarabtn.UseVisualStyleBackColor = true;
            this.Personelarabtn.Click += new System.EventHandler(this.Personelarabtn_Click);
            // 
            // BankaCikis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(736, 497);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "BankaCikis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Banka Cıkış";
            this.Load += new System.EventHandler(this.BankaCikis_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BankaCikis_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem yeniKayıtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem güncelleToolStripMenuItem;
        private System.Windows.Forms.ComboBox AramaKasakod;
        private System.Windows.Forms.DateTimePicker Tariharadate;
        private System.Windows.Forms.Button tariharabtn;
        private System.Windows.Forms.Button KasaArama;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox PersonelArama;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Personelarabtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CaricomboAra;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button tedarikciarabtn;
    }
}