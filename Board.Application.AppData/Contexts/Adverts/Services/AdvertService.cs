using AutoMapper;
using Board.Application.AppData.Contexts.Adverts.Repositories;
using Board.Contracts.Advert;
using Board.Domain;
using Microsoft.AspNetCore.Http;

namespace Board.Application.AppData.Contexts.Adverts.Services
{
    /// <inheritdoc />
    public class AdvertService : IAdvertService
    {
        private readonly IAdvertRepository _advertRepository;
        private readonly IMapper _mapper;

        public AdvertService(IAdvertRepository advertRepository, IMapper mapper)
        {
            _advertRepository = advertRepository;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public Task<AdvertShortInfoDto[]> GetAll(CancellationToken cancellationToken)
        {
            return _advertRepository.GetAll(cancellationToken);
        }

        /// <inheritdoc />
        public Task<AdvertInfoDto> Get(Guid id, CancellationToken cancellationToken)
        {
            return _advertRepository.Get(id, cancellationToken);
        }

        /// <inheritdoc />
        public Task<AdvertInfoDto> Add(CreateAdvertDto dto, CancellationToken cancellationToken)
        {
            Advert entity = _mapper.Map<Advert>(dto);
            return _advertRepository.Add(entity, cancellationToken);
        }

        public async Task UpdateAdvt(Guid id, UpdateAdvertDto model, HttpRequest Request, CancellationToken cancellation)
        {
            model.CreateAdvertDto.Id = id;
            var advert = _mapper.Map<Advert>(model.CreateAdvertDto);
            await _advertRepository.UpdateAdvtEntity(advert, cancellation);
        }

        /// <inheritdoc />
        public async Task Delete(Guid id, CancellationToken cancellationToken)
        {
            await _advertRepository.Delete(id, cancellationToken);
        }
    }
}
