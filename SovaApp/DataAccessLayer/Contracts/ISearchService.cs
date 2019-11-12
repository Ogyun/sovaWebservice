using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface ISearchService
    {
        List<SearchResult> SearchByKeyword(params string[] keywords);
    }
}