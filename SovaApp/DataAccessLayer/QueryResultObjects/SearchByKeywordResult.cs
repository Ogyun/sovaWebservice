using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.DTOs
{
    public class SearchByKeywordResult
    {
        public int PostId { get; set; }
        public int? Rank { get; set; }
        public string Type { get; set; }
        public string Body { get; set; }
    }
}
