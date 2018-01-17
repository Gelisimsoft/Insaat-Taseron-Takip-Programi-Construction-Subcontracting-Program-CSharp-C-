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
    public partial class CariOdemeRaporlari : Form
    {
        public CariOdemeRaporlari()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection(connect.connectroad);
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
        private void CariOdemeRaporlari_Load(object sender, EventArgs e)
        {
            CariGelArama();
        }
    }
}
