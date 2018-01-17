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
    public partial class YeniSenetGiris : Form
    {
        public YeniSenetGiris()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection(connect.connectroad);
        private static int ID;
        public void GelirSenet()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("select * from Kasa where ((Kasa.IsActive)=True) order by Kod", con);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            if (dt != null)
            {
                DataRow dr = dt.NewRow();
                dr[1] = "Lütfen Seçiniz";
                dt.Rows.InsertAt(dr, 0);
                GeliKasaCombo.DataSource = dt;
                GeliKasaCombo.DisplayMember = "Kod";
                GeliKasaCombo.ValueMember = "KasaID";
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
            SenetAciklama.Clear();
            GeliKasaCombo.SelectedIndex = 0;
            TedarikcicomboSenet.SelectedIndex = 0;
            SenetDuzenleme.Value = DateTime.Now;
            Senetvadetarihi.Value = DateTime.Now;
        }
        private void CariEkstresiEkle()
        {
            string Aciklama = "Senet Verildi (Senet No : " + senetnumarasi.Text + " - Ödeme Tarihi : " + Senetvadetarihi.Value + ")";
            OleDbCommand comK = new OleDbCommand("insert into CariEkstre(Tarih,Aciklama,FaturaTutari,OdemeTutari,Islem,TedarikciID,SenetID) values(@T,@A,@FT,@OT,@Islem,@TID,@SID)", con);
            comK.Parameters.AddWithValue("@T", SenetDuzenleme.Value.Date);
            comK.Parameters.AddWithValue("@A", Aciklama);
            comK.Parameters.AddWithValue("@FT", DBNull.Value);
            comK.Parameters.AddWithValue("@OT", Senettutar.Text);
            comK.Parameters.AddWithValue("@Islem", "Senet");
            comK.Parameters.AddWithValue("@TID", Convert.ToInt32(TedarikcicomboSenet.SelectedValue));
            comK.Parameters.AddWithValue("@SID", ID);
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
        public void TedarikciSenet()
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
        private void SenetIslemEkle()
        {
            DialogResult sor = MessageBox.Show("Kayıt etmek istiyor musunuz ?", "Kayıt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sor == DialogResult.Yes)
            {
                OleDbCommand comCek = new OleDbCommand("insert into SenetIslem(KayitTarihi,DuzenlemeTarihi,TedarikciID,Aciklama,SenetNo,VadeTarihi,Giris,Cikis,KasaID,Islem) values(@KT,@DT,@F,@A,@CN,@VT,@G,@C,@KID,@Islem)", con);
                comCek.Parameters.AddWithValue("@KT", DateTime.Now.ToShortDateString());
                comCek.Parameters.AddWithValue("@DT", SenetDuzenleme.Value.Date);
                comCek.Parameters.AddWithValue("@F", Convert.ToInt32(TedarikcicomboSenet.SelectedValue));
                comCek.Parameters.AddWithValue("@A", SenetAciklama.Text);
                comCek.Parameters.AddWithValue("@CN", senetnumarasi.Text);
                comCek.Parameters.AddWithValue("@VT", Senetvadetarihi.Value);
                comCek.Parameters.AddWithValue("@G", Senettutar.Text);
                comCek.Parameters.AddWithValue("@C", DBNull.Value);
                comCek.Parameters.AddWithValue("@KID", Convert.ToInt32(GeliKasaCombo.SelectedValue));
                comCek.Parameters.AddWithValue("@Islem", "Giris");
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                try
                {
                    if (comCek.ExecuteNonQuery() > 0)
                    {
                        OleDbCommand comID = new OleDbCommand("SELECT @@identity", con);
                        ID = Convert.ToInt32(comID.ExecuteScalar());
                        if (ID > 0)
                        {
                            OleDbCommand comT = new OleDbCommand("update tedarikciler set Bakiye=Bakiye-@ST where ((tedarikciler.TedarikciID)=@ID);", con);
                            comT.Parameters.AddWithValue("@ST", Senettutar.Text);
                            comT.Parameters.AddWithValue("@ID", Convert.ToInt32(TedarikcicomboSenet.SelectedValue));
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
        private void YeniSenetGiris_Load(object sender, EventArgs e)
        {
            GelirSenet();
            TedarikciSenet();
        }
        private void yenikasabtn_Click(object sender, EventArgs e)
        {
            YeniKasa yk = new YeniKasa();
            yk.ShowDialog();
            GelirSenet();
        }
        private void YeniTedarikciCek_Click(object sender, EventArgs e)
        {
            TedarikciCariKarti TCK = new TedarikciCariKarti();
            TCK.ShowDialog();
            TedarikciSenet();
        }
        private void CekKaydet_Click(object sender, EventArgs e)
        {
            if (GeliKasaCombo.SelectedIndex == 0)
            {
                MessageBox.Show("Lütfen kasa seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                if (TedarikcicomboSenet.SelectedIndex == 0)
                {
                    MessageBox.Show("Lütfen tedarikçi seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    SenetIslemEkle();
                }
            }
        }
    }
}
