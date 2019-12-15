using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using WebServiceLayer.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.IdentityModel.Tokens.Jwt;

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

            [Authorize]
            [HttpGet("keywords/{query}")]
            public ActionResult<IEnumerable<SearchResult>> GetSearchResult(string query)
            {
                var res = query.Split(",");
                var result = _searchService.SearchByKeyword(res);
                SaveSearchHistory(query);
                return Ok(result);
            }

            [Authorize]
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

            [Authorize]
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

            [Authorize]
            [HttpGet("history/user/{userEmail}")]
            public ActionResult GetSearchHistoryByUserEmail(string userEmail)
            {
                var historyList = _searchService.GetSearchHistoryByUserEmail(userEmail);

                if (historyList!=null)
                {
                    return Ok(historyList);
                }
                else
                {
                    return NotFound();
                }
            }

            [Authorize]
            [HttpGet("history/wordCloud/{userEmail}")]
            public ActionResult GetSearchHistoryWordCloud(string userEmail)
            {
                var historyList = _searchService.GetSearchHistoryByUserEmail(userEmail);

                var wordCloudList = _searchService.CalculateWordWeight(historyList);

                if (historyList != null)
                {
                    return Ok(wordCloudList);
                }
                else
                {
                    return NotFound();
                }
            }


        [Authorize]
            [HttpGet("score/{query}")]
            public ActionResult<IEnumerable<SearchResult>> SearchByScore(string query)
            {
                var res = query.Split(",");
                var result = _searchService.SearchByScore(res[0], res[1]);
                SaveSearchHistory(query);
                return Ok(result);
            }

            [Authorize]
            [HttpGet("tags/{query}")]
            public ActionResult<IEnumerable<SearchResult>> SearchByTag(string query)
            {
                var res = query.Split(",");
                var result = _searchService.SearchByTag(res);
                SaveSearchHistory(query);
                return Ok(result);
            }

            [Authorize]
            [HttpGet("answer/{isAccepted}/{keywords}")]
            public ActionResult<IEnumerable<SearchResult>> SearchByAcceptedAnswer(string isAccepted, string keywords)
            {
                bool accepted = isAccepted.Equals("yes");
                var result = _searchService.SearchByAcceptedAnswer(accepted, keywords);
                SaveSearchHistory(keywords);
                return Ok(result);
            }

            private void SaveSearchHistory(string query)
            {
                var userEmail = HttpContext.User.Identity.Name;
                var dto = new SearchHistoryForCreation { Email = userEmail, SearchText = query };
                var history = _mapper.Map<SearchHistory>(dto);
                _searchService.CreateSearchHistory(history);
            }

            //Another way to get the token and decode it
            // HttpContext.Request.Headers.TryGetValue("Authorization",out var jwt);
            //var handler = new JwtSecurityTokenHandler();
            // var token = handler.ReadJwtToken(jwt);

    }
}

