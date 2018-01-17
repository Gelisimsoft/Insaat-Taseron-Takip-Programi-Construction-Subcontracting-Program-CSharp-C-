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
    public partial class YeniCekCikis : Form
    {
        public YeniCekCikis()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection(connect.connectroad);
        private static int ID;
        public void GelirCek()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("select * from Kasa where ((Kasa.IsActive)=True) order by Kod", con);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            if (dt != null)
            {
                DataRow dr = dt.NewRow();
                dr[1] = "Lütfen Seçiniz";
                dt.Rows.InsertAt(dr, 0);
                GeliKasaCombo.DataSource = dt;
                GeliKasaCombo.DisplayMember = "Kod";
                GeliKasaCombo.ValueMember = "KasaID";
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
            CekAciklama.Clear();
            GeliKasaCombo.SelectedIndex = 0;
            TedarikcicomboCek.SelectedIndex = 0;
            CekDuzenleme.Value = DateTime.Now;
            Cekvadetarihi.Value = DateTime.Now;
        }
        public void TedarikciCek()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("select * from tedarikciler where ((tedarikciler.IsActive)=True) order by unvan", con);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            if (dt != null)
            {
                DataRow dr = dt.NewRow();
                dr[1] = "Lütfen Seçiniz";
                dt.Rows.InsertAt(dr, 0);
                TedarikcicomboCek.DataSource = dt;
                TedarikcicomboCek.DisplayMember = "unvan";
                TedarikcicomboCek.ValueMember = "TedarikciID";
            }
        }
        private void CariEkstresiEkle()
        {
            string Aciklama = "Çek Verildi (Çek No : " + ceknumarasi.Text + " - Ödeme Tarihi : " + Cekvadetarihi.Value + ")";
            OleDbCommand comK = new OleDbCommand("insert into CariEkstre(Tarih,Aciklama,FaturaTutari,OdemeTutari,Islem,TedarikciID,CekID) values(@T,@A,@FT,@OT,@Islem,@TID,@CID)", con);
            comK.Parameters.AddWithValue("@T", CekDuzenleme.Value.Date);
            comK.Parameters.AddWithValue("@A", Aciklama);
            comK.Parameters.AddWithValue("@FT", DBNull.Value);
            comK.Parameters.AddWithValue("@OT", Cektutar.Text);
            comK.Parameters.AddWithValue("@Islem", "Çek");
            comK.Parameters.AddWithValue("@TID", Convert.ToInt32(TedarikcicomboCek.SelectedValue));
            comK.Parameters.AddWithValue("@CID", ID);
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
        private void CekIslemEkle()
        {
            DialogResult sor = MessageBox.Show("Kayıt etmek istiyor musunuz ?", "Kayıt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sor == DialogResult.Yes)
            {
                OleDbCommand comCek = new OleDbCommand("insert into CekIslem(KayitTarihi,DuzenlemeTarihi,TedarikciID,Aciklama,CekNo,Banka,Sube,HesapNo,VadeTarihi,Giris,Cikis,KasaID,Islem) values(@KT,@DT,@F,@A,@CN,@B,@S,@HN,@VT,@G,@C,@KID,@Islem)", con);
                comCek.Parameters.AddWithValue("@KT", DateTime.Now.ToShortDateString());
                comCek.Parameters.AddWithValue("@DT", CekDuzenleme.Value.Date);
                comCek.Parameters.AddWithValue("@F", Convert.ToInt32(TedarikcicomboCek.SelectedValue));
                comCek.Parameters.AddWithValue("@A", CekAciklama.Text);
                comCek.Parameters.AddWithValue("@CN", ceknumarasi.Text);
                comCek.Parameters.AddWithValue("@B", banka.Text);
                comCek.Parameters.AddWithValue("@S", sube.Text);
                comCek.Parameters.AddWithValue("@HN", hesapno.Text);
                comCek.Parameters.AddWithValue("@VT", Cekvadetarihi.Value);
                comCek.Parameters.AddWithValue("@G", DBNull.Value);
                comCek.Parameters.AddWithValue("@C", Cektutar.Text);
                comCek.Parameters.AddWithValue("@KID", Convert.ToInt32(GeliKasaCombo.SelectedValue));
                comCek.Parameters.AddWithValue("@Islem", "Cikis");
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                try
                {
                    if (comCek.ExecuteNonQuery() > 0)
                    {
                        OleDbCommand comID = new OleDbCommand("SELECT @@identity", con);
                        ID = Convert.ToInt32(comID.ExecuteScalar());
                        if (ID > 0)
                        {
                            OleDbCommand comT = new OleDbCommand("update tedarikciler set Bakiye=Bakiye-@ST where ((tedarikciler.TedarikciID)=@ID);", con);
                            comT.Parameters.AddWithValue("@ST", Cektutar.Text);
                            comT.Parameters.AddWithValue("@ID", Convert.ToInt32(TedarikcicomboCek.SelectedValue));
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
        private void yenikasabtn_Click(object sender, EventArgs e)
        {
            YeniKasa yk = new YeniKasa();
            yk.ShowDialog();
            GelirCek();
        }
        private void YeniTedarikciCek_Click(object sender, EventArgs e)
        {
            TedarikciCariKarti TCK = new TedarikciCariKarti();
            TCK.ShowDialog();
            TedarikciCek();
        }
        private void CekKaydet_Click(object sender, EventArgs e)
        {
            if (GeliKasaCombo.SelectedIndex == 0)
            {
                MessageBox.Show("Lütfen kasa seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                if (TedarikcicomboCek.SelectedIndex == 0)
                {
                    MessageBox.Show("Lütfen tedarikçi seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    CekIslemEkle();
                }
            }
        }
        private void YeniCekCikis_Load(object sender, EventArgs e)
        {
            GelirCek();
            TedarikciCek();
        }
    }
}
