using Application.Commands.UserCommand;
using Application.DTO;
using Application.Exceptions;
using Application.Helpers;
using EFDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands.EFUserCommand
{
    public class EFAuthUserCommand : EFBaseCommand, IAuthUserCommand
    {
        public EFAuthUserCommand(DBContext context) : base(context)
        {
        }

        public LoggedUser Execute(UserAuthDTO request)
        {
            var user = _context.Users
                 .Include(u => u.Role)
                 .Where(u => u.Email == request.Email)
                 .Where(u => u.Password == request.Password)
                 .FirstOrDefault();

            if(user == null)
            {
                throw new NotFoundException();
            }
            return new LoggedUser
            {
                Id = user.Id,
                 Name = user.Name,
                  Surname = user.Surname,
                   Email = user.Email,
                    RoleName = user.Role.NameRole
            };
        }
    }
}
