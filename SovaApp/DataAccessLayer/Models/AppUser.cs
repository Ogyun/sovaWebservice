using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class AppUser
    {
       
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Salt { get; set; }

    }
}
