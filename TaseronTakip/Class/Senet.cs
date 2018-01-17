using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace TaseronTakip.Class
{
    class Senet
    {
        public int SenetID { get; set; }
        public string KayitTarihi { get; set; }
        public DateTime DuzenlemeTarihi { get; set; }
        public string Aciklama { get; set; }
        public string SenetNo { get; set; }
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
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT Kasa.Kod, Kasa.Tanim, SenetIslem.DuzenlemeTarihi, tedarikciler.unvan, SenetIslem.Aciklama, SenetIslem.SenetNo, SenetIslem.VadeTarihi, SenetIslem.Giris, SenetIslem.Cikis FROM Kasa INNER JOIN (SenetIslem INNER JOIN tedarikciler ON SenetIslem.TedarikciID = tedarikciler.TedarikciID) ON Kasa.KasaID = SenetIslem.KasaID WHERE (((SenetIslem.VadeTarihi)=[@Tarih]) AND ((SenetIslem.KasaID)=[@ID])) order by SenetIslem.DuzenlemeTarihi;", con);
            da.SelectCommand.Parameters.AddWithValue("@Tarih", tarih);
            da.SelectCommand.Parameters.AddWithValue("@ID", Kasa);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable KasaveTumZaman(int Kasa)
        {
            OleDbConnection con = new OleDbConnection(connect.connectroad);
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT Kasa.Kod, Kasa.Tanim,SenetIslem.DuzenlemeTarihi, tedarikciler.unvan, SenetIslem.Aciklama, SenetIslem.SenetNo, SenetIslem.VadeTarihi, SenetIslem.Giris, SenetIslem.Cikis FROM Kasa INNER JOIN (SenetIslem INNER JOIN tedarikciler ON SenetIslem.TedarikciID = tedarikciler.TedarikciID) ON Kasa.KasaID = SenetIslem.KasaID WHERE (((SenetIslem.KasaID)=[@ID])) order by SenetIslem.DuzenlemeTarihi;", con);
            da.SelectCommand.Parameters.AddWithValue("@ID", Kasa);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable TumKasaveZaman(string Tarih)
        {
            OleDbConnection con = new OleDbConnection(connect.connectroad);
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT Kasa.Kod, Kasa.Tanim, SenetIslem.DuzenlemeTarihi, tedarikciler.unvan, SenetIslem.Aciklama, SenetIslem.SenetNo, SenetIslem.VadeTarihi, SenetIslem.Giris, SenetIslem.Cikis FROM Kasa INNER JOIN (SenetIslem INNER JOIN tedarikciler ON SenetIslem.TedarikciID = tedarikciler.TedarikciID) ON Kasa.KasaID = SenetIslem.KasaID WHERE (((SenetIslem.VadeTarihi)=@Tarih)) order by SenetIslem.DuzenlemeTarihi;", con);
            da.SelectCommand.Parameters.AddWithValue("@Tarih", Tarih);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable TumKasaveTumZaman()
        {
            OleDbConnection con = new OleDbConnection(connect.connectroad);
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT Kasa.Kod, Kasa.Tanim,SenetIslem.DuzenlemeTarihi, tedarikciler.unvan, SenetIslem.Aciklama, SenetIslem.SenetNo, SenetIslem.VadeTarihi, SenetIslem.Giris, SenetIslem.Cikis FROM Kasa INNER JOIN (SenetIslem INNER JOIN tedarikciler ON SenetIslem.TedarikciID = tedarikciler.TedarikciID) ON Kasa.KasaID = SenetIslem.KasaID order by SenetIslem.DuzenlemeTarihi;", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable SenetNoGetir(string Senetnumarasi)
        {
            OleDbConnection con = new OleDbConnection(connect.connectroad);
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT Kasa.Kod, Kasa.Tanim, SenetIslem.DuzenlemeTarihi, tedarikciler.unvan, SenetIslem.Aciklama, SenetIslem.SenetNo, SenetIslem.VadeTarihi, SenetIslem.Giris, SenetIslem.Cikis FROM Kasa INNER JOIN (SenetIslem INNER JOIN tedarikciler ON SenetIslem.TedarikciID = tedarikciler.TedarikciID) ON Kasa.KasaID = SenetIslem.KasaID WHERE (((SenetIslem.SenetNo)=@Senetno)) order by SenetIslem.DuzenlemeTarihi;", con);
            da.SelectCommand.Parameters.AddWithValue("@Senetno", Senetnumarasi);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable Tedarikci(int Tedarikci)
        {
            OleDbConnection con = new OleDbConnection(connect.connectroad);
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT Kasa.Kod, Kasa.Tanim,SenetIslem.DuzenlemeTarihi, tedarikciler.unvan, SenetIslem.Aciklama, SenetIslem.SenetNo, SenetIslem.VadeTarihi, SenetIslem.Giris, SenetIslem.Cikis FROM Kasa INNER JOIN (SenetIslem INNER JOIN tedarikciler ON SenetIslem.TedarikciID = tedarikciler.TedarikciID) ON Kasa.KasaID = SenetIslem.KasaID WHERE (((SenetIslem.TedarikciID)=@TID)) order by SenetIslem.DuzenlemeTarihi;", con);
            da.SelectCommand.Parameters.AddWithValue("@TID", Tedarikci);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
