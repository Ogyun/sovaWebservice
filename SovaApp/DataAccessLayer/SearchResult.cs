using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class SearchResult
    {
        public int PostId{ get; set; }
        public int? Rank { get; set; }
        public string Type { get; set; }
        public string Body { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? Score { get; set; }
        public int? UserId { get; set; }
        

        public override string ToString()
        {
            return "PostId:" + PostId + " Rank:" + Rank + " Type:" + Type + " Body:" + Body + " Creation Date: " + CreationDate + " Score: " + Score
                + " User Id: " + UserId;
        }
    }
}
