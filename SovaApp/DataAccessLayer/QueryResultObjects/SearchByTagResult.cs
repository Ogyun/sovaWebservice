using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.QueryResultObjects
{
    public class SearchByTagResult
    {
        public int Id { get; set; }
        public int AcceptedAnswerId { get; set; }
        public int UserId { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ClosedDate { get; set; }
        public string Body { get; set; }
        public string Score { get; set; }
        public string Title { get; set; }
        public string Tag { get; set; }
    }
}
