using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace TaseronTakip.Class
{
    class Personel
    {
        public int TahakkukID { get; set; }
        public string Tarih { get; set; }
        public double Ucret { get; set; }
        public string OdemeSekli { get; set; }
        public string adsoyad { get; set; }
        public double maas { get; set; }
        public string Tutar { get; set; }
        public string Tanim { get; set; }
        public static DataTable PersonelveZaman(int ay, int yil, int personel)
        {
            OleDbConnection con = new OleDbConnection(connect.connectroad);
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT personeller.adsoyad, Tahakkuk.Tarih, personeller.maas, Avanslar.Tutar, Tahakkuk.Ucret, Tahakkuk.OdemeSekli, Kasa.Tanim FROM ((Tahakkuk INNER JOIN personeller ON Tahakkuk.personelID = personeller.personelID) INNER JOIN Kasa ON Tahakkuk.KasaID = Kasa.KasaID) INNER JOIN Avanslar ON personeller.personelID = Avanslar.personelID WHERE (((Month([Tahakkuk.Tarih]))=@AyTarih) AND ((Year([Tahakkuk.Tarih]))=@YilTarih) AND ((Tahakkuk.personelID)=@ID));", con);
            da.SelectCommand.Parameters.AddWithValue("@AyTarih", ay);
            da.SelectCommand.Parameters.AddWithValue("@YilTarih", yil);
            da.SelectCommand.Parameters.AddWithValue("@ID", personel);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable PersonelveTumZaman(int personel)
        {
            OleDbConnection con = new OleDbConnection(connect.connectroad);
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT personeller.adsoyad, Tahakkuk.Tarih, personeller.maas, Avanslar.Tutar, Tahakkuk.Ucret, Tahakkuk.OdemeSekli, Kasa.Tanim FROM ((Tahakkuk INNER JOIN personeller ON Tahakkuk.personelID = personeller.personelID) INNER JOIN Kasa ON Tahakkuk.KasaID = Kasa.KasaID) INNER JOIN Avanslar ON personeller.personelID = Avanslar.personelID WHERE (((Tahakkuk.personelID)=@ID));", con);
            da.SelectCommand.Parameters.AddWithValue("@ID", personel);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable TumPersonelveZaman(int ay, int yil)
        {
            OleDbConnection con = new OleDbConnection(connect.connectroad);
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT personeller.adsoyad, Tahakkuk.Tarih, personeller.maas, Avanslar.Tutar, Tahakkuk.Ucret, Tahakkuk.OdemeSekli, Kasa.Tanim FROM ((Tahakkuk INNER JOIN personeller ON Tahakkuk.personelID = personeller.personelID) INNER JOIN Kasa ON Tahakkuk.KasaID = Kasa.KasaID) INNER JOIN Avanslar ON personeller.personelID = Avanslar.personelID WHERE (((Month([Tahakkuk.Tarih]))=@AyTarih) AND ((Year([Tahakkuk.Tarih]))=@YilTarih));", con);
            da.SelectCommand.Parameters.AddWithValue("@AyTarih", ay);
            da.SelectCommand.Parameters.AddWithValue("@YilTarih", yil);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable TumPersonelveTumZaman()
        {
            OleDbConnection con = new OleDbConnection(connect.connectroad);
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT personeller.adsoyad, Tahakkuk.Tarih, personeller.maas, Avanslar.Tutar, Tahakkuk.Ucret, Tahakkuk.OdemeSekli, Kasa.Tanim FROM ((Tahakkuk INNER JOIN personeller ON Tahakkuk.personelID = personeller.personelID) INNER JOIN Kasa ON Tahakkuk.KasaID = Kasa.KasaID) INNER JOIN Avanslar ON personeller.personelID = Avanslar.personelID;", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
