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
    public partial class NakitGiris : Form
    {
        public NakitGiris()
        {
            InitializeComponent();
        }
        public static int ID;
        OleDbConnection con = new OleDbConnection(connect.connectroad);
        public void NakitGel()
        {
            try
            {
                OleDbDataAdapter dap = new OleDbDataAdapter("SELECT Kasa.Tanim, NakitIslem.Niteligi, NakitIslem.Tarih, NakitIslem.Aciklama, NakitIslem.Gelir, NakitIslem.NakitIslemID FROM NakitIslem INNER JOIN Kasa ON NakitIslem.KasaID = Kasa.KasaID WHERE (((NakitIslem.Niteligi)='Nakit Giriş'));", con);
                DataTable dt = new DataTable();
                dap.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[0].HeaderText = "Kasa";
                dataGridView1.Columns[4].HeaderText = "Tutar";
                if (dt.Rows.Count != 0)
                {
                    dataGridView1.Rows[0].Selected = false;
                    //dataGridView1.AutoResizeColumns();
                    //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void NakitGelKodaGore()
        {
            if (AramaKasakod.SelectedIndex != 0)
            {
                OleDbDataAdapter dap = new OleDbDataAdapter("SELECT Kasa.Tanim, NakitIslem.Niteligi, NakitIslem.Tarih, NakitIslem.Aciklama, NakitIslem.Gelir, NakitIslem.NakitIslemID FROM Kasa INNER JOIN NakitIslem ON Kasa.KasaID = NakitIslem.KasaID WHERE (((NakitIslem.Niteligi)= 'Nakit Giriş') AND ((Kasa.KasaID)=@Kod))", con);
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
                    NakitGel();
                }
            }
            else
            {
                MessageBox.Show("Lütfen kasa seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        public void NakitGelTariheGore()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("SELECT Kasa.Tanim, NakitIslem.Niteligi, NakitIslem.Tarih, NakitIslem.Aciklama, NakitIslem.Gelir, NakitIslem.NakitIslemID FROM Kasa INNER JOIN NakitIslem ON Kasa.KasaID = NakitIslem.KasaID WHERE (((NakitIslem.Niteligi)='Nakit Giriş') AND ((NakitIslem.Tarih)=@Tarih))", con);
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
                NakitGel();
            }
        }
        public void NakitGelTutaraGore()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("SELECT Kasa.Tanim, NakitIslem.Niteligi, NakitIslem.Tarih, NakitIslem.Aciklama, NakitIslem.Gelir, NakitIslem.NakitIslemID FROM Kasa INNER JOIN NakitIslem ON Kasa.KasaID = NakitIslem.KasaID WHERE (((NakitIslem.Niteligi)='Nakit Giriş') AND ((NakitIslem.Gelir)=@GeT));", con);
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
                NakitGel();
            }
        }
        public void GiderNakitAra()
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
        private void NakitGiris_Load(object sender, EventArgs e)
        {
            GiderNakitAra();
            NakitGel();
            dataGridView1.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void NakitGiris_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                YeniNakitGiris YBG = new YeniNakitGiris();
                YBG.ShowDialog();
                NakitGel();
            }
            if (e.KeyCode == Keys.F5)
            {
                NakitGel();
            }
        }
        private void KasaArama_Click(object sender, EventArgs e)
        {
            NakitGelKodaGore();
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
                NakitGelTutaraGore();
                TutarArabox.Text = "";
            }
        }
        private void tariharabtn_Click(object sender, EventArgs e)
        {
            NakitGelTariheGore();
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
            YeniNakitGiris YBG = new YeniNakitGiris();
            YBG.ShowDialog();
            NakitGel();
            GiderNakitAra();
        }
        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                NakitGirisGuncelle NGG = new NakitGirisGuncelle();
                NGG.ShowDialog();
                NakitGel();
                GiderNakitAra();
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
                NakitGirisGuncelle NGG = new NakitGirisGuncelle();
                NGG.ShowDialog();
                NakitGel();
            }
        }
    }
}
