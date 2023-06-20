using AutoMapper;
using AutoMapper.QueryableExtensions;
using Board.Application.AppData.Contexts.Categories.Repositories;
using Board.Contracts.Category;
using Board.Infastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Board.Infrastucture.DataAccess.Contexts.Categories
{
    /// <inheritdoc cref="ICategoryRepository"/
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IRepository<Domain.Category> _repository;
        private readonly IMapper _mapper;

        public CategoryRepository(IRepository<Domain.Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<Guid> AddAsync(Domain.Category model, CancellationToken cancellationToken)
        {
            model.Created = DateTime.UtcNow;
            await _repository.AddAsync(model, cancellationToken);
            return model.Id;
        }

        /// <inheritdoc/>
        public Task<CategoryInfoDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return _repository.GetAll().Where(s => s.Id == id)
                              .ProjectTo<CategoryInfoDto>(_mapper.ConfigurationProvider)
                              .FirstOrDefaultAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public Task<CategoryInfoDto[]> GetActiveAsync(CancellationToken cancellationToken)
        {
            return _repository.GetAll().AsNoTracking()
                .Where(x => x.IsActive)
                .ProjectTo<CategoryInfoDto>(_mapper.ConfigurationProvider)
                .ToArrayAsync(cancellationToken);
        }
    }
}
