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
            try
            {
                db.Markings.Add(marking);
                db.SaveChanges();
                return marking;
            }
            catch (Exception e)
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
