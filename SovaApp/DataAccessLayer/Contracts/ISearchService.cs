using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface ISearchService
    {
        List<SearchResult> SearchByKeyword(params string[] keywords);
        SearchHistory CreateSearchHistory(SearchHistory history);
        List<SearchHistory> GetSearchHistoryByUserEmail(string userEmail);
        bool DeleteSearchHistoryByUserEmail(string userEmail);
        bool DeleteSearchHistoryById(int historyId);
        List<SearchResult> SearchByScore(string fromScore, string toScore);
        List<SearchResult> SearchByTag(params string[] keywords);
        List<SearchResult> SearchByAcceptedAnswer(bool accepted, params string[] keywords);
    }
}