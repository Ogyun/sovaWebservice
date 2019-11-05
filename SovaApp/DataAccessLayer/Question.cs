using System;

namespace DataAccessLayer
{
    public class Question
    {
        public int Id { get; set; }
        
        public int? AcceptedAnswerId { get; set; }
        
        public DateTime CreationDate { get; set; }
        
        public int Score { get; set; }
        
        public String Body { get; set; }
        
        public DateTime? ClosedDate { get; set; }
        
        public String Title { get; set; }
        
        public int UserId { get; set; }

        public override string ToString()
        {
            return "Id:" + Id + " Accepted Answer Id:" + AcceptedAnswerId + " Creation Date:" + CreationDate + " Score:" + Score + " Body:" + Body
                + " Closed Date:" + ClosedDate + " Title:" + Title + " User Id:" + UserId;
        }
    }
}