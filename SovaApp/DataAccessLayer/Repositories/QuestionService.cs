using Microsoft.EntityFrameworkCore;
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
        public Question GetMarkedQuestion(int questionId)
        {
            using var db = new SovaDbContext();
            var result = (from m in db.Markings
                          join q in db.Questions on m.QuestionId equals q.Id
                          where q.Id == questionId
                          select q).Single();
            return result;

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
    }
}
