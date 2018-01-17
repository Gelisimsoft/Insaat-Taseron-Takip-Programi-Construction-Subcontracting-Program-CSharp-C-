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
    public partial class RaporlarPersonellerTahakkuk : Form
    {
        public RaporlarPersonellerTahakkuk()
        {
            InitializeComponent();
        }
        public static int Personel = 0;
        public static string ay = "";
        public static string yil = "";
        OleDbConnection con = new OleDbConnection(connect.connectroad);
        public void PersoneleGoreGetir()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("SELECT personeller.adsoyad, personeller.maas, personeller.Yemek, personeller.Yol, Tahakkuk.Tarih, Tahakkuk.Ucret FROM Tahakkuk INNER JOIN personeller ON Tahakkuk.personelID = personeller.personelID WHERE (((personeller.personelID)=" + Personel + "))", con);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "Ad Soyad";
            dataGridView1.Columns[1].HeaderText = "Maaş";
            dataGridView1.Columns[2].HeaderText = "Yemek Parası";
            dataGridView1.Columns[3].HeaderText = "Yol Parası";
            dataGridView1.Columns[4].HeaderText = "Tahakkuk Tarihi";
            dataGridView1.Columns[5].HeaderText = "Tahakkuk Eden Ücret";
        }
        public void TarihiGoreGetir()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("SELECT personeller.adsoyad, personeller.maas, personeller.Yemek, personeller.Yol, Tahakkuk.Tarih, Tahakkuk.Ucret FROM Tahakkuk INNER JOIN personeller ON Tahakkuk.personelID = personeller.personelID WHERE (((personeller.personelID)=" + Personel + ") AND ((Tahakkuk.Ay)=@Ay) AND ((Tahakkuk.Yil)=@Yil))", con);
            dap.SelectCommand.Parameters.AddWithValue("@Ay", ay);
            dap.SelectCommand.Parameters.AddWithValue("@Yil", yil);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "Ad Soyad";
            dataGridView1.Columns[1].HeaderText = "Maaş";
            dataGridView1.Columns[2].HeaderText = "Yemek Parası";
            dataGridView1.Columns[3].HeaderText = "Yol Parası";
            dataGridView1.Columns[4].HeaderText = "Tahakkuk Tarihi";
            dataGridView1.Columns[5].HeaderText = "Tahakkuk Eden Ücret";
        }
        private void RaporlarKasaNakit_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedHeaders;
            Personel = PersonelTahakkukRaporlari.PersonelID;
            ay = PersonelTahakkukRaporlari.ay.ToString();
            yil = PersonelTahakkukRaporlari.yil.ToString();
            if (string.IsNullOrEmpty(ay) && string.IsNullOrEmpty(yil))
            {
                PersoneleGoreGetir();
            }
            else
            {
                TarihiGoreGetir();
            }
        }
    }
}
