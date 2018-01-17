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
    public partial class YeniBankaCikis : Form
    {
        public YeniBankaCikis()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection(connect.connectroad);
        private static int ID;
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
        private void Temizle()
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = string.Empty;
                }
            }
            Aciklama.Clear();
            Giderkasacombo.SelectedIndex = 0;
            personelcombo.SelectedIndex = 0;
            turucombo.SelectedIndex = 0;
            Caricombo.SelectedIndex = 0;
            turucombo.Text = "Lütfen Seçiniz";
        }
        private void CariEkstresiEkle()
        {
            string Aciklama = "Bankadan Ödendi.";
            OleDbCommand comK = new OleDbCommand("insert into CariEkstre(Tarih,Aciklama,FaturaTutari,OdemeTutari,Islem,TedarikciID,BankaID) values(@T,@A,@FT,@OT,@Islem,@TID,@BID)", con);
            comK.Parameters.AddWithValue("@T", harcamadate.Value.Date);
            comK.Parameters.AddWithValue("@A", Aciklama);
            comK.Parameters.AddWithValue("@FT", DBNull.Value);
            comK.Parameters.AddWithValue("@OT", Tutar.Text);
            comK.Parameters.AddWithValue("@Islem", "Banka");
            comK.Parameters.AddWithValue("@TID", Convert.ToInt32(Caricombo.SelectedValue));
            comK.Parameters.AddWithValue("@BID", ID);
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
        private void YeniKasa_Click(object sender, EventArgs e)
        {
            YeniKasa yk = new YeniKasa();
            yk.ShowDialog();
            GiderKasa();
        }
        private void BankaIslemEkleAvans()
        {
            DialogResult sor = MessageBox.Show("Kayıt etmek istiyor musunuz ?", "Kayıt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sor == DialogResult.Yes)
            {
                if (personelcombo.SelectedIndex == 0)
                {
                    MessageBox.Show("Lütfen personel seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    string AciklamaKasa = personelcombo.Text + " avans verildi. " + Aciklama.Text;
                    string Nitelik = "Personel Avans";
                    OleDbCommand comK = new OleDbCommand("insert into BankaIslem(Niteligi,Tarih,Aciklama,Gelir,Gider,KasaID,PersonelID,Ay,Yil) values(@N,@T,@A,@Gelir,@Gider,@KID,@PID,@Ay,@Yil)", con);
                    comK.Parameters.AddWithValue("@N", Nitelik);
                    comK.Parameters.AddWithValue("@T", harcamadate.Value.Date);
                    comK.Parameters.AddWithValue("@A", AciklamaKasa);
                    comK.Parameters.AddWithValue("@Gelir", DBNull.Value);
                    comK.Parameters.AddWithValue("@Gider", Tutar.Text);
                    comK.Parameters.AddWithValue("@KID", Convert.ToInt32(Giderkasacombo.SelectedValue));
                    comK.Parameters.AddWithValue("@PID", Convert.ToInt32(personelcombo.SelectedValue));
                    comK.Parameters.AddWithValue("@Ay", harcamadate.Value.Date.Month);
                    comK.Parameters.AddWithValue("@Yil", harcamadate.Value.Date.Year);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    try
                    {
                        if (comK.ExecuteNonQuery() > 0)
                        {
                            OleDbCommand comID = new OleDbCommand("SELECT @@identity", con);
                            int BankaIslemID = Convert.ToInt32(comID.ExecuteScalar());
                            if (BankaIslemID > 0)
                            {
                                OleDbCommand comS = new OleDbCommand("insert into Avanslar(Tarih,Ay,Yil,Aciklama,Tutar,personelID,BankaIslemID) values(@KT,@Ay,@Yil,@A,@T,@PID,@KID)", con);
                                comS.Parameters.AddWithValue("@KT", harcamadate.Value.Date);
                                comS.Parameters.AddWithValue("@Ay", harcamadate.Value.Date.Month);
                                comS.Parameters.AddWithValue("@Yil", harcamadate.Value.Date.Year);
                                comS.Parameters.AddWithValue("@A", Aciklama.Text);
                                comS.Parameters.AddWithValue("@T", Tutar.Text);
                                comS.Parameters.AddWithValue("@PID", Convert.ToInt32(personelcombo.SelectedValue));
                                comS.Parameters.AddWithValue("@KID", BankaIslemID);

                                if (comS.ExecuteNonQuery() > 0)
                                {
                                    MessageBox.Show("Kayıt Tamamlandı.", "Sonuç", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Temizle();
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
        }
        private void BankaIslemEkleHarcama()
        {
            DialogResult sor = MessageBox.Show("Kayıt etmek istiyor musunuz ?", "Kayıt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sor == DialogResult.Yes)
            {
                string Nitelik = "Firma Harcama";
                OleDbCommand comK = new OleDbCommand("insert into BankaIslem(Niteligi,Tarih,Aciklama,Gelir,Gider,KasaID) values(@N,@T,@A,@Gelir,@Gider,@KID)", con);
                comK.Parameters.AddWithValue("@N", Nitelik);
                comK.Parameters.AddWithValue("@T", harcamadate.Value.Date);
                comK.Parameters.AddWithValue("@A", Aciklama.Text);
                comK.Parameters.AddWithValue("@Gelir", DBNull.Value);
                comK.Parameters.AddWithValue("@Gider", Tutar.Text);
                comK.Parameters.AddWithValue("@KID", Convert.ToInt32(Giderkasacombo.SelectedValue));
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
        }
        private void BankaIslemEkleFirma()
        {
            DialogResult sor = MessageBox.Show("Kayıt etmek istiyor musunuz ?", "Kayıt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sor == DialogResult.Yes)
            {
                string Nitelik = "Cari Ödemesi";
                OleDbCommand comK = new OleDbCommand("insert into BankaIslem(Niteligi,Tarih,Aciklama,Gelir,Gider,KasaID,TedarikciID) values(@N,@T,@A,@Gelir,@Gider,@KID,@TID)", con);
                comK.Parameters.AddWithValue("@N", Nitelik);
                comK.Parameters.AddWithValue("@T", harcamadate.Value.Date);
                comK.Parameters.AddWithValue("@A", Aciklama.Text);
                comK.Parameters.AddWithValue("@Gelir", DBNull.Value);
                comK.Parameters.AddWithValue("@Gider", Tutar.Text);
                comK.Parameters.AddWithValue("@KID", Convert.ToInt32(Giderkasacombo.SelectedValue));
                comK.Parameters.AddWithValue("@TID", Convert.ToInt32(Caricombo.SelectedValue));
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                try
                {
                    if (comK.ExecuteNonQuery() > 0)
                    {
                        OleDbCommand comID = new OleDbCommand("SELECT @@identity", con);
                        ID = Convert.ToInt32(comID.ExecuteScalar());
                        if (ID > 0)
                        {
                            OleDbCommand comT = new OleDbCommand("update tedarikciler set Bakiye=Bakiye-@ST where ((tedarikciler.TedarikciID)=@ID);", con);
                            comT.Parameters.AddWithValue("@ST", Tutar.Text);
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
        private void YeniPersonel_Click(object sender, EventArgs e)
        {
            PersonelCariKarti PCK = new PersonelCariKarti();
            PCK.ShowDialog();
            PersoenlGel();
        }
        private void harcamakaydetbtn_Click(object sender, EventArgs e)
        {
            if (Giderkasacombo.SelectedIndex == 0)
            {
                MessageBox.Show("Lütfen kasa seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                if (turucombo.Text == "Lütfen Seçiniz")
                {
                    MessageBox.Show("Lütfen türünü seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    if (turucombo.SelectedIndex == 0)
                    {
                        BankaIslemEkleAvans();
                    }
                    else
                        if (turucombo.SelectedIndex == 1)
                        {
                            BankaIslemEkleHarcama();
                        }
                        else
                        {
                            BankaIslemEkleFirma();
                        }
                }
            }
        }
        private void turucombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (turucombo.SelectedIndex == 0)
            {
                personelcombo.Enabled = true;
                YeniPersonel.Enabled = true;
                YeniCaribtn.Enabled = false;
                Caricombo.Enabled = false;
            }
            else
                if (turucombo.SelectedIndex == 1)
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
        private void YeniBankaCikis_Load(object sender, EventArgs e)
        {
            PersoenlGel();
            GiderKasa();
            TedarikciGel();
        }
        private void YeniCaribtn_Click(object sender, EventArgs e)
        {
            YeniTedarikci YT = new YeniTedarikci();
            YT.ShowDialog();
            TedarikciGel();
        }
    }
}
