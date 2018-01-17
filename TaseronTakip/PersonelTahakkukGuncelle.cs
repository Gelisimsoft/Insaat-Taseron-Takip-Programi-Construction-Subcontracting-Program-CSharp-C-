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
    public partial class PersonelTahakkukGuncelle : Form
    {
        public PersonelTahakkukGuncelle()
        {
            InitializeComponent();
        }
        public static int ID;
        private static double maas, Yol, Yemek;
        OleDbConnection con = new OleDbConnection(connect.connectroad);
        private void GelBilgi()
        {
            OleDbCommand com = new OleDbCommand("SELECT personeller.adsoyad, Tahakkuk.Tarih, personeller.maas, Tahakkuk.Ucret, personeller.Yemek, personeller.Yol FROM personeller RIGHT JOIN Tahakkuk ON personeller.personelID = Tahakkuk.personelID GROUP BY Tahakkuk.TahakkukID, personeller.adsoyad, Tahakkuk.Tarih, personeller.maas, Tahakkuk.Ucret, personeller.Yemek, personeller.Yol, Tahakkuk.TahakkukID HAVING (((Tahakkuk.TahakkukID)=[@ID]));", con);
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
                        guncellepersonelcombo.Text = dr[0].ToString();
                        tarihguncelle.Value = Convert.ToDateTime(dr[1]);
                        maas = Convert.ToDouble(dr[2]);
                        maasbox.Text = dr[2].ToString();
                        oncekitahakkukbox.Text = dr[3].ToString();
                        yemekbox.Text = dr[4].ToString();
                        Yemek = Convert.ToDouble(dr[4]);
                        yolbox.Text = dr[5].ToString();
                        Yol = Convert.ToDouble(dr[5]);
                        double hesaplanan = maas + Yemek + Yol;
                        hesaplananTahakkukbox.Text = hesaplanan.ToString();
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
            guncellepersonelcombo.SelectedIndex = 0;
            tarihguncelle.Value = DateTime.Now;
        }
        private void TahukkukIslemGuncelle()
        {
            DialogResult sor = MessageBox.Show("Güncellemek istediğinize emin misiniz ?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sor == DialogResult.Yes)
            {
                OleDbCommand comK = new OleDbCommand("update Tahakkuk set Tarih=@T,Ay=@Ay,Yil=@Yil,Ucret=@F,personelID=@PID where ((Tahakkuk.TahakkukID)=@ID)", con);
                comK.Parameters.AddWithValue("@T", tarihguncelle.Value.ToShortDateString());
                comK.Parameters.AddWithValue("@Ay", tarihguncelle.Value.Date.Month.ToString());
                comK.Parameters.AddWithValue("@Yil", tarihguncelle.Value.Date.Year.ToString());
                comK.Parameters.AddWithValue("@F", hesaplananTahakkukbox.Text);
                comK.Parameters.AddWithValue("@PID", Convert.ToInt32(guncellepersonelcombo.SelectedValue));
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
        private void TahukkukIslemSil()
        {
            DialogResult sor = MessageBox.Show("Silmek istediğinize emin misiniz ?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sor == DialogResult.Yes)
            {
                OleDbCommand comK = new OleDbCommand("delete from Tahakkuk where TahakkukID=@ID", con);
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
        }
        private void PersoenlGelGuncelle()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("select * from personeller where ((personeller.IsActive)=True) order by adsoyad", con);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            if (dt != null)
            {
                DataRow dr = dt.NewRow();
                dr[1] = "Lütfen Seçiniz";
                dt.Rows.InsertAt(dr, 0);
                guncellepersonelcombo.DataSource = dt;
                guncellepersonelcombo.DisplayMember = "adsoyad";
                guncellepersonelcombo.ValueMember = "personelID";
            }
        }
        private void PersonelTahakkukGuncelle_Load(object sender, EventArgs e)
        {
            ID = Convert.ToInt32(PersonelTahakkuk.ID);
            PersoenlGelGuncelle();
            GelBilgi();
        }
        private void guncellebtn_Click(object sender, EventArgs e)
        {
            if (guncellepersonelcombo.SelectedIndex == 0)
            {
                MessageBox.Show("Lütfen personel seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                TahukkukIslemGuncelle();
                Temizle();
                this.Close();
            }
        }
        private void silbtn_Click(object sender, EventArgs e)
        {
            TahukkukIslemSil();
            this.Close();
        }
    }
}
