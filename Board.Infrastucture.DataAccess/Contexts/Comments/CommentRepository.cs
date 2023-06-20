using AutoMapper;
using AutoMapper.QueryableExtensions;
using Board.Application.AppData.Contexts.Comments.Repositories;
using Board.Contracts.Comment;
using Board.Domain;
using Board.Infastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Board.Infrastucture.DataAccess.Contexts.Comments
{
    /// <inheritdoc cref="ICommentRepository"/>
    public class CommentRepository : ICommentRepository
    {
        private readonly IRepository<Comment> _repository;
        private readonly IMapper _mapper;

        public CommentRepository(IRepository<Comment> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CommentInfoDto> Add(Comment entity, CancellationToken cancellation)
        {
            await _repository.AddAsync(entity, cancellation);
            return _mapper.Map<CommentInfoDto>(entity);
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

        public Task<CommentInfoDto> Get(Guid id, CancellationToken cancellationToken)
        {
            return _repository.GetAll()
                .ProjectTo<CommentInfoDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public Task<CommentShortInfo[]> GetAll(CancellationToken cancellationToken)
        {
            return _repository.GetAll()
                .ProjectTo<CommentShortInfo>(_mapper.ConfigurationProvider)
                .ToArrayAsync(cancellationToken);
        }
    }
}
