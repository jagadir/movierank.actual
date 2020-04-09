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
    }
}
