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
        public DateTime DateOfBirth { get; set; }
        public DateTime CreationDate { get; set; }
        public string Location { get; set; }
        public List<Note> Notes { get; set; }
        public List<Marking> Markings { get; set; }
        public List<SearchHistory> SearchHistories { get; set; }

    }
}
