using Application.Commands.RoleCommand;
using Application.DTO;
using Application.Searches;
using EFDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands.EFRolleCommand
{
    public class EFGetRolesCommand : EFBaseCommand, IGetRolesCommand
    {
        public EFGetRolesCommand(DBContext context) : base(context)
        {
        }

        public IEnumerable<RoleDTO> Execute(RuleSearch request)
        {
            var query = _context.Roles.AsQueryable();

            if(request.RoleName != null)
            {
                var name = request.RoleName.ToLower();
                query = query.Where(r => r.NameRole.ToLower()
                .Contains(name) && r.IsDeleted == false);
            }

            if (request.Keyword != null)
            {
                var name = request.Keyword.ToLower();
                query = query.Where(r => r.NameRole.ToLower()
                .Contains(name) && r.IsDeleted == false);
            }

            if(request.IsDeleted.HasValue)
            {
                query = query.Where(r => r.IsDeleted == request.IsDeleted);
            }

            if(request.Id.HasValue)
            {
                query = query.Where(r => r.Id == request.Id && r.IsDeleted == false);
            }

            return query
                .Select(r => new RoleDTO {
                    Id = r.Id,
                    RoleName = r.NameRole,
                    IsDelete = r.IsDeleted
            });
        }
    }
}
