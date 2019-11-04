using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class SovaDbContext:DbContext
    {
        public DbQuery<SearchResult> SearchResults { get; set; }

        public static readonly ILoggerFactory MyLoggerFactory
           = LoggerFactory.Create(builder => { builder.AddConsole(); });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(MyLoggerFactory)
                .UseNpgsql("host=rawdata.ruc.dk;db=raw8;uid=raw8;pwd=IXi8ezoQ");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Query<SearchResult>().Property(x => x.PostId).HasColumnName("postid");
            modelBuilder.Query<SearchResult>().Property(x => x.Rank).HasColumnName("rank");
            modelBuilder.Query<SearchResult>().Property(x => x.Type).HasColumnName("type");
            modelBuilder.Query<SearchResult>().Property(x => x.Body).HasColumnName("body");
        }

    }
}
