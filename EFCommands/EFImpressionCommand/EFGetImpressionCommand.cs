using Application.Commands.ImpressionCommand;
using Application.DTO;
using Application.Exceptions;
using EFDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands.EFImpressionCommand
{
    public class EFGetImpressionCommand : EFBaseCommand, IGetImpressionCommand
    {
        public EFGetImpressionCommand(DBContext context) : base(context)
        {
        }

        public IEnumerable<ImpressionDTO> Execute(int id)
        {
            var query = _context.Impressions.AsQueryable();

            if(_context.Impressions.Any(i => i.Id == id))
            {
                query = query.Where(i => i.Id == id);
            }else
            {
                throw new NotFoundException();
            }


            return query.Include(u => u.User)
                .Select(i => new ImpressionDTO {
                    Id = i.Id,
                    Content = i.Content,
                    UserId = i.UserId,
                    NameSurname = i.User.Name + " " + i.User.Surname
                });

        }
    }
}
