using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace TaseronTakip
{
    public partial class FirmaFaturaTahukkuk : Form
    {
        public FirmaFaturaTahukkuk()
        {
            InitializeComponent();
        }
        public static int ID;
        OleDbConnection con = new OleDbConnection(connect.connectroad);
        public void TahakkukGelCariGore()
        {
            if (AramaCaricombo.SelectedIndex != 0)
            {
                OleDbDataAdapter dap = new OleDbDataAdapter("SELECT FaturaTahukkuk.FaturaID,FaturaTahukkuk.DuzenlemeTarihi, tedarikciler.unvan, FaturaTahukkuk.FaturaTarihi, FaturaTahukkuk.FaturaNo, FaturaTahukkuk.FaturaAciklama, FaturaTahukkuk.Tutar, Kasa.Tanim FROM (FaturaTahukkuk INNER JOIN tedarikciler ON FaturaTahukkuk.TedarikciID = tedarikciler.TedarikciID) INNER JOIN Kasa ON FaturaTahukkuk.KasaID = Kasa.KasaID WHERE (((FaturaTahukkuk.TedarikciID)=[@ID]));", con);
                dap.SelectCommand.Parameters.AddWithValue("@ID", Convert.ToInt32(AramaCaricombo.SelectedValue));
                DataTable dt = new DataTable();
                dap.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Düzenleme Tarihi";
                dataGridView1.Columns[2].HeaderText = "Ünvan";
                dataGridView1.Columns[3].HeaderText = "Fatura Tarihi";
                dataGridView1.Columns[4].HeaderText = "Fatura No";
                dataGridView1.Columns[5].HeaderText = "Fatura Açıklama";
                dataGridView1.Columns[6].HeaderText = "Tutar";
                dataGridView1.Columns[7].HeaderText = "Kasa";
                if (dt.Rows.Count != 0)
                {
                    dataGridView1.Rows[0].Selected = false;
                    //dataGridView1.AutoResizeColumns();
                    //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                else
                {
                    MessageBox.Show("Kayıt bulunamadı.", "Arama", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TahukkukGel();
                }
            }
            else
            {
                MessageBox.Show("Lütfen personel seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        public void TahakkukGelTariheGore()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("SELECT FaturaTahukkuk.FaturaID,FaturaTahukkuk.DuzenlemeTarihi, tedarikciler.unvan, FaturaTahukkuk.FaturaTarihi, FaturaTahukkuk.FaturaNo, FaturaTahukkuk.FaturaAciklama, FaturaTahukkuk.Tutar, Kasa.Tanim FROM (FaturaTahukkuk INNER JOIN tedarikciler ON FaturaTahukkuk.TedarikciID = tedarikciler.TedarikciID) INNER JOIN Kasa ON FaturaTahukkuk.KasaID = Kasa.KasaID WHERE (((FaturaTahukkuk.FaturaTarihi)=[@Tarih]));", con);
            dap.SelectCommand.Parameters.AddWithValue("@Tarih", AramaTarihdate.Value);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Düzenleme Tarihi";
            dataGridView1.Columns[2].HeaderText = "Ünvan";
            dataGridView1.Columns[3].HeaderText = "Fatura Tarihi";
            dataGridView1.Columns[4].HeaderText = "Fatura No";
            dataGridView1.Columns[5].HeaderText = "Fatura Açıklama";
            dataGridView1.Columns[6].HeaderText = "Tutar";
            dataGridView1.Columns[7].HeaderText = "Kasa";
            if (dt.Rows.Count != 0)
            {
                dataGridView1.Rows[0].Selected = false;
                //dataGridView1.AutoResizeColumns();
                //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            else
            {
                MessageBox.Show("Kayıt bulunamadı.", "Arama", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TahukkukGel();
            }
        }
        public void TahakkukGelFtNoGore()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("SELECT FaturaTahukkuk.FaturaID,FaturaTahukkuk.DuzenlemeTarihi, tedarikciler.unvan, FaturaTahukkuk.FaturaTarihi, FaturaTahukkuk.FaturaNo, FaturaTahukkuk.FaturaAciklama, FaturaTahukkuk.Tutar, Kasa.Tanim FROM (FaturaTahukkuk INNER JOIN tedarikciler ON FaturaTahukkuk.TedarikciID = tedarikciler.TedarikciID) INNER JOIN Kasa ON FaturaTahukkuk.KasaID = Kasa.KasaID WHERE (((FaturaTahukkuk.FaturaNo)=[@No]));", con);
            dap.SelectCommand.Parameters.AddWithValue("@No", FtNobox.Text);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Düzenleme Tarihi";
            dataGridView1.Columns[2].HeaderText = "Ünvan";
            dataGridView1.Columns[3].HeaderText = "Fatura Tarihi";
            dataGridView1.Columns[4].HeaderText = "Fatura No";
            dataGridView1.Columns[5].HeaderText = "Fatura Açıklama";
            dataGridView1.Columns[6].HeaderText = "Tutar";
            dataGridView1.Columns[7].HeaderText = "Kasa";
            if (dt.Rows.Count != 0)
            {
                dataGridView1.Rows[0].Selected = false;
                //dataGridView1.AutoResizeColumns();
                //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            else
            {
                MessageBox.Show("Kayıt bulunamadı.", "Arama", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TahukkukGel();
            }
        }
        public void TahukkukGel()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("SELECT FaturaTahukkuk.FaturaID,FaturaTahukkuk.DuzenlemeTarihi, tedarikciler.unvan, FaturaTahukkuk.FaturaTarihi, FaturaTahukkuk.FaturaNo, FaturaTahukkuk.FaturaAciklama, FaturaTahukkuk.Tutar, Kasa.Tanim FROM (FaturaTahukkuk INNER JOIN tedarikciler ON FaturaTahukkuk.TedarikciID = tedarikciler.TedarikciID) INNER JOIN Kasa ON FaturaTahukkuk.KasaID = Kasa.KasaID;", con);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Düzenleme Tarihi";
            dataGridView1.Columns[2].HeaderText = "Ünvan";
            dataGridView1.Columns[3].HeaderText = "Fatura Tarihi";
            dataGridView1.Columns[4].HeaderText = "Fatura No";
            dataGridView1.Columns[5].HeaderText = "Fatura Açıklama";
            dataGridView1.Columns[6].HeaderText = "Tutar";
            dataGridView1.Columns[7].HeaderText = "Kasa";
            if (dt.Rows.Count != 0)
            {
                dataGridView1.Rows[0].Selected = false;
                //dataGridView1.AutoResizeColumns();
                //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }
        private void CariGelArama()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("select * from tedarikciler where ((tedarikciler.IsActive)=True) order by unvan", con);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            if (dt != null)
            {
                DataRow dr = dt.NewRow();
                dr[1] = "Lütfen Seçiniz";
                dt.Rows.InsertAt(dr, 0);
                AramaCaricombo.DataSource = dt;
                AramaCaricombo.DisplayMember = "unvan";
                AramaCaricombo.ValueMember = "TedarikciID";
            }
        }
        private void FtNoGelArama()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("select * from tedarikciler where ((tedarikciler.IsActive)=True) order by unvan", con);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            if (dt != null)
            {
                DataRow dr = dt.NewRow();
                dr[1] = "Lütfen Seçiniz";
                dt.Rows.InsertAt(dr, 0);
                AramaCaricombo.DataSource = dt;
                AramaCaricombo.DisplayMember = "unvan";
                AramaCaricombo.ValueMember = "TedarikciID";
            }
        }
        private void yeniEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YeniFaturaTahukkuk YFT = new YeniFaturaTahukkuk();
            YFT.ShowDialog();
            TahukkukGel();
            CariGelArama();
        }
        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                FirmaFaturaTahukkukGuncelle FTTG = new FirmaFaturaTahukkukGuncelle();
                FTTG.ShowDialog();
                TahukkukGel();
                CariGelArama();
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir satırlı seçiniz.");
            }
        }
        private void FirmaFaturaTahukkuk_Load(object sender, EventArgs e)
        {
            CariGelArama();
            TahukkukGel();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void AraTarihbtn_Click(object sender, EventArgs e)
        {
            TahakkukGelTariheGore();
        }
        private void FtNoArabtn_Click(object sender, EventArgs e)
        {
            if (FtNobox.Text == "")
            {
                MessageBox.Show("Lütfen geçerli bir tutar yazınız.");
            }
            else
            {
                TahakkukGelFtNoGore();
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                ID = Convert.ToInt32((dataGridView1.CurrentRow.Cells[0].Value));
            }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                ID = Convert.ToInt32((dataGridView1.CurrentRow.Cells[0].Value));
                FirmaFaturaTahukkukGuncelle FTTG = new FirmaFaturaTahukkukGuncelle();
                FTTG.ShowDialog();
                TahukkukGel();
            }
        }
        private void cariarabtn_Click(object sender, EventArgs e)
        {
            if (AramaCaricombo.SelectedIndex != 0)
            {
                TahakkukGelCariGore();
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir satırlı seçiniz.");
            }
        }
        private void FirmaFaturaTahukkuk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                YeniFaturaTahukkuk YFT = new YeniFaturaTahukkuk();
                YFT.ShowDialog();
                TahukkukGel();
            }
            if (e.KeyCode == Keys.F5)
            {
                TahukkukGel();
            }
        }
    }
}
