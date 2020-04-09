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
        
        [HttpGet]
        [Route("{userid}/{movieName}")]
        public async Task<MovieResponse> GetMovie(int userId, string movieName)
        {
            var result = await _service.GetMovie(userId, movieName);
            return result;
        }

        [HttpGet]
        [Route("user/{userId}/rankedMovies/{movieName}")]
        public async Task<IEnumerable<MovieResponse>> GetUsersRankedMoviesByMovieTitle(int userId, string movieName)
        {
            var results = await _service.GetUsersRankedMoviesByMovieTitle(userId, movieName);
            return results;
        }

        [HttpPost]
        [Route("{userId}")]
        public async Task<IActionResult> AddMovie(int userid, [FromBody] MovieRankRequest movieRankRequest){
            await _service.AddMovie(userid, movieRankRequest);
            return Ok();
        }
    }
}