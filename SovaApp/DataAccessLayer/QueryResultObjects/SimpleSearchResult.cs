using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
        public class SimpleSearchResult
        {   
            public int QuestionId{ get; set; }
            public int? AnswerId { get; set; }
            public string Type { get; set; }
            public string Title { get; set; }
            public string Body { get; set; }
            public int Score { get; set; }
            
        }
    }

