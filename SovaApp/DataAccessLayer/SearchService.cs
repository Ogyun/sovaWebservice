﻿using Microsoft.EntityFrameworkCore;
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
