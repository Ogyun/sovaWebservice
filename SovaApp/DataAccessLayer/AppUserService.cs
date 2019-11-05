﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DataAccessLayer
{
    class AppUserService
    {
        public AppUser Create(AppUser appuser)
        {
            using (var db = new SovaDbContext())
            {
                db.AppUsers.Add(appuser);
                db.SaveChanges();

                return appuser;
            }
        }

        public List<AppUser> GetAllUsers()
        {
            using var db = new SovaDbContext();
            return db.AppUsers.ToList();
        }

        


    }
}
