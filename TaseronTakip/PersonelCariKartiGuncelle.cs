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
    public partial class PersonelCariKartiGuncelle : Form
    {
        public PersonelCariKartiGuncelle()
        {
            InitializeComponent();
        }
        public static int GidenID;
        OleDbConnection con = new OleDbConnection(connect.connectroad);
        private void GelBilgiler()
        {
            OleDbCommand comgel = new OleDbCommand("select personelID,adsoyad,gorev,tcno,adres,ceptlf,evtlf,isegiris,cikisdate,maas,Yol,Yemek from personeller WHERE (((personeller.personelID)=@ID) AND ((personeller.IsActive)=True))", con);
            comgel.Parameters.AddWithValue("@ID", GidenID);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            OleDbDataReader dr = comgel.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (dr.HasRows == true)
                    {
                        GidenID = Convert.ToInt32(dr["personelID"]);
                        GAdbox.Text = dr["adsoyad"].ToString();
                        Gorevbox.Text = dr["gorev"].ToString();
                        tcnobox.Text = dr["tcno"].ToString();
                        GAdresbox.Text = dr["adres"].ToString();
                        Gcepbox.Text = dr["ceptlf"].ToString();
                        Gevbox.Text = dr["evtlf"].ToString();
                        GGirisdatatime.Value = Convert.ToDateTime(dr["isegiris"]);
                        if (dr["cikisdate"].ToString() != "")
                        {
                            string Ge = dr["cikisdate"].ToString();
                            checkBox1.CheckState = CheckState.Checked;
                            GCikisDate.Value = Convert.ToDateTime(dr["cikisdate"]);
                        }
                        GMaasbox.Text = dr["maas"].ToString();
                        if (dr["Yol"].ToString() == "" || dr["Yol"].ToString() == "0,0000")
                        {
                            YolYardimibox.Visible = false;
                            YolYardimibox.Text = "0";
                        }
                        else
                        {
                            yolcheck.Checked = true;
                            YolYardimibox.Text = dr["Yol"].ToString();
                        }
                        if (dr["Yemek"].ToString() == "" || dr["Yemek"].ToString() == "0,0000")
                        {
                            yemekcheck.Checked = false;
                            yemekbox.Text = "0";
                        }
                        else
                        {
                            yemekcheck.Checked = true;
                            yemekbox.Text = dr["Yemek"].ToString();
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen personel seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                con.Close();
            }
        }
        private void KartiSil()
        {
            DialogResult dlg = MessageBox.Show("Personel Bilgileri Silinsinn mi?", "Silme Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dlg == DialogResult.Yes)
            {
                OleDbCommand comcuk = new OleDbCommand("Update personeller set IsActive=0 where ((personeller.personelID)=@ID)", con);
                comcuk.Parameters.AddWithValue("@ID", GidenID);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                try
                {
                    if (comcuk.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Silme işlemi tamam", "Sonuc", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            else
            {
                this.Height = 430;
            }
        }
        private void PersonelCariKartiGuncelle_Load(object sender, EventArgs e)
        {
            GidenID = Convert.ToInt32(PersonelCariKarti.GidenID);
            GelBilgiler();
        }
        private void Guncellebtn_Click(object sender, EventArgs e)
        {
            string Cikis = "";
            if (checkBox1.CheckState == CheckState.Checked)
            {
                Cikis = GCikisDate.Value.ToString();
            }
            if (GAdbox.Text == "")
            {
                MessageBox.Show("Ad Soyad Boş Geçilmez.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
                if (Gorevbox.Text == "")
                {
                    MessageBox.Show("Tc kimlik Boş Geçilmez.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                    if (GMaasbox.Text == "")
                    {
                        MessageBox.Show("Maaş Boş Geçilmez.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else
                    {
                        DialogResult sor = MessageBox.Show("Personel Bilgileri Güncellensin mi ?", "Güncelleme Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (sor == DialogResult.Yes)
                        {
                            OleDbCommand com = new OleDbCommand("update personeller set adsoyad=@adsoyad,gorev=@Gorev,tcno=@tcno,adres=@adres,ceptlf=@ceptlf,evtlf=@evtlf,isegiris=@isegiris,cikisdate=@Cikis,maas=@maas,Yemek=@Yemek,Yol=@Yol where personelID=@p", con);
                            com.Parameters.AddWithValue("@adsoyad", GAdbox.Text);
                            com.Parameters.AddWithValue("@Gorev", Gorevbox.Text);
                            com.Parameters.AddWithValue("@tcno", tcnobox.Text);
                            com.Parameters.AddWithValue("@adres", GAdresbox.Text);
                            com.Parameters.AddWithValue("@ceptlf", Gcepbox.Text);
                            com.Parameters.AddWithValue("@evtlf", Gevbox.Text);
                            com.Parameters.AddWithValue("@isegiris", GGirisdatatime.Value);
                            com.Parameters.AddWithValue("@Cikis", Cikis);
                            com.Parameters.AddWithValue("@maas", GMaasbox.Text);
                            com.Parameters.AddWithValue("@Yol", YolYardimibox.Text);
                            com.Parameters.AddWithValue("@Yemek", yemekbox.Text);
                            com.Parameters.AddWithValue("@p", GidenID);
                            if (con.State != ConnectionState.Open)
                            {
                                con.Open();
                            }
                            try
                            {
                                if (com.ExecuteNonQuery() > 0)
                                {
                                    MessageBox.Show("Güncellem İşlemi Yapılmıştır.", "Sonuc", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
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
        private void Silbtn_Click(object sender, EventArgs e)
        {
            KartiSil();
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
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                GCikisDate.Enabled = true;
            }
            else
            {
                GCikisDate.Enabled = false;
            }
        }
    }
}
