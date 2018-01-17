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
    public partial class YeniTedarikci : Form
    {
        public YeniTedarikci()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection(connect.connectroad);
        private void Temizle()
        {
            foreach (Control fatih in groupBox1.Controls)
            {
                if (fatih is TextBox)
                {
                    fatih.Text = string.Empty;
                }
                adrestxt.Clear();
                tlftxt.Clear();
                fakstxt.Clear();
            }
        }
        private void Kayit()
        {
            if (unvantxt.Text == "")
            {
                MessageBox.Show("Ünvan boş geçilemez.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                DialogResult sor = MessageBox.Show("Cari Kartı Kaydetmek İstediğinize Emin misiniz. ?", "Kayıt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (sor == DialogResult.Yes)
                {
                    OleDbCommand ekle = new OleDbCommand("insert into tedarikciler(unvan,faaliyet,adres,sehir,telefon,faks,vergidairesi,vergino) values(@unvan,@faaliyet,@adres,@sehir,@telefon,@faks,@vdairesi,@vno)", baglanti);
                    ekle.Parameters.AddWithValue("@unvan", unvantxt.Text);
                    ekle.Parameters.AddWithValue("@faaliyet", Faaliyetbox.Text);
                    ekle.Parameters.AddWithValue("@adres", adrestxt.Text);
                    ekle.Parameters.AddWithValue("@sehir", sehirtxt.Text);
                    ekle.Parameters.AddWithValue("@telefon", tlftxt.Text);
                    ekle.Parameters.AddWithValue("@faks", fakstxt.Text);
                    ekle.Parameters.AddWithValue("@vdairesi", vdairesitxt.Text);
                    ekle.Parameters.AddWithValue("@vno", vnotxt.Text);
                    if (baglanti.State == ConnectionState.Closed)
                    {
                        baglanti.Open();
                    }
                    try
                    {
                        if (ekle.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Kayıt İşlemi Yapılmıştır", "Sonuc", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Temizle();
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
        private void temizlebtn_Click(object sender, EventArgs e)
        {
            Temizle();
        }
        private void vagecbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void kaydetbtn_Click(object sender, EventArgs e)
        {
            Kayit();
        }
    }
}
