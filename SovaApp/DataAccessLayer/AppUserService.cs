
using System;
using System.Collections.Generic;
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

        


    }
}
