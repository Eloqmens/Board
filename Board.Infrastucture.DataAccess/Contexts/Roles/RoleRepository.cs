using Board.Application.AppData.Contexts.Roles.Repositories;
using Board.Infastructure.Repository;

namespace Board.Infrastucture.DataAccess.Contexts.Roles
{
    public class RoleRepository : IRoleRepository
    {
        public readonly IRepository<Domain.Role> _baseRepository;

        public RoleRepository(IRepository<Domain.Role> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public Task AddAsync(Domain.Role model, CancellationToken cancellation)
        {
            return _baseRepository.AddAsync(model, cancellation);
        }

        public async Task DeleteAsync(Domain.Role model, CancellationToken cancellation)
        {
            await _baseRepository.DeleteAsync(model, cancellation);
        }

        public async Task EditRoleAsync(Domain.Role edit, CancellationToken cancellation)
        {
            await _baseRepository.UpdateAsync(edit, cancellation);
        }

        public async Task<Domain.Role> FindById(Guid id, CancellationToken cancellation)
        {
            return await _baseRepository.GetByIdAsync(id, cancellation);
        }

        public IQueryable<Domain.Role> GetAll()
        {
            return _baseRepository.GetAll();
        }
    }
}
