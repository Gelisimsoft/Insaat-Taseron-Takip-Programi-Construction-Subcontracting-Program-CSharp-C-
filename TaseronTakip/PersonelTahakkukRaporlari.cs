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
    public partial class PersonelTahakkukRaporlari : Form
    {
        public PersonelTahakkukRaporlari()
        {
            InitializeComponent();
        }
        public static string ay, yil = "";
        public static int PersonelID = 0;
        OleDbConnection con = new OleDbConnection(connect.connectroad);
        private void PersoenlGel()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("select * from personeller where ((personeller.IsActive)=True) order by adsoyad", con);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            if (dt != null)
            {
                DataRow dr = dt.NewRow();
                dr["adsoyad"] = "Lütfen Seçiniz";
                dt.Rows.InsertAt(dr, 0);
                personelcombo.DataSource = dt;
                personelcombo.DisplayMember = "adsoyad";
                personelcombo.ValueMember = "personelID";
            }
        }
        private void PersonelRaporlari_Load(object sender, EventArgs e)
        {
            PersoenlGel();
        }
        private void Raporlabtn_Click(object sender, EventArgs e)
        {
            if (AycomboBox.Text == "" && SenecomboBox.Text == "")
            {
                if (personelcombo.Text != "Lütfen Seçiniz")
                {
                    ay = AycomboBox.Text;
                    yil = SenecomboBox.Text;
                    PersonelID = (Int32)personelcombo.SelectedValue;
                    RaporlarPersonellerTahakkuk RKN = new RaporlarPersonellerTahakkuk();
                    RKN.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Personel Seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
            {
                if (AycomboBox.Text != "" && SenecomboBox.Text == "")
                {
                    MessageBox.Show("Ay ve Yılı Seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                    if (SenecomboBox.Text != "" && AycomboBox.Text == "")
                    {
                        MessageBox.Show("Ay ve Yılı Seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        if (personelcombo.Text != "Lütfen Seçiniz")
                        {
                            ay = AycomboBox.Text;
                            yil = SenecomboBox.Text;
                            PersonelID = (Int32)personelcombo.SelectedValue;
                            RaporlarPersonellerTahakkuk RKN = new RaporlarPersonellerTahakkuk();
                            RKN.ShowDialog();
                        }
                    }
            }
        }
    }
}
