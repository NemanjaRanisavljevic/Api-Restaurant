using Application.Commands.ImpressionCommand;
using Application.DTO;
using Application.Responsed;
using Application.Searches;
using EFDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands.EFImpressionCommand
{
    public class EFGetImpressionsCommand : EFBaseCommand, IGetImpressionsCommand
    {
        public EFGetImpressionsCommand(DBContext context) : base(context)
        {
        }

        public PagedRespone<ImpressionDTO> Execute(ImpressSearch request)
        {
            var query = _context.Impressions.AsQueryable();

           if(request.Content != null)
            {
                var content = request.Content.ToLower();

                query = query.Where(i => i.Content.ToLower().Contains(content));
            }

            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pageCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            var response = new PagedRespone<ImpressionDTO>
            {
                TotalCount = totalCount,
                CurrentPage = request.PageNumber,
                PageCount = pageCount,
                Data = query.Include(u => u.User)
                       .Select(i => new ImpressionDTO
                       {
                            Id = i.Id,
                            Content = i.Content,
                            UserId = i.UserId,
                            NameSurname = i.User.Name + " " + i.User.Surname
                       })
            };


            return response;

        }
    }
}
