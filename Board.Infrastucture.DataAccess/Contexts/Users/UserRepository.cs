using AutoMapper;
using Board.Application.AppData.Contexts.Users.Repositories;
using Board.Infastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Board.Infrastucture.DataAccess.Contexts.Users
{
    /// <inheritdoc cref="IUserRepository"/>
    public class UserRepository : IUserRepository
    {
        private readonly IRepository<Domain.User> _repository;
        private readonly IMapper _mapper;

        public UserRepository(IRepository<Domain.User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<Guid> AddAsync(Domain.User model, CancellationToken cancellation)
        {
            await _repository.AddAsync(model, cancellation);
            return model.Id;
        }

        /// <inheritdoc/>
        public Task<Domain.User> FindById(Guid id, CancellationToken cancellation)
        {
            return _repository.GetByIdAsync(id, cancellation);
        }

        /// <inheritdoc/>
        public async Task<Domain.User> FindWhere(Expression<Func<Domain.User, bool>> predicate, CancellationToken cancellation)
        {
            var data = _repository.GetAllFiltered(predicate);

            Domain.User user = await data.Where(predicate).FirstOrDefaultAsync(cancellation);

            return user;
        }
    }
}
