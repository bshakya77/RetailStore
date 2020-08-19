using Microsoft.AspNetCore.Mvc;
using RetailStore.ApiSearch.BAL.Interfaces;
using RetailStore.ApiSearch.BAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailStore.ApiSearch.Controllers
{
    [ApiController]
    [Route("api/search")]
    public class SearchController: ControllerBase
    {
        private readonly ISearchService serviceService;

        public SearchController(ISearchService searchService)
        {
            this.serviceService = searchService;
        }

        [HttpPost]
        public async Task<IActionResult> SearchAsync(SearchTerm term)
        {
            var result = await serviceService.SearchAsync(term.CustomerId);
            
            if (result.IsSuccess)
            {
                return Ok(result.SearchResults);
            }
            return NotFound();
        }
    }
}
