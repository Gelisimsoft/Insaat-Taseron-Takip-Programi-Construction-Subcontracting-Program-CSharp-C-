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
    public partial class NakitCikis : Form
    {
        public NakitCikis()
        {
            InitializeComponent();
        }
        public static int GelenID;
        private static string Aciklama;
        OleDbConnection con = new OleDbConnection(connect.connectroad);
        public void NakitGel()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("SELECT Kasa.Tanim, NakitIslem.Niteligi, NakitIslem.Tarih, NakitIslem.Aciklama, NakitIslem.Gider, NakitIslem.NakitIslemID FROM Kasa INNER JOIN NakitIslem ON Kasa.KasaID = NakitIslem.KasaID WHERE (((NakitIslem.Niteligi)='Personel Avans')) OR (((NakitIslem.Niteligi)='Firma Harcama')) OR (((NakitIslem.Niteligi)='Cari Ödemesi'))", con);
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
        public void NakitGelKodaGore()
        {
            if (AramaKasakod.SelectedIndex != 0)
            {
                OleDbDataAdapter dap = new OleDbDataAdapter("SELECT Kasa.Tanim, NakitIslem.Niteligi, NakitIslem.Tarih, NakitIslem.Aciklama, NakitIslem.Gider, NakitIslem.NakitIslemID FROM NakitIslem INNER JOIN Kasa ON NakitIslem.KasaID = Kasa.KasaID WHERE (((NakitIslem.Niteligi)='Firma Harcama' Or (NakitIslem.Niteligi)='Personel Avans' Or (NakitIslem.Niteligi)='Cari Ödemesi') AND ((NakitIslem.KasaID)=@Kod));", con);
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
                    NakitGel();
                }
            }
            else
            {
                MessageBox.Show("Lütfen kasa seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        public void NakitGelPersoneleGore()
        {
            if (PersonelArama.SelectedIndex != 0)
            {
                OleDbDataAdapter dap = new OleDbDataAdapter("SELECT Kasa.Tanim, NakitIslem.Niteligi, NakitIslem.Tarih, NakitIslem.Aciklama, NakitIslem.Gider, NakitIslem.NakitIslemID FROM Kasa INNER JOIN NakitIslem ON Kasa.KasaID = NakitIslem.KasaID WHERE (((NakitIslem.Niteligi)='Firma Harcama' Or (NakitIslem.Niteligi)='Personel Avans' Or (NakitIslem.Niteligi)='Cari Ödemesi') AND ((NakitIslem.PersonelID)=@ID))", con);
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
                    NakitGel();
                }
            }
            else
            {
                MessageBox.Show("Lütfen personel seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        public void KasaGelTariheGore()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("SELECT Kasa.Tanim, NakitIslem.Niteligi, NakitIslem.Tarih, NakitIslem.Aciklama, NakitIslem.Gider, NakitIslem.NakitIslemID FROM Kasa INNER JOIN NakitIslem ON Kasa.KasaID = NakitIslem.KasaID WHERE (((NakitIslem.Niteligi)='Firma Harcama' Or (NakitIslem.Niteligi)='Personel Avans' Or (NakitIslem.Niteligi)='Cari Ödemesi') AND ((NakitIslem.Tarih)=@Tarih))", con);
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
        public void KasaGelTedarikciGore()
        {
            if (CaricomboAra.SelectedIndex != 0)
            {
                OleDbDataAdapter dap = new OleDbDataAdapter("SELECT Kasa.Tanim, NakitIslem.Niteligi, NakitIslem.Tarih, NakitIslem.Aciklama, NakitIslem.Gider, NakitIslem.NakitIslemID FROM Kasa INNER JOIN NakitIslem ON Kasa.KasaID = NakitIslem.KasaID WHERE (((NakitIslem.Niteligi)='Personel Avans' Or (NakitIslem.Niteligi)='Firma Harcama' Or (NakitIslem.Niteligi)='Cari Ödemesi') AND ((NakitIslem.[Tedarikc ID])=[@ID]));", con);
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
                    NakitGel();
                }
            }
            else
            {
                MessageBox.Show("Lütfen personel seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
        //private void NakitIslemGuncelleTahakkuk()
        //{
        //    if (personelcombo.SelectedIndex == 0)
        //    {
        //        MessageBox.Show("Lütfen personel seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //    }
        //    else
        //    {
        //        if (Aciklama == harcamaAciklama.Text)
        //        {
        //            Aciklama = harcamaAciklama.Text;
        //        }
        //        else
        //        {
        //            Aciklama = personelcombo.Text + " maaş ödemesi yapıldı. " + harcamaAciklama.Text;
        //        }
        //        string Nitelik = "Maaş Ödemesi";
        //        OleDbCommand comK = new OleDbCommand("update NakitIslem set Niteligi=@N,Tarih=@T,Aciklama=@A,Gider=@Gider,KasaID=@KID,PersonelID=@PID where NakitIslemID=@ID", con);
        //        comK.Parameters.AddWithValue("@N", Nitelik);
        //        comK.Parameters.AddWithValue("@T", harcamadate.Value.Date);
        //        comK.Parameters.AddWithValue("@A", Aciklama);
        //        comK.Parameters.AddWithValue("@Gider", HarcamaTutar.Text);
        //        comK.Parameters.AddWithValue("@KID", Convert.ToInt32(Giderkasacombo.SelectedValue));
        //        comK.Parameters.AddWithValue("@PID", Convert.ToInt32(personelcombo.SelectedValue));
        //        comK.Parameters.AddWithValue("@ID", GelenID);
        //        if (con.State == ConnectionState.Closed)
        //        {
        //            con.Open();
        //        }
        //        try
        //        {
        //            if (comK.ExecuteNonQuery() > 0)
        //            {
        //                OleDbCommand comS = new OleDbCommand("update Tahakkuk set Tarih=@Tarih,Ucret=@T,personelID=@P where NakitIslemID=@KID", con);
        //                comS.Parameters.AddWithValue("@Tarih", harcamadate.Value.Date);
        //                comS.Parameters.AddWithValue("@T", HarcamaTutar.Text);
        //                comS.Parameters.AddWithValue("@P", Convert.ToInt32(personelcombo.SelectedValue));
        //                comS.Parameters.AddWithValue("@KID", GelenID);
        //                if (comS.ExecuteNonQuery() > 0)
        //                {
        //                    MessageBox.Show("Kayıt Güncellendi.", "Sonuç", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                    this.Height = 525;
        //                    NakitGel();
        //                }
        //            }
        //        }
        //        catch (Exception Ex)
        //        {
        //            MessageBox.Show(Ex.ToString());
        //        }
        //        finally { con.Close(); }
        //    }
        //}
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
        private void KasaArama_Click(object sender, EventArgs e)
        {
            NakitGelKodaGore();
            AramaKasakod.SelectedIndex = 0;
        }
        private void Personelarabtn_Click(object sender, EventArgs e)
        {
            NakitGelPersoneleGore();
            PersonelArama.SelectedIndex = 0;
        }
        private void tariharabtn_Click(object sender, EventArgs e)
        {
            KasaGelTariheGore();
            Tariharadate.Value = DateTime.Now;
        }
        private void yeniKayıtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YeniNakitCikis YNC = new YeniNakitCikis();
            YNC.ShowDialog();
            NakitGel();
            GiderKasaAra();
            PersoenlGelAra();
            TedarikciGelAra();
        }
        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GelenID != 0)
            {
                NakitCikisGuncelle NCG = new NakitCikisGuncelle();
                NCG.ShowDialog();
                NakitGel();
                GiderKasaAra();
                PersoenlGelAra();
                TedarikciGelAra();
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir satırlı seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void NakitCikis_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                YeniNakitCikis YBC = new YeniNakitCikis();
                YBC.ShowDialog();
                NakitGel();
            }
            if (e.KeyCode == Keys.F5)
            {
                NakitGel();
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                GelenID = Convert.ToInt32((dataGridView1.CurrentRow.Cells[5].Value));
            }
        }
        private void vazgecbtn_Click(object sender, EventArgs e)
        {
            this.Height = 525;
        }
        private void NakitCikis_Load(object sender, EventArgs e)
        {
            NakitGel();
            GiderKasaAra();
            PersoenlGelAra();
            TedarikciGelAra();
            dataGridView1.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.AllCells;
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
                NakitCikisGuncelle NCG = new NakitCikisGuncelle();
                NCG.ShowDialog();
                NakitGel();
            }
        }
    }
}
