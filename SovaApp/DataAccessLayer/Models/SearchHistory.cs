using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class SearchHistory
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime SearchDate { get; set; }
        public string SearchText { get; set; }
    }
}
