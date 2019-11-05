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

        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<SearchHistory> SearchHistories { get; set; }
        public DbSet<Note> Notes { get; set; }

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

            modelBuilder.Entity<Question>().ToTable("questions");
            modelBuilder.Entity<Question>().Property(m => m.Id).HasColumnName("id");
            modelBuilder.Entity<Question>().Property(m => m.AcceptedAnswerId).HasColumnName("acceptedanswerid");
            modelBuilder.Entity<Question>().Property(m => m.CreationDate).HasColumnName("creationdate");
            modelBuilder.Entity<Question>().Property(m => m.Score).HasColumnName("score");
            modelBuilder.Entity<Question>().Property(m => m.Body).HasColumnName("body");
            modelBuilder.Entity<Question>().Property(m => m.ClosedDate).HasColumnName("closeddate");
            modelBuilder.Entity<Question>().Property(m => m.Title).HasColumnName("title");
            modelBuilder.Entity<Question>().Property(m => m.UserId).HasColumnName("userid");

            modelBuilder.Entity<Answer>().ToTable("answers");
            modelBuilder.Entity<Answer>().Property(m => m.Id).HasColumnName("id");
            modelBuilder.Entity<Answer>().Property(m => m.QuestionId).HasColumnName("questionid");
            modelBuilder.Entity<Answer>().Property(m => m.CreationDate).HasColumnName("creationdate");
            modelBuilder.Entity<Answer>().Property(m => m.Score).HasColumnName("score");
            modelBuilder.Entity<Answer>().Property(m => m.Body).HasColumnName("body");
            modelBuilder.Entity<Answer>().Property(m => m.UserId).HasColumnName("userid");

            modelBuilder.Entity<AppUser>().ToTable("app_users");
            modelBuilder.Entity<AppUser>().HasKey(m => m.Email);
            modelBuilder.Entity<AppUser>().Property(m => m.Email).HasColumnName("email");
            modelBuilder.Entity<AppUser>().Property(m => m.Password).HasColumnName("password");
            modelBuilder.Entity<AppUser>().Property(m => m.Name).HasColumnName("name");
            modelBuilder.Entity<AppUser>().Property(m => m.DateOfBirth).HasColumnName("dateofbirth");
            modelBuilder.Entity<AppUser>().Property(m => m.CreationDate).HasColumnName("creationdate");
            modelBuilder.Entity<AppUser>().Property(m => m.Email).HasColumnName("location");

            modelBuilder.Entity<SearchHistory>().ToTable("search_history");
            modelBuilder.Entity<SearchHistory>().Property(m => m.Id).HasColumnName("searchid");
            modelBuilder.Entity<SearchHistory>().Property(m => m.Email).HasColumnName("useremail");
            modelBuilder.Entity<SearchHistory>().Property(m => m.SearchDate).HasColumnName("searchdate");
            modelBuilder.Entity<SearchHistory>().Property(m => m.SearchText).HasColumnName("searchtext");



            modelBuilder.Entity<Note>().ToTable("notes");
            modelBuilder.Entity<Note>().HasKey(m => new { m.UserEmail, m.QuestionId});
            modelBuilder.Entity<Note>().Property(m => m.UserEmail).HasColumnName("useremail");
            modelBuilder.Entity<Note>().Property(m => m.Notetext).HasColumnName("notetext");
            modelBuilder.Entity<Note>().Property(m => m.QuestionId).HasColumnName("questionid");
        }

    }
}
