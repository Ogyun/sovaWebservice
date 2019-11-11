using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class QuestionTag
    {
        public int QuestionId { get; set; }
        public Question Question { get; set; }

       // public int TagQuestionId { get; set; }
        public string TagBody { get; set; }
        public  Tag Tag { get; set; }
    }
}
