using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Contracts
{
    public interface INoteService
    {
        public Note CreateNote(Note note);
        public List<Note> GetNotesByUserEmail(string userEmail, PagingAttributes pagingAttributes);
        public List<Note> GetAllNotesForQuestion(string userEmail, int questionId, PagingAttributes pagingAttributes);
        public bool UpdateNote(Note note);
        public bool DeleteNoteById(int noteId);
        public int NumberOfNotesPerUser(string userEmail);
        public int NumberOfNotesPerQuestion(int questionId);
        public Note GetNoteById(int noteId);
        public bool NoteExcist(int noteId);

    }
}
