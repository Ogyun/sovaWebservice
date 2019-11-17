using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebServiceLayer.Controllers
{
    [ApiController]
    [Route("api/questions")]
    public class QuestionsController : ControllerBase
    {
        private IQuestionService _questionService;
        public QuestionsController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet("{questionId}", Name = nameof(GetQuestion))]
        public ActionResult GetQuestion(int questionId)
        {
            var question = _questionService.GetQuestionById(questionId);
            if (question == null)
            {
                return NotFound();
            }
            return Ok(question);
        }
        
        [HttpGet("{questionId}/answers", Name = nameof(GetAnswers))]
        public ActionResult GetAnswers(int questionId)
        {
            var question = _questionService.GetAnswers(questionId);
            if (question == null)
            {
                return NotFound();
            }
            return Ok(question);
        }


    }
}
