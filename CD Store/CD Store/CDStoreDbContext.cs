﻿
using CDStore;
using System.Data.Entity;


namespace CD_Store
{
    public class CDStoreDbContext : DbContext
    {
        public CDStoreDbContext() : base("myConnectionString")
        {
            Database.SetInitializer(new CustomInitializer());
        }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }
        

    }
}
