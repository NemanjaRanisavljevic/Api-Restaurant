using Application.Commands.UserCommand;
using Application.DTO;
using Application.Helpers;
using EFDataAccess;
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

        public IEnumerable<LoggedUser> Execute(UserAuthDTO request)
        {
            var query = _context.Users.AsQueryable();

            query = query.Where(u => u.Email == request.Email && u.Password == request.Password);

            return query.Select(u => new LoggedUser
            {
                Id = u.Id,
                Email = u.Email,
                Name = u.Name,
                Surname = u.Surname,
                RoleName = u.Role.NameRole

            });
        }
    }
}
