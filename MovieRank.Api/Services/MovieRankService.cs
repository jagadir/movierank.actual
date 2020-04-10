using MovieRank.Contracts;
using MovieRank.Libs.Mappers;
using MovieRank.Libs.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRank.Api.Services
{
    public class MovieRankService : IMovieRankService
    {
        private readonly IMovieRankRepository _repository;
        private readonly IMapper _mapper;
        public MovieRankService(IMovieRankRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<MovieResponse>> GetAllItemsFromDatabase()
        {
          var items =  await _repository.GetAllItems();
          
          return items.Select(_mapper.ToMovieContract);
        }

        public async Task<MovieResponse> GetMovie(int userId, string movieName)
        {
            var result =await _repository.GetMovie(userId, movieName);
            return _mapper.ToMovieContract(result);
        }

        public async Task<IEnumerable<MovieResponse>> GetUsersRankedMoviesByMovieTitle(int userId, string movieName)
        {
            var items = await _repository.GetUsersRankedMoviesByMovieTitle(userId, movieName);
            return _mapper.ToMovieContracts(items);
        }

        public async Task AddMovie(int userId, MovieRankRequest movieRankRequest)
        {
            var movieDb = _mapper.ToMovieDbModel(userId, movieRankRequest);
            await _repository.AddMovie(movieDb);
        }

        public async Task UpdateMovie(int userId, MovieUpdateRequest updateRequest)
        {
            var movieDb = await _repository.GetMovie(userId, updateRequest.MovieName);
            if(movieDb != null)
            {
                var movieToBeUpdated= _mapper.ToMovieDbModel(userId, movieDb, updateRequest);
               await _repository.UpdateMovie(movieToBeUpdated);  
            }
        }

        public async Task<MovieRankResponse> GetMovieRank(string movieName)
        {
            var result =await _repository.GetMovieRanks(movieName);
            var overallMovieRanking = Math.Round(result.Select(m=> m.Ranking).Average());
            return _mapper.ToMovieRankResponse(movieName, overallMovieRanking);
        }
    }
}
