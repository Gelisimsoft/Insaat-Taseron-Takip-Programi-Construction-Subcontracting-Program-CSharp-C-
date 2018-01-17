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
    public partial class NakitGirisGuncelle : Form
    {
        public NakitGirisGuncelle()
        {
            InitializeComponent();
        }
        public static int ID;
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
                Giderkasacombo.DataSource = dt;
                Giderkasacombo.DisplayMember = "Kod";
                Giderkasacombo.ValueMember = "KasaID";
            }
        }
        private void NakitIslemGuncelle()
        {
            DialogResult sor = MessageBox.Show("Güncellemek istediğinize emin misiniz ?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sor == DialogResult.Yes)
            {
                OleDbCommand comK = new OleDbCommand("update NakitIslem set Tarih=@T,Aciklama=@A,Gelir=@Gelir,KasaID=@KID where NakitIslemID=@ID", con);
                comK.Parameters.AddWithValue("@T", harcamadate.Value.Date);
                comK.Parameters.AddWithValue("@A", harcamaAciklama.Text);
                comK.Parameters.AddWithValue("@Gelir", HarcamaTutar.Text);
                comK.Parameters.AddWithValue("@KID", Convert.ToInt32(Giderkasacombo.SelectedValue));
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
        }
        private void NakitIslemSil()
        {
            DialogResult sor = MessageBox.Show("Silmek istediğinize emin misiniz ?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sor == DialogResult.Yes)
            {
                OleDbCommand comK = new OleDbCommand("delete from NakitIslem where NakitIslemID=@ID", con);
                comK.Parameters.AddWithValue("@ID", ID);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                try
                {
                    if (comK.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Kayıt Silindi..", "Sonuç", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        }
        private void GelBilgi()
        {
            OleDbCommand com = new OleDbCommand("SELECT NakitIslem.Tarih, NakitIslem.Aciklama, NakitIslem.Gelir,NakitIslem.KasaID FROM NakitIslem  WHERE (((NakitIslem.NakitIslemID)=@ID))", con);
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
                        harcamadate.Value = Convert.ToDateTime(dr[0]);
                        harcamaAciklama.Text = dr[1].ToString();
                        HarcamaTutar.Text = dr[2].ToString();
                        Giderkasacombo.SelectedValue = Convert.ToInt32(dr[3]);
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
        private void guncellebtn_Click(object sender, EventArgs e)
        {
            if (Giderkasacombo.SelectedIndex == 0)
            {
                MessageBox.Show("Lütfen kasa seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                NakitIslemGuncelle();
            }
        }
        private void Silbtn_Click(object sender, EventArgs e)
        {
            NakitIslemSil();
        }
        private void NakitGirisGuncelle_Load(object sender, EventArgs e)
        {
            ID = Convert.ToInt32(NakitGiris.ID);
            GiderKasa();
            GelBilgi();
        }
    }
}
