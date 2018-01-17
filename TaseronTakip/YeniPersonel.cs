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
    public partial class YeniPersonel : Form
    {
        public YeniPersonel()
        {
            InitializeComponent();
        }
        private void Temizle()
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = string.Empty;
                }
                adres.Clear();
                ceptlf.Clear();
                evtlf.Clear();
                yemekcheck.Checked = false;
                yolcheck.Checked = false;
            }
        }
        OleDbConnection con = new OleDbConnection(connect.connectroad);
        private void Temizlebtn_Click(object sender, EventArgs e)
        {
            Temizle();
        }
        private void Kaydetbtn_Click(object sender, EventArgs e)
        {
            if (adsoyad.Text == "")
            {
                MessageBox.Show("Ad Soyad Boş Geçilmez.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
                if (tcno.Text == "")
                {
                    MessageBox.Show("Tc kimlik Boş Geçilmez.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                    if (maasbox.Text == "")
                    {
                        MessageBox.Show("Maaş Boş Geçilmez.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else
                    {
                        DialogResult sor = MessageBox.Show("Personel Kartı Kaydı Yapmak İstiyor musunuz ?", "Personel Kaydı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (sor == DialogResult.Yes)
                        {
                            OleDbCommand com = new OleDbCommand("insert into personeller(adsoyad,gorev,tcno,adres,ceptlf,evtlf,isegiris,cikisdate,maas,Yol,Yemek) values(@adsoyad,@Gorev,@tcno,@adres,@ceptlf,@evtlf,@isegiris,@Cikis,@maas,@Yol,@Yemek)", con);
                            com.Parameters.AddWithValue("@adsoyad", adsoyad.Text);
                            com.Parameters.AddWithValue("@Gorev", gorevbox.Text);
                            com.Parameters.AddWithValue("@tcno", tcno.Text);
                            com.Parameters.AddWithValue("@adres", adres.Text);
                            com.Parameters.AddWithValue("@ceptlf", ceptlf.Text);
                            com.Parameters.AddWithValue("@evtlf", evtlf.Text);
                            com.Parameters.AddWithValue("@isegiris", isegiris.Value);
                            com.Parameters.AddWithValue("@Cikis", DBNull.Value);
                            com.Parameters.AddWithValue("@maas", maasbox.Text);
                            com.Parameters.AddWithValue("@Yol", YolYardimibox.Text);
                            com.Parameters.AddWithValue("@Yemek", yemekbox.Text);
                            if (con.State != ConnectionState.Open)
                            {
                                con.Open();
                            }
                            try
                            {
                                if (com.ExecuteNonQuery() > 0)
                                {
                                    MessageBox.Show("Kayıt İşlemi Yapılmıştır.", "Sonuc", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Temizle();
                                }
                            }
                            catch (Exception Ex)
                            {
                                MessageBox.Show(Ex.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            finally
                            {
                                con.Close();
                            }
                        }
                    }
        }
        private void YeniPersonel_Load(object sender, EventArgs e)
        {
        }
        private void yolcheck_CheckedChanged(object sender, EventArgs e)
        {
            if (yolcheck.Checked == true)
            {
                YolYardimibox.Visible = true;
            }
            else
            {
                YolYardimibox.Visible = false;
                YolYardimibox.Text = "0";
            }
        }
        private void yemekcheck_CheckedChanged(object sender, EventArgs e)
        {
            if (yemekcheck.Checked == true)
            {
                yemekbox.Visible = true;
            }
            else
            {
                yemekbox.Visible = false;
                yemekbox.Text = "0";
            }
        }
    }
}
