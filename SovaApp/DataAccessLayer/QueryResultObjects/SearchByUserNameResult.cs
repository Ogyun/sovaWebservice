using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.QueryResultObjects
{
    public class SearchByUserNameResult
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string User_Name { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Type { get; set; }
        public string Body { get; set; }
        public string Score { get; set; }
    }
}
