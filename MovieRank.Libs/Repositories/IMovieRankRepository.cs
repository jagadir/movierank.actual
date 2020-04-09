using System.Collections.Generic;
using System.Threading.Tasks;
using MovieRank.Libs.Models;

namespace MovieRank.Libs.Repositories
{
    public interface IMovieRankRepository
    {
       Task<IEnumerable<MovieDb>> GetAllItems();
        Task<MovieDb> GetMovie(int userId, string movieName);
        Task<IEnumerable<MovieDb>> GetUsersRankedMoviesByMovieTitle(int userId, string movieName);

        Task AddMovie(MovieDb movie);
        Task UpdateMovie(MovieDb movie);
    }
}