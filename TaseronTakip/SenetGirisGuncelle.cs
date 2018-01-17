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
    public partial class SenetGirisGuncelle : Form
    {
        public SenetGirisGuncelle()
        {
            InitializeComponent();
        }
        public static int ID, EskiCariID;
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
                TedarikcicomboSenet.DataSource = dt;
                TedarikcicomboSenet.DisplayMember = "unvan";
                TedarikcicomboSenet.ValueMember = "TedarikciID";
            }
        }
        private void SenetIslemGuncelle()
        {
            int YeniCariID = Convert.ToInt32(TedarikcicomboSenet.SelectedValue);
            DialogResult sor = MessageBox.Show("Güncellemek istediğinize emin misiniz ?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sor == DialogResult.Yes)
            {
                OleDbCommand comK = new OleDbCommand("update SenetIslem set DuzenlemeTarihi=@DT,TedarikciID=@F,Aciklama=@Aciklama,SenetNo=@SN,VadeTarihi=@VT,Giris=@Giris,KasaID=@KID where SenetIslem.SenetID=@ID", con);
                comK.Parameters.AddWithValue("@DT", SenetDuzenleme.Value.Date);
                comK.Parameters.AddWithValue("@F", Convert.ToInt32(TedarikcicomboSenet.SelectedValue));
                comK.Parameters.AddWithValue("@Aciklama", SenetAciklama.Text);
                comK.Parameters.AddWithValue("@SN", Senetnumarasi.Text);
                comK.Parameters.AddWithValue("@VT", Senetvadetarihi.Value.Date);
                comK.Parameters.AddWithValue("@Giris", Senettutar.Text);
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
                                //OleDbCommand comOnceki = new OleDbCommand("update tedarikciler set Bakiye=Bakiye+@ST where ((tedarikciler.TedarikciID)=@ID);", con);
                                //comOnceki.Parameters.AddWithValue("@ST", Senettutar.Text);
                                //comOnceki.Parameters.AddWithValue("@ID", YeniCariID);
                                //if (comOnceki.ExecuteNonQuery() > 0)
                                //{
                                OleDbCommand comSonraki = new OleDbCommand("update tedarikciler set Bakiye=Bakiye-@ST where ((tedarikciler.TedarikciID)=@ID);", con);
                                comSonraki.Parameters.AddWithValue("@ST", Senettutar.Text);
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
                                comSonraki.Parameters.AddWithValue("@ST", Senettutar.Text);
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
        }
        private void SenetIslemSil()
        {
            DialogResult sor = MessageBox.Show("Silmek istediğinize emin misiniz ?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sor == DialogResult.Yes)
            {
                OleDbCommand comK = new OleDbCommand("delete from SenetIslem where SenetID=@ID", con);
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
                        comOnceki.Parameters.AddWithValue("@ST", Senettutar.Text);
                        comOnceki.Parameters.AddWithValue("@ID", Convert.ToInt32(TedarikcicomboSenet.SelectedValue));
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
        private void CariEkstresiGuncelle()
        {
            string Aciklama = "Senet Verildi (Senet No : " + Senetnumarasi.Text + " - Ödeme Tarihi : " + Senetvadetarihi.Value + ")";
            OleDbCommand comK = new OleDbCommand("Update CariEkstre set Tarih=@T,Aciklama=@A,OdemeTutari=@OT,TedarikciID=@TID where SenetID=@ID", con);
            comK.Parameters.AddWithValue("@T", SenetDuzenleme.Value.Date);
            comK.Parameters.AddWithValue("@A", Aciklama);
            comK.Parameters.AddWithValue("@OT", Senettutar.Text);
            comK.Parameters.AddWithValue("@TID", Convert.ToInt32(TedarikcicomboSenet.SelectedValue));
            comK.Parameters.AddWithValue("@ID", ID);
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
            OleDbCommand comK = new OleDbCommand("delete from CariEkstre where SenetID=@ID", con);
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
        private void GelBilgi()
        {
            OleDbCommand com = new OleDbCommand("SELECT SenetIslem.DuzenlemeTarihi, SenetIslem.TedarikciID, SenetIslem.Aciklama, SenetIslem.SenetNo, SenetIslem.VadeTarihi, SenetIslem.Giris, SenetIslem.KasaID FROM SenetIslem WHERE (((SenetIslem.SenetID)=@ID))", con);
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
                        SenetDuzenleme.Value = Convert.ToDateTime(dr[0]);
                        TedarikcicomboSenet.SelectedValue = Convert.ToInt32(dr[1]);
                        EskiCariID = Convert.ToInt32(dr[1]);
                        SenetAciklama.Text = dr[2].ToString();
                        Senetnumarasi.Text = dr[3].ToString();
                        Senetvadetarihi.Value = Convert.ToDateTime(dr[4]);
                        Senettutar.Text = dr[5].ToString();
                        Tutar = dr[5].ToString();
                        kasaGuncellecombo.SelectedValue = Convert.ToInt32(dr[6]);
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
        private void YeniKasa_Click(object sender, EventArgs e)
        {
            YeniKasa yk = new YeniKasa();
            yk.ShowDialog();
            GiderKasa();
        }
        private void YeniTedarikciSenet_Click(object sender, EventArgs e)
        {
            YeniTedarikci YT = new YeniTedarikci();
            YT.ShowDialog();
            TedarikciGel();
        }
        private void guncellebtn_Click(object sender, EventArgs e)
        {
            if (kasaGuncellecombo.SelectedIndex != 0)
            {
                SenetIslemGuncelle();
                this.Close();
            }
            else
            {
                MessageBox.Show("Lütfen kasa seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void Silbtn_Click(object sender, EventArgs e)
        {
            SenetIslemSil();
            this.Close();
        }
        private void SenetGirisGuncelle_Load(object sender, EventArgs e)
        {
            ID = Convert.ToInt32(SenetGiris.ID);
            TedarikciGel();
            GiderKasa();
            GelBilgi();
        }
    }
}
