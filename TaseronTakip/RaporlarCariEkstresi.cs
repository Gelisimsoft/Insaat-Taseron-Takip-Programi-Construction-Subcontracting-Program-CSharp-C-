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
    public partial class RaporlarCariEkstresi : Form
    {
        public RaporlarCariEkstresi()
        {
            InitializeComponent();
        }
        public static int Cari = 0;
        public static string IlkTarih = "";
        public static string IkinciTarih = "";
        OleDbConnection con = new OleDbConnection(connect.connectroad);
        public void IlkTariheGoreKasa()
        {
            IkinciTarih = "31.12.2199";
            OleDbDataAdapter dap = new OleDbDataAdapter("SELECT tedarikciler.unvan, CariEkstre.Tarih, CariEkstre.Aciklama, CariEkstre.FaturaTutari, CariEkstre.OdemeTutari, CariEkstre.Islem FROM tedarikciler INNER JOIN CariEkstre ON tedarikciler.TedarikciID = CariEkstre.TedarikciID WHERE (((CariEkstre.Tarih) Between [@IlkD] And [@IkinciD]) AND ((CariEkstre.TedarikciID)=" + Cari + ")) GROUP BY tedarikciler.unvan, CariEkstre.Tarih, CariEkstre.Aciklama, CariEkstre.FaturaTutari, CariEkstre.OdemeTutari, CariEkstre.Islem", con);
            dap.SelectCommand.Parameters.AddWithValue("@IlkD", IlkTarih);
            dap.SelectCommand.Parameters.AddWithValue("@IkinciD", IkinciTarih);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public void IkinciTariheGoreKasa()
        {
            IlkTarih = "01.01.1900";
            OleDbDataAdapter dap = new OleDbDataAdapter("SELECT tedarikciler.unvan, CariEkstre.Tarih, CariEkstre.Aciklama, CariEkstre.FaturaTutari, CariEkstre.OdemeTutari, CariEkstre.Islem FROM tedarikciler INNER JOIN CariEkstre ON tedarikciler.TedarikciID = CariEkstre.TedarikciID WHERE (((CariEkstre.Tarih) Between [@IlkD] And [@IkinciD]) AND ((CariEkstre.TedarikciID)=" + Cari + ")) GROUP BY tedarikciler.unvan, CariEkstre.Tarih, CariEkstre.Aciklama, CariEkstre.FaturaTutari, CariEkstre.OdemeTutari, CariEkstre.Islem", con);
            dap.SelectCommand.Parameters.AddWithValue("@IlkD", IlkTarih);
            dap.SelectCommand.Parameters.AddWithValue("@IkinciD", IkinciTarih);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public void IlkveIkinciTariheGoreKasa()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("SELECT tedarikciler.unvan, CariEkstre.Tarih, CariEkstre.Aciklama, CariEkstre.FaturaTutari, CariEkstre.OdemeTutari, CariEkstre.Islem FROM tedarikciler INNER JOIN CariEkstre ON tedarikciler.TedarikciID = CariEkstre.TedarikciID WHERE (((CariEkstre.Tarih) Between [@IlkD] And [@IkinciD]) AND ((CariEkstre.TedarikciID)=" + Cari + ")) GROUP BY tedarikciler.unvan, CariEkstre.Tarih, CariEkstre.Aciklama, CariEkstre.FaturaTutari, CariEkstre.OdemeTutari, CariEkstre.Islem", con);
            dap.SelectCommand.Parameters.AddWithValue("@IlkD", IlkTarih);
            dap.SelectCommand.Parameters.AddWithValue("@IkinciD", IkinciTarih);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public void TarihsizSiralaGoreKasa()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("SELECT tedarikciler.unvan, CariEkstre.Tarih, CariEkstre.Aciklama, CariEkstre.FaturaTutari, CariEkstre.OdemeTutari, CariEkstre.Islem FROM tedarikciler INNER JOIN CariEkstre ON tedarikciler.TedarikciID = CariEkstre.TedarikciID WHERE (((CariEkstre.TedarikciID)=" + Cari + ")) GROUP BY tedarikciler.unvan, CariEkstre.Tarih, CariEkstre.Aciklama, CariEkstre.FaturaTutari, CariEkstre.OdemeTutari, CariEkstre.Islem", con);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void RaporlarKasaNakit_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Cari = CariEkstresi.SeciliCari;
            IlkTarih = CariEkstresi.IlkTarih;
            IkinciTarih = CariEkstresi.IkinciTarih;
            if (!string.IsNullOrEmpty(IlkTarih) && string.IsNullOrEmpty(IkinciTarih))
            {
                IlkTariheGoreKasa();
            }
            else
                if (string.IsNullOrEmpty(IlkTarih) && !string.IsNullOrEmpty(IkinciTarih))
                {
                    IkinciTariheGoreKasa();
                }
                else
                    if (!string.IsNullOrEmpty(IlkTarih) && !string.IsNullOrEmpty(IkinciTarih))
                    {
                        IlkveIkinciTariheGoreKasa();
                    }
                    else
                    {
                        TarihsizSiralaGoreKasa();
                    }
        }
    }
}
