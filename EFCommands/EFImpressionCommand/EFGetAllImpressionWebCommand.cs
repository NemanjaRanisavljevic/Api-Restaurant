using Application.Commands.ImpressionCommand;
using Application.DTO;
using Application.Searches;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands.EFImpressionCommand
{
    public class EFGetAllImpressionWebCommand : EFBaseCommand, IGetAllImpressionWebCommand
    {
        public EFGetAllImpressionWebCommand(DBContext context) : base(context)
        {
        }

        public IEnumerable<ImpressionDTO> Execute(ImpressionSearchWeb request)
        {
            var query = _context.Impressions.AsQueryable();

            if (request.Content != null)
            {
                var content = request.Content.ToLower();

                query = query.Where(i => i.Content.ToLower().Contains(content));
            }

            return query.Select(i => new ImpressionDTO
            {
                Id = i.Id,
                Content = i.Content,
                UserId = i.UserId,
                NameSurname = i.User.Name + " " + i.User.Surname
            });

        }
    }
}
