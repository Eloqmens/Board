using AutoMapper;
using AutoMapper.QueryableExtensions;
using Board.Application.AppData.Contexts.Messages.Repositories;
using Board.Contracts.Message;
using Board.Domain;
using Board.Infastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Board.Infrastucture.DataAccess.Contexts.Messages
{
    public class MessageRepository : IMessageRepository
    {
        private readonly IRepository<Message> _repository;
        private readonly IMapper _mapper;

        public MessageRepository(IRepository<Message> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<MessageInfoDto> Add(Message entity, CancellationToken cancellation)
        {
            await _repository.AddAsync(entity, cancellation);
            return _mapper.Map<MessageInfoDto>(entity);
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

        public Task<MessageInfoDto> Get(Guid id, CancellationToken cancellationToken)
        {
            return _repository.GetAll()
                .ProjectTo<MessageInfoDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public Task<MessageShortInfoDto[]> GetAll(CancellationToken cancellationToken)
        {
            return _repository.GetAll()
                .ProjectTo<MessageShortInfoDto>(_mapper.ConfigurationProvider)
                .ToArrayAsync(cancellationToken);
        }
    }
}
