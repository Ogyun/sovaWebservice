using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;

namespace WebServiceLayer.Controllers
{
    [ApiController]
    [Route("api/search")]
    public class SearchController:ControllerBase
    {
           private ISearchService _searchService;
        
            public SearchController(ISearchService searchService)
            {
                _searchService = searchService;
            }

            [HttpGet("{keywords}")]
            public ActionResult<IEnumerable<SearchResult>> GetSearchResult(string keywords)
            {
                var res = keywords.Split(",");
                var result = _searchService.SearchByKeyword(res);
                return Ok(result);
            }

            
    }
}

