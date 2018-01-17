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
    public partial class TedarikciCariKartiGuncelle : Form
    {
        public TedarikciCariKartiGuncelle()
        {
            InitializeComponent();
        }
        public static int GidenID;
        OleDbConnection baglanti = new OleDbConnection(connect.connectroad);
        private void Guncelle()
        {
            if (Gunvanbox.Text == "")
            {
                MessageBox.Show("Ünvan boş geçilemez.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                DialogResult sor = MessageBox.Show("Güncellemek İstediğinize Emin misiniz. ?", "Kayıt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (sor == DialogResult.Yes)
                {
                    OleDbCommand ekle = new OleDbCommand("update tedarikciler set unvan=@unvan,faaliyet=@faaliyet,adres=@adres,sehir=@sehir,telefon=@telefon,faks=@faks,vergidairesi=@vdairesi,vergino=@vno WHERE (((tedarikciler.TedarikciID)=@ID))", baglanti);
                    ekle.Parameters.AddWithValue("@unvan", Gunvanbox.Text);
                    ekle.Parameters.AddWithValue("@faaliyet", Faaliyetbox.Text);
                    ekle.Parameters.AddWithValue("@adres", Gadresbox.Text);
                    ekle.Parameters.AddWithValue("@sehir", GSehirbox.Text);
                    ekle.Parameters.AddWithValue("@telefon", Gtlfbox.Text);
                    ekle.Parameters.AddWithValue("@faks", Gfaksbox.Text);
                    ekle.Parameters.AddWithValue("@vdairesi", Gvdairesibox.Text);
                    ekle.Parameters.AddWithValue("@vno", GVnobox.Text);
                    ekle.Parameters.AddWithValue("@ID", GidenID);
                    if (baglanti.State == ConnectionState.Closed)
                    {
                        baglanti.Open();
                    }
                    try
                    {
                        if (ekle.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Güncelleme İşlemi Yapılmıştır", "Sonuc", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    finally
                    {
                        baglanti.Close();
                    }
                }
            }
        }
        private void Sil()
        {
            DialogResult sor = MessageBox.Show("Silmek İstediğinize Emin misiniz. ?", "Kayıt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sor == DialogResult.Yes)
            {
                OleDbCommand Sil = new OleDbCommand("update tedarikciler set IsActive=False WHERE (((tedarikciler.TedarikciID)=@ID))", baglanti);
                Sil.Parameters.AddWithValue("@ID", GidenID);
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                try
                {
                    if (Sil.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Silme İşlemi Yapılmıştır", "Sonuc", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                finally
                {
                    baglanti.Close();
                }
            }
            else
            {
                this.Close();
            }
        }
        private void GelBilgiler()
        {
            try
            {
                OleDbCommand comgel = new OleDbCommand("SELECT tedarikciler.unvan,tedarikciler.faaliyet, tedarikciler.adres, tedarikciler.sehir, tedarikciler.telefon, tedarikciler.faks, tedarikciler.vergidairesi, tedarikciler.vergino FROM tedarikciler WHERE (((tedarikciler.TedarikciID)=@ID) AND ((tedarikciler.IsActive)=True))", baglanti);
                comgel.Parameters.AddWithValue("@ID", GidenID);
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                OleDbDataReader dr = comgel.ExecuteReader();
                try
                {
                    while (dr.Read())
                    {
                        if (dr.HasRows == true)
                        {
                            Gunvanbox.Text = dr["unvan"].ToString();
                            Faaliyetbox.Text = dr["faaliyet"].ToString();
                            Gadresbox.Text = dr["adres"].ToString();
                            GSehirbox.Text = dr["sehir"].ToString();
                            Gtlfbox.Text = dr["telefon"].ToString();
                            Gfaksbox.Text = dr["faks"].ToString();
                            Gvdairesibox.Text = dr["vergidairesi"].ToString();
                            GVnobox.Text = dr["vergino"].ToString();
                        }
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.ToString());
                }
                finally
                {
                    baglanti.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen tedarikçi seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void Gncellebtn_Click(object sender, EventArgs e)
        {
            Guncelle();
            this.Close();
        }
        private void Silbtn_Click(object sender, EventArgs e)
        {
            Sil();
            this.Close();
        }
        private void TedarikciCariKartiGuncelle_Load(object sender, EventArgs e)
        {
            GidenID = Convert.ToInt32(TedarikciCariKarti.GidenID);
            GelBilgiler();
        }
    }
}
