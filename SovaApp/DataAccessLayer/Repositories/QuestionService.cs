using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Repositories
{
    public class QuestionService:IQuestionService
    {
        public Question GetQuestionById(int questionId)
        {
            using var db = new SovaDbContext();
            return db.Questions.Find(questionId);
        }
        public Question GetMarkedQuestion(int questionId, string userEmail)
        {
            using var db = new SovaDbContext();
            try
            {
                return (from m in db.Markings
                              join q in db.Questions on m.QuestionId equals q.Id
                              where q.Id == questionId && m.UserEmail == userEmail
                              select q).Single();
            }
            catch (Exception e)
            {

                return null;
            }
 
        }

        public List<Question> GetAllMarkedQuestionsByUserEmail(string userEmail,PagingAttributes pagingAttributes)
        {
            using var db = new SovaDbContext();
            var result = (from m in db.Markings
                          join q in db.Questions on m.QuestionId equals q.Id
                          where m.UserEmail == userEmail
                          select q)
                          .Skip(pagingAttributes.Page * pagingAttributes.PageSize)
                          .Take(pagingAttributes.PageSize)
                          .ToList();
            return result;
                
        }
        public bool QuestionExcist(int questionId)
        {
            return GetQuestionById(questionId) != null;
        }
    }
}
