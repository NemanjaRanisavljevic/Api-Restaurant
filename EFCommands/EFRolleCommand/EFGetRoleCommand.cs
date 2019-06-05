using Application.Commands.RoleCommand;
using Application.DTO;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands.EFRolleCommand
{
    public class EFGetRoleCommand : EFBaseCommand, IGetRoleCommand
    {
        public EFGetRoleCommand(DBContext context) : base(context)
        {
        }

        public IEnumerable<RoleDTO> Execute(int request)
        {
            var query = _context.Roles.AsQueryable();

            if(_context.Roles.Any(r => r.Id == request))
            {
                query = query.Where(r => r.Id == request);
            }else
            {
                throw new NotFoundException();
            }

            return query.Select(r => new RoleDTO {
                Id = r.Id,
                RoleName = r.NameRole,
                IsDelete = r.IsDeleted
            });
        }
    }
}
