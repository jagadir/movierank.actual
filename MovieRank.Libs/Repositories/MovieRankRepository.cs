using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using MovieRank.Libs.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MovieRank.Libs.Repositories
{
    public class MovieRankRepository : IMovieRankRepository
    {
        private readonly IDynamoDBContext _context;

        public MovieRankRepository(IDynamoDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MovieDb>> GetAllItems()
        {
            return await _context.ScanAsync<MovieDb>(new List<ScanCondition>()).GetRemainingAsync();
        }

        public async Task<MovieDb> GetMovie(int userId, string movieName)
        {
            return await _context.LoadAsync<MovieDb>(userId, movieName);
        }

        public async Task<IEnumerable<MovieDb>> GetUsersRankedMoviesByMovieTitle(int userId, string movieName)
        {
            var queryConfig = new DynamoDBOperationConfig{
                QueryFilter = new List<ScanCondition>
                {
                    new ScanCondition("MovieName", ScanOperator.BeginsWith, movieName)
                }
            };
        return await _context.QueryAsync<MovieDb>(userId, queryConfig).GetRemainingAsync();
        }

        public async Task AddMovie(MovieDb movie)
        {
            await _context.SaveAsync(movie);
        }

        public async Task UpdateMovie(MovieDb movie)
        {
           await _context.SaveAsync(movie);
        }
    }
}
