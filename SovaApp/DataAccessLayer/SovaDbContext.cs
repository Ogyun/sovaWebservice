
using DataAccessLayer.Models;
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
        //public DbQuery<SearchByKeywordResult> SearchByKeywordResult { get; set; }
        //public DbQuery<SearchByScoreResult> SearchByScoreResult { get; set; }
        //public DbQuery<SearchByTagResult> SearchByTagResult { get; set; }
        //public DbQuery<SearchByUserNameResult> SearchByUserNameResult { get; set; }
        //public DbQuery<SearchByAcceptedAnswerResult> SearchByAcceptedAnswerResult { get; set; }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<SearchHistory> SearchHistories { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Marking> Markings { get; set; }
        public DbSet<Tag> Tags { get; set; }

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

            modelBuilder.Query<SearchResult>().Property(x => x.QuestionId).HasColumnName("questionid");
            modelBuilder.Query<SearchResult>().Property(x => x.AnswerId).HasColumnName("answerid");
            modelBuilder.Query<SearchResult>().Property(x => x.Type).HasColumnName("type");
            modelBuilder.Query<SearchResult>().Property(x => x.Body).HasColumnName("body");
            modelBuilder.Query<SearchResult>().Property(x => x.Title).HasColumnName("title");
            modelBuilder.Query<SearchResult>().Property(x => x.CreationDate).HasColumnName("creationdate");
            modelBuilder.Query<SearchResult>().Property(x => x.Score).HasColumnName("score");
            modelBuilder.Query<SearchResult>().Property(x => x.UserId).HasColumnName("userid");
            modelBuilder.Query<SearchResult>().Property(x => x.Username).HasColumnName("username");
            modelBuilder.Query<SearchResult>().Property(x => x.Tags).HasColumnName("tags");

            modelBuilder.Entity<Question>().ToTable("questions");
            modelBuilder.Entity<Question>().HasKey(m => m.Id);
            //modelBuilder.Entity<Question>().HasOne(q => q.User).WithMany(u => u.Questions);
            modelBuilder.Entity<Question>().Property(m => m.Id).HasColumnName("id");
            modelBuilder.Entity<Question>().Property(m => m.AcceptedAnswerId).HasColumnName("acceptedanswerid");
            modelBuilder.Entity<Question>().Property(m => m.CreationDate).HasColumnName("creationdate");
            modelBuilder.Entity<Question>().Property(m => m.Score).HasColumnName("score");
            modelBuilder.Entity<Question>().Property(m => m.Body).HasColumnName("body");
            modelBuilder.Entity<Question>().Property(m => m.ClosedDate).HasColumnName("closeddate");
            modelBuilder.Entity<Question>().Property(m => m.Title).HasColumnName("title");
          //  modelBuilder.Entity<Question>().Property(m => m.UserId).HasColumnName("userid");

            modelBuilder.Entity<Answer>().ToTable("answers");
            modelBuilder.Entity<Answer>().HasKey(m => m.Id);
            //modelBuilder.Entity<Answer>().HasOne(a => a.User).WithMany(u => u.Answers);
            //modelBuilder.Entity<Answer>().HasOne(a => a.Question).WithMany(q => q.Answers);
            modelBuilder.Entity<Answer>().Property(m => m.Id).HasColumnName("id");
            modelBuilder.Entity<Answer>().Property(m => m.QuestionId).HasColumnName("questionid");
            modelBuilder.Entity<Answer>().Property(m => m.CreationDate).HasColumnName("creationdate");
            modelBuilder.Entity<Answer>().Property(m => m.Score).HasColumnName("score");
            modelBuilder.Entity<Answer>().Property(m => m.Body).HasColumnName("body");
           // modelBuilder.Entity<Answer>().Property(m => m.UserId).HasColumnName("userid");

            modelBuilder.Entity<AppUser>().ToTable("app_users");
            modelBuilder.Entity<AppUser>().HasKey(m => m.Email);
            modelBuilder.Entity<AppUser>().Property(m => m.Email).HasColumnName("email");
            modelBuilder.Entity<AppUser>().Property(m => m.Password).HasColumnName("password");
            modelBuilder.Entity<AppUser>().Property(m => m.Name).HasColumnName("name");
            modelBuilder.Entity<AppUser>().Property(m => m.DateOfBirth).HasColumnName("dateofbirth");
            modelBuilder.Entity<AppUser>().Property(m => m.CreationDate).HasColumnName("creationdate");
            modelBuilder.Entity<AppUser>().Property(m => m.Location).HasColumnName("location");

            modelBuilder.Entity<SearchHistory>().ToTable("search_history");
            modelBuilder.Entity<SearchHistory>().HasKey(m => m.Id);
           // modelBuilder.Entity<SearchHistory>().HasOne(m => m.AppUser).WithMany(u => u.SearchHistories);
            modelBuilder.Entity<SearchHistory>().Property(m => m.Id).HasColumnName("searchid");
            modelBuilder.Entity<SearchHistory>().Property(m => m.Email).HasColumnName("useremail");
            modelBuilder.Entity<SearchHistory>().Property(m => m.SearchDate).HasColumnName("searchdate");
            modelBuilder.Entity<SearchHistory>().Property(m => m.SearchText).HasColumnName("searchtext");

            modelBuilder.Entity<Note>().ToTable("notes");
            modelBuilder.Entity<Note>().HasKey(m => m.Id);
            //modelBuilder.Entity<Note>().HasOne(n => n.AppUser).WithMany(u => u.Notes);
            //modelBuilder.Entity<Note>().HasOne(n => n.Question).WithMany(q => q.Notes);
            modelBuilder.Entity<Note>().Property(m => m.UserEmail).HasColumnName("useremail");
            modelBuilder.Entity<Note>().Property(m => m.Notetext).HasColumnName("notetext");
            modelBuilder.Entity<Note>().Property(m => m.QuestionId).HasColumnName("questionid");
            modelBuilder.Entity<Note>().Property(m => m.Id).HasColumnName("id");


            modelBuilder.Entity<Marking>().ToTable("markings");
            modelBuilder.Entity<Marking>().HasKey(m => new { m.UserEmail, m.QuestionId });
           // modelBuilder.Entity<Marking>().HasOne(m => m.AppUser).WithMany(u => u.Markings);
           // modelBuilder.Entity<Marking>().HasOne(m => m.Question).WithMany(q => q.Markings);
            modelBuilder.Entity<Marking>().Property(m => m.UserEmail).HasColumnName("useremail");
            modelBuilder.Entity<Marking>().Property(m => m.QuestionId).HasColumnName("qid");

            modelBuilder.Entity<Tag>().ToTable("tags");
            modelBuilder.Entity<Tag>().HasKey(m=>new {m.QuestionId,m.TagBody});
            modelBuilder.Entity<Tag>().Property(m => m.QuestionId).HasColumnName("questionid");
            modelBuilder.Entity<Tag>().Property(m => m.TagBody).HasColumnName("tag");

            modelBuilder.Entity<QuestionTag>().HasKey(t => new { t.QuestionId,t.TagBody });
           // modelBuilder.Entity<QuestionTag>().HasOne(qt => qt.Question).WithMany(q => q.QuestionTags);
            //modelBuilder.Entity<QuestionTag>().HasOne(qt => qt.Tag).WithMany(t => t.QuestionTags);
        }

    }
}
