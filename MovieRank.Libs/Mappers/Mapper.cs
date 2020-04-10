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
                UserId = item.UserId,
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

         public MovieDb ToMovieDbModel(int userId, MovieDb movie, MovieUpdateRequest movieUpdateRequest)
        {
           return new MovieDb {
               UserId = userId,
               MovieName = movie.MovieName,
               Description = movie.Description,
               Actors = movie.Actors,
               Ranking = movieUpdateRequest.Ranking,
               RankedDateTime = DateTime.UtcNow.ToString()
           };
        }

        public MovieRankResponse ToMovieRankResponse(string movieName, double overallRanking)
        {
            return new MovieRankResponse{
                MovieName = movieName,
                OverallRanking = overallRanking
            };
        }
    }
}
