using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Timers;
using System.Web;

namespace WebApplication1.Models
{
    public class Context : DbContext
    {
        public DbSet<Departmen> Departmens { get; set; }
        public DbSet<Personel> Personels { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Sirket> Sirkets { get; set; }
        public DbSet<toplamsayis> toplamsayis { get; set; }



        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Departmen>()
        //        .HasMany(d => d.Personels)
        //        .WithRequired(p => p.Departman)
        //        .HasForeignKey(p => p.Departman_Departmanid);

        //    modelBuilder.Entity<toplamsayis>()
        //        .HasKey(t => t.id);
        //}

        //public void UpdateToplamSayis()
        //{
        //    var toplamSayisList = Departmens.Select(d => new toplamsayis
        //    {
        //        DepartmanAd = d.DepartmanAd,
        //        PersonelSayisi = d.Personels.Count(p => p.Durum == true) +1
        //    }).ToList();

        //    Database.ExecuteSqlCommand("TRUNCATE TABLE [toplamsayis]");
        //    toplamsayis.AddRange(toplamSayisList);

        //    SaveChanges();
        //}

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Departmen>()
        //        .HasMany(d => d.Personels)
        //        .WithRequired(p => p.Departman)
        //        .HasForeignKey(p => p.Departman_Departmanid);

        //    modelBuilder.Entity<toplamsayis>()
        //        .HasKey(t => t.id);
        //}

        //public void UpdateToplamSayis()
        //{
        //    var toplamSayisList = Departmens.Select(d => new toplamsayis
        //    {
        //        DepartmanAd = d.DepartmanAd,
        //        PersonelSayisi = d.Personels.Count(p => p.Durum == true) + 1
        //    }).ToList();

        //    var existingData = toplamsayis.ToList();
        //    var newData = toplamSayisList.Except(existingData).ToList();

        //    foreach (var data in newData)
        //    {
        //        toplamsayis.Add(data);
        //    }

        //    SaveChanges();
        //}
        //public void UpdateToplamSayis()
        //{
        //    var toplamSayisList = from d in Departmens
        //                          select new toplamsayis
        //                          {
        //                              DepartmanAd = d.DepartmanAd,
        //                              PersonelSayisi = d.Personels.Count(p => p.Durum == true) + 1
        //                          };

        //    var existingData = toplamsayis.ToList();
        //    var newData = toplamSayisList.Except(existingData).ToList();

        //    foreach (var data in newData)
        //    {
        //        toplamsayis.Add(new toplamsayis
        //        {
        //            DepartmanAd = data.DepartmanAd,
        //            PersonelSayisi = data.PersonelSayisi
        //        });
        //    }

        //    SaveChanges();
        //}

        //public override int SaveChanges()
        //{
        //    var result = base.SaveChanges();

        //    if (result > 0)
        //    {
        //        UpdateToplamSayis();
        //    }

        //    return result;
        //}
    }

}

