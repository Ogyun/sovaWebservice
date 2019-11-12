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

    }
}
