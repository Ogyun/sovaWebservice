using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repositories
{
    public class AnswerService
    {
        public Answer GetAnswerById(int answerId)
        {
            using var db = new SovaDbContext();
            return db.Answers.Find(answerId);
        }
    }
}
