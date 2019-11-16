using DataAccessLayer.Models;
using System.Collections.Generic;

namespace DataAccessLayer.Repositories
{
    public interface IQuestionService
    {
        Question GetQuestionById(int questionId);
        MarkedQuestion GetMarkedQuestion(int questionId, string userEmail);
        public bool QuestionExcist(int questionId);
        public List<MarkedQuestion> GetAllMarkedQuestionsByUserEmail(string userEmail, PagingAttributes pagingAttributes);
    }
}