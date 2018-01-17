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
    public partial class RaporlarKasaSenet : Form
    {
        public RaporlarKasaSenet()
        {
            InitializeComponent();
        }
        public static string SeciliKasa = "";
        public static string VadeTarih = "";
        public static string SenetNo = "";
        public static int TedID = 0;
        OleDbConnection con = new OleDbConnection(connect.connectroad);
        public void SecileneGoreKasa(string SecilenKasa)
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("SELECT Kasa.Kod, Kasa.Tanim, tedarikciler.unvan, SenetIslem.KayitTarihi, SenetIslem.SenetNo, SenetIslem.VadeTarihi, SenetIslem.Aciklama, SenetIslem.Giris, SenetIslem.Cikis FROM Kasa INNER JOIN (SenetIslem INNER JOIN tedarikciler ON SenetIslem.TedarikciID = tedarikciler.TedarikciID) ON Kasa.KasaID = SenetIslem.KasaID WHERE (((Kasa.KasaID)=" + SecilenKasa + "))", con);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public void SecileneGoreKasaveVadeTarihi(string SecilenKasa)
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("SELECT Kasa.Kod, Kasa.Tanim, tedarikciler.unvan, SenetIslem.KayitTarihi, SenetIslem.SenetNo, SenetIslem.VadeTarihi, SenetIslem.Aciklama, SenetIslem.Giris, SenetIslem.Cikis FROM Kasa INNER JOIN (SenetIslem INNER JOIN tedarikciler ON SenetIslem.TedarikciID = tedarikciler.TedarikciID) ON Kasa.KasaID = SenetIslem.KasaID WHERE (((SenetIslem.VadeTarihi)=@Tarih) AND ((Kasa.KasaID)=" + SecilenKasa + "))", con);
            dap.SelectCommand.Parameters.AddWithValue("@Tarih", VadeTarih);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public void SecileneSenetGore()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("SELECT Kasa.Kod, Kasa.Tanim, tedarikciler.unvan, SenetIslem.KayitTarihi, SenetIslem.SenetNo, SenetIslem.VadeTarihi, SenetIslem.Aciklama, SenetIslem.Giris, SenetIslem.Cikis FROM Kasa INNER JOIN (SenetIslem INNER JOIN tedarikciler ON SenetIslem.TedarikciID = tedarikciler.TedarikciID) ON Kasa.KasaID = SenetIslem.KasaID WHERE (((SenetIslem.SenetNo)=@CekNo));", con);
            dap.SelectCommand.Parameters.AddWithValue("@CekNo", SenetNo);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public void SecileneTedGore()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("SELECT Kasa.Kod, Kasa.Tanim, tedarikciler.unvan, SenetIslem.KayitTarihi, SenetIslem.SenetNo, SenetIslem.VadeTarihi, SenetIslem.Aciklama, SenetIslem.Giris, SenetIslem.Cikis FROM Kasa INNER JOIN (SenetIslem INNER JOIN tedarikciler ON SenetIslem.TedarikciID = tedarikciler.TedarikciID) ON Kasa.KasaID = SenetIslem.KasaID WHERE (((SenetIslem.TedarikciID)=@TedID))", con);
            dap.SelectCommand.Parameters.AddWithValue("@TedID", TedID);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void RaporlarKasaNakit_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            SeciliKasa = SenetRaporlari.SeciliKasa.ToString();
            VadeTarih = SenetRaporlari.VadeTarihi.ToString();
            TedID = SenetRaporlari.TedID;
            SenetNo = SenetRaporlari.SenetNo;
            if (!string.IsNullOrEmpty(VadeTarih) || !string.IsNullOrEmpty(SeciliKasa))
            {
                if (!string.IsNullOrEmpty(VadeTarih) && !string.IsNullOrEmpty(SeciliKasa))
                {
                    SecileneGoreKasaveVadeTarihi(SeciliKasa);
                }
                else
                {
                    SecileneGoreKasa(SeciliKasa);
                }
            }
            else
                if (!string.IsNullOrEmpty(SenetNo))
                {
                    SecileneSenetGore();
                }
                else
                {
                    SecileneTedGore();
                }
        }
    }
}
