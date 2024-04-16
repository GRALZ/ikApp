using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Personel
    {
        [Key]
        public int Personelid { get; set; }
        public string PersonelAd { get; set; }
        public string PersonelSoyad { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime personelDogumT { get; set; }
        public int Maas { get; set; }
        public string Adres { get; set; }
        public string PersonelGorsel { get; set; }
        public string TCKimlik { get; set; }
        public Cinsiyet Cinsiyet { get; set; }
        public int SosyalGuvenlikNo { get; set; }
        public string Gorevi { get; set; }
        public string Takımlideri { get; set; }
        public string AtamalıMeslegi { get; set; }
        public int MeslekKodu { get; set; }
        public string GorevYaptıgıYer { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime GoreveBaslamaT { get; set; }
        public string MezunOlduguOkul { get; set; }
        public string YabanciDil { get; set; }
        public string OncekiIsYeri_Gorevi { get; set; }
        public string DeneyimSuresi { get; set; }
        public string OncekiISYeri_gorev2 { get; set; }
        public string DeneyimSuresi2 { get; set; }
        public string OncekiIsYeri_gorev3 { get; set; }
        public string DeneyimSuresi3 { get; set; }
        public string KanGrubu { get; set; }
        public int CepTel { get; set; }
        public string Mail { get; set; }
        public string Ililce { get; set; }
        public string BirlestirmisAdres { get; set; }
        public string Medeni { get; set; }
        public string EsAdıSoyadı { get; set; }
        public string EsTcKimlik { get; set; }
        [Column(TypeName = "datetime2")]

        public DateTime EsDogumT { get; set; }
        public string EsTahsil { get; set; }
        public string EsMeslek { get; set; }
        public string Escalısıyormu { get; set; }
        public string kamuOzel { get; set; }
        [Column(TypeName = "datetime2")]

        public DateTime EvlilikT { get; set; }
        public int Estel { get; set; }
        public string CocukAdı1 { get; set; }
        public Cinsiyet Cinsiyetcocuk1 { get; set; }
        public string Cocuk1TCKimlik { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime cocuk1DogumT { get; set; }
        public string Cocuk1OkduguOkul { get; set; }
        public string cocuk1hastalık { get; set; }
        public string CocukAdı2 { get; set; }
        public Cinsiyet Cinsiyetcocuk2 { get; set; }
        public string Cocuk2TCKimlik { get; set; }
        [Column(TypeName = "datetime2")]

        public DateTime cocuk2DogumT { get; set; }
        public string Cocuk2OkduguOkul { get; set; }
        public string cocuk2hastalık { get; set; }
        public string CocukAdı3 { get; set; }

        public Cinsiyet Cinsiyetcocuk3 { get; set; }
        public string Cocuk3TCKimlik { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime cocuk3DogumT { get; set; }
        public string Cocuk3OkduguOkul { get; set; }
        public string cocuk3hastalık { get; set; }
        public string erkekCalısanlarınaskerlik { get; set; }
        public string EngelliRapor { get; set; }
        public string babaSagVefat { get; set; }
        public string BabaAdıSoyadı { get; set; }
        public int BabaTel { get; set; }
        public string AnneSagVefat { get; set; }
        public string AnneAdıSoyadı { get; set; }
        public int AnneTel { get; set; }
        public string İleveBilgi { get; set; }
        public bool Durum { get; set; }
        public virtual Sirket Sirket { get; set; }
        public int Departman_Departmanid { get; set; }
        public virtual Departmen Departman { get; set; }
        public DateTime DateTime { get; internal set; }
    }
    public enum Cinsiyet
    {
        Seçiniz,
        Boş,
        Erkek,
        Kadın
    }
}