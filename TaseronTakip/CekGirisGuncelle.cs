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
    public partial class CekGirisGuncelle : Form
    {
        public CekGirisGuncelle()
        {
            InitializeComponent();
        }
        private static int ID, EskiCariID;
        private static string Tutar;
        OleDbConnection con = new OleDbConnection(connect.connectroad);
        public void GiderKasa()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("select * from Kasa where ((Kasa.IsActive)=True) order by Kod", con);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            if (dt.Columns.Count != 0)
            {
                DataRow dr = dt.NewRow();
                dr[1] = "Lütfen Seçiniz";
                dt.Rows.InsertAt(dr, 0);
                kasaGuncellecombo.DataSource = dt;
                kasaGuncellecombo.DisplayMember = "Kod";
                kasaGuncellecombo.ValueMember = "KasaID";
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
                TedarikcicomboCek.DataSource = dt;
                TedarikcicomboCek.DisplayMember = "unvan";
                TedarikcicomboCek.ValueMember = "TedarikciID";
            }
        }
        private void CekIslemGuncelle()
        {
            int YeniCariID = Convert.ToInt32(TedarikcicomboCek.SelectedValue);
            DialogResult sor = MessageBox.Show("Güncellemek istediğinize emin misiniz ?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sor == DialogResult.Yes)
            {
                OleDbCommand comK = new OleDbCommand("update CekIslem set DuzenlemeTarihi=@DT,TedarikciID=@F,Aciklama=@Aciklama,CekNo=@CN,Banka=@B,Sube=@S,HesapNo=@HN,VadeTarihi=@VT,Giris=@Giris,KasaID=@KID where CekIslem.CekID=@ID", con);
                comK.Parameters.AddWithValue("@DT", CekDuzenleme.Value.Date);
                comK.Parameters.AddWithValue("@F", Convert.ToInt32(TedarikcicomboCek.SelectedValue));
                comK.Parameters.AddWithValue("@Aciklama", CekAciklama.Text);
                comK.Parameters.AddWithValue("@CN", ceknumarasi.Text);
                comK.Parameters.AddWithValue("@B", banka.Text);
                comK.Parameters.AddWithValue("@S", sube.Text);
                comK.Parameters.AddWithValue("@HN", hesapno.Text);
                comK.Parameters.AddWithValue("@VT", Cekvadetarihi.Value.Date);
                comK.Parameters.AddWithValue("@Giris", Cektutar.Text);
                comK.Parameters.AddWithValue("@KID", Convert.ToInt32(kasaGuncellecombo.SelectedValue));
                comK.Parameters.AddWithValue("@ID", ID);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                try
                {
                    if (comK.ExecuteNonQuery() > 0)
                    {
                        if (EskiCariID != YeniCariID)
                        {
                            OleDbCommand comEski = new OleDbCommand("update tedarikciler set Bakiye=Bakiye+@FT where ((tedarikciler.TedarikciID)=@ID);", con);
                            comEski.Parameters.AddWithValue("@FT", Tutar);
                            comEski.Parameters.AddWithValue("@ID", EskiCariID);
                            if (comEski.ExecuteNonQuery() > 0)
                            {
                                OleDbCommand comSonraki = new OleDbCommand("update tedarikciler set Bakiye=Bakiye-@ST where ((tedarikciler.TedarikciID)=@ID);", con);
                                comSonraki.Parameters.AddWithValue("@ST", Cektutar.Text);
                                comSonraki.Parameters.AddWithValue("@ID", YeniCariID);
                                if (comSonraki.ExecuteNonQuery() > 0)
                                {
                                    CariEkstresiGuncelle();
                                }
                            }
                        }
                        else
                        {
                            OleDbCommand comOnceki = new OleDbCommand("update tedarikciler set Bakiye=Bakiye+@ST where ((tedarikciler.TedarikciID)=@ID);", con);
                            comOnceki.Parameters.AddWithValue("@ST", Tutar);
                            comOnceki.Parameters.AddWithValue("@ID", Convert.ToInt32(TedarikcicomboCek.SelectedValue));
                            if (comOnceki.ExecuteNonQuery() > 0)
                            {
                                OleDbCommand comSonraki = new OleDbCommand("update tedarikciler set Bakiye=Bakiye-@ST where ((tedarikciler.TedarikciID)=@ID);", con);
                                comSonraki.Parameters.AddWithValue("@ST", Cektutar.Text);
                                comSonraki.Parameters.AddWithValue("@ID", Convert.ToInt32(TedarikcicomboCek.SelectedValue));
                                if (comSonraki.ExecuteNonQuery() > 0)
                                {
                                    CariEkstresiGuncelle();
                                }
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
        private void CekIslemSil()
        {
            DialogResult sor = MessageBox.Show("Silmek istediğinize emin misiniz ?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sor == DialogResult.Yes)
            {
                OleDbCommand comK = new OleDbCommand("delete from CekIslem where CekID=@ID", con);
                comK.Parameters.AddWithValue("@ID", ID);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                try
                {
                    if (comK.ExecuteNonQuery() > 0)
                    {
                        OleDbCommand comOnceki = new OleDbCommand("update tedarikciler set Bakiye=Bakiye+@ST where ((tedarikciler.TedarikciID)=@ID);", con);
                        comOnceki.Parameters.AddWithValue("@ST", Cektutar.Text);
                        comOnceki.Parameters.AddWithValue("@ID", Convert.ToInt32(TedarikcicomboCek.SelectedValue));
                        if (comOnceki.ExecuteNonQuery() > 0)
                        {
                            CariEkstresiSil();
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
        private void GelBilgi()
        {
            OleDbCommand com = new OleDbCommand("SELECT CekIslem.DuzenlemeTarihi, CekIslem.TedarikciID, CekIslem.Aciklama, CekIslem.CekNo, CekIslem.Banka, CekIslem.Sube, CekIslem.HesapNo, CekIslem.VadeTarihi, CekIslem.Giris, CekIslem.KasaID FROM CekIslem WHERE (((CekIslem.CekID)=@ID))", con);
            com.Parameters.AddWithValue("@ID", ID);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            OleDbDataReader dr = com.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (dr.HasRows)
                    {
                        CekDuzenleme.Value = Convert.ToDateTime(dr[0]);
                        TedarikcicomboCek.SelectedValue = Convert.ToInt32(dr[1]);
                        EskiCariID = Convert.ToInt32(dr[1]);
                        CekAciklama.Text = dr[2].ToString();
                        ceknumarasi.Text = dr[3].ToString();
                        banka.Text = dr[4].ToString();
                        sube.Text = dr[5].ToString();
                        hesapno.Text = dr[6].ToString();
                        Cekvadetarihi.Value = Convert.ToDateTime(dr[7]);
                        Cektutar.Text = dr[8].ToString();
                        Tutar = dr[8].ToString();
                        kasaGuncellecombo.SelectedValue = Convert.ToInt32(dr[9]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
                dr.Close();
            }
        }
        private void CariEkstresiGuncelle()
        {
            string Aciklama = "Çek Verildi (Çek No : " + ceknumarasi.Text + " - Ödeme Tarihi : " + Cekvadetarihi.Value + ")";
            OleDbCommand comK = new OleDbCommand("Update CariEkstre set Tarih=@T,Aciklama=@A,OdemeTutari=@OT,TedarikciID=@TID where CekID=@CID", con);
            comK.Parameters.AddWithValue("@T", CekDuzenleme.Value.Date);
            comK.Parameters.AddWithValue("@A", Aciklama);
            comK.Parameters.AddWithValue("@OT", Cektutar.Text);
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
                    MessageBox.Show("Kayıt Güncellendi.", "Sonuç", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
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
        private void CariEkstresiSil()
        {
            OleDbCommand comK = new OleDbCommand("delete from CariEkstre where CekID=@ID", con);
            comK.Parameters.AddWithValue("@ID", ID);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                if (comK.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Kayıt Silindi.", "Sonuç", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
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
        private void CekGirisGuncelle_Load(object sender, EventArgs e)
        {
            ID = Convert.ToInt32(CekGiris.ID);
            GiderKasa();
            TedarikciGel();
            GelBilgi();
        }
        private void YeniKasa_Click(object sender, EventArgs e)
        {
            YeniKasa Yk = new YeniKasa();
            Yk.ShowDialog();
            GiderKasa();
        }
        private void YeniTedarikciCek_Click(object sender, EventArgs e)
        {
            YeniTedarikci YT = new YeniTedarikci();
            YT.ShowDialog();
            TedarikciGel();
        }
        private void guncellebtn_Click(object sender, EventArgs e)
        {
            if (kasaGuncellecombo.SelectedIndex != 0)
            {
                CekIslemGuncelle();
            }
            else
            {
                MessageBox.Show("Lütfen kasa seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void Silbtn_Click(object sender, EventArgs e)
        {
            CekIslemSil();
        }
    }
}
