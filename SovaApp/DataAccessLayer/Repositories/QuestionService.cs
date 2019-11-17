using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories
{
    public class QuestionService:IQuestionService
    {
        public Question GetQuestionById(int questionId)
        {
            using var db = new SovaDbContext();
            return db.Questions.Find(questionId);
        }
        public MarkedQuestion GetMarkedQuestion(int questionId, string userEmail)
        {
            using var db = new SovaDbContext();
            try
            {
                var result = (from m in db.Markings
                         join q in db.Questions on m.QuestionId equals q.Id
                         where q.Id == questionId && m.UserEmail == userEmail
                         select new MarkedQuestion { Id = q.Id, Title = q.Title, UserEmail = m.UserEmail }).Single();
                return result;
            }
            catch (Exception e)
            {

                return null;
            }
 
        }

        public List<MarkedQuestion> GetAllMarkedQuestionsByUserEmail(string userEmail,PagingAttributes pagingAttributes)
        {
            using var db = new SovaDbContext();
            var result = (from m in db.Markings
                          join q in db.Questions on m.QuestionId equals q.Id
                          where m.UserEmail == userEmail
                          select new MarkedQuestion{Id = q.Id,Title = q.Title, UserEmail = m.UserEmail })
                          .Skip(pagingAttributes.Page * pagingAttributes.PageSize)
                          .Take(pagingAttributes.PageSize)
                          .ToList();
            return result;
                
        }

        public List<Answer> GetAnswers(int questionid)
        {
            using var db = new SovaDbContext();
            var result = (from a in db.Answers
                join q in db.Questions on a.QuestionId equals q.Id
                where q.Id == questionid
                select a).ToList();
            return result;
        }
        public bool QuestionExcist(int questionId)
        {
            return GetQuestionById(questionId) != null;
        }
    }
}
