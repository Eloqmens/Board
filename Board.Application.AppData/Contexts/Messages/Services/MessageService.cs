using AutoMapper;
using Board.Application.AppData.Contexts.Messages.Repositories;
using Board.Contracts.Message;
using Board.Domain;

namespace Board.Application.AppData.Contexts.Messages.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _commentRepository;
        private readonly IMapper _mapper;

        public MessageService(IMessageRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public Task<MessageInfoDto> Add(CreateMessageDto dto, CancellationToken cancellationToken)
        {
            Message entity = _mapper.Map<Message>(dto);
            return _commentRepository.Add(entity, cancellationToken);

        }

        public async Task Delete(Guid id, CancellationToken cancellationToken)
        {
            await _commentRepository.Delete(id, cancellationToken);
        }

        public Task<MessageInfoDto> Get(Guid id, CancellationToken cancellationToken)
        {
            return _commentRepository.Get(id, cancellationToken);
        }

        public Task<MessageShortInfoDto[]> GetAll(CancellationToken cancellationToken)
        {
            return _commentRepository.GetAll(cancellationToken);
        }
    }
}
