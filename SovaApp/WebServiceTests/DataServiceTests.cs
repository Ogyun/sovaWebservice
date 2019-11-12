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
            var search = service.SearchByKeyword("c#", "constructors");
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
            Assert.Equal("2013-09-16 14:49:26", question.CreationDate.ToString("yyyy-MM-dd HH:mm:ss"));
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

        [Fact]
        public void GetNotesByUserEmailTest()
        {
            var userEmail = "i@mail.com";
            var service = new NoteService();
            var result = service.GetNotesByUserEmail(userEmail);
            Assert.Equal(3, result.Count);

        }

        [Fact]
        public void GetNotesByQuestionIdTest()
        {
            var questionId = 18830964;
            var service = new NoteService();
            var result = service.GetNotesByQuestionId(questionId);
            Assert.Equal(3, result.Count);

        }
        [Fact]
        public void CreateMarkingTest()
        {
            var marking = new Marking() { UserEmail = "i@mail.com", QuestionId = 18830964 };
            var service = new MarkingService();
            var result = service.CreateMarking(marking);
            Assert.Equal("i@mail.com", result.UserEmail);
            Assert.Equal(18830964, result.QuestionId);
        }
    }
}
