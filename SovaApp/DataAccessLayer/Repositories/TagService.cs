using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Repositories
{
    class TagService
    {
        public IEnumerable<Tag> GetAll()
        {
            using (var db = new SovaDbContext())
            {
                IQueryable<Tag> tags = db.Tags
                    .OrderBy(au => au.QuestionId);
                return tags.ToList();
            }
        }

        public Tag GetOne(int id)
        {
            using var db = new SovaDbContext();
            return db.Tags.Find(id);
        }

        
        public int GetCount()
        {
            using (var db = new SovaDbContext())
            {
                return db.Tags.Count();
            }
        }
    }
}
