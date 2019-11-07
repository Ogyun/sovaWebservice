using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public  class SearchService
    {
        public List<SearchResult> SearchByKeyword(params string[] keywords)
        {
            using var db = new SovaDbContext();
            var s = BuildStringFromParams(keywords);
            var result = db.SearchResults.FromSqlRaw("select * from best_match(" + s + ")");
//            var searchResultList = new List<SearchResult>();
//            SearchResult searchResult;
//            foreach (var item in result)
//            {
//                searchResult = new SearchResult
//                {
//                    PostId = item.PostId,
//                    Type = item.Type,
//                    Rank = item.Rank,
//                    Body = item.Body
//                };
//                searchResultList.Add(searchResult);
//            }
//            return searchResultList;
            return ListResults(result);
        }

        public List<Question> SearchByAcceptedAnswer(Boolean accepted)
        {
            using var db = new  SovaDbContext();
            if(accepted) { return ListQuestions(db.Questions.FromSqlRaw("select * from questions where acceptedanswerid is not null")); }
            return ListQuestions(db.Questions.FromSqlRaw("select * from questions where acceptedanswerid is null")); 
        }

        public List<Question> SearchByTag(params string[] tags)
        {
            using var db = new SovaDbContext();
            var s = BuildStringFromParams(tags);
            var result = db.Questions.FromSqlRaw("select * from search_by_tags(" + s + ")");
            return ListQuestions(result);
        }

        public List<SearchResult> SearchByScore(int fromScore, int toScore)
        {
            using var db = new SovaDbContext();
            var result = db.SearchResults.FromSqlRaw("select * from search_by_score(" + fromScore + ", " + toScore + ")");
            return ListResults(result);
        }

        public List<SearchResult> SearchByUsername(string username)
        {
            using var db = new SovaDbContext();
            var result = db.SearchResults.FromSqlRaw("select * from search_by_username(" + username + ")");
            return ListResults(result);
        }

        private List<SearchResult> ListResults(IQueryable<SearchResult> result)
        {
            var searchResultList = new List<SearchResult>();
            SearchResult searchResult;
            foreach (var item in result)
            {
                searchResult = new SearchResult
                {
                    PostId = item.PostId,
                    Type = item.Type,
                    Rank = item.Rank,
                    Body = item.Body,
                    CreationDate = item.CreationDate,
                    Score = item.Score,
                    UserId = item.UserId,
                    Username = item.Username
                };
                searchResultList.Add(searchResult);
            }
            return searchResultList;
        }


        public bool DeleteSearchHistory(string email)
        {
            bool deleted = false;
            bool match = false;
            using var db = new SovaDbContext();
            var appUserService = new AppUserService();
            var users = appUserService.GetAllUsers();
            foreach (var item in users)
            {
                if (item.Email == email)
                {
                    match = true;
                } 
            }

            if (match)
            {
                var result = db.SearchHistories.FromSqlRaw("select delete_history({0})", email);
                Console.WriteLine(result.ToString());
                return deleted = true;
            }
            else
            {
                return deleted = false;
            }
            

        }

        
        private List<Question> ListQuestions(IQueryable<Question> result)
        {
            var searchResultList = new List<Question>();
            foreach (var item in result)
            {
                var searchResult = new Question
                {
                    Id = item.Id,
                    AcceptedAnswerId = item.AcceptedAnswerId,
                    CreationDate = item.CreationDate,
                    Score = item.Score,
                    Body = item.Body,
                    ClosedDate = item.ClosedDate,
                    Title = item.Title,
                    UserId = item.UserId,
                    Tag = item.Tag
                };
                searchResultList.Add(searchResult);
            }
            return searchResultList;
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
