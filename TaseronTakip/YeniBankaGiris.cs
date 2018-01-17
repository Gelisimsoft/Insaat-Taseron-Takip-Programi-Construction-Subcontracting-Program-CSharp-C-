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
    public partial class YeniBankaGiris : Form
    {
        public YeniBankaGiris()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection(connect.connectroad);
        public void GiderBanka()
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
        }
        private void BankaIslemEkle()
        {
            DialogResult sor = MessageBox.Show("Kayıt etmek istiyor musunuz ?", "Kayıt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sor == DialogResult.Yes)
            {
                string Nitelik = "Banka Giriş";
                OleDbCommand comK = new OleDbCommand("insert into BankaIslem(Niteligi,Tarih,Aciklama,Gelir,Gider,KasaID) values(@N,@T,@A,@Gelir,@Gider,@KID)", con);
                comK.Parameters.AddWithValue("@N", Nitelik);
                comK.Parameters.AddWithValue("@T", harcamadate.Value.Date);
                comK.Parameters.AddWithValue("@A", Aciklama.Text);
                comK.Parameters.AddWithValue("@Gelir", Tutar.Text);
                comK.Parameters.AddWithValue("@Gider", DBNull.Value);
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
        private void YeniKasa_Click(object sender, EventArgs e)
        {
            YeniKasa yk = new YeniKasa();
            yk.ShowDialog();
            GiderBanka();
        }
        private void harcamakaydetbtn_Click(object sender, EventArgs e)
        {
            if (Giderkasacombo.SelectedIndex == 0)
            {
                MessageBox.Show("Lütfen kasa seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                BankaIslemEkle();
            }
        }
        private void YeniBankaGiris_Load(object sender, EventArgs e)
        {
            GiderBanka();
        }
    }
}
