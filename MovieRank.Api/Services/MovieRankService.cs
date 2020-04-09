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
    }
}
