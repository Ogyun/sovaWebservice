using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class Answer
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public DateTime CreationDate { get; set; }
        public int Score { get; set; } = 0;
        public string Body { get; set; }
    }
}
