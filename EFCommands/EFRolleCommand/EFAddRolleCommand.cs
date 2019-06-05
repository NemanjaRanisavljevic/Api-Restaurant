using Application.Commands.RoleCommand;
using Application.DTO;
using Application.Exceptions;
using Domain;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands.EFRolleCommand
{
    public class EFAddRolleCommand : EFBaseCommand, IAddRolleCommand
    {
        public EFAddRolleCommand(DBContext context) : base(context)
        {
        }

        public void Execute(RoleDTO request)
        {
            if(_context.Roles.Any(r => r.NameRole == request.RoleName))
            {
                throw new AlredyExistException();
            }

            if(request.RoleName == null)
            {
                throw new DataCanNotBeNull();
            }

            _context.Add(new Role
            {
                NameRole = request.RoleName
            });

            _context.SaveChanges();
        }
    }
}
