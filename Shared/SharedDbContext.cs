using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Shared
{
    public class SharedDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<SocialNetworkProfile> SocialNetworkProfiles { get; set; }

        public SharedDbContext(DbContextOptions options)
          : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .Property(e => e.Categories)
                .HasConversion(
                    v => string.Join(",", v),
                    v => v.Split(','));
        }

        public void Populate()
        {
            if (Authors.Count() > 0 || Posts.Count() > 0 || SocialNetworkProfiles.Count() > 0)
            {
                return;
            }

            string jsonData = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "/initial-data.json");
            var authors = JsonConvert.DeserializeObject<List<Author>>(jsonData);

            Authors.AddRange(authors);

            this.SaveChanges();
        }
    }
}
