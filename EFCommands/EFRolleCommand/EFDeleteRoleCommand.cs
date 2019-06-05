using Application.Commands.RoleCommand;
using Application.DTO;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCommands.EFRolleCommand
{
    public class EFDeleteRoleCommand : EFBaseCommand, IDeleteRoleCommand
    {
        public EFDeleteRoleCommand(DBContext context) : base(context)
        {
        }

        public void Execute(int id)
        {
            var role = _context.Roles.Find(id);

            if(role == null)
            {
                throw new NotFoundException();
            }

            if(role.IsDeleted == true)
            {
                throw new AlredyExistException();
            }

            role.IsDeleted = true;

            _context.SaveChanges();
        }
    }
}
