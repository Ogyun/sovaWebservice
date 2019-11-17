using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class MarkedQuestion
    {
        public int Id { get; set; }
        public string Title{ get; set; }
        public string UserEmail { get; set; }
    }
}
