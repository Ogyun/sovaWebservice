using System;

namespace DataAccessLayer
{
    public class Question
    {
        public int Id { get; set; }
        
        public int AcceptedAnswerId { get; set; }
        
        public String CreationDate { get; set; }
        
        public int Score { get; set; }
        
        public String Body { get; set; }
        
        public String ClosedDate { get; set; }
        
        public String Title { get; set; }
        
        public int UserId { get; set; }
    }
}