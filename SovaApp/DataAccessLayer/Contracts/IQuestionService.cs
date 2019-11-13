using System.Collections.Generic;

namespace DataAccessLayer.Repositories
{
    public interface IQuestionService
    {
        Question GetQuestionById(int questionId);
        public List<Question> GetAllMarkedQuestionsByUserEmail(string userEmail);
    }
}