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
    public partial class FirmaFaturaTahukkukGuncelle : Form
    {
        public FirmaFaturaTahukkukGuncelle()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection(connect.connectroad);
        private static int ID, EskiCariID;
        private static string EskiTutar;
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
        }
        private void FaturaEkle()
        {
            int YeniCariID = Convert.ToInt32(Caricombo.SelectedValue);
            DialogResult sor = MessageBox.Show("Kayıt etmek istiyor musunuz ?", "Kayıt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sor == DialogResult.Yes)
            {
                OleDbCommand comK = new OleDbCommand("update FaturaTahukkuk set DuzenlemeTarihi=@DT,FaturaNo=@FN,FaturaTarihi=@FT,FaturaAciklama=@FA,Tutar=@Tutar,TedarikciID=@TID,KasaID=@KID where FaturaID=@ID", con);
                comK.Parameters.AddWithValue("@DT", DuzenlemeTarihi.Value.ToShortDateString());
                comK.Parameters.AddWithValue("@FN", FtNobox.Text);
                comK.Parameters.AddWithValue("@FT", FaturaTarihi.Value);
                comK.Parameters.AddWithValue("@FA", FtAciklama.Text);
                comK.Parameters.AddWithValue("@Tutar", FtTutaribox.Text);
                comK.Parameters.AddWithValue("@TID", Convert.ToInt32(Caricombo.SelectedValue));
                comK.Parameters.AddWithValue("@KID", Convert.ToInt32(Kasacombo.SelectedValue));
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
                            OleDbCommand comEski = new OleDbCommand("update tedarikciler set Bakiye=Bakiye-@FT where ((tedarikciler.TedarikciID)=@ID);", con);
                            comEski.Parameters.AddWithValue("@FT", EskiTutar);
                            comEski.Parameters.AddWithValue("@ID", EskiCariID);
                            if (comEski.ExecuteNonQuery() > 0)
                            {
                                OleDbCommand comT = new OleDbCommand("update tedarikciler set Bakiye=Bakiye+@FT where ((tedarikciler.TedarikciID)=@ID);", con);
                                comT.Parameters.AddWithValue("@FT", FtTutaribox.Text);
                                comT.Parameters.AddWithValue("@ID", YeniCariID);
                                if (comT.ExecuteNonQuery() > 0)
                                {
                                    CariEkstresiGuncelle();
                                }
                            }
                        }
                        else
                        {
                            OleDbCommand comEski = new OleDbCommand("update tedarikciler set Bakiye=Bakiye-@FT where ((tedarikciler.TedarikciID)=@ID);", con);
                            comEski.Parameters.AddWithValue("@FT", FtTutaribox.Text);
                            comEski.Parameters.AddWithValue("@ID", YeniCariID);
                            if (comEski.ExecuteNonQuery() > 0)
                            {
                                OleDbCommand comT = new OleDbCommand("update tedarikciler set Bakiye=Bakiye+@FT where ((tedarikciler.TedarikciID)=@ID);", con);
                                comT.Parameters.AddWithValue("@FT", FtTutaribox.Text);
                                comT.Parameters.AddWithValue("@ID", YeniCariID);
                                if (comT.ExecuteNonQuery() > 0)
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
        private void CariEkstresiGuncelle()
        {
            string Aciklama = "Fatura No : " + FtNobox.Text + " - Fatura Açıklama : " + FtAciklama.Text + " - Cari : " + Caricombo.Text;
            OleDbCommand comK = new OleDbCommand("Update CariEkstre set Tarih=@T,Aciklama=@A,FaturaTutari=@FT,TedarikciID=@TID where FaturaID=@ID", con);
            comK.Parameters.AddWithValue("@T", FaturaTarihi.Value);
            comK.Parameters.AddWithValue("@A", Aciklama);
            comK.Parameters.AddWithValue("@FT", FtTutaribox.Text);
            comK.Parameters.AddWithValue("@TID", Convert.ToInt32(Caricombo.SelectedValue));
            comK.Parameters.AddWithValue("@ID", ID);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                if (comK.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Kayıt Tamamlandı.", "Sonuç", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            OleDbCommand comK = new OleDbCommand("delete from CariEkstre where FaturaID=@ID", con);
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
        private void FaturaSil()
        {
            DialogResult sor = MessageBox.Show("Silmek istiyor musunuz ?", "Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sor == DialogResult.Yes)
            {
                OleDbCommand comK = new OleDbCommand("delete from FaturaTahukkuk where FaturaID=@ID", con);
                comK.Parameters.AddWithValue("@ID", ID);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                try
                {
                    if (comK.ExecuteNonQuery() > 0)
                    {
                        OleDbCommand comT = new OleDbCommand("update tedarikciler set Bakiye=Bakiye-@FT where ((tedarikciler.TedarikciID)=@ID);", con);
                        comT.Parameters.AddWithValue("@FT", FtTutaribox.Text);
                        comT.Parameters.AddWithValue("@ID", Convert.ToInt32(Caricombo.SelectedValue));
                        if (comT.ExecuteNonQuery() > 0)
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
            OleDbCommand com = new OleDbCommand("SELECT FaturaTahukkuk.DuzenlemeTarihi, FaturaTahukkuk.FaturaNo, FaturaTahukkuk.FaturaTarihi, FaturaTahukkuk.FaturaAciklama, FaturaTahukkuk.Tutar, FaturaTahukkuk.TedarikciID, FaturaTahukkuk.KasaID FROM FaturaTahukkuk WHERE (((FaturaTahukkuk.FaturaID)=[@ID]));", con);
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
                        DuzenlemeTarihi.Value = Convert.ToDateTime(dr[0]);
                        FtNobox.Text = dr[1].ToString();
                        FaturaTarihi.Value = Convert.ToDateTime(dr[2]);
                        FtAciklama.Text = dr[3].ToString();
                        FtTutaribox.Text = dr[4].ToString();
                        EskiTutar = dr[4].ToString();
                        Caricombo.SelectedValue = Convert.ToInt32(dr[5]);
                        EskiCariID = Convert.ToInt32(dr[5]);
                        Kasacombo.SelectedValue = Convert.ToInt32(dr[6]);
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
        private void FirmaFaturaTahukkukGuncelle_Load(object sender, EventArgs e)
        {
            ID = Convert.ToInt32(FirmaFaturaTahukkuk.ID);
            GiderKasa();
            TedarikciGel();
            GelBilgi();
        }
        private void SilBtn_Click(object sender, EventArgs e)
        {
            FaturaSil();
        }
    }
}
