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
    public partial class YeniKasa : Form
    {
        public YeniKasa()
        {
            InitializeComponent();
        }
        private static string KasaKod;
        private void Temizle()
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = string.Empty;
                }
            }
        }
        private static int GidenID;
        OleDbConnection con = new OleDbConnection(connect.connectroad);
        private void GuncelleBilgiGel()
        {
            if (listView1.Columns.Count != 0)
            {
                try
                {
                    int index = listView1.SelectedItems[0].Index;
                    string GelenKod = listView1.Items[index].SubItems[0].Text;
                    OleDbCommand comgel = new OleDbCommand("SELECT Kasa.KasaID,Kasa.Kod, Kasa.Tanim FROM Kasa WHERE (((Kasa.IsActive)=Yes) AND ((Kasa.Kod)=@kod))", con);
                    comgel.Parameters.AddWithValue("@kod", GelenKod);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    OleDbDataReader dr = comgel.ExecuteReader();

                    while (dr.Read())
                    {
                        if (dr.HasRows == true)
                        {
                            GidenID = Convert.ToInt32(dr["KasaID"]);
                            KasaKod = dr["Kod"].ToString();
                            GKodbox.Text = dr["Kod"].ToString();
                            Gaciklamabox.Text = dr["Tanim"].ToString();
                            this.Height = 520;
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Lütfen kasa seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    con.Close();
                }
            }
        }
        public void Listemidoldur()
        {
            listView1.Items.Clear();
            OleDbDataAdapter dappersn = new OleDbDataAdapter("select Kod,Tanim from Kasa WHERE ((Kasa.IsActive)=True) order by Kod", con);
            DataTable pdet = new DataTable();
            dappersn.Fill(pdet);
            for (int i = 0; i < pdet.Rows.Count; i++)
            {
                ListViewItem listecik = new ListViewItem(pdet.Rows[i]["Kod"].ToString());
                listecik.SubItems.Add(pdet.Rows[i]["Tanim"].ToString());
                listView1.Items.Add(listecik);
            }
        }
        private void kaydetbtn_Click(object sender, EventArgs e)
        {
            Kayit();
        }
        private void Kayit()
        {
            if (KontrolETt() == true)
            {
                MessageBox.Show(kodbox.Text + " Kod adı ile kasa açılmıştır.\r\n Lütfen kayıtları kontrol ediniz.", "Kontrol", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                if (kodbox.Text == "")
                {
                    MessageBox.Show("Kasa Boş Geçilmez.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                    if (aciklamabox.Text == "")
                    {
                        MessageBox.Show("Açıklama Boş Geçilmez.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else
                    {
                        DialogResult sor = MessageBox.Show("Kasa Kaydı Yapmak İstiyor musunuz ?", "Personel Kaydı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (sor == DialogResult.Yes)
                        {
                            OleDbCommand com = new OleDbCommand("insert into Kasa(Kod,Tanim) values(@kod,@aciklama)", con);
                            com.Parameters.AddWithValue("@kod", kodbox.Text);
                            com.Parameters.AddWithValue("@aciklama", aciklamabox.Text);
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
                                    Listemidoldur();
                                    groupBox1.Location = new Point(10, 10);
                                    this.Height = 430;
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
        }
        private bool KontrolETt()
        {
            bool sonuc = false;
            OleDbCommand com = new OleDbCommand("select KasaID from Kasa where ((Kasa.Kod)=@AD)", con);
            com.Parameters.AddWithValue("@AD", kodbox.Text);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            OleDbDataReader dr = com.ExecuteReader();
            try
            {
                if (dr.HasRows == true)
                {
                    sonuc = true;
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
        private bool GKontrolETt()
        {
            bool sonuc = false;
            OleDbCommand com = new OleDbCommand("select KasaID from Kasa where ((Kasa.Kod)=@AD)", con);
            com.Parameters.AddWithValue("@AD", GKodbox.Text);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            OleDbDataReader dr = com.ExecuteReader();
            try
            {
                if (dr.HasRows == true)
                {
                    sonuc = true;
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
        private void Sil()
        {
            DialogResult sor = MessageBox.Show("Kasayı Silmek İstiyor musunuz ?", "Kasa Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sor == DialogResult.Yes)
            {
                OleDbCommand com = new OleDbCommand("update Kasa set IsActive=False where ((Kasa.KasaID)=@ID)", con);
                com.Parameters.AddWithValue("@ID", GidenID);
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                try
                {
                    if (com.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Silme İşlemi Yapılmıştır.", "Sonuc", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Temizle();
                        Listemidoldur();
                        this.Height = 430;
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
        private void Guncelle()
        {
            if (GKodbox.Text != KasaKod && GKontrolETt() == true)
            {
                MessageBox.Show(kodbox.Text + " Kod adı ile kasa açılmıştır.\r\n Lütfen kayıtları kontrol ediniz.", "Kontrol", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                if (GKodbox.Text == "")
                {
                    MessageBox.Show("Kasa Boş Geçilmez.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                    if (Gaciklamabox.Text == "")
                    {
                        MessageBox.Show("Açıklama Boş Geçilmez.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else
                    {
                        DialogResult sor = MessageBox.Show("Güncelle Yapmak İstiyor musunuz ?", "Güncelle", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (sor == DialogResult.Yes)
                        {
                            OleDbCommand com = new OleDbCommand("update Kasa set Kod=@kod,Tanim=@Tanim where ((Kasa.KasaID)=@ID)", con);
                            com.Parameters.AddWithValue("@kod", GKodbox.Text);
                            com.Parameters.AddWithValue("@Tanim", Gaciklamabox.Text);
                            com.Parameters.AddWithValue("@ID", GidenID);
                            if (con.State != ConnectionState.Open)
                            {
                                con.Open();
                            }
                            try
                            {
                                if (com.ExecuteNonQuery() > 0)
                                {
                                    MessageBox.Show("Güncelle İşlemi Yapılmıştır.", "Sonuc", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Temizle();
                                    Listemidoldur();
                                    this.Height = 430;
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
        }
        private void YeniKasa_Load(object sender, EventArgs e)
        {
            Listemidoldur();
        }
        private void guncellebtn_Click(object sender, EventArgs e)
        {
            Guncelle();
        }
        private void Silbtn_Click(object sender, EventArgs e)
        {
            Sil();
            this.Height = 430;
        }
        private void yeniKasaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Location = new Point(10, 47);
            this.Height = 461;
        }
        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GuncelleBilgiGel();
        }
        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GuncelleBilgiGel();
            Sil();
        }
    }
}
