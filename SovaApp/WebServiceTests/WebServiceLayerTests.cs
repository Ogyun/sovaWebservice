using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;

namespace Tests
{
    public class WebServiceLayerTests
    {
        private const string NotesApi = "http://localhost:5001/api/notes";
        private const string SearchApi = "http://localhost:5001/api/search";
        private const string QuestionsApi = "http://localhost:5001/api/questions";

        /*/api/notes*/
        [Fact]
        public void ApiNotes_GetNotesByUserEmail_OkAndAllNotes()
        {
            string userEmail = "i@mail.com";
            var (data, statusCode) = GetObject(NotesApi+"/"+userEmail);
            Assert.Equal(HttpStatusCode.OK, statusCode);
            Assert.Equal(5, data.Count);
        }

        [Fact]
        public void ApiNotes_GetAllNotesForQuestion_OkAndAllNotes()
        {
            string userEmail = "i@mail.com";
            int questionId = 18830964;
            var (data, statusCode) = GetObject(NotesApi + "/" + userEmail+"/question/"+questionId);
            Assert.Equal(HttpStatusCode.OK, statusCode);
            Assert.Equal(5, data.Count);
            Assert.Equal(7, data["items"].Count());
        }
        [Fact]
        public void ApiNotes_CreateNote_Created()
        {
            var newNote = new
            {             
                UserEmail = "i@mail.com",
                Notetext="testnoteFromWebServiceTest",
                QuestionId = "10405320"
                };
            var (note, statusCode) = PostData(NotesApi, newNote);
            Assert.Equal(HttpStatusCode.Created, statusCode);
        }

        [Fact]
        public void ApiNotes_DeleteWithValidId_Ok()
        {

            int noteId = 11;
            var statusCode = DeleteData($"{NotesApi}/{noteId}");

            Assert.Equal(HttpStatusCode.OK, statusCode);
        }


        //Helpers
        (JArray, HttpStatusCode) GetArray(string url)
        {
            var client = new HttpClient();
            var response = client.GetAsync(url).Result;
            var data = response.Content.ReadAsStringAsync().Result;
            return ((JArray)JsonConvert.DeserializeObject(data), response.StatusCode);
        }

        (JObject, HttpStatusCode) GetObject(string url)
        {
            var client = new HttpClient();
            var response = client.GetAsync(url).Result;
            var data = response.Content.ReadAsStringAsync().Result;
            return ((JObject)JsonConvert.DeserializeObject(data), response.StatusCode);
        }

        (JObject, HttpStatusCode) PostData(string url, object content)
        {
            var client = new HttpClient();
            var requestContent = new StringContent(
                JsonConvert.SerializeObject(content),
                Encoding.UTF8,
                "application/json");
            var response = client.PostAsync(url, requestContent).Result;
            var data = response.Content.ReadAsStringAsync().Result;
            return ((JObject)JsonConvert.DeserializeObject(data), response.StatusCode);
        }

        HttpStatusCode PutData(string url, object content)
        {
            var client = new HttpClient();
            var response = client.PutAsync(
                url,
                new StringContent(
                    JsonConvert.SerializeObject(content),
                    Encoding.UTF8,
                    "application/json")).Result;
            return response.StatusCode;
        }

        HttpStatusCode DeleteData(string url)
        {
            var client = new HttpClient();
            var response = client.DeleteAsync(url).Result;
            return response.StatusCode;
        }
    }
}
