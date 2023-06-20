using AutoMapper;
using Board.Application.AppData.Contexts.Comments.Repositories;
using Board.Contracts.Comment;
using Board.Domain;

namespace Board.Application.AppData.Contexts.Comments.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public Task<CommentInfoDto> Add(CreateCommentDto dto, CancellationToken cancellationToken)
        {
            Comment entity = _mapper.Map<Comment>(dto);
            return _commentRepository.Add(entity, cancellationToken);
            
        }

        public async Task Delete(Guid id, CancellationToken cancellationToken)
        {
            await _commentRepository.Delete(id, cancellationToken);
        }

        public Task<CommentInfoDto> Get(Guid id, CancellationToken cancellationToken)
        {
            return _commentRepository.Get(id, cancellationToken);
        }

        public Task<CommentShortInfo[]> GetAll(CancellationToken cancellationToken)
        {
             return _commentRepository.GetAll(cancellationToken);
        }
    }
}
