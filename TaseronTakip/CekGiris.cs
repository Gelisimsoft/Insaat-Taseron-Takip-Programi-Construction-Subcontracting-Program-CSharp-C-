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
    public partial class CekGiris : Form
    {
        public CekGiris()
        {
            InitializeComponent();
        }
        public static int ID;
        OleDbConnection con = new OleDbConnection(connect.connectroad);
        public void CekGel()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("SELECT Kasa.Tanim, CekIslem.CekID, CekIslem.KayitTarihi, CekIslem.DuzenlemeTarihi, tedarikciler.unvan, CekIslem.Aciklama, CekIslem.CekNo, CekIslem.Banka, CekIslem.Sube, CekIslem.HesapNo, CekIslem.VadeTarihi, CekIslem.Giris FROM Kasa INNER JOIN (tedarikciler INNER JOIN CekIslem ON tedarikciler.TedarikciID = CekIslem.TedarikciID) ON Kasa.KasaID = CekIslem.KasaID WHERE (((CekIslem.Islem)='Giris'))", con);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[0].HeaderText = "Kasa";
            dataGridView1.Columns[11].HeaderText = "Tutar";
            if (dt.Rows.Count != 0)
            {
                dataGridView1.Rows[0].Selected = false;
                //dataGridView1.AutoResizeColumns();
                //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }
        public void CekGelKodaGore()
        {
            if (AramaKasacomco.SelectedIndex != 0)
            {
                OleDbDataAdapter dap = new OleDbDataAdapter("SELECT Kasa.Tanim, CekIslem.CekID, CekIslem.KayitTarihi, CekIslem.DuzenlemeTarihi, tedarikciler.unvan, CekIslem.Aciklama, CekIslem.CekNo, CekIslem.Banka, CekIslem.Sube, CekIslem.HesapNo, CekIslem.VadeTarihi, CekIslem.Giris FROM Kasa INNER JOIN (tedarikciler INNER JOIN CekIslem ON tedarikciler.TedarikciID = CekIslem.TedarikciID) ON Kasa.KasaID = CekIslem.KasaID WHERE (((CekIslem.KasaID)=@Kod) AND ((CekIslem.Islem)='Giris'));", con);
                dap.SelectCommand.Parameters.AddWithValue("@Kod", Convert.ToInt32(AramaKasacomco.SelectedValue));
                DataTable dt = new DataTable();
                dap.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[1].Visible = false;
                    dataGridView1.Columns[11].HeaderText = "Tutar";
                    dataGridView1.Columns[0].HeaderText = "Kasa";
                }
                else
                {
                    MessageBox.Show("Kayıt bulunamadı.", "Arama", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CekGel();
                }
            }
            else
            {
                MessageBox.Show("Lütfen kasa seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        public void CekGelTariheGore()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("SELECT Kasa.Tanim, CekIslem.CekID, CekIslem.KayitTarihi, CekIslem.DuzenlemeTarihi, tedarikciler.unvan, CekIslem.Aciklama, CekIslem.CekNo, CekIslem.Banka, CekIslem.Sube, CekIslem.HesapNo, CekIslem.VadeTarihi, CekIslem.Giris FROM Kasa INNER JOIN (tedarikciler INNER JOIN CekIslem ON tedarikciler.TedarikciID = CekIslem.TedarikciID) ON Kasa.KasaID = CekIslem.KasaID WHERE (((CekIslem.VadeTarihi)=@Tarih) AND ((CekIslem.Islem)='Giris'))", con);
            dap.SelectCommand.Parameters.AddWithValue("@Tarih", AramaTarihdate.Value);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[11].HeaderText = "Tutar";
                dataGridView1.Columns[0].HeaderText = "Kasa";
            }
            else
            {
                MessageBox.Show("Kayıt bulunamadı.", "Arama", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CekGel();
            }
        }
        public void CekGelTutaraGore()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("SELECT Kasa.Tanim, CekIslem.CekID, CekIslem.KayitTarihi, CekIslem.DuzenlemeTarihi, tedarikciler.unvan, CekIslem.Aciklama, CekIslem.CekNo, CekIslem.Banka, CekIslem.Sube, CekIslem.HesapNo, CekIslem.VadeTarihi, CekIslem.Giris FROM Kasa INNER JOIN (tedarikciler INNER JOIN CekIslem ON tedarikciler.TedarikciID = CekIslem.TedarikciID) ON Kasa.KasaID = CekIslem.KasaID WHERE (((CekIslem.Giris)=@Tutar) AND ((CekIslem.Islem)='Giris'))", con);
            dap.SelectCommand.Parameters.AddWithValue("@Tutar", Convert.ToDouble(AramaTutarbox.Text));
            DataTable dt = new DataTable();
            dap.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[11].HeaderText = "Tutar";
                dataGridView1.Columns[0].HeaderText = "Kasa";
            }
            else
            {
                MessageBox.Show("Kayıt bulunamadı.", "Arama", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CekGel();
            }
        }
        public void CekGelCekNoGore()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("SELECT Kasa.Tanim, CekIslem.CekID, CekIslem.KayitTarihi, CekIslem.DuzenlemeTarihi, tedarikciler.unvan, CekIslem.Aciklama, CekIslem.CekNo, CekIslem.Banka, CekIslem.Sube, CekIslem.HesapNo, CekIslem.VadeTarihi, CekIslem.Giris FROM Kasa INNER JOIN (tedarikciler INNER JOIN CekIslem ON tedarikciler.TedarikciID = CekIslem.TedarikciID) ON Kasa.KasaID = CekIslem.KasaID WHERE (((CekIslem.CekNo)=@CekNo) AND ((CekIslem.Islem)='Giris'))", con);
            dap.SelectCommand.Parameters.AddWithValue("@CekNo", AramaCeknobox.Text);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[11].HeaderText = "Tutar";
                dataGridView1.Columns[0].HeaderText = "Kasa";
            }
            else
            {
                MessageBox.Show("Kayıt bulunamadı.", "Arama", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CekGel();
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
            YeniCekGiris YCG = new YeniCekGiris();
            YCG.ShowDialog();
            CekGel();
            GiderKasaAra();
        }
        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                CekGirisGuncelle CGG = new CekGirisGuncelle();
                CGG.ShowDialog();
                CekGel();
                GiderKasaAra();
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir satırlı seçiniz.");
            }
        }
        private void CekGiris_Load(object sender, EventArgs e)
        {
            GiderKasaAra();
            CekGel();
            dataGridView1.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void KasaArama_Click(object sender, EventArgs e)
        {
            CekGelKodaGore();
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
                CekGelTutaraGore();
                AramaTutarbox.Text = "";
            }
        }
        private void tariharabtn_Click(object sender, EventArgs e)
        {
            CekGelTariheGore();
            AramaTarihdate.Value = DateTime.Now;
        }
        private void Cekbtnara_Click(object sender, EventArgs e)
        {
            CekGelCekNoGore();
            AramaCeknobox.Text = "";
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                ID = Convert.ToInt32((dataGridView1.CurrentRow.Cells[1].Value));
            }
        }
        private void CekGiris_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                YeniCekGiris YCG = new YeniCekGiris();
                YCG.ShowDialog();
                CekGel();
            }
            if (e.KeyCode == Keys.F5)
            {
                CekGel();
            }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                ID = Convert.ToInt32((dataGridView1.CurrentRow.Cells[1].Value));
                CekGirisGuncelle YCG = new CekGirisGuncelle();
                YCG.ShowDialog();
                CekGel();
            }
        }
    }
}
