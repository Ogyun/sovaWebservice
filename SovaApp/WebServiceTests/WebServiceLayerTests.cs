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
            var userEmail = "i@mail.com";
            var (data, statusCode) = GetArray(NotesApi+"/"+userEmail);

            Assert.Equal(HttpStatusCode.OK, statusCode);
            Assert.Equal(2, data.Count);
           // Assert.Equal("UpdatedNote", data.First()["notetext"]);
           // Assert.Equal("Apples", data.Last()["notetext"]);
        }
        //Helpers
        (JArray, HttpStatusCode) GetArray(string url)
        {
            var client = new HttpClient();
            var response = client.GetAsync(url).Result;
            var data = response.Content.ReadAsStringAsync().Result;
            return ((JArray)JsonConvert.DeserializeObject(data), response.StatusCode);
        }
    }
}
