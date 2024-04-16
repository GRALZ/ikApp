using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Sirket
    {
        [Key]
        public int Sirketid { get; set; }
        public string SirketAd { get; set; }
        public string SirketAdres { get; set; }
        public string SirketSahibi { get; set; }
        public int SirketsecilNo { get; set; }
        public int SirketVergiNo { get; set; }
        public int isYeriTelefon { get; set; }
        public int İsyeriBelgegecerNo { get; set; }
        public string Mail { get; set; }
        public int İsyeriTehlikesınıfı { get; set; }
        public bool Durum { get; set; }

        public ICollection<Personel> personels { get; set; }
    }
}