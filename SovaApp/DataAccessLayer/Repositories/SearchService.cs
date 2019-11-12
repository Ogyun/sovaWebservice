using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public  class SearchService:ISearchService
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
                CreationDate = x.CreationDate,
                Tags = x.Tags

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

        //public List<Question> SearchByAcceptedAnswer(Boolean accepted)
        //{
        //    using var db = new  SovaDbContext();
        //    if(accepted) { return ListQuestions(db.Questions.FromSqlRaw("select * from questions where acceptedanswerid is not null")); }
        //    return ListQuestions(db.Questions.FromSqlRaw("select * from questions where acceptedanswerid is null")); 
        //}

        //public List<SearchByAcceptedAnswerResult> SearchByAcceptedAnswer(Boolean accepted)
        //{
        //    using var db = new SovaDbContext();
        //    var searchResultList = new List<SearchByAcceptedAnswerResult>();
        //    SearchByAcceptedAnswerResult searchResult;
            
        //    if (accepted)
        //    {
        //        return ListResults(db.SearchByAcceptedAnswerResult.FromSqlRaw("select * from questions where acceptedanswerid is not null"));

        //    }
        //       return ListResults(db.SearchByAcceptedAnswerResult.FromSqlRaw("select * from questions where acceptedanswerid is null"));
        //}

        //public List<Question> SearchByTag(params string[] tags)
        //{
        //    using var db = new SovaDbContext();
        //    var s = BuildStringFromParams(tags);
        //    var result = db.Questions.FromSqlRaw("select * from search_by_tags(" + s + ")");
        //    return ListQuestions(result);
        //}
        //public List<SearchByTagResult> SearchByTag(params string[] tags)
        //{
        //    using var db = new SovaDbContext();
        //    var s = BuildStringFromParams(tags);
        //    var result = db.SearchByTagResult.FromSqlRaw("select * from search_by_tags(" + s + ")");
        //    var searchResultList = new List<SearchByTagResult>();
        //    SearchByTagResult searchResult;
        //    foreach (var item in result)
        //    {
        //        searchResult = new SearchByTagResult
        //        {
        //            Id = item.Id,
        //            Body = item.Body,
        //            Score=item.Score,
        //            AcceptedAnswerId = item.AcceptedAnswerId,
        //            ClosedDate = item.ClosedDate,
        //            CreationDate = item.CreationDate,
        //            Tag = item.Tag,
        //            Title = item.Title,
        //            UserId = item.UserId
        //        };
        //        searchResultList.Add(searchResult);
        //    }
        //    return searchResultList;
        //}
        //public List<SearchResult> SearchByScore(int fromScore, int toScore)
        //{
        //    using var db = new SovaDbContext();
        //    var result = db.SearchResults.FromSqlRaw("select * from search_by_score(" + fromScore + ", " + toScore + ")");
        //    return ListResults(result);
        //}
        //public List<SearchByScoreResult> SearchByScore(int fromScore, int toScore)
        //{
        //    using var db = new SovaDbContext();
        //    var result = db.SearchByScoreResult.FromSqlRaw("select * from search_by_score(" + fromScore + ", " + toScore + ")");
        //    var searchResultList = new List<SearchByScoreResult>();
        //    SearchByScoreResult searchResult;
        //    foreach (var item in result)
        //    {
        //        searchResult = new SearchByScoreResult
        //        {
        //            PostId = item.PostId,
        //            Type = item.Type,
        //            CreationDate = item.CreationDate,
        //            Body = item.Body,
        //            Score = item.Score,
        //            UserId = item.UserId
                    
        //        };
        //        searchResultList.Add(searchResult);
        //    }
        //    return searchResultList;
        //}

        //public List<SearchResult> SearchByUsername(string username)
        //{
        //    using var db = new SovaDbContext();
        //    var result = db.SearchResults.FromSqlRaw("select * from search_by_username(" + username + ")");
        //    return ListResults(result);
        //}

        //public List<SearchByUserNameResult> SearchByUsername(string username)
        //{
        //    using var db = new SovaDbContext();
        //    var result = db.SearchByUserNameResult.FromSqlRaw("select * from search_by_username(" + username + ")");
        //    var searchResultList = new List<SearchByUserNameResult>();
        //    SearchByUserNameResult searchResult;
        //    foreach (var item in result)
        //    {
        //        searchResult = new SearchByUserNameResult
        //        {
        //            PostId = item.PostId,
        //            Type = item.Type,
        //            Body = item.Body,
        //            CreationDate=item.CreationDate,
        //            Score = item.Score,
        //            UserId = item.UserId,
        //            User_Name = item.User_Name
        //        };
        //        searchResultList.Add(searchResult);
        //    }
        //    return searchResultList;
        //}

        //private List<SearchResult> ListResults(IQueryable<SearchResult> result)
        //{
        //    var searchResultList = new List<SearchResult>();
        //    SearchResult searchResult;
        //    foreach (var item in result)
        //    {
        //        searchResult = new SearchResult
        //        {
        //            PostId = item.PostId,
        //            Type = item.Type,
        //            Rank = item.Rank,
        //            Body = item.Body,
        //            CreationDate = item.CreationDate,
        //            Score = item.Score,
        //            UserId = item.UserId,
        //            Username = item.Username
        //        };
        //        searchResultList.Add(searchResult);
        //    }
        //    return searchResultList;
        //}


        //public bool DeleteSearchHistory(string email)
        //{
        //    bool deleted = false;
        //    bool match = false;
        //    using var db = new SovaDbContext();
        //    var appUserService = new AppUserService();
        //    var users = appUserService.GetAllUsers();
        //    foreach (var item in users)
        //    {
        //        if (item.Email == email)
        //        {
        //            match = true;
        //        } 
        //    }

        //    if (match)
        //    {
        //        var result = db.SearchHistories.FromSqlRaw("select delete_history({0})", email);
        //        Console.WriteLine(result.ToString());
        //        return deleted = true;
        //    }
        //    else
        //    {
        //        return deleted = false;
        //    }
            

        //}


        //private List<Question> ListQuestions(IQueryable<Question> result)
        //{
        //    var searchResultList = new List<Question>();
        //    foreach (var item in result)
        //    {
        //        var searchResult = new Question
        //        {
        //            Id = item.Id,
        //            AcceptedAnswerId = item.AcceptedAnswerId,
        //            CreationDate = item.CreationDate,
        //            Score = item.Score,
        //            Body = item.Body,
        //            ClosedDate = item.ClosedDate,
        //            Title = item.Title,
        //            UserId = item.UserId,
        //            //Tag = item.Tag
        //        };
        //        searchResultList.Add(searchResult);
        //    }
        //    return searchResultList;
        //}


        //private List<SearchByAcceptedAnswerResult> ListResults(IQueryable<SearchByAcceptedAnswerResult> result)
        //{
        //    var searchResultList = new List<SearchByAcceptedAnswerResult>();
        //    foreach (var item in result)
        //    {
        //        var searchResult = new SearchByAcceptedAnswerResult
        //        {
        //        };
        //        searchResultList.Add(searchResult);
        //    }
        //    return searchResultList;
        //}

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
