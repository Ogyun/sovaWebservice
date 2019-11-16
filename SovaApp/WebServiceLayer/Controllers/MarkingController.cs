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
        private IAppUserService _appUserService;
        private IMapper _mapper;

        public MarkingController(IMarkingService markingService, IQuestionService questionService, IAppUserService appUserService, IMapper mapper)
        {
            _markingService = markingService;
            _questionService = questionService;
            _appUserService = appUserService;
            _mapper = mapper;
        }
        
        [HttpGet("{userEmail}/{questionId}", Name = nameof(GetMarking))]
        public ActionResult GetMarking(int questionId, string userEmail)
        {
            var markedQuestion= _questionService.GetMarkedQuestion(questionId,userEmail);
            if (markedQuestion == null)
            {
                return NotFound();
            }
            return Ok(markedQuestion);
        }

        [HttpPost]
        public ActionResult CreateMarking(string userEmail, int questionId)
        {
            var marking = new Marking
            {
                UserEmail = userEmail,
                QuestionId = questionId
            };
            if (_appUserService.AppUserExcist(userEmail) && _questionService.QuestionExcist(questionId))
            {
                _markingService.CreateMarking(marking);
              var question = _questionService.GetMarkedQuestion(marking.QuestionId,marking.UserEmail);
                return CreatedAtRoute(
                    nameof(GetMarking),
                    new { userEmail = marking.UserEmail, questionId = marking.QuestionId },
                    CreateQuestionDto(question));
            }
            return NotFound();
           
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
                var markedQuestions = _questionService.GetAllMarkedQuestionsByUserEmail(userEmail, pagingAttributes);

                var result = CreateResult(markedQuestions,pagingAttributes,userEmail);

                return Ok(result);
            }

        private string CreatePagingLink(int page, int pageSize)
        {
            return Url.Link(nameof(GetMarking), new { page, pageSize });
        }

        private object CreateResult(IEnumerable<MarkedQuestion> markedQuestions, PagingAttributes attr,string userEmail)
        {
            var totalItems = _markingService.NumberOfMarkingsPerUser(userEmail);
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
                items = markedQuestions.Select(CreateQuestionDto)
            };
        }
        private MarkedQuestionDto CreateQuestionDto(MarkedQuestion question)
        {
                var dto = _mapper.Map<MarkedQuestionDto>(question);
                dto.Link = Url.Link(
                    nameof(GetMarking),
                    new { userEmail = question.UserEmail,questionId = question.Id });
                return dto;
        }

    }
}