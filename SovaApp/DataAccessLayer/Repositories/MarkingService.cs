using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repositories
{
    public class MarkingService
    {
        public Marking CreateMarking(Marking marking)
        {
            using var db = new SovaDbContext();
            db.Markings.Add(marking);
            int changes = db.SaveChanges();
            if (changes > 0)
            {
                return marking;
            }
            else
            {
                return null;
            }
        }

        public bool DeleteMarking(Marking marking)
        {
            using var db = new SovaDbContext();
            var result = db.Markings.Find(marking.UserEmail,marking.QuestionId);
            if (result == null) return false;
            db.Markings.Remove(result);
            return db.SaveChanges() > 0;

        }

    }
}
