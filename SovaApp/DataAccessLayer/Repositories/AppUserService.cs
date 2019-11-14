
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
            return user;
        }

        public AppUser GetUserByEmail(string email)
        {
                using var db = new SovaDbContext();
                return db.AppUsers.Find(email);
        }


        public List<AppUser> GetAllUsers()
        {
            using var db = new SovaDbContext();
            return db.AppUsers.ToList();
        }

        public int GetCount()
        {
            using (var db = new SovaDbContext())
            {
                return db.AppUsers.Count();
            }
        }
    }
}
