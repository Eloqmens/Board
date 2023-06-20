using AutoMapper;
using AutoMapper.QueryableExtensions;
using Board.Application.AppData.Contexts.ImageAdverts.Repositories;
using Board.Contracts.ImageAdvert;
using Board.Infastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Board.Infrastucture.DataAccess.Contexts.ImageAdverts
{
    public class ImageAdvertRepository : IImageAdvertRepository
    {
        private readonly IRepository<Domain.ImageAdvert> _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Инициализация экземпляра <see cref="ImageAdvertRepository"/>.
        /// </summary>
        public ImageAdvertRepository(IRepository<Domain.ImageAdvert> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var file = await _repository.GetByIdAsync(id, cancellationToken);
            if (file == null)
            {
                return;
            }

            await _repository.DeleteAsync(file, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ImageAdvertDto> DownloadAsync(Guid id, Guid AdvertId, CancellationToken cancellationToken)
        {
            return _repository.GetAll().Where(x => x.Id == id)
                              .ProjectTo<ImageAdvertDto>(_mapper.ConfigurationProvider)
                              .FirstOrDefaultAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ImageAdvertInfoDto> GetInfoByIdAsync(Guid id, Guid AdvertId, CancellationToken cancellationToken)
        {
            return _repository.GetAll().Where(x => x.Id == id)
                              .ProjectTo<ImageAdvertInfoDto>(_mapper.ConfigurationProvider)
                              .FirstOrDefaultAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<Guid> UploadAsync(Domain.ImageAdvert model, CancellationToken cancellationToken)
        {
            await _repository.AddAsync(model, cancellationToken);
            return model.Id;
        }
    }
}
