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
    public class EFEditRoleCommand : EFBaseCommand, IEditRoleCommand
    {
        public EFEditRoleCommand(DBContext context) : base(context)
        {
        }

        public void Execute(RoleDTO request)
        {
            var searchRole = _context.Roles.Find(request.Id);

            if(searchRole == null)
            {
                throw new NotFoundException();
            }

            if(_context.Roles.Any(r => r.NameRole == request.RoleName))
            {
                throw new AlredyExistException();
            }

            if(searchRole.NameRole == request.RoleName)
            {
                throw new AlredyExistException();
            }

            if(searchRole.IsDeleted == request.IsDelete)
            {
                throw new AlredyExistException();
            }

            searchRole.NameRole = request.RoleName;
            searchRole.IsDeleted = request.IsDelete;

            _context.SaveChanges();
        }
    }
}
