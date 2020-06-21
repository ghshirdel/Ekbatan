using Ekbatan.DomainClasses;
using Ekbatan.DomainClasses.Customer;
using Ekbatan.DomainClasses.FrontAge;
using Ekbatan.DomainClasses.Images;
using Ekbatan.DomainClasses.Karbari;
using Ekbatan.DomainClasses.MContract;
using Ekbatan.DomainClasses.MelkPosition;
using Ekbatan.DomainClasses.MelkType;
using Ekbatan.DomainClasses.Project;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Ekbatan.DataLayer
{
   public  class EkbatanDbContext : DbContext
    {
        public EkbatanDbContext(DbContextOptions<EkbatanDbContext> options) : base(options)
        {

        }
        public DbSet<Project> Projects { get; set; } //1
        public DbSet<Melk> Melks { get; set; }       //2
        public DbSet<Karbari> Karbaris { get; set; } //3
        public DbSet<MelkType> MelkTypes { get; set; } //4
        public DbSet<MelkPosition> MelkPositions { get; set; } //5
        public DbSet<FrontAge> FrontAges { get; set; } //6

        public DbSet<Customer> Customers { get; set; } //7
        public DbSet<MContract> MContracts { get; set; } //8

        public DbSet<SubContract> SubContracts { get; set; } //9
        public DbSet<Images> Images { get; set; } //10
        public DbSet<ImageType> ImageTypes { get; set; } //11


    }
}
