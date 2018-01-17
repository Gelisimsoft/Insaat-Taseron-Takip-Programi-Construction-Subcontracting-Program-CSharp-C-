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
    public partial class BankaCikisGuncelle : Form
    {
        public BankaCikisGuncelle()
        {
            InitializeComponent();
        }
        private static int GelenID, EskiCariID;
        private static string Aciklama, Tutar;
        OleDbConnection con = new OleDbConnection(connect.connectroad);
        private void BankaCikisGuncelle_Load(object sender, EventArgs e)
        {
            GelenID = Convert.ToInt32(BankaCikis.GelenID);
            GiderKasa();
            PersoenlGel();
            TedarikciGel();
            GelBilgi();
        }
        private void Guncelle()
        {
            if (turucombo.Text == "Personel Avans")
            {
                BankaIslemGuncelleAvans();
            }
            else
                if (turucombo.Text == "Firma Harcama")
                {
                    BankaIslemGuncelleHarcama();
                }
                else
                {
                    BankaIslemGuncelleFirma();
                }
        }
        private void Sil()
        {
            DialogResult sor = MessageBox.Show("Silmek istediğinize emin misiniz ?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sor == DialogResult.Yes)
            {
                if (turucombo.SelectedIndex == 0)
                {
                    BankaIslemSilAvans();
                }
                else
                {
                    BankaIslemSilHarcama();
                }
            }
        }
        private void GelBilgi()
        {
            OleDbCommand com = new OleDbCommand("SELECT BankaIslem.Niteligi, BankaIslem.Tarih, BankaIslem.Aciklama, BankaIslem.Gider, BankaIslem.KasaID, BankaIslem.PersonelID,BankaIslem.TedarikciID FROM BankaIslem WHERE (((BankaIslem.BankaIslemID)=@ID))", con);
            com.Parameters.AddWithValue("@ID", GelenID);
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
                        turucombo.Text = dr[0].ToString();
                        if (turucombo.SelectedIndex == 0)
                        {
                            personelcombo.SelectedValue = Convert.ToInt32(dr[5]);
                        }
                        harcamadate.Value = Convert.ToDateTime(dr[1]);
                        Aciklama = dr[2].ToString();
                        harcamaAciklama.Text = dr[2].ToString();
                        HarcamaTutar.Text = dr[3].ToString();
                        Tutar = dr[3].ToString();
                        Giderkasacombo.SelectedValue = Convert.ToInt32(dr[4]);
                        Caricombo.SelectedValue = Convert.ToInt32(dr[6]);
                        EskiCariID = Convert.ToInt32(dr[6]);
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
        private void BankaIslemGuncelleAvans()
        {
            if (personelcombo.SelectedIndex == 0)
            {
                MessageBox.Show("Lütfen personel seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                if (Aciklama == harcamaAciklama.Text)
                {
                    Aciklama = harcamaAciklama.Text;
                }
                else
                {
                    Aciklama = personelcombo.Text + " avans verildi. " + harcamaAciklama.Text;
                }
                string Nitelik = "Personel Avans";
                OleDbCommand comK = new OleDbCommand("update BankaIslem set Niteligi=@N,Tarih=@T,Aciklama=@A,Gider=@Gider,KasaID=@KID,PersonelID=@PID where BankaIslemID=@ID", con);
                comK.Parameters.AddWithValue("@N", Nitelik);
                comK.Parameters.AddWithValue("@T", harcamadate.Value.Date.Date);
                comK.Parameters.AddWithValue("@A", Aciklama);
                comK.Parameters.AddWithValue("@Gider", HarcamaTutar.Text);
                comK.Parameters.AddWithValue("@KID", Convert.ToInt32(Giderkasacombo.SelectedValue));
                comK.Parameters.AddWithValue("@PID", Convert.ToInt32(personelcombo.SelectedValue));
                comK.Parameters.AddWithValue("@ID", GelenID);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                try
                {
                    if (comK.ExecuteNonQuery() > 0)
                    {
                        OleDbCommand comS = new OleDbCommand("update Avanslar set Tarih=@Tarih,Aciklama=@A,Tutar=@T,personelID=@P where BankaIslemID=@KID", con);
                        comS.Parameters.AddWithValue("@Tarih", harcamadate.Value.Date.Date);
                        comS.Parameters.AddWithValue("@A", harcamaAciklama.Text);
                        comS.Parameters.AddWithValue("@T", HarcamaTutar.Text);
                        comS.Parameters.AddWithValue("@P", Convert.ToInt32(personelcombo.SelectedValue));
                        comS.Parameters.AddWithValue("@KID", GelenID);
                        if (comS.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Kayıt Güncellendi.", "Sonuç", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
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
        private void BankaIslemGuncelleHarcama()
        {
            string Nitelik = "Firma Harcama";
            OleDbCommand comK = new OleDbCommand("update BankaIslem set Niteligi=@N,Tarih=@T,Aciklama=@A,Gider=@Gider,KasaID=@KID where BankaIslemID=@ID", con);
            comK.Parameters.AddWithValue("@N", Nitelik);
            comK.Parameters.AddWithValue("@T", harcamadate.Value.Date.Date);
            comK.Parameters.AddWithValue("@A", harcamaAciklama.Text);
            comK.Parameters.AddWithValue("@Gider", HarcamaTutar.Text);
            comK.Parameters.AddWithValue("@KID", Convert.ToInt32(Giderkasacombo.SelectedValue));
            comK.Parameters.AddWithValue("@ID", GelenID);
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
            }
            con.Close();
        }
        private void BankaIslemGuncelleFirma()
        {
            int YeniCariID = Convert.ToInt32(Caricombo.SelectedValue);
            string Nitelik = "Cari Ödemesi";
            OleDbCommand comK = new OleDbCommand("update BankaIslem set Niteligi=@N,Tarih=@T,Aciklama=@A,Gider=@Gider,KasaID=@KID,TedarikciID=@TID where BankaIslemID=@ID", con);
            comK.Parameters.AddWithValue("@N", Nitelik);
            comK.Parameters.AddWithValue("@T", harcamadate.Value.Date.Date);
            comK.Parameters.AddWithValue("@A", harcamaAciklama.Text);
            comK.Parameters.AddWithValue("@Gider", HarcamaTutar.Text);
            comK.Parameters.AddWithValue("@KID", Convert.ToInt32(Giderkasacombo.SelectedValue));
            comK.Parameters.AddWithValue("@TID", Convert.ToInt32(Caricombo.SelectedValue));
            comK.Parameters.AddWithValue("@ID", GelenID);
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
                        comEski.Parameters.AddWithValue("@FT", HarcamaTutar.Text);
                        comEski.Parameters.AddWithValue("@ID", EskiCariID);
                        if (comEski.ExecuteNonQuery() > 0)
                        {
                            //OleDbCommand comOnceki = new OleDbCommand("update tedarikciler set Bakiye=Bakiye+@ST where ((tedarikciler.TedarikciID)=@ID);", con);
                            //comOnceki.Parameters.AddWithValue("@ST", Tutar);
                            //comOnceki.Parameters.AddWithValue("@ID", YeniCariID);
                            //if (comOnceki.ExecuteNonQuery() > 0)
                            //{
                            OleDbCommand comSonraki = new OleDbCommand("update tedarikciler set Bakiye=Bakiye-@ST where ((tedarikciler.TedarikciID)=@ID);", con);
                            comSonraki.Parameters.AddWithValue("@ST", HarcamaTutar.Text);
                            comSonraki.Parameters.AddWithValue("@ID", YeniCariID);
                            if (comSonraki.ExecuteNonQuery() > 0)
                            {
                                CariEkstresiGuncelle();
                            }
                            //}
                        }
                    }
                    else
                    {
                        OleDbCommand comOnceki = new OleDbCommand("update tedarikciler set Bakiye=Bakiye+@ST where ((tedarikciler.TedarikciID)=@ID);", con);
                        comOnceki.Parameters.AddWithValue("@ST", Tutar);
                        comOnceki.Parameters.AddWithValue("@ID", YeniCariID);
                        if (comOnceki.ExecuteNonQuery() > 0)
                        {
                            OleDbCommand comSonraki = new OleDbCommand("update tedarikciler set Bakiye=Bakiye-@ST where ((tedarikciler.TedarikciID)=@ID);", con);
                            comSonraki.Parameters.AddWithValue("@ST", HarcamaTutar.Text);
                            comSonraki.Parameters.AddWithValue("@ID", YeniCariID);
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
        private void BankaIslemSilAvans()
        {
            OleDbCommand comK = new OleDbCommand("delete from BankaIslem where ((BankaIslem.BankaIslemID)=@ID)", con);
            comK.Parameters.AddWithValue("@ID", GelenID);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                if (comK.ExecuteNonQuery() > 0)
                {
                    OleDbCommand comS = new OleDbCommand("delete from Avanslar where ((Avanslar.BankaIslemID)=@KID)", con);
                    comS.Parameters.AddWithValue("@KID", GelenID);
                    if (comS.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Kayıt Silindi.", "Sonuç", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
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
        private void BankaIslemSilHarcama()
        {
            OleDbCommand comK = new OleDbCommand("delete from BankaIslem where ((BankaIslem.BankaIslemID)=@ID)", con);
            comK.Parameters.AddWithValue("@ID", GelenID);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                if (comK.ExecuteNonQuery() > 0)
                {
                    OleDbCommand comOnceki = new OleDbCommand("update tedarikciler set Bakiye=Bakiye+@ST where ((tedarikciler.TedarikciID)=@ID);", con);
                    comOnceki.Parameters.AddWithValue("@ST", HarcamaTutar.Text);
                    comOnceki.Parameters.AddWithValue("@ID", Convert.ToInt32(Caricombo.SelectedValue));
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
                Giderkasacombo.DataSource = dt;
                Giderkasacombo.DisplayMember = "Kod";
                Giderkasacombo.ValueMember = "KasaID";
            }
        }
        private void PersoenlGel()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("select * from personeller where ((personeller.IsActive)=True) order by adsoyad", con);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            if (dt != null)
            {
                DataRow dr = dt.NewRow();
                dr[1] = "Lütfen Seçiniz";
                dt.Rows.InsertAt(dr, 0);
                personelcombo.DataSource = dt;
                personelcombo.DisplayMember = "adsoyad";
                personelcombo.ValueMember = "personelID";
            }
        }
        private void CariEkstresiGuncelle()
        {
            OleDbCommand comK = new OleDbCommand("Update CariEkstre set Aciklama=@A,OdemeTutari=@OT,TedarikciID=@TID where BankaID=@ID", con);
            comK.Parameters.AddWithValue("@A", Aciklama);
            comK.Parameters.AddWithValue("@OT", HarcamaTutar.Text);
            comK.Parameters.AddWithValue("@TID", Convert.ToInt32(Caricombo.SelectedValue));
            comK.Parameters.AddWithValue("@ID", GelenID);
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
            OleDbCommand comK = new OleDbCommand("delete from CariEkstre where BankaID=@ID", con);
            comK.Parameters.AddWithValue("@ID", GelenID);
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
        private void YeniKasa_Click(object sender, EventArgs e)
        {
            YeniKasa yk = new YeniKasa();
            yk.ShowDialog();
            GiderKasa();
        }
        private void YeniPersonel_Click(object sender, EventArgs e)
        {
            PersonelCariKarti PCK = new PersonelCariKarti();
            PCK.ShowDialog();
            PersoenlGel();
        }
        private void YeniCaribtn_Click(object sender, EventArgs e)
        {
            YeniTedarikci YT = new YeniTedarikci();
            YT.ShowDialog();
            TedarikciGel();
        }
        private void guncellebtn_Click(object sender, EventArgs e)
        {
            DialogResult sor = MessageBox.Show("Güncellemek istediğinize emin misiniz ?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sor == DialogResult.Yes)
            {
                if (Giderkasacombo.SelectedIndex == 0)
                {
                    MessageBox.Show("Lütfen kasa seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    Guncelle();
                    this.Close();
                }
            }
        }
        private void Silbtn_Click(object sender, EventArgs e)
        {
            Sil();
            this.Close();
        }
        private void turucombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (turucombo.Text == "Personel Avans")
            {
                personelcombo.Enabled = true;
                YeniPersonel.Enabled = true;
                YeniCaribtn.Enabled = false;
                Caricombo.Enabled = false;
            }
            else
                if (turucombo.Text == "Firma Harcama")
                {
                    personelcombo.Enabled = false;
                    YeniPersonel.Enabled = false;
                    YeniCaribtn.Enabled = false;
                    Caricombo.Enabled = false;
                }
                else
                {
                    personelcombo.Enabled = false;
                    YeniPersonel.Enabled = false;
                    YeniCaribtn.Enabled = true;
                    Caricombo.Enabled = true;
                }
        }
        private void personelcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            harcamaAciklama.Text = "";
        }
    }
}
