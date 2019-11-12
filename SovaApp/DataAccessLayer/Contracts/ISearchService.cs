namespace DataAccessLayer
{
    public interface ISearchService
    {
        System.Collections.Generic.List<SearchResult> SearchByKeyword(params string[] keywords);
    }
}