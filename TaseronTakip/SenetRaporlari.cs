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
    public partial class SenetRaporlari : Form
    {
        public SenetRaporlari()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection(connect.connectroad);
        public void GiderKasa()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("select * from Kasa where ((Kasa.IsActive)=True) order by Kod", con);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            if (dt != null)
            {
                DataRow dr = dt.NewRow();
                dr["Tanim"] = "Lütfen Seçiniz";
                dt.Rows.InsertAt(dr, 0);
                kasacombo.DataSource = dt;
                kasacombo.DisplayMember = "Tanim";
                kasacombo.ValueMember = "KasaID";
            }
        }
        public void TedarikciGel()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("select * from tedarikciler where ((tedarikciler.IsActive)=True) order by unvan", con);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            if (dt != null)
            {
                DataRow dr = dt.NewRow();
                dr["unvan"] = "Lütfen Seçiniz";
                dt.Rows.InsertAt(dr, 0);
                Tcombo.DataSource = dt;
                Tcombo.DisplayMember = "unvan";
                Tcombo.ValueMember = "TedarikciID";
            }
        }
        public static string SeciliKasa = "";
        public static string VadeTarihi = "";
        public static string SenetNo = "";
        public static int TedID = 0;
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            tarih1box.Text = dateTimePicker1.Value.ToShortDateString();
        }
        private void Raporlabtn_Click(object sender, EventArgs e)
        {
            if (kasacombo.Text != "Lütfen Seçiniz")
            {
                SeciliKasa = kasacombo.SelectedValue.ToString();
                VadeTarihi = tarih1box.Text;
                SenetNo = "";
                TedID = 0;
                RaporlarKasaSenet RKN = new RaporlarKasaSenet();
                RKN.ShowDialog();
            }
            else
            {
                MessageBox.Show("Kasa Seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void SenetRaporlari_Load(object sender, EventArgs e)
        {
            GiderKasa();
            TedarikciGel();
        }
        private void RaporlaSenetBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Senetnobox.Text))
            {
                SeciliKasa = "";
                VadeTarihi = "";
                TedID = 0;
                SenetNo = Senetnobox.Text;
                RaporlarKasaSenet RKN = new RaporlarKasaSenet();
                RKN.ShowDialog();
            }
            else
            {
                MessageBox.Show("Senet Numarasını Yazınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void RaporlaTedBtn_Click(object sender, EventArgs e)
        {
            if (Tcombo.Text != "Lütfen Seçiniz")
            {
                SeciliKasa = "";
                VadeTarihi = "";
                SenetNo = "";
                TedID = (Int32)Tcombo.SelectedValue;
                RaporlarKasaSenet RKN = new RaporlarKasaSenet();
                RKN.ShowDialog();
            }
            else
            {
                MessageBox.Show("Tedarikçi Seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
