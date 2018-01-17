using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace TaseronTakip
{
    public partial class TedarikciCariKarti : Form
    {
        public TedarikciCariKarti()
        {
            InitializeComponent();
        }
        public static int GidenID;
        OleDbConnection baglanti = new OleDbConnection(connect.connectroad);
        public void Listemidoldur()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("SELECT tedarikciler.TedarikciID, tedarikciler.unvan,tedarikciler.faaliyet, tedarikciler.adres, tedarikciler.sehir, tedarikciler.telefon, tedarikciler.faks, tedarikciler.vergidairesi, tedarikciler.vergino,tedarikciler.Bakiye FROM tedarikciler WHERE (((tedarikciler.IsActive)=True)) order by TedarikciID", baglanti);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Ünvan";
            dataGridView1.Columns[2].HeaderText = "Faaliyet Alanı";
            dataGridView1.Columns[3].HeaderText = "Adres";
            dataGridView1.Columns[4].HeaderText = "Şehir";
            dataGridView1.Columns[5].HeaderText = "Telefon";
            dataGridView1.Columns[6].HeaderText = "Faks";
            dataGridView1.Columns[7].HeaderText = "Vergi Dairesi";
            dataGridView1.Columns[8].HeaderText = "Vergi No";
            if (dt.Rows.Count != 0)
            {
                dataGridView1.Rows[0].Selected = false;
            }
        }
        private void TedarikciCariKarti_Load(object sender, EventArgs e)
        {
            Listemidoldur();
            dataGridView1.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void Gvazgecbtn_Click(object sender, EventArgs e)
        {
            this.Height = 565;
        }
        private void yeniTedarikciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YeniTedarikci YT = new YeniTedarikci();
            YT.ShowDialog();
            Listemidoldur();
        }
        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GidenID != 0)
            {
                TedarikciCariKartiGuncelle TCKG = new TedarikciCariKartiGuncelle();
                TCKG.ShowDialog();
                Listemidoldur();
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir satırlı seçiniz.");
            }
        }
        private void TedarikciCariKarti_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                YeniTedarikci YT = new YeniTedarikci();
                YT.ShowDialog();
                Listemidoldur();
            }
            else
                if (e.KeyCode == Keys.F5)
                {
                    Listemidoldur();
                }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                GidenID = Convert.ToInt32((dataGridView1.CurrentRow.Cells[0].Value));
            }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                GidenID = Convert.ToInt32((dataGridView1.CurrentRow.Cells[0].Value));
                TedarikciCariKartiGuncelle TCKG = new TedarikciCariKartiGuncelle();
                TCKG.ShowDialog();
                Listemidoldur();
            }
        }
    }
}
