using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface IAppUserService
    {

        AppUser GetUserByEmail(string email);
        AppUser CreateUser(string name, string email, string password, string salt);
        public bool AppUserExcist(string email);
        bool DeleteUserByEmail(string useremail);
        bool UpdateUser(AppUser user);
    }
}