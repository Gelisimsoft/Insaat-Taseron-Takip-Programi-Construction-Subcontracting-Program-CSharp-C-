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
    public partial class YeniTahakkuk : Form
    {
        public YeniTahakkuk()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection(connect.connectroad);
        private static string TahakkukEden;
        private static double maas, Yol, Yemek;
        private void guncelbtn_Click(object sender, EventArgs e)
        {
            PersonelCariKarti PCK = new PersonelCariKarti();
            PCK.ShowDialog();
            GelBilgiMaas();
        }
        private void PersoenlGelArama()
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
        private void GelBilgiMaas()
        {
            OleDbCommand com = new OleDbCommand("SELECT personeller.maas,personeller.Yemek,personeller.Yol FROM personeller WHERE (((personeller.personelID)=@ID))", con);
            com.Parameters.AddWithValue("@ID", Convert.ToInt32(personelcombo.SelectedValue));
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
                        if (dr[0].ToString() == null || dr[0].ToString() == "")
                        {
                            maasbox.Text = "0";
                        }
                        else
                        {
                            maasbox.Text = dr[0].ToString();
                            maas = Convert.ToDouble(dr[0]);
                        }
                        yemekbox.Text = dr[1].ToString();
                        Yemek = Convert.ToDouble(dr[1]);
                        yolbox.Text = dr[2].ToString();
                        Yol = Convert.ToDouble(dr[2]);
                        double hesapla = maas + Yemek + Yol;
                        tahakkukedenbox.Text = hesapla.ToString();
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
        private void Temizle()
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = string.Empty;
                }
            }
            tarihguncelle.Value = DateTime.Now;
            personelcombo.SelectedIndex = 0;
        }
        private bool GelBilgiTahakkuk()
        {
            bool sonuc = false;
            OleDbCommand com = new OleDbCommand("SELECT Tahakkuk.Ucret FROM Tahakkuk WHERE (((Month([Tahakkuk].[Tarih]))=[@Tarih]) AND ((Tahakkuk.personelID)=[@ID]));", con);
            com.Parameters.AddWithValue("@Tarih", Convert.ToInt32(tarihguncelle.Value.Month));
            com.Parameters.AddWithValue("@ID", Convert.ToInt32(personelcombo.SelectedValue));
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            OleDbDataReader dr = com.ExecuteReader();
            try
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        TahakkukEden = dr[0].ToString();
                        sonuc = true;
                    }
                }
                else
                {
                    sonuc = false;
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
            return sonuc;
        }
        private void TahukkukIslemEkle()
        {
            DialogResult sor = MessageBox.Show("Kaydıt etmek istediğinize emin misiniz ?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sor == DialogResult.Yes)
            {
                OleDbCommand comK = new OleDbCommand("insert into Tahakkuk(Tarih,Ay,Yil,Ucret,personelID) values(@T,@Ay,@Yil,@F,@PID)", con);
                comK.Parameters.AddWithValue("@T", tarihguncelle.Value.Date.ToShortDateString());
                comK.Parameters.AddWithValue("@Ay", tarihguncelle.Value.Date.Month);
                comK.Parameters.AddWithValue("@Yil", tarihguncelle.Value.Year);
                comK.Parameters.AddWithValue("@F", tahakkukedenbox.Text);
                comK.Parameters.AddWithValue("@PID", Convert.ToInt32(personelcombo.SelectedValue));
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
        private void YeniTahakkuk_Load(object sender, EventArgs e)
        {
            PersoenlGelArama();
        }
        private void personelcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (personelcombo.SelectedIndex != 0)
            {
                GelBilgiMaas();
            }
        }
        private void onaylabtn_Click(object sender, EventArgs e)
        {
            if (GelBilgiTahakkuk() == true)
            {
                MessageBox.Show("Seçmiş Olduğunuz Tarih İçin Daha Önce Tahakkuk Yapılmıştır.\r\nLütfen Bilgilerinizi Kontrol Ediniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tahakkukedenbox.Text = TahakkukEden;
            }
            else
            {
                TahukkukIslemEkle();
            }
        }
    }
}
