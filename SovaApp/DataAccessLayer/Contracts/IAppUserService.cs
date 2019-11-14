using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface IAppUserService
    {
        List<AppUser> GetAllUsers();
        int GetCount();
        AppUser GetUserByEmail(string email);
        AppUser CreateUser(string name, string username, string password, string salt);
    }
}