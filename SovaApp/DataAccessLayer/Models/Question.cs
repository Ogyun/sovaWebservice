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


    }
}