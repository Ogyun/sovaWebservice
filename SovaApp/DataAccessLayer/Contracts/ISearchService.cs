using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface ISearchService
    {
        List<SearchResult> SearchByKeyword(params string[] keywords);
        public SearchHistory CreateSearchHistory(SearchHistory history);
        public List<SearchHistory> GetSearchHistoryByUserEmail(string userEmail);
        public bool DeleteSearchHistoryByUserEmail(string userEmail);
        public bool DeleteSearchHistoryById(int historyId);
    }
}