﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public  class SearchService
    {
        public List<SearchResult> SearchByKeyword(params string[] keywords)
        {
            using var db = new SovaDbContext();
            var s = "";
            foreach (var elem in keywords)
            {
                s += "'" + elem + "',";
            }
            s = s.Remove(s.Length - 1);
            var result = db.SearchResults.FromSqlRaw("select * from best_match(" + s + ")");
            var searchResultList = new List<SearchResult>();
            SearchResult searchResult;
            foreach (var item in result)
            {
                searchResult = new SearchResult
                {
                    PostId = item.PostId,
                    Type = item.Type,
                    Rank = item.Rank,
                    Body = item.Body
                };
                searchResultList.Add(searchResult);
            }
            return searchResultList;
        }
    }
}
