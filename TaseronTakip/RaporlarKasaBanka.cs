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
    public partial class RaporlarKasaBanka : Form
    {
        public RaporlarKasaBanka()
        {
            InitializeComponent();
        }
        public static string SeciliKasa;
        public static string IlkTarih;
        public static string IkinciTarih;
        OleDbConnection con = new OleDbConnection(connect.connectroad);
        public void IlkTariheGoreKasa(string SecilenKasa)
        {
            IkinciTarih = "31.12.2199";
            OleDbDataAdapter dap = new OleDbDataAdapter("SELECT Kasa.Kod, Kasa.Tanim, NakitIslem.Niteligi, NakitIslem.Tarih, NakitIslem.Aciklama, NakitIslem.Gelir, NakitIslem.Gider FROM Kasa LEFT JOIN NakitIslem ON Kasa.KasaID = NakitIslem.KasaID WHERE (((NakitIslem.Tarih) Between @IlkD AND @IkinciD) AND ((Kasa.KasaID)=" + SecilenKasa + ")) GROUP BY Kasa.Kod, Kasa.Tanim, NakitIslem.Niteligi, NakitIslem.Tarih, NakitIslem.Aciklama, NakitIslem.Gelir, NakitIslem.Gider", con);
            dap.SelectCommand.Parameters.AddWithValue("@IlkD", IlkTarih);
            dap.SelectCommand.Parameters.AddWithValue("@IkinciD", IkinciTarih);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public void IkinciTariheGoreKasa(string SecilenKasa)
        {
            IlkTarih = "01.01.1900";
            OleDbDataAdapter dap = new OleDbDataAdapter("SELECT Kasa.Kod, Kasa.Tanim, NakitIslem.Niteligi, BankaIslem.Tarih, BankaIslem.Aciklama, BankaIslem.Gelir, BankaIslem.Gider FROM Kasa LEFT JOIN BankaIslem ON Kasa.KasaID = BankaIslem.KasaID WHERE (((BankaIslem.Tarih) Between @IlkD AND @IkinciD) AND ((Kasa.KasaID)=" + SecilenKasa + ")) GROUP BY Kasa.Kod, Kasa.Tanim, BankaIslem.Niteligi, BankaIslem.Tarih, BankaIslem.Aciklama, BankaIslem.Gelir, BankaIslem.Gider", con);
            dap.SelectCommand.Parameters.AddWithValue("@IlkD", IlkTarih);
            dap.SelectCommand.Parameters.AddWithValue("@IkinciD", IkinciTarih);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public void IlkveIkinciTariheGoreKasa(string SecilenKasa)
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("SELECT Kasa.Kod, Kasa.Tanim, BankaIslem.Niteligi, BankaIslem.Tarih, BankaIslem.Aciklama, BankaIslem.Gelir, BankaIslem.Gider FROM Kasa LEFT JOIN BankaIslem ON Kasa.KasaID = BankaIslem.KasaID WHERE (((BankaIslem.Tarih) Between @IlkD AND @IkinciD) AND ((Kasa.KasaID)=" + SecilenKasa + ")) GROUP BY Kasa.Kod, Kasa.Tanim, BankaIslem.Niteligi, BankaIslem.Tarih, BankaIslem.Aciklama, BankaIslem.Gelir, BankaIslem.Gider", con);
            dap.SelectCommand.Parameters.AddWithValue("@IlkD", IlkTarih);
            dap.SelectCommand.Parameters.AddWithValue("@IkinciD", IkinciTarih);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public void TarihsizSiralaGoreKasa(string SecilenKasa)
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("SELECT Kasa.Kod, Kasa.Tanim, BankaIslem.Niteligi, BankaIslem.Tarih, BankaIslem.Aciklama, BankaIslem.Gelir, BankaIslem.Gider FROM Kasa LEFT JOIN BankaIslem ON Kasa.KasaID = BankaIslem.KasaID where Kasa.KasaID=" + SecilenKasa + " GROUP BY Kasa.Kod, Kasa.Tanim, BankaIslem.Niteligi, BankaIslem.Tarih, BankaIslem.Aciklama, BankaIslem.Gelir, BankaIslem.Gider", con);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void RaporlarKasaNakit_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            SeciliKasa = BankaRaporlari.SeciliKasa.ToString();
            IlkTarih = BankaRaporlari.IlkTarih.ToString();
            IkinciTarih = BankaRaporlari.IkinciTarih.ToString();
            if (!string.IsNullOrEmpty(IlkTarih) && string.IsNullOrEmpty(IkinciTarih))
            {
                IlkTariheGoreKasa(SeciliKasa);
            }
            else
                if (string.IsNullOrEmpty(IlkTarih) && !string.IsNullOrEmpty(IkinciTarih))
                {
                    IkinciTariheGoreKasa(SeciliKasa);
                }
                else
                    if (!string.IsNullOrEmpty(IlkTarih) && !string.IsNullOrEmpty(IkinciTarih))
                    {
                        IlkveIkinciTariheGoreKasa(SeciliKasa);
                    }
                    else
                    {
                        TarihsizSiralaGoreKasa(SeciliKasa);
                    }
        }
    }
}
