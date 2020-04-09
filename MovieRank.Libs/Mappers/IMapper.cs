using System;
using System.Collections.Generic;
using System.Text;
using MovieRank.Contracts;
using MovieRank.Libs.Models;

namespace MovieRank.Libs.Mappers
{
    public interface IMapper
    {
        IEnumerable<MovieResponse> ToMovieContracts(IEnumerable<MovieDb> items);
        MovieResponse ToMovieContract(MovieDb item);
        MovieDb ToMovieDbModel(int userId, MovieRankRequest movieRankRequest);
    }
}
