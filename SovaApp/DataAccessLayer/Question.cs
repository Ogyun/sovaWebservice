using System;

namespace DataAccessLayer
{
    public class Question
    {
        public int Id { get; set; }
        
        public int AcceptedAnswerId { get; set; }
        
        public DateTime CreationDate { get; set; }
        
        public int Score { get; set; }
        
        public String Body { get; set; }
        
        public DateTime? ClosedDate { get; set; }
        
        public String Title { get; set; }
        
        public int UserId { get; set; }
    }
}