using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieRank.Api.Services;
using MovieRank.Contracts;

namespace MovieRank.Api.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MovieController : Controller
    {
        private readonly IMovieRankService _service;

        public MovieController(IMovieRankService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IList<MovieResponse>>> GetAllItemsFromDatabase()
        {
            var response = await _service.GetAllItemsFromDatabase();
            return Ok(response);
        }
    }
}