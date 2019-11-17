using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class Note
    {
        public int Id { get; set; }
        public string UserEmail{ get; set; }
        public string Notetext { get; set; }
        public int QuestionId { get; set; }

    }
}
