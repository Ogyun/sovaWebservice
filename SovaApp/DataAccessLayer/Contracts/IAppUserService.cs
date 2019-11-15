using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface IAppUserService
    {

        AppUser GetUserByEmail(string email);
        AppUser CreateUser(string name, string email, string password, string salt);
    }
}