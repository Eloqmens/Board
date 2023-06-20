using AutoMapper;
using AutoMapper.QueryableExtensions;
using Board.Application.AppData.Contexts.FavoriteAdverts.Repositories;
using Board.Contracts.FavoriteAdvert;
using Board.Domain;
using Board.Infastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Board.Infrastucture.DataAccess.Contexts.FavoriteAdverts
{
    public class FavoriteAdvertRepository : IFavoriteAdvertRepository
    {
        private readonly IRepository<FavoriteAdvert> _repository;
        private readonly IMapper _mapper;

        public FavoriteAdvertRepository(IRepository<FavoriteAdvert> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<FavoriteAdvertInfoDto> Add(FavoriteAdvert entity, CancellationToken cancellation)
        {
            await _repository.AddAsync(entity, cancellation);
            return _mapper.Map<FavoriteAdvertInfoDto>(entity);
        }

        public async Task Delete(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetAll().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            if (entity == null)
            {
                return;
            }

            await _repository.DeleteAsync(entity, cancellationToken);
        }

        public Task<FavoriteAdvertInfoDto> Get(Guid id, CancellationToken cancellationToken)
        {
            return _repository.GetAll()
                .ProjectTo<FavoriteAdvertInfoDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public Task<FavoriteAdvertShortInfoDto[]> GetAll(CancellationToken cancellationToken)
        {
            return _repository.GetAll()
                .ProjectTo<FavoriteAdvertShortInfoDto>(_mapper.ConfigurationProvider)
                .ToArrayAsync(cancellationToken);
        }
    }
}
