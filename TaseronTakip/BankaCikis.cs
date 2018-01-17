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
    public partial class BankaCikis : Form
    {
        public BankaCikis()
        {
            InitializeComponent();
        }
        public static int GelenID;
        private static string Aciklama;
        OleDbConnection con = new OleDbConnection(connect.connectroad);
        public void BankaGel()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("SELECT Kasa.Tanim, BankaIslem.Niteligi, BankaIslem.Tarih, BankaIslem.Aciklama, BankaIslem.Gider, BankaIslem.BankaIslemID FROM Kasa INNER JOIN BankaIslem ON Kasa.KasaID = BankaIslem.KasaID WHERE (((BankaIslem.Niteligi)='Personel Avans')) OR (((BankaIslem.Niteligi)='Firma Harcama')) OR (((BankaIslem.Niteligi)='Cari Ödemesi'))", con);
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
        }
        public void BankaGelKodaGore()
        {
            if (AramaKasakod.SelectedIndex != 0)
            {
                OleDbDataAdapter dap = new OleDbDataAdapter("SELECT Kasa.Tanim, BankaIslem.Niteligi, BankaIslem.Tarih, BankaIslem.Aciklama, BankaIslem.Gider, BankaIslem.BankaIslemID FROM BankaIslem INNER JOIN Kasa ON BankaIslem.KasaID = Kasa.KasaID WHERE (((BankaIslem.KasaID)=[@Kod])) AND ((((BankaIslem.Niteligi)='Firma Harcama')) OR (((BankaIslem.Niteligi)='Cari Ödemesi')) OR (((BankaIslem.Niteligi)='Personel Avans')));", con);
                dap.SelectCommand.Parameters.AddWithValue("@Kod", Convert.ToInt32(AramaKasakod.SelectedValue));
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
            else
            {
                MessageBox.Show("Lütfen kasa seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        public void BankaGelPersoneleGore()
        {
            if (PersonelArama.SelectedIndex != 0)
            {
                OleDbDataAdapter dap = new OleDbDataAdapter("SELECT Kasa.Tanim, BankaIslem.Niteligi, BankaIslem.Tarih, BankaIslem.Aciklama, BankaIslem.Gider, BankaIslem.BankaIslemID FROM Kasa INNER JOIN BankaIslem ON Kasa.KasaID = BankaIslem.KasaID WHERE (((BankaIslem.Niteligi)='Firma Harcama' Or (BankaIslem.Niteligi)='Cari Ödemesi' Or (BankaIslem.Niteligi)='Personel Avans') AND ((BankaIslem.PersonelID)=@ID));", con);
                dap.SelectCommand.Parameters.AddWithValue("@ID", Convert.ToInt32(PersonelArama.SelectedValue));
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
            else
            {
                MessageBox.Show("Lütfen personel seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        public void KasaGelTariheGore()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("SELECT Kasa.Tanim, BankaIslem.Niteligi, BankaIslem.Tarih, BankaIslem.Aciklama, BankaIslem.Gider, BankaIslem.BankaIslemID FROM Kasa INNER JOIN BankaIslem ON Kasa.KasaID = BankaIslem.KasaID WHERE (((BankaIslem.Tarih)=@Tarih)) AND  ((((BankaIslem.Niteligi)='Firma Harcama')) OR (((BankaIslem.Niteligi)='Cari Ödemesi')) OR (((BankaIslem.Niteligi)='Personel Avans')));", con);
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
        public void KasaGelTedarikciGore()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("SELECT Kasa.Tanim, BankaIslem.Niteligi, BankaIslem.Tarih, BankaIslem.Aciklama, BankaIslem.Gider, BankaIslem.BankaIslemID FROM Kasa INNER JOIN BankaIslem ON Kasa.KasaID = BankaIslem.KasaID WHERE (((BankaIslem.Niteligi)='Personel Avans' Or (BankaIslem.Niteligi)='Firma Harcama' Or (BankaIslem.Niteligi)='Cari Ödemesi') AND ((BankaIslem.TedarikciID)=[@ID]));", con);
            dap.SelectCommand.Parameters.AddWithValue("@ID", Convert.ToInt32(CaricomboAra.SelectedValue));
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
        public void GiderKasaAra()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("select * from Kasa where ((Kasa.IsActive)=True) order by Kod", con);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            if (dt != null)
            {
                DataRow dr = dt.NewRow();
                dr[1] = "Lütfen Seçiniz";
                dt.Rows.InsertAt(dr, 0);
                AramaKasakod.DataSource = dt;
                AramaKasakod.DisplayMember = "Kod";
                AramaKasakod.ValueMember = "KasaID";
            }
        }
        private void PersoenlGelAra()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("select * from personeller where ((personeller.IsActive)=True) order by adsoyad", con);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            if (dt != null)
            {
                DataRow dr = dt.NewRow();
                dr[1] = "Lütfen Seçiniz";
                dt.Rows.InsertAt(dr, 0);
                PersonelArama.DataSource = dt;
                PersonelArama.DisplayMember = "adsoyad";
                PersonelArama.ValueMember = "personelID";
            }
        }
        public void TedarikciGelAra()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("select * from tedarikciler where ((tedarikciler.IsActive)=True) order by unvan", con);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            if (dt != null)
            {
                DataRow dr = dt.NewRow();
                dr[1] = "Lütfen Seçiniz";
                dt.Rows.InsertAt(dr, 0);
                CaricomboAra.DataSource = dt;
                CaricomboAra.DisplayMember = "unvan";
                CaricomboAra.ValueMember = "TedarikciID";
            }
        }
        private void BankaCikis_Load(object sender, EventArgs e)
        {
            BankaGel();
            GiderKasaAra();
            PersoenlGelAra();
            TedarikciGelAra();
            dataGridView1.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void KasaArama_Click(object sender, EventArgs e)
        {
            BankaGelKodaGore();
            AramaKasakod.SelectedIndex = 0;
        }
        private void Personelarabtn_Click(object sender, EventArgs e)
        {
            BankaGelPersoneleGore();
            PersonelArama.SelectedIndex = 0;
        }
        private void tariharabtn_Click(object sender, EventArgs e)
        {
            KasaGelTariheGore();
            Tariharadate.Value = DateTime.Now;
        }
        private void yeniKayıtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YeniBankaCikis YBC = new YeniBankaCikis();
            YBC.ShowDialog();
            BankaGel();
            GiderKasaAra();
            PersoenlGelAra();
            TedarikciGelAra();
        }
        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GelenID != 0)
            {
                BankaCikisGuncelle BCG = new BankaCikisGuncelle();
                BCG.ShowDialog();
                BankaGel();
                GiderKasaAra();
                PersoenlGelAra();
                TedarikciGelAra();
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir satırlı seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void BankaCikis_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                YeniBankaCikis YBC = new YeniBankaCikis();
                YBC.ShowDialog();
                BankaGel();
            }
            if (e.KeyCode == Keys.F5)
            {
                BankaGel();
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                GelenID = Convert.ToInt32((dataGridView1.CurrentRow.Cells[5].Value));
            }
        }
        private void tedarikciarabtn_Click(object sender, EventArgs e)
        {
            KasaGelTedarikciGore();
            CaricomboAra.SelectedIndex = 0;
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                GelenID = Convert.ToInt32((dataGridView1.CurrentRow.Cells[5].Value));
                BankaCikisGuncelle BCG = new BankaCikisGuncelle();
                BCG.ShowDialog();
                BankaGel();
            }
        }
    }
}
