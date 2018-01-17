using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace TaseronTakip
{
    public partial class Anamenu : Form
    {
        public Anamenu()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection(connect.connectroad);
        #region KasayaGirenler
        private static double KGTNakit;
        private static double KGTBanka;
        private static double KGTSenet;
        private static double KGTCek;
        private static double KGToplamlar;
        private static double KGAyNakit;
        private static double KGAyBanka;
        private static double KGAySenet;
        private static double KGAyCek;
        private static double KGAylar;
        #endregion
        #region KasadanCikanlar
        private static double KCTNakit;
        private static double KCTBanka;
        private static double KCTSenet;
        private static double KCTCek;
        private static double KCToplamlar;
        private static double KCAyNakit;
        private static double KCAyBanka;
        private static double KCAySenet;
        private static double KCAyCek;
        private static double KCAylar;
        #endregion
        string AdresLink;
        private void kasaraporlaribtn_Click(object sender, EventArgs e)
        {
            //KasaNakitRaporlari KR = new KasaNakitRaporlari();
            //KR.Show();
        }
        private void personelraporlaribtn_Click(object sender, EventArgs e)
        {
            PersonelTahakkukRaporlari PR = new PersonelTahakkukRaporlari();
            PR.Show();
        }
        private void tedarikcibtn_Click(object sender, EventArgs e)
        {
            TedarikciCariKarti TCK = new TedarikciCariKarti();
            TCK.Show();
        }
        private void nakitGirişiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NakitGiris NG = new NakitGiris();
            NG.ShowDialog();
            KasayaGirenToplamNakit();
            AylıkKasayaGirenToplamNakit();
            KalanNakit();
        }
        private void bankaGirişiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BankaGiris BG = new BankaGiris();
            BG.ShowDialog();
            KasayaGirenToplamBanka();
            AylıkKasayaGirenToplamBanka();
            KalanBanka();
        }
        private void çekGirişiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CekGiris CG = new CekGiris();
            CG.ShowDialog();
            KasayaGirenToplamCek();
            AylıkKasayaGirenToplamCek();
            KalanCek();
        }
        private void senetGirişToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SenetGiris SG = new SenetGiris();
            SG.ShowDialog();
            KasayaGirenToplamSenet();
            AylıkKasayaGirenToplamSenet();
            KalanSenet();
        }
        private void nakitÇıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NakitCikis NC = new NakitCikis();
            NC.ShowDialog();
            KasadanCikanToplamNakit();
            AylıkKasadanCikanToplamNakit();
            KalanNakit();
            GelKasalar();
        }
        private void bankaÇıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BankaCikis BC = new BankaCikis();
            BC.ShowDialog();
            KasadanCikanToplamBanka();
            AylıkKasadanCikanToplamBanka();
            KalanBanka();
            GelKasalar();
        }
        private void çekÇıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CekCikis CC = new CekCikis();
            CC.ShowDialog();
            KasadanCikanToplamCek();
            AylıkKasadanCikanToplamCek();
            KalanCek();
            GelKasalar();
        }
        private void senetÇıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SenetCikis SC = new SenetCikis();
            SC.ShowDialog();
            KasadanCikanToplamSenet();
            AylıkKasadanCikanToplamSenet();
            KalanSenet();
            GelKasalar();
        }
        private void personelTakipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonelCariKarti PCK = new PersonelCariKarti();
            PCK.Show();
        }
        private void maaşTahakkukToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonelTahakkuk PT = new PersonelTahakkuk();
            PT.ShowDialog();
            KasadanCikanToplamNakit();
            AylıkKasadanCikanToplamNakit();
            KasadanCikanToplamBanka();
            AylıkKasadanCikanToplamBanka();
            KalanNakit();
            KalanBanka();
            GelKasalar();
        }
        private void tedarikçiTakipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TedarikciCariKarti TCK = new TedarikciCariKarti();
            TCK.Show();
        }
        private void yedeklemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YedekAl YA = new YedekAl();
            YA.Show();
        }
        private void yedekGeriYükleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YedekGeriYukle YGY = new YedekGeriYukle();
            YGY.ShowDialog();
        }
        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About H = new About();
            H.Show();
        }
        private void iletişimToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #region Kalanlar
        private void KalanNakit()
        {
            double KalanToplam = KGTNakit - KCTNakit;
            if (KalanToplam == 0)
            {
                KasadaKalanToplamNakitlbl.Text = "0,00";
            }
            else
            {
                KasadaKalanToplamNakitlbl.Text = string.Format("{0:#,###,###.##}", KalanToplam);
            }
            double KalanAy = KGAyNakit - KCAyNakit;
            if (KalanAy == 0)
            {
                KasadaKalanAyNakitlbl.Text = "0,00";
            }
            else
            {
                KasadaKalanAyNakitlbl.Text = string.Format("{0:#,###,###.##}", KalanAy);
            }
        }
        private void KalanBanka()
        {
            double Kalan = KGTBanka - KCTBanka;
            if (Kalan == 0)
            {
                KasadaKalanToplamBankalbl.Text = "0,00";
            }
            else
            {
                KasadaKalanToplamBankalbl.Text = string.Format("{0:#,###,###.##}", Kalan);
            }
            double KalanAy = KGAyBanka - KCAyBanka;
            if (KalanAy == 0)
            {
                KasadaKalanAyBankalbl.Text = "0,00";
            }
            else
            {
                KasadaKalanAyBankalbl.Text = string.Format("{0:#,###,###.##}", KalanAy);
            }
        }
        private void KalanSenet()
        {
            double Kalan = KGTSenet - KCTSenet;
            if (Kalan == 0)
            {
                KasadaKalanToplamSenetlbl.Text = "0,00";
            }
            else
            {
                KasadaKalanToplamSenetlbl.Text = string.Format("{0:#,###,###.##}", Kalan);
            }
            double KalanAy = KGAySenet - KCAySenet;
            if (KalanAy == 0)
            {
                KasadaKalanAySenetlbl.Text = "0,00";
            }
            else
            {
                KasadaKalanAySenetlbl.Text = string.Format("{0:#,###,###.##}", KalanAy);
            }
        }
        private void KalanCek()
        {
            double Kalan = KGTCek - KCTCek;
            if (Kalan == 0)
            {
                KasadaKalanToplamCeklbl.Text = "0,00";
            }
            else
            {
                KasadaKalanToplamCeklbl.Text = string.Format("{0:#,###,###.##}", Kalan);
            }
            double KalanAy = KGAyCek - KCAyCek;
            if (KalanAy == 0)
            {
                KasadaKalanAyCeklbl.Text = "0,00";
            }
            else
            {
                KasadaKalanAyCeklbl.Text = string.Format("{0:#,###,###.##}", KalanAy);
            }
        }
        #endregion
        #region KasayaGirenIslemler
        public void KasayaGirenToplamNakit()
        {
            OleDbCommand com = new OleDbCommand("SELECT SUM(Gelir) FROM NakitIslem", con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            OleDbDataReader dr = com.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (dr.HasRows)
                    {
                        if (dr[0].ToString() == "" || dr[0].ToString() == "0" || dr[0].ToString() == null)
                        {
                            KGTNakit = 0;
                            KasayaGirenToplamNakitlbl.Text = "0,00";
                        }
                        else
                        {
                            KGTNakit = Convert.ToDouble(dr[0]);
                            KasayaGirenToplamNakitlbl.Text = string.Format("{0:#,###,###.##}", KGTNakit);
                        }
                        KGToplamlar += KGTNakit;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
                dr.Close();
            }
        }
        public void AylıkKasayaGirenToplamNakit()
        {
            OleDbCommand com = new OleDbCommand("SELECT SUM(Gelir) As Deyim1 FROM NakitIslem WHERE (((Month([NakitIslem.Tarih]))=@Tarih))", con);
            com.Parameters.AddWithValue("@Tarih", DateTime.Now.Month);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            OleDbDataReader dr = com.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (dr.HasRows)
                    {
                        if (dr[0].ToString() == "" || dr[0].ToString() == "0" || dr[0].ToString() == null)
                        {
                            KGAyNakit = 0;
                            KasayaGirenAyNakitlbl.Text = "0,00";
                        }
                        else
                        {
                            KGAyNakit = Convert.ToDouble(dr[0]);
                            KasayaGirenAyNakitlbl.Text = string.Format("{0:#,###,###.##}", KGAyNakit);
                        }
                        KGAylar += KGAyNakit;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
                dr.Close();
            }
        }
        public void KasayaGirenToplamBanka()
        {
            OleDbCommand com = new OleDbCommand("SELECT SUM(Gelir) FROM BankaIslem", con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            OleDbDataReader dr = com.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (dr.HasRows)
                    {
                        if (dr[0].ToString() == "" || dr[0].ToString() == "0" || dr[0].ToString() == null)
                        {
                            KGTBanka = 0;
                            KasayaGirenToplamBankalbl.Text = "0,00";
                        }
                        else
                        {
                            KGTBanka = Convert.ToDouble(dr[0]);
                            KasayaGirenToplamBankalbl.Text = string.Format("{0:#,###,###.##}", KGTBanka);
                        }
                        KGToplamlar += KGTBanka;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
                dr.Close();
            }
        }
        public void AylıkKasayaGirenToplamBanka()
        {
            OleDbCommand com = new OleDbCommand("SELECT SUM(Gelir) As Deyim1 FROM BankaIslem WHERE (((Month([BankaIslem.Tarih]))=@Tarih))", con);
            com.Parameters.AddWithValue("@Tarih", DateTime.Now.Month);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            OleDbDataReader dr = com.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (dr.HasRows)
                    {
                        if (dr[0].ToString() == "" || dr[0].ToString() == "0" || dr[0].ToString() == null)
                        {
                            KGAyBanka = 0;
                            KasayaGirenAyBankalbl.Text = "0,00";
                        }
                        else
                        {
                            KGAyBanka = Convert.ToDouble(dr[0]);
                            KasayaGirenAyBankalbl.Text = string.Format("{0:#,###,###.##}", KGAyBanka);
                        }
                        KGAylar += KGAyBanka;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
                dr.Close();
            }
        }
        public void KasayaGirenToplamCek()
        {
            OleDbCommand com = new OleDbCommand("SELECT SUM(Giris) FROM CekIslem", con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            OleDbDataReader dr = com.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (dr.HasRows)
                    {
                        if (dr[0].ToString() == "" || dr[0].ToString() == "0" || dr[0].ToString() == null)
                        {
                            KGTCek = 0;
                            KasayaGirenToplamCeklbl.Text = "0,00";
                        }
                        else
                        {
                            KGTCek = Convert.ToDouble(dr[0]);
                            KasayaGirenToplamCeklbl.Text = string.Format("{0:#,###,###.##}", KGTCek);
                        }
                        KGToplamlar += KGTCek;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
                dr.Close();
            }
        }
        public void AylıkKasayaGirenToplamCek()
        {
            OleDbCommand com = new OleDbCommand("SELECT SUM(Giris) As Deyim1 FROM CekIslem WHERE (((Month([CekIslem.DuzenlemeTarihi]))=@Tarih))", con);
            com.Parameters.AddWithValue("@Tarih", DateTime.Now.Month);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            OleDbDataReader dr = com.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (dr.HasRows)
                    {
                        if (dr[0].ToString() == "" || dr[0].ToString() == "0" || dr[0].ToString() == null)
                        {
                            KGAyCek = 0;
                            KasayaGirenAyCeklbl.Text = "0,00";
                        }
                        else
                        {
                            KGAyCek = Convert.ToDouble(dr[0]);
                            KasayaGirenAyCeklbl.Text = string.Format("{0:#,###,###.##}", KGAyCek);
                        }
                        KGAylar += KGAyCek;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
                dr.Close();
            }
        }
        public void KasayaGirenToplamSenet()
        {
            OleDbCommand com = new OleDbCommand("SELECT SUM(Giris) FROM SenetIslem", con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            OleDbDataReader dr = com.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (dr.HasRows)
                    {
                        if (dr[0].ToString() == "" || dr[0].ToString() == "0" || dr[0].ToString() == null)
                        {
                            KGTSenet = 0;
                            KasayaGirenToplamSenetlbl.Text = "0,00";
                        }
                        else
                        {
                            KGTSenet = Convert.ToDouble(dr[0]);
                            KasayaGirenToplamSenetlbl.Text = string.Format("{0:#,###,###.##}", KGTSenet);
                        }
                        KGToplamlar += KGTSenet;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
                dr.Close();
            }
        }
        public void AylıkKasayaGirenToplamSenet()
        {
            OleDbCommand com = new OleDbCommand("SELECT SUM(Giris) As Deyim1 FROM SenetIslem WHERE (((Month([SenetIslem.DuzenlemeTarihi]))=@Tarih))", con);
            com.Parameters.AddWithValue("@Tarih", DateTime.Now.Month);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            OleDbDataReader dr = com.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (dr.HasRows)
                    {
                        if (dr[0].ToString() == "" || dr[0].ToString() == "0" || dr[0].ToString() == null)
                        {
                            KGAySenet = 0;
                            KasayaGirenAySenetlbl.Text = "0,00";
                        }
                        else
                        {
                            KGAySenet = Convert.ToDouble(dr[0]);
                            KasayaGirenAySenetlbl.Text = string.Format("{0:#,###,###.##}", KGAySenet);
                        }
                        KGAylar += KGAySenet;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
                dr.Close();
            }
        }
        #endregion
        #region KasayaCikanIslemler
        public void KasadanCikanToplamNakit()
        {
            OleDbCommand com = new OleDbCommand("SELECT SUM(Gider) FROM NakitIslem", con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            OleDbDataReader dr = com.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (dr.HasRows)
                    {
                        if (dr[0].ToString() == "" || dr[0].ToString() == "0" || dr[0].ToString() == null)
                        {
                            KCTNakit = 0;
                            KasadanCikanToplamNakitlbl.Text = "0,00";
                        }
                        else
                        {
                            KCTNakit = Convert.ToDouble(dr[0]);
                            KasadanCikanToplamNakitlbl.Text = string.Format("{0:#,###,###.##}", KCTNakit);
                        }
                        KCToplamlar += KCTNakit;
                        ToplamKasadanCikanGenel.Text = string.Format("{0:#,###,###.##}", KCToplamlar);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
                dr.Close();
            }
        }
        public void AylıkKasadanCikanToplamNakit()
        {
            OleDbCommand com = new OleDbCommand("SELECT SUM(Gider) As Deyim1 FROM NakitIslem WHERE (((Month([NakitIslem.Tarih]))=@Tarih))", con);
            com.Parameters.AddWithValue("@Tarih", DateTime.Now.Month);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            OleDbDataReader dr = com.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (dr.HasRows)
                    {
                        if (dr[0].ToString() == "" || dr[0].ToString() == "0" || dr[0].ToString() == null)
                        {
                            KCAyNakit = 0;
                            KasadanCikanAyNakitlbl.Text = "0,00";
                        }
                        else
                        {
                            KCAyNakit = Convert.ToDouble(dr[0]);
                            KasadanCikanAyNakitlbl.Text = string.Format("{0:#,###,###.##}", KCAyNakit);
                        }
                        KCAylar += KCAyNakit;
                        ToplamKasadanCikanGenelAy.Text = string.Format("{0:#,###,###.##}", KCAylar);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
                dr.Close();
            }
        }
        public void KasadanCikanToplamBanka()
        {
            OleDbCommand com = new OleDbCommand("SELECT SUM(Gider) FROM BankaIslem", con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            OleDbDataReader dr = com.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (dr.HasRows)
                    {
                        if (dr[0].ToString() == "" || dr[0].ToString() == "0" || dr[0].ToString() == null)
                        {
                            KCTBanka = 0;
                            KasadanCikanToplamBankalbl.Text = "0,00";
                        }
                        else
                        {
                            KCTBanka = Convert.ToDouble(dr[0]);
                            KasadanCikanToplamBankalbl.Text = string.Format("{0:#,###,###.##}", KCTBanka);
                        }
                        KCToplamlar += KCTBanka;
                        ToplamKasadanCikanGenel.Text = string.Format("{0:#,###,###.##}", KCToplamlar);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
                dr.Close();
            }
        }
        public void AylıkKasadanCikanToplamBanka()
        {
            OleDbCommand com = new OleDbCommand("SELECT SUM(Gider) As Deyim1 FROM BankaIslem WHERE (((Month([BankaIslem.Tarih]))=@Tarih))", con);
            com.Parameters.AddWithValue("@Tarih", DateTime.Now.Month);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            OleDbDataReader dr = com.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (dr.HasRows)
                    {
                        if (dr[0].ToString() == "" || dr[0].ToString() == "0" || dr[0].ToString() == null)
                        {
                            KCAyBanka = 0;
                            KasadanCikanAyBankalbl.Text = "0,00";
                        }
                        else
                        {
                            KCAyBanka = Convert.ToDouble(dr[0]);
                            KasadanCikanAyBankalbl.Text = string.Format("{0:#,###,###.##}", KCAyBanka);
                        }
                        KCAylar += KCAyBanka;
                        ToplamKasadanCikanGenelAy.Text = string.Format("{0:#,###,###.##}", KCAylar);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
                dr.Close();
            }
        }
        public void KasadanCikanToplamCek()
        {
            OleDbCommand com = new OleDbCommand("SELECT SUM(Cikis) FROM CekIslem", con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            OleDbDataReader dr = com.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (dr.HasRows)
                    {
                        if (dr[0].ToString() == "" || dr[0].ToString() == "0" || dr[0].ToString() == null)
                        {
                            KCTCek = 0;
                            KasadanCikanToplamCeklbl.Text = "0,00";
                        }
                        else
                        {
                            KCTCek = Convert.ToDouble(dr[0]);
                            KasadanCikanToplamCeklbl.Text = string.Format("{0:#,###,###.##}", KCTCek);
                        }
                        KCToplamlar += KCTCek;
                        ToplamKasadanCikanGenel.Text = string.Format("{0:#,###,###.##}", KCToplamlar);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
                dr.Close();
            }
        }
        public void AylıkKasadanCikanToplamCek()
        {
            OleDbCommand com = new OleDbCommand("SELECT SUM(Cikis) As Deyim1 FROM CekIslem WHERE (((Month([CekIslem.DuzenlemeTarihi]))=@Tarih))", con);
            com.Parameters.AddWithValue("@Tarih", DateTime.Now.Month);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            OleDbDataReader dr = com.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (dr.HasRows)
                    {
                        if (dr[0].ToString() == "" || dr[0].ToString() == "0" || dr[0].ToString() == null)
                        {
                            KCAyCek = 0;
                            KasadanCikanAyCeklbl.Text = "0,00";
                        }
                        else
                        {
                            KCAyCek = Convert.ToDouble(dr[0]);
                            KasadanCikanAyCeklbl.Text = string.Format("{0:#,###,###.##}", KCAyCek);
                        }
                        KCAylar += KCAyCek;
                        ToplamKasadanCikanGenelAy.Text = string.Format("{0:#,###,###.##}", KCAylar);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
                dr.Close();
            }
        }
        public void KasadanCikanToplamSenet()
        {
            OleDbCommand com = new OleDbCommand("SELECT SUM(Cikis) FROM SenetIslem", con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            OleDbDataReader dr = com.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (dr.HasRows)
                    {
                        if (dr[0].ToString() == "" || dr[0].ToString() == "0" || dr[0].ToString() == null)
                        {
                            KCTSenet = 0;
                            KasadanCikanToplamSenetlbl.Text = "0,00";
                        }
                        else
                        {
                            KCTSenet = Convert.ToDouble(dr[0]);
                            KasadanCikanToplamSenetlbl.Text = string.Format("{0:#,###,###.##}", KCTSenet);
                        }
                        KCToplamlar += KCTSenet;
                        ToplamKasadanCikanGenel.Text = string.Format("{0:#,###,###.##}", KCToplamlar);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
                dr.Close();
            }
        }
        public void AylıkKasadanCikanToplamSenet()
        {
            OleDbCommand com = new OleDbCommand("SELECT SUM(Cikis) As Deyim1 FROM SenetIslem WHERE (((Month([SenetIslem.DuzenlemeTarihi]))=@Tarih))", con);
            com.Parameters.AddWithValue("@Tarih", DateTime.Now.Month);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            OleDbDataReader dr = com.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (dr.HasRows)
                    {
                        if (dr[0].ToString() == "" || dr[0].ToString() == "0" || dr[0].ToString() == null)
                        {
                            KCAySenet = 0;
                            KasadanCikanAySenetlbl.Text = "0,00";
                        }
                        else
                        {
                            KCAySenet = Convert.ToDouble(dr[0]);
                            KasadanCikanAySenetlbl.Text = string.Format("{0:#,###,###.##}", KCAySenet);
                        }
                        KCAylar += KCAySenet;
                        ToplamKasadanCikanGenelAy.Text = string.Format("{0:#,###,###.##}", KCAylar);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
                dr.Close();
            }
        }
        #endregion
        public void GelAyBilgisi()
        {
            switch (DateTime.Now.Month)
            {
                case 1:
                    Aylbl.Text = "Ocak";
                    break;
                case 2:
                    Aylbl.Text = "Şubat";
                    break;
                case 3:
                    Aylbl.Text = "Mart";
                    break;
                case 4:
                    Aylbl.Text = "Nisan";
                    break;
                case 5:
                    Aylbl.Text = "Mayıs";
                    break;
                case 6:
                    Aylbl.Text = "Haziran";
                    break;
                case 7:
                    Aylbl.Text = "Temmuz";
                    break;
                case 8:
                    Aylbl.Text = "Ağustos";
                    break;
                case 9:
                    Aylbl.Text = "Eylül";
                    break;
                case 10:
                    Aylbl.Text = "Ekim";
                    break;
                case 11:
                    Aylbl.Text = "Kasım";
                    break;
                case 12:
                    Aylbl.Text = "Aralık";
                    break;
            }
        }
        public void GelKasalar()
        {
            OleDbDataAdapter dap = new OleDbDataAdapter("SELECT Kasa.Kod,Kasa.Tanim, Sum(BankaIslem.Gider) AS BankaCikis, Sum(CekIslem.Cikis) AS CekCikis, Sum(NakitIslem.Gider) AS NakitCikis, Sum(SenetIslem.Cikis) AS SenetCikis FROM (((Kasa LEFT JOIN BankaIslem ON Kasa.KasaID = BankaIslem.KasaID) LEFT JOIN CekIslem ON Kasa.KasaID = CekIslem.KasaID) LEFT JOIN NakitIslem ON Kasa.KasaID = NakitIslem.KasaID) LEFT JOIN SenetIslem ON Kasa.KasaID = SenetIslem.KasaID GROUP BY Kasa.Kod,Kasa.Tanim;", con);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[2].HeaderText = "Banka Çıkış";
            dataGridView1.Columns[3].HeaderText = "Çek Çıkış";
            dataGridView1.Columns[4].HeaderText = "Nakit Çıkış";
            dataGridView1.Columns[5].HeaderText = "Senet Çıkış";
        }
        private void Anamenu_Load(object sender, EventArgs e)
        {
            KasayaGirenToplamNakit();
            AylıkKasayaGirenToplamNakit();
            KasayaGirenToplamBanka();
            AylıkKasayaGirenToplamBanka();
            KasayaGirenToplamCek();
            AylıkKasayaGirenToplamCek();
            KasayaGirenToplamSenet();
            AylıkKasayaGirenToplamSenet();
            KasadanCikanToplamNakit();
            AylıkKasadanCikanToplamNakit();
            KasadanCikanToplamBanka();
            AylıkKasadanCikanToplamBanka();
            KasadanCikanToplamSenet();
            AylıkKasadanCikanToplamSenet();
            KasadanCikanToplamCek();
            AylıkKasadanCikanToplamCek();
            KalanNakit();
            KalanBanka();
            KalanSenet();
            KalanCek();
            GelAyBilgisi();
            GelKasalar();
            dataGridView1.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void faturaTahakkukToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FirmaFaturaTahukkuk FFT = new FirmaFaturaTahukkuk();
            FFT.Show();
        }
        private void dToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NakitRaporlari NR = new NakitRaporlari();
            NR.Show();
        }
        private void kasaBankaRaporlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BankaRaporlari KR = new BankaRaporlari();
            KR.Show();
        }
        private void kasaÇekRaporlarıToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CekRaporlari CK = new CekRaporlari();
            CK.Show();
        }
        private void kasaSenetRaporlarıToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SenetRaporlari SR = new SenetRaporlari();
            SR.Show();
        }
        private void personelTahakkukRaporlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonelTahakkukRaporlari PR = new PersonelTahakkukRaporlari();
            PR.Show();
        }
        private void personelÖdemeRaporlarıToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PersonelMaasRaporlari PMR  = new PersonelMaasRaporlari();
            PMR.Show();
        }
        private void cariFaturaRaporlarıToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CariFaturaRaporlari CFR = new CariFaturaRaporlari();
            CFR.Show();
        }
        private void cariÖdemeRaporlarıToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CariOdemeRaporlari COR = new CariOdemeRaporlari();
            COR.Show();
        }
        private void cariEkstresiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CariEkstresi CE = new CariEkstresi();
            CE.Show();
        }
    }
}
