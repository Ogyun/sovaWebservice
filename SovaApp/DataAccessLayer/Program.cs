using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;

namespace DataAccessLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                var note = new Note() { UserEmail = "i@mail.com", Notetext = "testnote", QuestionId = 18830964 };
                var service = new NoteService();
                var result = service.GetNotes("i@mail.com");
                foreach (var item in result)
                {
                    Console.WriteLine(item);
                }
      
            }
        }
    }
}
