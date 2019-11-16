using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.Contracts;
using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories
{
    public class MarkingService:IMarkingService
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


        
        public int NumberOfMarkingsPerUser(string userEmail)
        {
            using var db = new SovaDbContext();
            return db.Markings.Where(n => n.UserEmail == userEmail).Count();
        }



    }
}
