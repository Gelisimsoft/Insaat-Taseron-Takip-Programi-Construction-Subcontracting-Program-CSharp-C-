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
    public partial class SenetGiris : Form
    {
        public SenetGiris()
        {
            InitializeComponent();
        }
        public static int ID;
        OleDbConnection con = new OleDbConnection(connect.connectroad);
        public void SenetGel()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("SELECT Kasa.Tanim, SenetIslem.SenetID, SenetIslem.KayitTarihi, SenetIslem.DuzenlemeTarihi, tedarikciler.unvan, SenetIslem.Aciklama, SenetIslem.SenetNo,SenetIslem.VadeTarihi, SenetIslem.Giris FROM Kasa INNER JOIN (tedarikciler INNER JOIN SenetIslem ON tedarikciler.TedarikciID = SenetIslem.TedarikciID) ON Kasa.KasaID = SenetIslem.KasaID WHERE (((SenetIslem.Islem)='Giris'))", con);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[0].HeaderText = "Kasa";
            dataGridView1.Columns[8].HeaderText = "Tutar";
            if (dt.Rows.Count != 0)
            {
                dataGridView1.Rows[0].Selected = false;
                //dataGridView1.AutoResizeColumns();
                //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }
        public void SenetGelKodaGore()
        {
            if (AramaKasacomco.SelectedIndex != 0)
            {
                OleDbDataAdapter dap = new OleDbDataAdapter("SELECT Kasa.Tanim, SenetIslem.SenetID, SenetIslem.KayitTarihi, SenetIslem.DuzenlemeTarihi, tedarikciler.unvan, SenetIslem.Aciklama, SenetIslem.SenetNo,SenetIslem.VadeTarihi, SenetIslem.Giris FROM Kasa INNER JOIN (tedarikciler INNER JOIN SenetIslem ON tedarikciler.TedarikciID = SenetIslem.TedarikciID) ON Kasa.KasaID = SenetIslem.KasaID WHERE (((SenetIslem.KasaID)=@Kod) AND ((SenetIslem.Islem)='Giris'));", con);
                dap.SelectCommand.Parameters.AddWithValue("@Kod", Convert.ToInt32(AramaKasacomco.SelectedValue));
                DataTable dt = new DataTable();
                dap.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[1].Visible = false;
                    dataGridView1.Columns[8].HeaderText = "Tutar";
                    dataGridView1.Columns[0].HeaderText = "Kasa";
                }
                else
                {
                    MessageBox.Show("Kayıt bulunamadı.", "Arama", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SenetGel();
                }
            }
            else
            {
                MessageBox.Show("Lütfen kasa seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        public void SenetGelTariheGore()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("SELECT Kasa.Tanim, SenetIslem.SenetID, SenetIslem.KayitTarihi, SenetIslem.DuzenlemeTarihi, tedarikciler.unvan, SenetIslem.Aciklama, SenetIslem.SenetNo,SenetIslem.VadeTarihi, SenetIslem.Giris FROM Kasa INNER JOIN (tedarikciler INNER JOIN SenetIslem ON tedarikciler.TedarikciID = SenetIslem.TedarikciID) ON Kasa.KasaID = SenetIslem.KasaID WHERE (((SenetIslem.VadeTarihi)=@Tarih) AND ((SenetIslem.Islem)='Giris'))", con);
            dap.SelectCommand.Parameters.AddWithValue("@Tarih", AramaTarihdate.Value);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[8].HeaderText = "Tutar";
                dataGridView1.Columns[0].HeaderText = "Kasa";
            }
            else
            {
                MessageBox.Show("Kayıt bulunamadı.", "Arama", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SenetGel();
            }
        }
        public void SenetGelTutaraGore()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("SELECT Kasa.Tanim, SenetIslem.SenetID, SenetIslem.KayitTarihi, SenetIslem.DuzenlemeTarihi, tedarikciler.unvan, SenetIslem.Aciklama, SenetIslem.SenetNo,SenetIslem.VadeTarihi, SenetIslem.Giris FROM Kasa INNER JOIN (tedarikciler INNER JOIN SenetIslem ON tedarikciler.TedarikciID = SenetIslem.TedarikciID) ON Kasa.KasaID = SenetIslem.KasaID WHERE (((SenetIslem.Cikis)=@Tutar) AND ((SenetIslem.Islem)='Giris'))", con);
            dap.SelectCommand.Parameters.AddWithValue("@Tutar", Convert.ToDouble(AramaTutarbox.Text));
            DataTable dt = new DataTable();
            dap.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[8].HeaderText = "Tutar";
                dataGridView1.Columns[0].HeaderText = "Kasa";
            }
            else
            {
                MessageBox.Show("Kayıt bulunamadı.", "Arama", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SenetGel();
            }
        }
        public void SenetGelSenetNoGore()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("SELECT Kasa.Tanim, SenetIslem.SenetID, SenetIslem.KayitTarihi, SenetIslem.DuzenlemeTarihi, tedarikciler.unvan, SenetIslem.Aciklama, SenetIslem.SenetNo, SenetIslem.VadeTarihi, SenetIslem.Giris FROM Kasa INNER JOIN (tedarikciler INNER JOIN SenetIslem ON tedarikciler.TedarikciID = SenetIslem.TedarikciID) ON Kasa.KasaID = SenetIslem.KasaID WHERE (((SenetIslem.SenetNo)=@SenetNo) AND ((SenetIslem.Islem)='Giris'))", con);
            dap.SelectCommand.Parameters.AddWithValue("@SenetNo", AramaSenetnobox.Text);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[8].HeaderText = "Tutar";
                dataGridView1.Columns[0].HeaderText = "Kasa";
            }
            else
            {
                MessageBox.Show("Kayıt bulunamadı.", "Arama", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SenetGel();
            }
        }
        public void GiderKasaAra()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("select * from Kasa where ((Kasa.IsActive)=True) order by Kod", con);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            if (dt.Columns.Count != 0)
            {
                DataRow dr = dt.NewRow();
                dr[1] = "Lütfen Seçiniz";
                dt.Rows.InsertAt(dr, 0);
                AramaKasacomco.DataSource = dt;
                AramaKasacomco.DisplayMember = "Kod";
                AramaKasacomco.ValueMember = "KasaID";
            }
        }
        private void yeniKayıtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YeniSenetGiris YCG = new YeniSenetGiris();
            YCG.ShowDialog();
            SenetGel();
            GiderKasaAra();
        }
        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                SenetGirisGuncelle SGG = new SenetGirisGuncelle();
                SGG.ShowDialog();
                SenetGel();
                GiderKasaAra();
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir satırlı seçiniz.");
            }
        }
        private void SenetGiris_Load(object sender, EventArgs e)
        {
            GiderKasaAra();
            SenetGel();
            dataGridView1.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void KasaArama_Click(object sender, EventArgs e)
        {
            SenetGelKodaGore();
            AramaKasacomco.SelectedIndex = 0;
        }
        private void tutararabtn_Click(object sender, EventArgs e)
        {
            if (AramaTutarbox.Text == "")
            {
                MessageBox.Show("Lütfen geçerli bir tutar yazınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                SenetGelTutaraGore();
                AramaTutarbox.Text = "";
            }
        }
        private void tariharabtn_Click(object sender, EventArgs e)
        {
            SenetGelTariheGore();
            AramaTarihdate.Value = DateTime.Now;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                ID = Convert.ToInt32((dataGridView1.CurrentRow.Cells[1].Value));
            }
        }
        private void Senetbtnara_Click(object sender, EventArgs e)
        {
            SenetGelSenetNoGore();
            AramaSenetnobox.Text = "";
        }
        private void SenetGiris_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                YeniSenetCikis YCC = new YeniSenetCikis();
                YCC.ShowDialog();
                SenetGel();
            }
            if (e.KeyCode == Keys.F5)
            {
                SenetGel();
            }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                ID = Convert.ToInt32((dataGridView1.CurrentRow.Cells[1].Value));
                SenetGirisGuncelle SGG = new SenetGirisGuncelle();
                SGG.ShowDialog();
                SenetGel();
            }
        }
    }
}
