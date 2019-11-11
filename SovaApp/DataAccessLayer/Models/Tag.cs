using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class Tag
    {
        public int QuestionId { get; set; }
        public string TagBody { get; set; }
        public List<QuestionTag> QuestionTags { get; set; }
    }
}
