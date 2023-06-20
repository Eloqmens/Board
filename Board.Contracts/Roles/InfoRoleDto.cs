using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board.Contracts.Roles
{
    /// <summary>
    /// Роль
    /// </summary>
    public class InfoRoleDto
    {
        /// <summary>
        /// Индификатор Роли
        /// </summary>
        public Guid RoleId { get; set; }

        /// <summary>
        /// Имя роли
        /// </summary>
        public string RoleName { get; set; }
    }
}
