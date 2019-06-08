using Application.Commands.UserCommand;
using Application.DTO;
using Application.Exceptions;
using Domain;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands.EFUserCommand
{
    public class EFAddUserCommand : EFBaseCommand, IAddUserCommand
    {
        public EFAddUserCommand(DBContext context) : base(context)
        {
        }

        public void Execute(UserDTO request)
        {
            if(_context.Users.Any(u => u.Email == request.Email))
            {
                throw new AlredyExistException();
            }

            if (_context.Roles.Any(r => r.Id == request.RoleId))
            {
                
            }else
            {
                throw new NotFoundException();
            }

            _context.Users.Add(new User {
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                Password = request.Password,
                RoleId = request.RoleId
            });

            _context.SaveChanges();
        }
    }
}
