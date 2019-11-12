using System.Collections.Generic;

namespace DataAccessLayer.Repositories
{
    public class QuestionService:IQuestionService
    {
        public Question GetQuestionById(int questionId)
        {
            using var db = new SovaDbContext();
            return db.Questions.Find(questionId);
        }


        //public List<Question> GetAllMarkedQuestionsByUserEmail(string userEmail)
        //{
        //    using var db = new SovaDbContext();
        //  return
        //}
    }
}
