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
            public ActionResult<IEnumerable<SearchResult>> GetSearchResult(string query)
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

        [HttpGet("history/user/{userEmail}")]
        public ActionResult GetSearchHistoryByUserEmail(string userEmail)
        {
            var historyList = _searchService.GetSearchHistoryByUserEmail(userEmail);
            Console.WriteLine("This is the list" + historyList);
            if (historyList!=null)
            {
                return CreatedAtAction(
                 nameof(GetSearchHistoryByUserEmail),historyList);
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

        [HttpGet("score/{query}")]
        public ActionResult<IEnumerable<SearchResult>> SearchByScore(string query)
        {
            var res = query.Split(",");
            var result = _searchService.SearchByScore(res[0], res[1]);
            return Ok(result);
        }
        
        [HttpGet("tags/{query}")]
        public ActionResult<IEnumerable<SearchResult>> SearchByTag(string query)
        {
            var res = query.Split(",");
            var result = _searchService.SearchByTag(res);

            //get the user email from token and search text from keywords 
            //if user is authorized call searchService.CreateSearchHistory()
            return Ok(result);
        }

        [HttpGet("accepted/{query}")]
        public ActionResult<IEnumerable<SearchResult>> SearchByAcceptedAnswer(string query)
        {
            bool accepted = query.Equals("yes");
            var result = _searchService.SearchByAcceptedAnswer(accepted);
            return Ok(result);
        }

    }
}

