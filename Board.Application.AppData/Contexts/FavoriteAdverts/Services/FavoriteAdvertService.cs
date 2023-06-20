using AutoMapper;
using Board.Application.AppData.Contexts.FavoriteAdverts.Repositories;
using Board.Contracts.FavoriteAdvert;
using Board.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board.Application.AppData.Contexts.FavoriteAdverts.Services
{
    public class FavoriteAdvertService : IFavoriteAdvertService
    {
        private readonly IFavoriteAdvertRepository _favoriteAdvertRepository;
        private readonly IMapper _mapper;

        public FavoriteAdvertService(IFavoriteAdvertRepository favoriteAdvertRepository, IMapper mapper)
        {
            _favoriteAdvertRepository = favoriteAdvertRepository;
            _mapper = mapper;
        }

        public Task<FavoriteAdvertInfoDto> Add(CreateFavoriteAdvertDto dto, CancellationToken cancellationToken)
        {
            FavoriteAdvert entity = _mapper.Map<FavoriteAdvert>(dto);
            return _favoriteAdvertRepository.Add(entity, cancellationToken);

        }

        public async Task Delete(Guid id, CancellationToken cancellationToken)
        {
            await _favoriteAdvertRepository.Delete(id, cancellationToken);
        }

        public Task<FavoriteAdvertInfoDto> Get(Guid id, CancellationToken cancellationToken)
        {
            return _favoriteAdvertRepository.Get(id, cancellationToken);
        }

        public Task<FavoriteAdvertShortInfoDto[]> GetAll(CancellationToken cancellationToken)
        {
            return _favoriteAdvertRepository.GetAll(cancellationToken);
        }
    }
}
