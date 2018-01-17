using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace TaseronTakip.Class
{
    class Banka
    {
        public int BankaIslemID { get; set; }
        public string Niteligi { get; set; }
        public DateTime Tarih { get; set; }
        public string Aciklama { get; set; }
        public double Gelir { get; set; }
        public double Gider { get; set; }
        public int KasaID { get; set; }
        public string Kod { get; set; }
        public string Tanim { get; set; }

        public static DataTable KasaVeZaman(int ay, int yil, int Kasa)
        {
            OleDbConnection con = new OleDbConnection(connect.connectroad);
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT Kasa.Kod, Kasa.Tanim, BankaIslem.Tarih, BankaIslem.Niteligi, BankaIslem.Aciklama, BankaIslem.Gelir, BankaIslem.Gider, BankaIslem.KasaID FROM Kasa INNER JOIN BankaIslem ON Kasa.KasaID = BankaIslem.KasaID WHERE (((Month([BankaIslem.Tarih]))=[@AyTarih]) AND ((Year([BankaIslem.Tarih]))=[@YilTarih]) AND ((BankaIslem.KasaID)=[@ID])) order by BankaIslem.Tarih;", con);
            da.SelectCommand.Parameters.AddWithValue("@AyTarih", ay);
            da.SelectCommand.Parameters.AddWithValue("@YilTarih", yil);
            da.SelectCommand.Parameters.AddWithValue("@ID", Kasa);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable KasaveTumZaman(int Kasa)
        {
            OleDbConnection con = new OleDbConnection(connect.connectroad);
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT Kasa.Kod, Kasa.Tanim, BankaIslem.Tarih, BankaIslem.Niteligi, BankaIslem.Aciklama, BankaIslem.Gelir, BankaIslem.Gider, BankaIslem.KasaID FROM Kasa INNER JOIN BankaIslem ON Kasa.KasaID = BankaIslem.KasaID WHERE (((BankaIslem.KasaID)=[@ID])) order by BankaIslem.Tarih;", con);
            da.SelectCommand.Parameters.AddWithValue("@ID", Kasa);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable TumKasaveZaman(int ay, int yil)
        {
            OleDbConnection con = new OleDbConnection(connect.connectroad);
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT Kasa.Kod, Kasa.Tanim, BankaIslem.Tarih, BankaIslem.Niteligi, BankaIslem.Aciklama, BankaIslem.Gelir, BankaIslem.Gider FROM Kasa INNER JOIN BankaIslem ON Kasa.KasaID = BankaIslem.KasaID WHERE (((Month([BankaIslem.Tarih]))=[@AyTarih]) AND ((Year([BankaIslem.Tarih]))=[@YilTarih])) order by BankaIslem.Tarih;", con);
            da.SelectCommand.Parameters.AddWithValue("@AyTarih", ay);
            da.SelectCommand.Parameters.AddWithValue("@YilTarih", yil);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable TumKasaveTumZaman()
        {
            OleDbConnection con = new OleDbConnection(connect.connectroad);
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT Kasa.Kod, Kasa.Tanim, BankaIslem.Tarih, BankaIslem.Niteligi, BankaIslem.Aciklama, BankaIslem.Gelir, BankaIslem.Gider FROM Kasa INNER JOIN BankaIslem ON Kasa.KasaID = BankaIslem.KasaID order by BankaIslem.Tarih;", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
