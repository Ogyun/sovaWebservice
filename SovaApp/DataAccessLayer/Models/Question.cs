using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer
{
    public class Question
    {
        public int Id { get; set; }
        
        public int? AcceptedAnswerId { get; set; }
        
        public DateTime CreationDate { get; set; }

        public int Score { get; set; } = 0;
        
        public String Body { get; set; }
        
        public DateTime? ClosedDate { get; set; }
        
        public String Title { get; set; }
        
      //  public User User{ get; set; }

        //public List<Answer> Answers { get; set; }
        //public List<Note> Notes { get; set; }
        //public List<Marking> Markings { get; set; }
        //public List<QuestionTag> QuestionTags{ get; set; }

        public override string ToString()
        {
            return "Id:" + Id + " Accepted Answer Id:" + AcceptedAnswerId + " Creation Date:" + CreationDate + " Score:" + Score + " Body:" + Body
                + " Closed Date:" + ClosedDate + " Title:" + Title;// + " User Id:" + UserId;// + " Tag:" + Tag;
        }
    }
}