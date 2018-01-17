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
    public partial class RaporlarPersonellerUcret : Form
    {
        public RaporlarPersonellerUcret()
        {
            InitializeComponent();
        }
        public static int Personel = 0;
        public static string ay = "";
        public static string yil = "";
        OleDbConnection con = new OleDbConnection(connect.connectroad);
        public void PersoneleGoreGetir()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("SELECT personeller.adsoyad, Kasa.Kod, Kasa.Tanim, NakitIslem.Tarih, NakitIslem.Aciklama, NakitIslem.Gider FROM (Kasa INNER JOIN NakitIslem ON Kasa.KasaID = NakitIslem.KasaID) INNER JOIN personeller ON  NakitIslem.PersonelID = personeller.personelID WHERE (((NakitIslem.PersonelID)=" + Personel + ")) UNION ALL SELECT personeller.adsoyad, Kasa.Kod, Kasa.Tanim, BankaIslem.Tarih, BankaIslem.Aciklama, BankaIslem.Gider FROM personeller INNER JOIN (Kasa INNER JOIN BankaIslem ON Kasa.KasaID = BankaIslem.KasaID) ON personeller.personelID = BankaIslem.PersonelID WHERE (((BankaIslem.PersonelID)=" + Personel + "))", con);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "Ad Soyad";
            dataGridView1.Columns[1].HeaderText = "Kasa Kod";
            dataGridView1.Columns[2].HeaderText = "Kasa Tanım";
            dataGridView1.Columns[3].HeaderText = "Tarih";
            dataGridView1.Columns[4].HeaderText = "Açıklama";
            dataGridView1.Columns[5].HeaderText = "Ücret";
        }
        public void TarihiGoreGetir()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("SELECT personeller.adsoyad, Kasa.Kod, Kasa.Tanim, NakitIslem.Tarih, NakitIslem.Aciklama, NakitIslem.Gider FROM (Kasa INNER JOIN NakitIslem ON Kasa.KasaID = NakitIslem.KasaID) INNER JOIN personeller ON  NakitIslem.PersonelID = personeller.personelID WHERE (((NakitIslem.PersonelID)=" + Personel + ") AND ((NakitIslem.Ay)=@Ay) AND ((NakitIslem.Yil)=@Yil)) UNION ALL SELECT personeller.adsoyad, Kasa.Kod, Kasa.Tanim, BankaIslem.Tarih, BankaIslem.Aciklama, BankaIslem.Gider FROM personeller INNER JOIN (Kasa INNER JOIN BankaIslem ON Kasa.KasaID = BankaIslem.KasaID) ON personeller.personelID = BankaIslem.PersonelID WHERE (((BankaIslem.PersonelID)=" + Personel + ") AND ((BankaIslem.Ay)=@Ay) AND ((BankaIslem.Yil)=@Yil))", con);
            dap.SelectCommand.Parameters.AddWithValue("@Ay", ay);
            dap.SelectCommand.Parameters.AddWithValue("@Yil", yil);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "Ad Soyad";
            dataGridView1.Columns[1].HeaderText = "Kasa Kod";
            dataGridView1.Columns[2].HeaderText = "Kasa Tanım";
            dataGridView1.Columns[3].HeaderText = "Tarih";
            dataGridView1.Columns[4].HeaderText = "Açıklama";
            dataGridView1.Columns[5].HeaderText = "Ücret";
        }

        private void RaporlarKasaNakit_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Personel = PersonelMaasRaporlari.PersonelID;
            ay = PersonelMaasRaporlari.ay.ToString();
            yil = PersonelMaasRaporlari.yil.ToString();
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
