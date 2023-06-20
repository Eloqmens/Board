using AutoMapper;
using Board.Application.AppData.Contexts.ImageAdverts.Repositories;
using Board.Contracts.ImageAdvert;

namespace Board.Application.AppData.Contexts.ImageAdverts.Services
{
    public class ImageAdvertService : IImageAdvertService
    {
        private readonly IImageAdvertRepository _imageAdvertRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Инициализация экземпляра <see cref="ImageAdvertService"/>.
        /// </summary>        
        public ImageAdvertService(IImageAdvertRepository imageAdvertRepository, IMapper mapper)
        {
            _imageAdvertRepository = imageAdvertRepository;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            return _imageAdvertRepository.DeleteAsync(id, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ImageAdvertDto> DownloadAsync(Guid id, Guid AdvertId, CancellationToken cancellationToken)
        {
            return _imageAdvertRepository.DownloadAsync(id, AdvertId, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<ImageAdvertInfoDto> GetInfoByIdAsync(Guid id, Guid AdvertId, CancellationToken cancellationToken)
        {
            return _imageAdvertRepository.GetInfoByIdAsync(id, AdvertId, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<Guid> UploadAsync(ImageAdvertDto model, Guid AdvertId, CancellationToken cancellationToken)
        {
            var imageAdvert = _mapper.Map<ImageAdvertDto, Domain.ImageAdvert>(model);
            return _imageAdvertRepository.UploadAsync(imageAdvert, cancellationToken);
        }
    }
}
