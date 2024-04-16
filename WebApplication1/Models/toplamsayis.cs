using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class toplamsayis
    {
        [Key]
        public int id { get; set; }
        public string DepartmanAd { get; set; }
        public int PersonelSayisi { get;  set; }
    }

}