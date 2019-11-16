
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DataAccessLayer
{
    public class AppUserService : IAppUserService
    {
        public AppUser CreateUser(string name, string email, string password, string salt)
        {
            using var db = new SovaDbContext();
            var user = new AppUser()
            {
                Name = name,
                Email = email,
                Password = password,
                Salt = salt
            };
            db.AppUsers.Add(user);
            int changes = db.SaveChanges();
            if (changes > 0)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public AppUser GetUserByEmail(string email)
        {
                using var db = new SovaDbContext();
                return db.AppUsers.Find(email);
        }
        public bool AppUserExcist(string email)
        {
            return GetUserByEmail(email) != null;
        }

    }
}
