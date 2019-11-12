using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Contracts
{
    interface INoteService
    {
        public Note CreateNote(Note note);
        public List<Note> GetNotesByUserEmail(string userEmail);
        public List<Note> GetNotesByQuestionId(int questionId);

    }
}
