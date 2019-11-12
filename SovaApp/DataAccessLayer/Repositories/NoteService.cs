using DataAccessLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public class NoteService:INoteService
    {
        public Note CreateNote(Note note)
        {
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
        public List<Note> GetNotesByUserEmail(string userEmail)
        {
            using var db = new SovaDbContext();
            return db.Notes.Where(n => n.UserEmail == userEmail).ToList();
        }

        public List<Note> GetNotesByQuestionId(int questionId)
        {
            using var db = new SovaDbContext();
            return db.Notes.Where(n => n.QuestionId == questionId).ToList();
        }
    }
}
