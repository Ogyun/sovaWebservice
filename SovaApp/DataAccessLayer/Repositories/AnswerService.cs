using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Repositories
{
    public class AnswerService
    {
        public IEnumerable<Answer> GetAll()
        {
            using (var db = new SovaDbContext())
            {
                IQueryable<Answer> answers = db.Answers
                    .Include(a => a.User)
                    .OrderBy(an => an.Id);
                return answers.ToList();
            }
        }
        



        public Answer GetAnswerById(int answerId)
        {
            using var db = new SovaDbContext();
            return db.Answers.Find(answerId);
        }

        public IEnumerable<Answer> GetAnswersForQuestion(int questionId)
        {
            using (var db = new SovaDbContext())
            {
                IQueryable<Answer> answers = db.Answers
                    .Where(an => an.QuestionId == questionId)
                    .Include(q => q.Question)
                    .OrderBy(an => an.Id);
                return answers.ToList();
            }
        }
}
