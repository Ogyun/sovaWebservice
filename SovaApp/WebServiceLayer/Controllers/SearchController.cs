using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using WebServiceLayer.Models;
using AutoMapper;

namespace WebServiceLayer.Controllers
{
    [ApiController]
    [Route("api/search")]
    public class SearchController:ControllerBase
    {
         private ISearchService _searchService;
         private IMapper _mapper;
         public SearchController(ISearchService searchService, IMapper mapper)
            {
                _searchService = searchService;
                _mapper = mapper;
            }
        [HttpGet("keywords/{query}")]
       // [HttpGet("{keywords}")]
            public ActionResult<IEnumerable<SimpleSearchResult>> GetSearchResult(string query)
            {
                var res = query.Split(",");
                var result = _searchService.SearchByKeyword(res);

            //get the user email from token and search text from keywords 
            //if user is authorized call searchService.CreateSearchHistory()
            return Ok(result);
        }
        [HttpDelete("history/{historyId}")]
        public ActionResult DeleteHistoryById(int historyId)
        {
            if (_searchService.DeleteSearchHistoryById(historyId))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }

        [HttpDelete("history/user/{userEmail}")]
        public ActionResult DeleteAllHistoryByUserEmail(string userEmail)
        {
            if (_searchService.DeleteSearchHistoryByUserEmail(userEmail))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }

        //we might not need this route
        //[HttpPost]
        //public ActionResult CreateSearchHistory(SearchHistoryForCreation searchHistoryDto)
        //{
        //    var history = _mapper.Map<SearchHistory>(searchHistoryDto);
        //    _searchService.CreateSearchHistory(history);
        //    return Ok();
        //}





    }
}

