using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Contracts
{
    public interface INoteService
    {
        public Note CreateNote(Note note);
        public List<Note> GetNotesByUserEmail(string userEmail);
        public List<Note> GetNotesByQuestionId(int questionId);
        public bool UpdateNote(Note note);
        public bool DeleteNoteById(int noteId);

    }
}
