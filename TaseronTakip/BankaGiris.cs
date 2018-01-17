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
    public partial class BankaGiris : Form
    {
        public BankaGiris()
        {
            InitializeComponent();
        }
        public static int ID;
        OleDbConnection con = new OleDbConnection(connect.connectroad);
        public void BankaGel()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("SELECT Kasa.Tanim, BankaIslem.Niteligi, BankaIslem.Tarih, BankaIslem.Aciklama, BankaIslem.Gelir, BankaIslem.BankaIslemID FROM BankaIslem INNER JOIN Kasa ON BankaIslem.KasaID = Kasa.KasaID WHERE (((BankaIslem.Niteligi)='Banka Giriş'));", con);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[0].HeaderText = "Kasa";
            dataGridView1.Columns[4].HeaderText = "Tutar";
            if (dt.Rows.Count != 0)
            {
                dataGridView1.Rows[0].Selected = false;
            }
            //dataGridView1.AutoResizeColumns();
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        public void BankaGelKodaGore()
        {
            if (AramaKasakod.SelectedIndex != 0)
            {
                OleDbDataAdapter dap = new OleDbDataAdapter("SELECT Kasa.Tanim, BankaIslem.Niteligi, BankaIslem.Tarih, BankaIslem.Aciklama, BankaIslem.Gelir, BankaIslem.BankaIslemID FROM Kasa INNER JOIN BankaIslem ON Kasa.KasaID = BankaIslem.KasaID WHERE (((BankaIslem.Niteligi)= 'Banka Giriş') AND ((Kasa.KasaID)=@Kod))", con);
                dap.SelectCommand.Parameters.AddWithValue("@Kod", Convert.ToInt32(AramaKasakod.SelectedValue));
                DataTable dt = new DataTable();
                dap.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[5].Visible = false;
                    dataGridView1.Columns[0].HeaderText = "Kasa";
                }
                else
                {
                    MessageBox.Show("Kayıt bulunamadı.", "Arama", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BankaGel();
                }
            }
            else
            {
                MessageBox.Show("Lütfen kasa seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        public void BankaGelTariheGore()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("SELECT Kasa.Tanim, BankaIslem.Niteligi, BankaIslem.Tarih, BankaIslem.Aciklama, BankaIslem.Gelir, BankaIslem.BankaIslemID FROM Kasa INNER JOIN BankaIslem ON Kasa.KasaID = BankaIslem.KasaID WHERE (((BankaIslem.Niteligi)='Banka Giriş') AND ((BankaIslem.Tarih)=@Tarih))", con);
            dap.SelectCommand.Parameters.AddWithValue("@Tarih", Tariharadate.Value);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[0].HeaderText = "Kasa";
                dataGridView1.Columns[4].HeaderText = "Tutar";
            }
            else
            {
                MessageBox.Show("Kayıt bulunamadı.", "Arama", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BankaGel();
            }
        }
        public void BankaGelTutaraGore()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("SELECT Kasa.Tanim, BankaIslem.Niteligi, BankaIslem.Tarih, BankaIslem.Aciklama, BankaIslem.Gelir, BankaIslem.BankaIslemID FROM Kasa INNER JOIN BankaIslem ON Kasa.KasaID = BankaIslem.KasaID WHERE (((BankaIslem.Niteligi)='Banka Giriş') AND ((BankaIslem.Gelir)=@GeT));", con);
            dap.SelectCommand.Parameters.AddWithValue("@GeT", Convert.ToDouble(TutarArabox.Text));
            DataTable dt = new DataTable();
            dap.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[0].HeaderText = "Kasa";
                dataGridView1.Columns[4].HeaderText = "Tutar";
            }
            else
            {
                MessageBox.Show("Kayıt bulunamadı.", "Arama", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BankaGel();
            }
        }
        public void GiderBankaAra()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("select * from Kasa where ((Kasa.IsActive)=True) order by Kod", con);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            if (dt.Columns.Count != 0)
            {
                DataRow dr = dt.NewRow();
                dr[1] = "Lütfen Seçiniz";
                dt.Rows.InsertAt(dr, 0);
                AramaKasakod.DataSource = dt;
                AramaKasakod.DisplayMember = "Kod";
                AramaKasakod.ValueMember = "KasaID";
            }
        }
        private void BankaGiris_Load(object sender, EventArgs e)
        {
            GiderBankaAra();
            BankaGel();
            dataGridView1.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void BankaGiris_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                YeniBankaGiris YBG = new YeniBankaGiris();
                YBG.ShowDialog();
                BankaGel();
            }
            if (e.KeyCode == Keys.F5)
            {
                BankaGel();
            }
        }
        private void KasaArama_Click(object sender, EventArgs e)
        {
            BankaGelKodaGore();
            AramaKasakod.SelectedIndex = 0;
        }
        private void tutararabtn_Click(object sender, EventArgs e)
        {
            if (TutarArabox.Text == "")
            {
                MessageBox.Show("Lütfen geçerli bir tutar yazınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                BankaGelTutaraGore();
                TutarArabox.Text = "";
            }
        }
        private void tariharabtn_Click(object sender, EventArgs e)
        {
            BankaGelTariheGore();
            Tariharadate.Value = DateTime.Now;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                ID = Convert.ToInt32((dataGridView1.CurrentRow.Cells[5].Value));
            }
        }
        private void yeniKayıtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YeniBankaGiris YBG = new YeniBankaGiris();
            YBG.ShowDialog();
            BankaGel();
        }
        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                BankaGirisGuncelle BGG = new BankaGirisGuncelle();
                BGG.ShowDialog();
                BankaGel();
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir satırlı seçiniz.");
            }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                ID = Convert.ToInt32((dataGridView1.CurrentRow.Cells[5].Value));
                BankaGirisGuncelle BGG = new BankaGirisGuncelle();
                BGG.ShowDialog();
                BankaGel();
            }
        }
    }
}
