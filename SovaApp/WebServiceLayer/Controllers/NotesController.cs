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

        private object CreateResult(IEnumerable<Note> notes, PagingAttributes attr, string userEmail)
        {
            var totalItems = _noteService.NumberOfNotesPerUser(userEmail);
            var numberOfPages = Math.Ceiling((double)totalItems / attr.PageSize);

            var prev = attr.Page > 0
                ? CreatePagingLink(attr.Page - 1, attr.PageSize)
                : null;
            var next = attr.Page < numberOfPages - 1
                ? CreatePagingLink(attr.Page + 1, attr.PageSize)
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

        private string CreatePagingLink(int page, int pageSize)
        {
            return Url.Link(nameof(GetNotesByUserEmail), new { page, pageSize });
        }

        private NoteDto CreateNoteDto(Note note)
        {
            var dto = _mapper.Map<NoteDto>(note);
            dto.Link = Url.Link(
                    nameof(GetNotesByUserEmail),
                    new { noteId = note.Id });
            return dto;
        }
    }
}
