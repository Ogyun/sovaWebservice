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

/*        [HttpPost]
        public ActionResult CreateMarking(Marking marking)
        {
            
        }*/

        [HttpGet("{userEmail}",Name = nameof(GetMarkingsByUserEmail))]
            public ActionResult GetMarkingsByUserEmail(string userEmail, [FromQuery] PagingAttributes pagingAttributes)
            {
                var markings = _markingService.GetAllMarkedQuestionsByUserEmail(userEmail, pagingAttributes);

                List<Question> questions = new List<Question>();
                foreach (var marking in markings)
                {
                    questions.Add(_questionService.GetQuestionById(marking.QuestionId));
                }
                var result = CreateResult(questions, pagingAttributes, userEmail);

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
            
            private object CreateResult(IEnumerable<Question> questions, PagingAttributes attr, string userEmail ="", int questionId=0)
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

                return new
                {
                    totalItems,
                    numberOfPages,
                    prev,
                    next,
                    items = questions
                };
            }
            
            /*private MarkingDto CreateMarkingDto(Marking marking)
            {
                var dto = _mapper.Map<MarkingDto>(marking);
                dto.Link = Url.Link(
                    nameof(GetMarking),
                    new { userEmail = marking.UserEmail,questionId = marking.QuestionId });
                return dto;
            }*/
        
      
    }
}