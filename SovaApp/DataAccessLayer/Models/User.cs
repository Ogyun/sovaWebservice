using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserDisplayName { get; set; }
        public DateTime UserCreationDate { get; set; }
        public string? UserLocation { get; set; }
        public int? UserAge { get; set; }
        public List<Question> Questions { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
