using AutoMapper;
using AutoMapper.QueryableExtensions;
using Board.Application.AppData.Contexts.Files.Repositories;
using Board.Contracts.File;
using Board.Infastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board.Infrastucture.DataAccess.Contexts.Files
{
    /// <inheritdoc cref="IFileRepository"/>
    public class FileRepository : IFileRepository
    {
        private readonly IRepository<Domain.File> _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Инициализация экземпляра <see cref="FileRepository"/>.
        /// </summary>
        public FileRepository(IRepository<Domain.File> repository, IMapper mapper)
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
        public Task<FileDto> DownloadAsync(Guid id, CancellationToken cancellationToken)
        {
            return _repository.GetAll().Where(x => x.Id == id)
                              .ProjectTo<FileDto>(_mapper.ConfigurationProvider)
                              .FirstOrDefaultAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public Task<FileInfoDto> GetInfoByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return _repository.GetAll().Where(x => x.Id == id)
                              .ProjectTo<FileInfoDto>(_mapper.ConfigurationProvider)
                              .FirstOrDefaultAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<Guid> UploadAsync(Domain.File model, CancellationToken cancellationToken)
        {
            await _repository.AddAsync(model, cancellationToken);
            return model.Id;
        }
    }
}
