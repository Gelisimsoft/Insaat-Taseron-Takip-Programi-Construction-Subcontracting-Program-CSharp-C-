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
    public partial class PersonelCariKarti : Form
    {
        public PersonelCariKarti()
        {
            InitializeComponent();
        }
        public static int GidenID;
        public void Listemidoldur()
        {
            OleDbDataAdapter dappersn = new OleDbDataAdapter("select personelID,adsoyad,gorev,tcno,adres,ceptlf,evtlf,isegiris,cikisdate,maas,Yemek,Yol from personeller WHERE ((personeller.IsActive)=True) order by adsoyad", con);
            DataTable pdet = new DataTable();
            dappersn.Fill(pdet);
            dataGridView1.DataSource = pdet;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Adı Soyadı";
            dataGridView1.Columns[2].HeaderText = "Görevi";
            dataGridView1.Columns[3].HeaderText = "Tcno";
            dataGridView1.Columns[4].HeaderText = "Adres";
            dataGridView1.Columns[5].HeaderText = "Cep Tel";
            dataGridView1.Columns[6].HeaderText = "Ev Tel";
            dataGridView1.Columns[7].HeaderText = "Giriş Tarihi";
            dataGridView1.Columns[8].HeaderText = "Çıkış Tarihi";
            dataGridView1.Columns[9].HeaderText = "Maaş";
            dataGridView1.Columns[10].HeaderText = "Yemek Yardımı";
            dataGridView1.Columns[11].HeaderText = "Yol Yardımı";
            if (pdet.Rows.Count != 0)
            {
                dataGridView1.Rows[0].Selected = false;
                //dataGridView1.AutoResizeColumns();
                //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }
        OleDbConnection con = new OleDbConnection(connect.connectroad);
        private void PersonelCariKarti_Load(object sender, EventArgs e)
        {
            Listemidoldur();
            dataGridView1.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void PersonelCariKarti_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                YeniPersonel YP = new YeniPersonel();
                YP.ShowDialog();
                Listemidoldur();
            }
        }
        private void yeniPersonelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YeniPersonel YP = new YeniPersonel();
            YP.ShowDialog();
            Listemidoldur();
        }
        private void düzenlemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GidenID != 0)
            {
                PersonelCariKartiGuncelle PCKG = new PersonelCariKartiGuncelle();
                PCKG.ShowDialog();
                Listemidoldur();
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir satırlı seçiniz.");
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                GidenID = Convert.ToInt32((dataGridView1.CurrentRow.Cells[0].Value));
            }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                GidenID = Convert.ToInt32((dataGridView1.CurrentRow.Cells[0].Value));
                PersonelCariKartiGuncelle PCKG = new PersonelCariKartiGuncelle();
                PCKG.ShowDialog();
                Listemidoldur();
            }
        }
    }
}
