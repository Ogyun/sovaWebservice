using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;

namespace WebServiceLayer.Controllers
{
    public class SearchController
    {
        [ApiController]
        [Route("api/search")]
        public class CategoriesController : ControllerBase
        {

            ISearchService _searchService;

            public CategoriesController(ISearchService searchService)
            {
                _searchService = searchService;
            }

            [HttpGet("{keywords}")]
            public ActionResult<IEnumerable<SearchResult>> GetSearchResult(params string[] keywords)
            {
                var result = _searchService.SearchByKeyword(keywords);
                return Ok(result);
            }

            
        }
    }
}
