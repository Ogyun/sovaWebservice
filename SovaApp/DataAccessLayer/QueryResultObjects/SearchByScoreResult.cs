using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.DTOs
{
    public class SearchByScoreResult
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Type { get; set; }
        public string Body { get; set; }
        public string Score { get; set; }
    }
}
