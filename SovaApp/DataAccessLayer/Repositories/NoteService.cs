using DataAccessLayer.Contracts;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public class NoteService : INoteService
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
        public List<Note> GetNotesByUserEmail(string userEmail,PagingAttributes pagingAttributes)
        {
            using var db = new SovaDbContext();
            return db.Notes.Where(n => n.UserEmail == userEmail)
                .Skip(pagingAttributes.Page * pagingAttributes.PageSize)
                .Take(pagingAttributes.PageSize)
                .ToList();
        }

        public List<Note> GetAllNotesForQuestion(string userEmail,int questionId, PagingAttributes pagingAttributes)
        {
            using var db = new SovaDbContext();
            return db.Notes.Where(n => n.QuestionId == questionId && n.UserEmail == userEmail)
                .Skip(pagingAttributes.Page * pagingAttributes.PageSize)
                .Take(pagingAttributes.PageSize)
                .ToList();
        }

        public bool UpdateNote(Note note)
        {
            using var db = new SovaDbContext();
            if (NoteExcist(note.Id))
            {
                db.Notes.Update(note);
                return db.SaveChanges() > 0;
            }
            return false;
        }
        public Note GetNoteById(int noteId)
        {
            using var db = new SovaDbContext();
            return db.Notes.Find(noteId);
        }

        public bool DeleteNoteById(int noteId)
        {
            using var db = new SovaDbContext();
            var note = db.Notes.Find(noteId);
            if (note == null) return false;
            db.Notes.Remove(note);
            return db.SaveChanges() > 0;

        }
        public int NumberOfNotesPerUser(string userEmail)
        {
            using var db = new SovaDbContext();
            return db.Notes.Where(n => n.UserEmail == userEmail).Count();
        }
        public int NumberOfNotesPerQuestion(int questionId)
        {
            using var db = new SovaDbContext();
            return db.Notes.Where(n => n.QuestionId == questionId).Count();
        }

        public bool NoteExcist(int noteId)
        {
            return GetNoteById(noteId) != null;
        }
    }
}
