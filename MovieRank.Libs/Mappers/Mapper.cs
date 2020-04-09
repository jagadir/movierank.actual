using System;
using System.Collections.Generic;
using System.Linq;
using MovieRank.Contracts;
using MovieRank.Libs.Models;

namespace MovieRank.Libs.Mappers
{
    public class Mapper: IMapper
    {
        public IEnumerable<MovieResponse> ToMovieContracts(IEnumerable<MovieDb> items)
        {
            return items.Select(ToMovieContract);
        }

        public MovieResponse ToMovieContract(MovieDb item)
        {
            return new MovieResponse {
                MovieName = item.MovieName,
                Description = item.Description,
                Actors = item.Actors,
                Ranking = item.Ranking,
                TimeRanked = item.RankedDateTime
            };
        }

        public MovieDb ToMovieDbModel(int userId, MovieRankRequest movieRankRequest)
        {
           return new MovieDb {
               UserId = userId,
               MovieName = movieRankRequest.MovieName,
               Description = movieRankRequest.Description,
               Actors = movieRankRequest.Actors,
               Ranking = movieRankRequest.Ranking,
               RankedDateTime = DateTime.UtcNow.ToString()
           };
        }
    }
}
