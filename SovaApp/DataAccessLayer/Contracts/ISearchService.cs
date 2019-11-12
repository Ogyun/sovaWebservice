using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Contracts
{
    public interface ISearchService
    {
        public List<SearchResult> SearchByKeyword(params string[] keywords);

    }
}
