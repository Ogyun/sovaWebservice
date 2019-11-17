using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class SearchService : ISearchService
    {
        public List<SearchResult> SearchByKeyword(params string[] keywords)
        {
            using var db = new SovaDbContext();
            var s = BuildStringFromParams(keywords);
            return db.SearchResults.FromSqlRaw("select * from new_best_match(" + s + ")").Select(x => new SearchResult
            {
                QuestionId = x.QuestionId,
                AnswerId = x.AnswerId,
                Type = x.Type,
                Body = x.Body,
                Title = x.Title,
                Score = x.Score,
                Tags = x.Tags,
                CreationDate = x.CreationDate
            }).ToList();
          
        }

        public SearchHistory CreateSearchHistory(SearchHistory history)
        {
            using var db = new SovaDbContext();
            db.SearchHistories.Add(history);
            int changes = db.SaveChanges();
            if (changes > 0)
            {
                return history;
            }
            else
            {
                return null;
            }
        }

        public List<SearchHistory>GetSearchHistoryByUserEmail(string userEmail)
        {
            using var db = new SovaDbContext();
            return db.SearchHistories.Where(n => n.Email == userEmail).ToList();
        }

       
        public bool DeleteSearchHistoryByUserEmail(string userEmail)
        {
            using var db = new SovaDbContext();
            var history = db.SearchHistories.Where(u => u.Email == userEmail);
            if (history == null) return false;
            foreach (var item in history)
            {
                db.SearchHistories.Remove(item);
            }            
            return db.SaveChanges() > 0;
        }

        public bool DeleteSearchHistoryById(int historyId)
        {
            using var db = new SovaDbContext();
            var history = db.SearchHistories.Find(historyId);
            if (history == null) return false;
            db.SearchHistories.Remove(history);
            return db.SaveChanges() > 0;

        }

        public List<SearchResult> SearchByAcceptedAnswer(Boolean accepted)
        {
            using var db = new  SovaDbContext();
            if(accepted) { return db.SearchResults.FromSqlRaw("select * from questions where acceptedanswerid is not null order by score").Select(x => new SearchResult
            {
                QuestionId = x.QuestionId,
                AnswerId = x.AnswerId,
                Type = "question",
                Body = x.Body,
                Title = x.Title,
                Score = x.Score,
                Tags = x.Tags,
                CreationDate = x.CreationDate
            }).ToList(); }
            return db.SearchResults.FromSqlRaw("select * from questions where acceptedanswerid is null order by score").Select(x => new SearchResult
            {
                QuestionId = x.QuestionId,
                AnswerId = x.AnswerId,
                Type = "question",
                Body = x.Body,
                Title = x.Title,
                Score = x.Score,
                Tags = x.Tags,
                CreationDate = x.CreationDate
            }).ToList(); 
        }

        public List<SearchResult> SearchByTag(params string[] tags)
        {
            using var db = new SovaDbContext();
            var s = BuildStringFromParams(tags); 
            return db.SearchResults.FromSqlRaw("select * from search_by_tags(" + s + ")").Select(x => new SearchResult
            {
                QuestionId = x.QuestionId,
                AnswerId = x.AnswerId,
                Type = x.Type,
                Body = x.Body,
                Title = x.Title,
                Score = x.Score,
                Tags = x.Tags,
                CreationDate = x.CreationDate
            }).ToList();
        }
     
        public List<SearchResult> SearchByScore(string fromScore, string toScore)
        {
            using var db = new SovaDbContext();
            return db.SearchResults.FromSqlRaw("select * from search_by_score(" + fromScore + "," + toScore  + ")").Select(x => new SearchResult
            {
                QuestionId = x.QuestionId,
                AnswerId = x.AnswerId,
                Type = x.Type,
                Body = x.Body,
                Title = x.Title,
                Score = x.Score,
                Tags = x.Tags,
                CreationDate = x.CreationDate
            }).ToList();
        }
       
        private String BuildStringFromParams(string[] words)
        {
            var s = "";
            foreach (var elem in words)
            {
                s += "'" + elem + "',";
            }
            s = s.Remove(s.Length - 1);
            return s;
        }
    }
}
