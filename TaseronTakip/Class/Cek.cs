using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace TaseronTakip.Class
{
    class Cek
    {
        public int CekID { get; set; }
        public string KayitTarihi { get; set; }
        public DateTime DuzenlemeTarihi { get; set; }
        public string Aciklama { get; set; }
        public string CekNo { get; set; }
        public string Banka { get; set; }
        public string Sube { get; set; }
        public int HesapNo { get; set; }
        public DateTime VadeTarihi { get; set; }
        public double Giris { get; set; }
        public double Cikis { get; set; }
        public int KasaID { get; set; }
        public string Kod { get; set; }
        public string Tanim { get; set; }
        public string unvan { get; set; }

        public static DataTable KasaVeZaman(string tarih, int Kasa)
        {
            OleDbConnection con = new OleDbConnection(connect.connectroad);
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT Kasa.Kod, Kasa.Tanim, CekIslem.DuzenlemeTarihi, tedarikciler.unvan, CekIslem.Aciklama, CekIslem.CekNo, CekIslem.Banka, CekIslem.Sube, CekIslem.HesapNo, CekIslem.VadeTarihi, CekIslem.Giris, CekIslem.Cikis FROM (Kasa INNER JOIN CekIslem ON Kasa.KasaID = CekIslem.KasaID) INNER JOIN tedarikciler ON CekIslem.TedarikciID = tedarikciler.TedarikciID WHERE (((CekIslem.VadeTarihi)=@Tarih) AND ((CekIslem.KasaID)=@ID)) order by CekIslem.DuzenlemeTarihi;", con);
            da.SelectCommand.Parameters.AddWithValue("@Tarih", tarih);
            da.SelectCommand.Parameters.AddWithValue("@ID", Kasa);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable KasaveTumZaman(int Kasa)
        {
            OleDbConnection con = new OleDbConnection(connect.connectroad);
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT Kasa.Kod, Kasa.Tanim,CekIslem.DuzenlemeTarihi, tedarikciler.unvan, CekIslem.Aciklama, CekIslem.CekNo, CekIslem.Banka, CekIslem.Sube, CekIslem.HesapNo, CekIslem.VadeTarihi, CekIslem.Giris, CekIslem.Cikis FROM Kasa INNER JOIN (CekIslem INNER JOIN tedarikciler ON CekIslem.TedarikciID = tedarikciler.TedarikciID) ON Kasa.KasaID = CekIslem.KasaID WHERE (((CekIslem.KasaID)=[@ID])) order by CekIslem.DuzenlemeTarihi;", con);
            da.SelectCommand.Parameters.AddWithValue("@ID", Kasa);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable TumKasaveZaman(string Tarih)
        {
            OleDbConnection con = new OleDbConnection(connect.connectroad);
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT Kasa.Kod, Kasa.Tanim, CekIslem.DuzenlemeTarihi, tedarikciler.unvan, CekIslem.Aciklama, CekIslem.CekNo, CekIslem.Banka, CekIslem.Sube, CekIslem.HesapNo, CekIslem.VadeTarihi, CekIslem.Giris, CekIslem.Cikis FROM Kasa INNER JOIN (CekIslem INNER JOIN tedarikciler ON CekIslem.TedarikciID = tedarikciler.TedarikciID) ON Kasa.KasaID = CekIslem.KasaID WHERE (((CekIslem.VadeTarihi)=@Tarih)) order by CekIslem.DuzenlemeTarihi;", con);
            da.SelectCommand.Parameters.AddWithValue("@Tarih", Tarih);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable TumKasaveTumZaman()
        {
            OleDbConnection con = new OleDbConnection(connect.connectroad);
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT Kasa.Kod, Kasa.Tanim, CekIslem.DuzenlemeTarihi, tedarikciler.unvan, CekIslem.Aciklama, CekIslem.CekNo, CekIslem.Banka, CekIslem.Sube, CekIslem.HesapNo, CekIslem.VadeTarihi, CekIslem.Giris, CekIslem.Cikis FROM (Kasa INNER JOIN CekIslem ON Kasa.KasaID = CekIslem.KasaID) INNER JOIN tedarikciler ON CekIslem.TedarikciID = tedarikciler.TedarikciID order by CekIslem.DuzenlemeTarihi;", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable CekNoGetir(string Ceknumarasi)
        {
            OleDbConnection con = new OleDbConnection(connect.connectroad);
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT Kasa.Kod, Kasa.Tanim, CekIslem.DuzenlemeTarihi, tedarikciler.unvan, CekIslem.Aciklama, CekIslem.CekNo, CekIslem.Banka, CekIslem.Sube, CekIslem.HesapNo, CekIslem.VadeTarihi, CekIslem.Giris, CekIslem.Cikis FROM Kasa INNER JOIN (CekIslem INNER JOIN tedarikciler ON CekIslem.TedarikciID = tedarikciler.TedarikciID) ON Kasa.KasaID = CekIslem.KasaID WHERE (((CekIslem.CekNo)=@Cekno)) order by CekIslem.DuzenlemeTarihi;", con);
            da.SelectCommand.Parameters.AddWithValue("@Cekno", Ceknumarasi);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable Tedarikci(int Tedarikci)
        {
            OleDbConnection con = new OleDbConnection(connect.connectroad);
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT Kasa.Kod, Kasa.Tanim, CekIslem.DuzenlemeTarihi, tedarikciler.unvan, CekIslem.Aciklama, CekIslem.CekNo, CekIslem.Banka, CekIslem.Sube, CekIslem.HesapNo, CekIslem.VadeTarihi, CekIslem.Giris, CekIslem.Cikis FROM Kasa INNER JOIN (CekIslem INNER JOIN tedarikciler ON CekIslem.TedarikciID = tedarikciler.TedarikciID) ON Kasa.KasaID = CekIslem.KasaID WHERE (((CekIslem.TedarikciID)=@TID)) order by CekIslem.DuzenlemeTarihi;", con);
            da.SelectCommand.Parameters.AddWithValue("@TID", Tedarikci);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
