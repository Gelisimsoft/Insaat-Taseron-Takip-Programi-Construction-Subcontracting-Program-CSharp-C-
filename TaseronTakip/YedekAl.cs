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
    public partial class YedekAl : Form
    {
        public YedekAl()
        {
            InitializeComponent();
        }

        string yol;
        private void button1_Click(object sender, EventArgs e)
        {
            string buugun = Convert.ToString(DateTime.Now.ToShortDateString().Replace(".", ""));
            string bugun = buugun.Replace("/", "");

            saveFileDialog1.FileName = "InsaatProgramiYedek" + "-" + bugun;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName != null)
            {
                yol = saveFileDialog1.FileName;
                textBox1.Text = yol;
            }
        }
        OleDbConnection con = new OleDbConnection(connect.connectroad);
        private void button2_Click(object sender, EventArgs e)
        {
            string AnaDosyayol = Application.StartupPath + "\\Veritabani\\Data.mdb";
            int saat, dakika;
            DateTime date = DateTime.Now;
            saat = date.Hour;
            dakika = date.Minute;
            string time = saat + ":" + dakika;
            OleDbCommand com = new OleDbCommand("insert into Databasem (Ad,Tarih,Timecik) values(@Ad,@Tarih,@Timecik)", con);
            com.Parameters.AddWithValue("@Ad", yol);
            com.Parameters.AddWithValue("@Tarih", DateTime.Now.ToShortDateString());
            com.Parameters.AddWithValue("@Timecik", time);
            if (com.Connection.State == ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                if (com.ExecuteNonQuery() > 0)
                {
                    System.IO.File.Copy(AnaDosyayol, yol + ".mdb");
                    MessageBox.Show("Yedek  '" + yol + "' kaydedildi.", "Yedek Alma İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Yedekleme işlemi sırasında bir hata oluştu!" + ex.Message);
            }
            finally
            {
                con.Close();
                this.Close();
            }
        }
        private void YedekAl_Load(object sender, EventArgs e)
        {
            YedeklemeBilgileriGetir();
        }
        private void YedeklemeBilgileriGetir()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            OleDbDataAdapter dt = new OleDbDataAdapter("select * from Databasem where Ad=(select MAX(ID) from Databasem)", con);
            DataTable adp = new DataTable();
            dt.Fill(adp);
            try
            {
                textBox2.Text = Convert.ToString(adp.Rows[0]["Ad"].ToString());
                textBox3.Text = Convert.ToString(adp.Rows[0]["Tarih"].ToString().Remove(11));
                textBox4.Text = Convert.ToString(adp.Rows[0]["Timecik"].ToString().Remove(5));
            }
            catch (Exception)
            {
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
            finally
            {
                con.Close();
            }
        }
    }
}
