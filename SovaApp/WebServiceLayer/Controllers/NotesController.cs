using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.Contracts;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceLayer.Models;


namespace WebServiceLayer.Controllers
{
    [ApiController]
    [Route("api/notes")]
    public class NotesController:ControllerBase
    {
        private INoteService _noteService;
        private IMapper _mapper;

        public NotesController(INoteService noteService, IMapper mapper)
        {
            _noteService = noteService;
            _mapper = mapper;
        }

        [HttpGet("{userEmail}",Name = nameof(GetNotesByUserEmail))]
        public ActionResult GetNotesByUserEmail(string userEmail,[FromQuery] PagingAttributes pagingAttributes)
        {
            var notes = _noteService.GetNotesByUserEmail(userEmail, pagingAttributes);

            var result = CreateResult(notes, pagingAttributes,userEmail);

            return Ok(result);
        }

        [HttpGet("{userEmail}/question/{questionId}", Name = nameof(GetAllNotesForQuestion))]
        public ActionResult GetAllNotesForQuestion(string userEmail,int questionId, [FromQuery] PagingAttributes pagingAttributes)
        {
            var notes = _noteService.GetAllNotesForQuestion(userEmail,questionId, pagingAttributes);

            var result = CreateResult(notes, pagingAttributes, userEmail);

            return Ok(result);
        }



        [HttpGet("{userEmail}/{noteId}", Name = nameof(GetNote))]
        public ActionResult GetNote(int noteId)
        {
            var note = _noteService.GetNoteById(noteId);
            if (note == null)
            {
                return NotFound();
            }
            return Ok(CreateNoteDto(note));
        }
        [HttpPost]
        public ActionResult CreateNote(NoteForCreation noteDto)
        {
            var note = _mapper.Map<Note>(noteDto);
            _noteService.CreateNote(note);
            return CreatedAtRoute(
                nameof(GetNote),
                new { userEmail = note.UserEmail, noteId = note.Id },
                CreateNoteDto(note));
        }

        private object CreateResult(IEnumerable<Note> notes, PagingAttributes attr, string userEmail ="", int questionId=0)
        {
            int totalItems = 0;
            if (userEmail!="")
            {
                totalItems = _noteService.NumberOfNotesPerUser(userEmail);
            }
            if (questionId!=0)
            {
                totalItems = _noteService.NumberOfNotesPerQuestion(questionId);
            }
           
            var numberOfPages = Math.Ceiling((double)totalItems / attr.PageSize);

            var prev = attr.Page > 0
                ? CreatePagingLink(attr.Page - 1, attr.PageSize, userEmail,questionId)
                : null;
            var next = attr.Page < numberOfPages - 1
                ? CreatePagingLink(attr.Page + 1, attr.PageSize, userEmail, questionId)
                : null;

            return new
            {
                totalItems,
                numberOfPages,
                prev,
                next,
                items = notes.Select(CreateNoteDto)
            };
        }

        private string CreatePagingLink(int page, int pageSize,string userEmail, int questionId)
        {
            string pageLink = "";
            if (userEmail!="")
            {
                pageLink = Url.Link(nameof(GetNotesByUserEmail), new { page, pageSize });
            }
            if (questionId!=0)
            {
                pageLink = Url.Link(nameof(GetAllNotesForQuestion), new { page, pageSize });
            }

            return pageLink;
            
        }

        private NoteDto CreateNoteDto(Note note)
        {
            var dto = _mapper.Map<NoteDto>(note);
            dto.Link = Url.Link(
                    nameof(GetNote),
                    new { userEmail = note.UserEmail,noteId = note.Id });
            return dto;
        }
    }
}

