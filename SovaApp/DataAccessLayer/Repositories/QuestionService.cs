using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace DataAccessLayer.Repositories
{
    public class QuestionService:IQuestionService
    {
        public Question GetQuestionById(int questionId)
        {
            using var db = new SovaDbContext();
            return db.Questions.Find(questionId);
        }

            
        public List<Question> GetAllMarkedQuestionsByUserEmail(string userEmail)
        {
            using var db = new SovaDbContext();
            var result = (from m in db.Markings
                          join q in db.Questions on m.QuestionId equals q.Id
                          where m.UserEmail == userEmail
                          select q).ToList();
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
    }
}
