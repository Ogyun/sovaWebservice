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
            var s = "";
            foreach (var elem in keywords)
            {
                s += "'" + elem + "',";
            }
            s = s.Remove(s.Length - 1);
            var result = db.SearchResults.FromSqlRaw("select * from best_match(" + s + ")");
            var searchResultList = new List<SearchResult>();
            SearchResult searchResult;
            foreach (var item in result)
            {
                searchResult = new SearchResult
                {
                    PostId = item.PostId,
                    Type = item.Type,
                    Rank = item.Rank,
                    Body = item.Body
                };
                searchResultList.Add(searchResult);
            }
            return searchResultList;
        }

        public List<SearchResult> SearchByAcceptedAnswer(Boolean accepted)
        {
            using var db = new  SovaDbContext();
            if(accepted) { var result = db.Questions.FromSqlRaw("select * from questions where acceptedanswerid is not null"); }
            else{ var result = db.Questions.FromSqlRaw("select * from questions where acceptedanswerid is null"); }
            return ListQuestions(result);
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
                    Body = item.Body
                };
                searchResultList.Add(searchResult);
            }
            return searchResultList;
        }

        public Question GetQuestionById(int questionId)
        {
            using var db = new SovaDbContext();
            return db.Questions.Find(questionId);    
        }

        public Answer GetAnswerById(int answerId)
        {
            using var db = new SovaDbContext();
            return db.Answers.Find(answerId);
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
                    UserId = item.UserId
                };
                searchResultList.Add(searchResult);
            }
            return searchResultList;
        }
    }
}
