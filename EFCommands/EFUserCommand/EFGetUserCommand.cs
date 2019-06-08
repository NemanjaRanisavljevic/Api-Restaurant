using Application.Commands.UserCommand;
using Application.DTO;
using Application.Exceptions;
using EFDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands.EFUserCommand
{
    public class EFGetUserCommand : EFBaseCommand, IGetUserCommand
    {
        public EFGetUserCommand(DBContext context) : base(context)
        {
        }

        public IEnumerable<UserSearchDTO> Execute(int id)
        {
            var query = _context.Users.AsQueryable();

            if (_context.Users.Any(u => u.Id == id))
            {
                query = query.Where(u => u.Id == id);
            }else
            {
                throw new NotFoundException();
            }

            return query
                .Include(r => r.Role)
                .Select(u => new UserSearchDTO
                {
                    Id = u.Id,
                    Name = u.Name,
                    Surname = u.Surname,
                    Password = u.Password,
                    Email = u.Email,
                    RoleId = u.RoleId,
                    RoleName = u.Role.NameRole,
                    IsDelete = u.IsDeleted
                });
        }
    }
}
