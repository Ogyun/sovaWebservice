using DataAccessLayer;
using DataAccessLayer.Repositories;
using System;
using System.Linq;
using Xunit;

namespace WebServiceTests
{
    public class DataServiceTests
    {
        [Fact]
        public void SearchByKeywordTest()
        {
            var service = new SearchService();
            var search = service.SearchByKeyword("c#","constructors");
            Assert.Equal(92, search.Count);
            Assert.Equal(231767, search.First().QuestionId);
            Assert.Equal("answer", search.First().Type);
            Assert.Null(search.First().Tags);
        }

        [Fact]
        public void GetQuestionByIdTest()
        {
            var service = new QuestionService();
            var question = service.GetQuestionById(18830964);
            Assert.Equal(2, question.Score);
            Assert.Equal("2013-09-16 14:49:26",question.CreationDate.ToString("yyyy-MM-dd HH:mm:ss"));
            Assert.Equal(18831685, question.AcceptedAnswerId);
            Assert.Null(question.ClosedDate);
          
        }
        [Fact]
        public void GetAnswerByIdTest()
        {
            var service = new AnswerService();
            var answer = service.GetAnswerById(71);
            Assert.Equal(43, answer.Score);
            Assert.Equal("2008-08-01 13:38:00", answer.CreationDate.ToString("yyyy-MM-dd HH:mm:ss"));
            Assert.Equal(19, answer.QuestionId);         

        }
        //[Fact]
        //public void GetAllTest()
        //{

        //    var service = new AnswerService();
        //    // When.
        //    var answers = service.GetAll();
        //    // Then.
        //    Assert.Equal(11182, answers.Count());
        //    Assert.Equal(71, answers.First().Id);
        //    Assert.Equal("<p>Here's a general description of a technique for calculating pi that I learnt in high school.</p>&#xA;&#xA;<p>I only share this because I think it is simple enough that anyone can remember it, indef", answers.First().Body.Substring(0, 200));
        //    Assert.Equal(1446, answers.First().Body.Length);
        //    Assert.Equal(43, answers.First().Score);
        //    Assert.Equal("2008-08-01 13:38:00", answers.First().CreationDate.ToString("yyyy-MM-dd HH:mm:ss"));
        //    Assert.Equal(49, answers.First().User.UserId);
        //}
        [Fact]
        public void CreateNoteTest()
        {
            var note = new Note() { UserEmail = "i@mail.com", Notetext = "testnote", QuestionId = 18830964 };
            var service = new NoteService();
            var result = service.CreateNote(note);
            Assert.Equal("i@mail.com", result.UserEmail);
            Assert.Equal("testnote", result.Notetext);
            Assert.Equal(18830964, result.QuestionId);
        }

    }
}
