using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace TaseronTakip.Class
{
    class Nakit
    {
        public int NakitIslemID { get; set; }
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
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT Kasa.Kod, Kasa.Tanim, NakitIslem.Tarih, NakitIslem.Niteligi, NakitIslem.Aciklama, NakitIslem.Gelir, NakitIslem.Gider, NakitIslem.KasaID FROM Kasa INNER JOIN NakitIslem ON Kasa.KasaID = NakitIslem.KasaID WHERE (((Month([NakitIslem.Tarih]))=[@AyTarih]) AND ((Year([NakitIslem.Tarih]))=[@YilTarih]) AND ((NakitIslem.KasaID)=[@ID])) order by NakitIslem.Tarih;", con);
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
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT Kasa.Kod, Kasa.Tanim, NakitIslem.Tarih, NakitIslem.Niteligi, NakitIslem.Aciklama, NakitIslem.Gelir, NakitIslem.Gider, NakitIslem.KasaID FROM Kasa INNER JOIN NakitIslem ON Kasa.KasaID = NakitIslem.KasaID WHERE (((NakitIslem.KasaID)=[@ID])) order by NakitIslem.Tarih;", con);
            da.SelectCommand.Parameters.AddWithValue("@ID", Kasa);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable TumKasaveZaman(int ay, int yil)
        {
            OleDbConnection con = new OleDbConnection(connect.connectroad);
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT Kasa.Kod, Kasa.Tanim, NakitIslem.Tarih, NakitIslem.Niteligi, NakitIslem.Aciklama, NakitIslem.Gelir, NakitIslem.Gider FROM Kasa INNER JOIN NakitIslem ON Kasa.KasaID = NakitIslem.KasaID WHERE (((Month([NakitIslem.Tarih]))=[@AyTarih]) AND ((Year([NakitIslem.Tarih]))=[@YilTarih])) order by NakitIslem.Tarih;", con);
            da.SelectCommand.Parameters.AddWithValue("@AyTarih", ay);
            da.SelectCommand.Parameters.AddWithValue("@YilTarih", yil);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable TumKasaveTumZaman()
        {
            OleDbConnection con = new OleDbConnection(connect.connectroad);
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT Kasa.Kod, Kasa.Tanim, NakitIslem.Tarih, NakitIslem.Niteligi, NakitIslem.Aciklama, NakitIslem.Gelir, NakitIslem.Gider FROM Kasa INNER JOIN NakitIslem ON Kasa.KasaID = NakitIslem.KasaID order by NakitIslem.Tarih;", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
