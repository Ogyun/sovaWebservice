using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Contracts
{
    public interface IQuestionService
    {
        public Question GetQuestionById(int questionId);
    }
}
