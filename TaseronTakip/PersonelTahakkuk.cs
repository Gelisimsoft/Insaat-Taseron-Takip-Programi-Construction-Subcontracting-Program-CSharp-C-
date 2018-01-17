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
    public partial class PersonelTahakkuk : Form
    {
        public PersonelTahakkuk()
        {
            InitializeComponent();
        }
        public static int ID;
        private static double maas, Yol, Yemek;
        OleDbConnection con = new OleDbConnection(connect.connectroad);
        public void TahakkukGelPersoneleGore()
        {
            if (AramaPersonelcombo.SelectedIndex != 0)
            {
                OleDbDataAdapter dap = new OleDbDataAdapter("SELECT Tahakkuk.TahakkukID, personeller.adsoyad, Tahakkuk.Tarih, personeller.maas, personeller.Yemek, personeller.Yol, Tahakkuk.Ucret  FROM personeller RIGHT JOIN Tahakkuk ON personeller.personelID = Tahakkuk.personelID GROUP BY Tahakkuk.TahakkukID, personeller.adsoyad, Tahakkuk.Tarih, personeller.maas, personeller.Yemek, personeller.Yol, Tahakkuk.Ucret, Tahakkuk.personelID HAVING (((Tahakkuk.personelID)=[@ID]));", con);
                dap.SelectCommand.Parameters.AddWithValue("@ID", Convert.ToInt32(AramaPersonelcombo.SelectedValue));
                DataTable dt = new DataTable();
                dap.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Adı Soyadı";
                dataGridView1.Columns[2].HeaderText = "Tahakkuk Tarihi";
                dataGridView1.Columns[3].HeaderText = "Maaş";
                dataGridView1.Columns[4].HeaderText = "Yemek Yardımı";
                dataGridView1.Columns[5].HeaderText = "Yol Yardımı";
                dataGridView1.Columns[6].HeaderText = "Tahakkuk Eden";
                if (dt.Rows.Count != 0)
                {
                    dataGridView1.Rows[0].Selected = false;
                    //dataGridView1.AutoResizeColumns();
                    //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                else
                {
                    MessageBox.Show("Kayıt bulunamadı.", "Arama", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TahukkukGel();
                }
            }
            else
            {
                MessageBox.Show("Lütfen personel seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        public void TahakkukGelTariheGore()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("SELECT Tahakkuk.TahakkukID, personeller.adsoyad, Tahakkuk.Tarih, personeller.maas, personeller.Yemek, personeller.Yol, Tahakkuk.Ucret FROM personeller RIGHT JOIN Tahakkuk ON personeller.personelID = Tahakkuk.personelID GROUP BY Tahakkuk.TahakkukID, personeller.adsoyad, Tahakkuk.Tarih, personeller.maas, personeller.Yemek, personeller.Yol, Tahakkuk.Ucret, Tahakkuk.Tarih HAVING (((Tahakkuk.Tarih)=[@Tarih]));", con);
            dap.SelectCommand.Parameters.AddWithValue("@Tarih", AramaTarihdate.Value);
            DataTable dt = new DataTable();
            dap.Fill(dt);

            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Adı Soyadı";
            dataGridView1.Columns[2].HeaderText = "Tahakkuk Tarihi";
            dataGridView1.Columns[3].HeaderText = "Maaş";
            dataGridView1.Columns[4].HeaderText = "Yemek Yardımı";
            dataGridView1.Columns[5].HeaderText = "Yol Yardımı";
            dataGridView1.Columns[6].HeaderText = "Tahakkuk Eden";
            if (dt.Rows.Count != 0)
            {
                dataGridView1.Rows[0].Selected = false;
                //dataGridView1.AutoResizeColumns();
                //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            else
            {
                MessageBox.Show("Kayıt bulunamadı.", "Arama", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TahukkukGel();
            }
        }
        public void TahukkukGel()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("SELECT Tahakkuk.TahakkukID, personeller.adsoyad, Tahakkuk.Tarih, personeller.maas, personeller.Yemek, personeller.Yol, Tahakkuk.Ucret FROM personeller RIGHT JOIN Tahakkuk ON personeller.personelID = Tahakkuk.personelID GROUP BY Tahakkuk.TahakkukID, personeller.adsoyad, Tahakkuk.Tarih, personeller.maas, personeller.Yemek, personeller.Yol, Tahakkuk.Ucret;", con);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Adı Soyadı";
            dataGridView1.Columns[2].HeaderText = "Tahakkuk Tarihi";
            dataGridView1.Columns[3].HeaderText = "Maaş";
            dataGridView1.Columns[4].HeaderText = "Yemek Yardımı";
            dataGridView1.Columns[5].HeaderText = "Yol Yardımı";
            dataGridView1.Columns[6].HeaderText = "Tahakkuk Eden";
            if (dt.Rows.Count != 0)
            {
                dataGridView1.Rows[0].Selected = false;
                //dataGridView1.AutoResizeColumns();
                //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }
        private void PersoenlGelArama()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("select * from personeller where ((personeller.IsActive)=True) order by adsoyad", con);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            if (dt != null)
            {
                DataRow dr = dt.NewRow();
                dr[1] = "Lütfen Seçiniz";
                dt.Rows.InsertAt(dr, 0);
                AramaPersonelcombo.DataSource = dt;
                AramaPersonelcombo.DisplayMember = "adsoyad";
                AramaPersonelcombo.ValueMember = "personelID";
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                ID = Convert.ToInt32((dataGridView1.CurrentRow.Cells[0].Value));
            }
        }
        private void PersonelTahakkuk_Load(object sender, EventArgs e)
        {
            TahukkukGel();
            PersoenlGelArama();
            PersoenlGelArama();
            //           dataGridView1.AutoSizeColumnsMode =
            //DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void yeniEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YeniTahakkuk YT = new YeniTahakkuk();
            YT.ShowDialog();
            TahukkukGel();
        }
        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                PersonelTahakkukGuncelle PTG = new PersonelTahakkukGuncelle();
                PTG.ShowDialog();
                TahukkukGel();
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir satırlı seçiniz.");
            }
        }
        private void PersonelTahakkuk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                YeniTahakkuk YT = new YeniTahakkuk();
                YT.ShowDialog();
                TahukkukGel();
            }
            if (e.KeyCode == Keys.F5)
            {
                TahukkukGel();
            }
        }
        private void personelarabtn_Click(object sender, EventArgs e)
        {
            if (AramaPersonelcombo.SelectedIndex == 0)
            {
                MessageBox.Show("Lütfen personel seçiniz.");
            }
            else
            {
                TahakkukGelPersoneleGore();
            }
        }
        private void AraTarihbtn_Click(object sender, EventArgs e)
        {
            TahakkukGelTariheGore();
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                ID = Convert.ToInt32((dataGridView1.CurrentRow.Cells[0].Value));
                PersonelTahakkukGuncelle PTG = new PersonelTahakkukGuncelle();
                PTG.ShowDialog();
                TahukkukGel();
            }
        }
    }
}
