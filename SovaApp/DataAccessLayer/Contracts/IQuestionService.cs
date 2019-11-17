using System.Collections.Generic;

namespace DataAccessLayer.Repositories
{
    public interface IQuestionService
    {
        Question GetQuestionById(int questionId);
        List<Answer> GetAnswers(int questionId);

    }
}