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
    public partial class CariFaturaRaporlari : Form
    {
        public CariFaturaRaporlari()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection(connect.connectroad);
        public static int SeciliCari = 0;
        public static string IlkTarih = "";
        public static string IkinciTarih = "";
        private void CariGelArama()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("select * from tedarikciler where ((tedarikciler.IsActive)=True) order by unvan", con);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            if (dt != null)
            {
                DataRow dr = dt.NewRow();
                dr["unvan"] = "Lütfen Seçiniz";
                dt.Rows.InsertAt(dr, 0);
                CariKombo.DataSource = dt;
                CariKombo.DisplayMember = "unvan";
                CariKombo.ValueMember = "TedarikciID";
            }
        }
        private void CariFaturaRaporlari_Load(object sender, EventArgs e)
        {
            CariGelArama();
        }
        private void Raporlabtn_Click(object sender, EventArgs e)
        {
            if (CariKombo.Text != "Lütfen Seçiniz")
            {
                SeciliCari = (Int32)CariKombo.SelectedValue;
                IlkTarih = tarih1box.Text;
                IkinciTarih = Tarih2box.Text;
                RaporlarCariFaturalar RKN = new RaporlarCariFaturalar();
                RKN.ShowDialog();
            }
            else
            {
                MessageBox.Show("Cari Seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            tarih1box.Text = dateTimePicker1.Value.ToShortDateString();
        }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            Tarih2box.Text = dateTimePicker2.Value.ToShortDateString();
        }
    }
}
