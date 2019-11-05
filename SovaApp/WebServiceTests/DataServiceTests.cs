using DataAccessLayer;
using System;
using System.Linq;
using Xunit;

namespace WebServiceTests
{
    public class DataServiceTests
    {
        [Fact]
        public void SearchFunctionTest()
        {
            var service = new SearchService();
            var search = service.SearchByKeyword("c#","constructors");
            Assert.Equal(92, search.Count);
            Assert.Equal(69718, search.First().PostId);
        }
    }
}
