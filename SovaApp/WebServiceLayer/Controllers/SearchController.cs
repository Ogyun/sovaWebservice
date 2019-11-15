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

            [HttpGet("{keywords}")]
            public ActionResult<IEnumerable<SimpleSearchResult>> GetSearchResult(string keywords)
            {
                var res = keywords.Split(",");
                var result = _searchService.SearchByKeyword(res);
                return Ok(result);
            }
            
        [HttpPost]
        public ActionResult CreateSearchHistory(SearchHistoryForCreation searchHistoryDto)
        {
            var history = _mapper.Map<SearchHistory>(searchHistoryDto);
            _searchService.CreateSearchHistory(history);
            return Ok();
        }





    }
}

