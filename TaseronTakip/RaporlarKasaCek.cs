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
    public partial class RaporlarKasaCek : Form
    {
        public RaporlarKasaCek()
        {
            InitializeComponent();
        }
        public static string SeciliKasa = "";
        public static string VadeTarih = "";
        public static string CekNo = "";
        public static int TedID = 0;
        OleDbConnection con = new OleDbConnection(connect.connectroad);
        public void SecileneGoreKasa(string SecilenKasa)
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("SELECT Kasa.Kod, Kasa.Tanim, tedarikciler.unvan, CekIslem.KayitTarihi, CekIslem.CekNo, CekIslem.Banka, CekIslem.Sube, CekIslem.HesapNo, CekIslem.VadeTarihi, CekIslem.Aciklama, CekIslem.Giris, CekIslem.Cikis FROM Kasa INNER JOIN (CekIslem INNER JOIN tedarikciler ON CekIslem.TedarikciID = tedarikciler.TedarikciID) ON Kasa.KasaID = CekIslem.KasaID WHERE (((Kasa.KasaID)=" + SecilenKasa + "))", con);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public void SecileneGoreKasaveVadeTarihi(string SecilenKasa)
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("SELECT Kasa.Kod, Kasa.Tanim, tedarikciler.unvan, CekIslem.KayitTarihi, CekIslem.CekNo, CekIslem.Banka, CekIslem.Sube, CekIslem.HesapNo, CekIslem.VadeTarihi, CekIslem.Aciklama, CekIslem.Giris, CekIslem.Cikis FROM Kasa INNER JOIN (CekIslem INNER JOIN tedarikciler ON CekIslem.TedarikciID = tedarikciler.TedarikciID) ON Kasa.KasaID = CekIslem.KasaID WHERE (((CekIslem.VadeTarihi)=@Tarih) AND ((Kasa.KasaID)=" + SecilenKasa + "))", con);
            dap.SelectCommand.Parameters.AddWithValue("@Tarih", VadeTarih);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public void SecileneCekeGore()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("SELECT Kasa.Kod, Kasa.Tanim, tedarikciler.unvan, CekIslem.KayitTarihi, CekIslem.CekNo, CekIslem.Banka, CekIslem.Sube, CekIslem.HesapNo, CekIslem.VadeTarihi, CekIslem.Aciklama, CekIslem.Giris, CekIslem.Cikis FROM Kasa INNER JOIN (CekIslem INNER JOIN tedarikciler ON CekIslem.TedarikciID = tedarikciler.TedarikciID) ON Kasa.KasaID = CekIslem.KasaID WHERE (((CekIslem.CekNo)=@CekNo));", con);
            dap.SelectCommand.Parameters.AddWithValue("@CekNo", CekNo);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public void SecileneTedeGore()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("SELECT Kasa.Kod, Kasa.Tanim, tedarikciler.unvan, CekIslem.KayitTarihi, CekIslem.CekNo, CekIslem.Banka, CekIslem.Sube, CekIslem.HesapNo, CekIslem.VadeTarihi, CekIslem.Aciklama, CekIslem.Giris, CekIslem.Cikis FROM Kasa INNER JOIN (CekIslem INNER JOIN tedarikciler ON CekIslem.TedarikciID = tedarikciler.TedarikciID) ON Kasa.KasaID = CekIslem.KasaID WHERE (((CekIslem.TedarikciID)=@TedID))", con);
            dap.SelectCommand.Parameters.AddWithValue("@TedID", TedID);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void RaporlarKasaNakit_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            SeciliKasa = CekRaporlari.SeciliKasa.ToString();
            VadeTarih = CekRaporlari.VadeTarihi.ToString();
            TedID = CekRaporlari.TedID;
            CekNo = CekRaporlari.CekNo;
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
                if (!string.IsNullOrEmpty(CekNo))
                {
                    SecileneCekeGore();
                }
                else
                {
                    SecileneTedeGore();
                }
        }
    }
}
