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
    public partial class YeniFaturaTahukkuk : Form
    {
        public YeniFaturaTahukkuk()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection(connect.connectroad);
        private static int FtID;
        public void GiderKasa()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("select * from Kasa where ((Kasa.IsActive)=True) order by Kod", con);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            if (dt != null)
            {
                DataRow dr = dt.NewRow();
                dr[1] = "Lütfen Seçiniz";
                dt.Rows.InsertAt(dr, 0);
                Kasacombo.DataSource = dt;
                Kasacombo.DisplayMember = "Kod";
                Kasacombo.ValueMember = "KasaID";
            }
        }
        public void TedarikciGel()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("select * from tedarikciler where ((tedarikciler.IsActive)=True) order by unvan", con);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            if (dt != null)
            {
                DataRow dr = dt.NewRow();
                dr[1] = "Lütfen Seçiniz";
                dt.Rows.InsertAt(dr, 0);
                Caricombo.DataSource = dt;
                Caricombo.DisplayMember = "unvan";
                Caricombo.ValueMember = "TedarikciID";
            }
        }
        private void Temizle()
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = string.Empty;
                }
            }
            FtAciklama.Clear();
            Kasacombo.SelectedIndex = 0;
            Caricombo.SelectedIndex = 0;
            FaturaTarihi.Value = DateTime.Now;
            DuzenlemeTarihi.Value = DateTime.Now;
        }
        private void FaturaEkle()
        {
            DialogResult sor = MessageBox.Show("Kayıt etmek istiyor musunuz ?", "Kayıt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sor == DialogResult.Yes)
            {
                OleDbCommand comK = new OleDbCommand("insert into FaturaTahukkuk(DuzenlemeTarihi,FaturaNo,FaturaTarihi,FaturaAciklama,Tutar,TedarikciID,KasaID) values(@DT,@FN,@FT,@FA,@Tutar,@TID,@KID)", con);
                comK.Parameters.AddWithValue("@DT", DuzenlemeTarihi.Value.Date);
                comK.Parameters.AddWithValue("@FN", FtNobox.Text);
                comK.Parameters.AddWithValue("@FT", FaturaTarihi.Value.Date);
                comK.Parameters.AddWithValue("@FA", FtAciklama.Text);
                comK.Parameters.AddWithValue("@Tutar", FtTutaribox.Text);
                comK.Parameters.AddWithValue("@TID", Convert.ToInt32(Caricombo.SelectedValue));
                comK.Parameters.AddWithValue("@KID", Convert.ToInt32(Kasacombo.SelectedValue));
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                try
                {
                    if (comK.ExecuteNonQuery() > 0)
                    {
                        OleDbCommand comID = new OleDbCommand("SELECT @@identity", con);
                        FtID = Convert.ToInt32(comID.ExecuteScalar());
                        if (FtID > 0)
                        {
                            OleDbCommand comT = new OleDbCommand("update tedarikciler set Bakiye=Bakiye+@FT where ((tedarikciler.TedarikciID)=@ID);", con);
                            comT.Parameters.AddWithValue("@FT", FtTutaribox.Text);
                            comT.Parameters.AddWithValue("@ID", Convert.ToInt32(Caricombo.SelectedValue));
                            if (comT.ExecuteNonQuery() > 0)
                            {
                                CariEkstresiEkle();
                            }
                        }
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.ToString());
                }
                finally
                {
                    con.Close();
                }
            }
        }
        private void CariEkstresiEkle()
        {
            string Aciklama = "Fatura No : " + FtNobox.Text + " - Fatura Açıklama : " + FtAciklama.Text + " - Cari : " + Caricombo.Text;
            OleDbCommand comK = new OleDbCommand("insert into CariEkstre(Tarih,Aciklama,FaturaTutari,OdemeTutari,Islem,TedarikciID,FaturaID) values(@T,@A,@FT,@OT,@Islem,@TID,@FID)", con);
            comK.Parameters.AddWithValue("@T", FaturaTarihi.Value.Date);
            comK.Parameters.AddWithValue("@A", Aciklama);
            comK.Parameters.AddWithValue("@FT", FtTutaribox.Text);
            comK.Parameters.AddWithValue("@OT", DBNull.Value);
            comK.Parameters.AddWithValue("@Islem", "Fatura");
            comK.Parameters.AddWithValue("@TID", Convert.ToInt32(Caricombo.SelectedValue));
            comK.Parameters.AddWithValue("@FID", FtID);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                if (comK.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Kayıt Tamamlandı.", "Sonuç", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Temizle();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }
        private void YeniFirmaTahukkuk_Load(object sender, EventArgs e)
        {
            GiderKasa();
            TedarikciGel();
        }
        private void KaydetBtn_Click(object sender, EventArgs e)
        {
            if (Kasacombo.SelectedIndex == 0)
            {
                MessageBox.Show("Lütfen Kasa Seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                if (Caricombo.SelectedIndex == 0)
                {
                    MessageBox.Show("Lütfen Cari Seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    FaturaEkle();
                }
            }
        }
        private void YeniKasaBtn_Click(object sender, EventArgs e)
        {
            YeniKasa YK = new YeniKasa();
            YK.ShowDialog();
            GiderKasa();
        }
        private void YeniCariBtn_Click(object sender, EventArgs e)
        {
            YeniTedarikci YT = new YeniTedarikci();
            YT.ShowDialog();
            TedarikciGel();
        }
    }
}
