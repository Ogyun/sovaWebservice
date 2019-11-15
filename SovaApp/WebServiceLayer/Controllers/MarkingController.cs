using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.Contracts;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.VisualBasic.CompilerServices;
using WebServiceLayer.Models;

namespace WebServiceLayer.Controllers
{
    [ApiController]
    [Route("api/markings")]
    public class MarkingController:ControllerBase
    {
        private IMarkingService _markingService;
        private IQuestionService _questionService;
        private IMapper _mapper;

        public MarkingController(IMarkingService markingService, IQuestionService questionService, IMapper mapper)
        {
            _markingService = markingService;
            _questionService = questionService;
            _mapper = mapper;
        }
        
        [HttpGet("{userEmail}/{questionId}", Name = nameof(GetMarking))]
        public ActionResult GetMarking(int questionId)
        {
            var marking = _questionService.GetQuestionById(questionId);
            if (marking == null)
            {
                return NotFound();
            }
            return Ok(marking);
        }

        [HttpPost]
        public ActionResult CreateMarking(string userEmail, int questionId)
        {
            var marking = new Marking
            {
                UserEmail = userEmail,
                QuestionId = questionId
            };
            _markingService.CreateMarking(marking);
            return CreatedAtRoute(
                nameof(GetMarking),
                new {userEmail = marking.UserEmail, questionId = marking.QuestionId},
                CreateMarkingDto(marking));
        }

        [HttpDelete]
        public ActionResult DeleteMarking(string userEmail, int questionId)
        {
            var marking = new Marking
            {
                UserEmail = userEmail,
                QuestionId = questionId

            };
            if (_markingService.DeleteMarking(marking))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{userEmail}",Name = nameof(GetMarkingsByUserEmail))]
            public ActionResult GetMarkingsByUserEmail(string userEmail, [FromQuery] PagingAttributes pagingAttributes)
            {
                var markings = _markingService.GetAllMarkedQuestionsByUserEmail(userEmail, pagingAttributes);

                List<Question> questions = new List<Question>();
                foreach (var marking in markings)
                {
                    questions.Add(_questionService.GetQuestionById(marking.QuestionId));
                }
                var result = CreateResult(questions, markings, pagingAttributes, userEmail);

                return Ok(result);
            }
            
            private string CreatePagingLink(int page, int pageSize,string userEmail, int questionId)
            {
                string pageLink = "";
                if (userEmail!="")
                {
                    pageLink = Url.Link(nameof(GetMarkingsByUserEmail), new { page, pageSize });
                }
            
                return pageLink;
            
            }
            
            private object CreateResult(IEnumerable<Question> questions, IEnumerable<Marking> markings,PagingAttributes attr, string userEmail ="", int questionId=0)
            {
                int totalItems = 0;
                
                totalItems = _markingService.NumberOfMarkingsPerUser(userEmail);
                
                var numberOfPages = Math.Ceiling((double)totalItems / attr.PageSize);

                var prev = attr.Page > 0
                    ? CreatePagingLink(attr.Page - 1, attr.PageSize, userEmail,questionId)
                    : null;
                var next = attr.Page < numberOfPages - 1
                    ? CreatePagingLink(attr.Page + 1, attr.PageSize, userEmail, questionId)
                    : null;
            var titles = questions.Select(q => q.Title);
            var links = markings.Select(CreateMarkingDto);
            return new
            {
                totalItems,
                numberOfPages,
                prev,
                next,
                items = new { titles = titles, links = links }
            };
            }
            
            private MarkingDto CreateMarkingDto(Marking marking)
            {
                var dto = _mapper.Map<MarkingDto>(marking);
                dto.Link = Url.Link(
                    nameof(GetMarking),
                    new { userEmail = marking.UserEmail,questionId = marking.QuestionId });
                return dto;
            }
        
      
    }
}