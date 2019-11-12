using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public class NoteService
    {
        public Note CreateNote(Note note)
        {
            Console.WriteLine(note);
            using var db = new SovaDbContext();
            db.Notes.Add(note);
            int changes = db.SaveChanges();
            if (changes > 0)
            {
                return note;
            }
            else
            {
                return null;
            }
        }
        public List<Note> GetNotes(string userEmail)
        {
            using var db = new SovaDbContext();
            return db.Notes.Where(n => n.UserEmail == userEmail).ToList();
        }
    }
}
