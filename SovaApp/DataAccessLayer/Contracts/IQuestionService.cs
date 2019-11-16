using System.Collections.Generic;

namespace DataAccessLayer.Repositories
{
    public interface IQuestionService
    {
        Question GetQuestionById(int questionId);
        Question GetMarkedQuestion(int questionId, string userEmail);
        public bool QuestionExcist(int questionId);
    }
}