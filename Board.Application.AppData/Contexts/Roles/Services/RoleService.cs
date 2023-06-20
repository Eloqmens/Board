using AutoMapper;
using Board.Application.AppData.Contexts.Roles.Repositories;
using Board.Contracts.Roles;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Board.Application.AppData.Contexts.Roles.Services
{
    public class RoleService : IRoleService
    {
        private readonly ILogger<RoleService> _logger;
        private readonly IRoleRepository _repository;
        private readonly IMapper _mapper;

        public RoleService(ILogger<RoleService> logger, IRoleRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Создание роли
        /// </summary>
        /// <param name="name"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        public async Task<Guid> CreateRoleAsync(string name, CancellationToken cancellation)
        {
            var newRole = new Domain.Role { RoleName = name, Id = Guid.NewGuid() };

            await _repository.AddAsync(newRole, cancellation);

            return newRole.Id;
        }

        /// <summary>
        /// Удаление роли
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task DeleteAsync(Guid id, CancellationToken cancellation)
        {
            var existingRole = await _repository.FindById(id, cancellation);

            if (existingRole == null)
                throw new Exception("Роли под данным Id не существует");

            await _repository.DeleteAsync(existingRole, cancellation);
        }

        /// <summary>
        /// Получение всех ролей
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        public async Task<IReadOnlyCollection<InfoRoleDto>> GetAll(int take, int skip)
        {
            return await _repository.GetAll()
                .Select(r => new InfoRoleDto
                {
                    RoleId = r.Id,
                    RoleName = r.RoleName
                }).Take(take).Skip(skip)
                .OrderBy(x => x.RoleId)
                .ToListAsync();
        }

        /// <summary>
        /// Получение роли по ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        public async Task<InfoRoleDto> GetByIdAsync(Guid id, CancellationToken cancellation)
        {
            return _mapper.Map<InfoRoleDto>(await _repository.FindById(id, cancellation));
        }
    }
}
