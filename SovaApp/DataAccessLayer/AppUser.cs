using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    class AppUser
    {
       
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }
        public DateTime CreationDate { get; set; }
        public string Location { get; set; }
       

    }
}
