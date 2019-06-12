using Application.Commands.UserCommand;
using Application.DTO;
using Application.Responsed;
using Application.Searches;
using EFDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands.EFUserCommand
{
    public class EFGetUsersCommand : EFBaseCommand, IGetUsersCommand
    {
        public EFGetUsersCommand(DBContext context) : base(context)
        {
        }

        public PagedRespone<UserOnlySearchDTO> Execute(UserSearch request)
        {
            var query = _context.Users.AsQueryable();

            if (request.Name != null)
            {
                var name = request.Name.ToLower();
                query = query.Where(u => u.Name.ToLower()
                .Contains(name)
                && u.IsDeleted == false);
            }

            if (request.SurName != null)
            {
                var name = request.SurName.ToLower();
                query = query.Where(u => u.Surname.ToLower()
                .Contains(name)
                && u.IsDeleted == false);
            }

            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage)
                .Take(request.PerPage);

            var pageCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            var response = new PagedRespone<UserOnlySearchDTO>
            {

                CurrentPage = request.PageNumber,
                TotalCount = totalCount,
                PageCount = pageCount,
                Data = query.Include(r => r.Role)
                .Select(u => new UserOnlySearchDTO
                {
                    Id = u.Id,
                    Name = u.Name,
                    Surname = u.Surname,
                    Email = u.Email,
                    RoleName = u.Role.NameRole,
                    IsDelete = u.IsDeleted
                })

            };
            return response;
        }
    }
}
