using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands.DrinkCommand;
using Application.DTO.CreateDTO;
using Application.Responsed;
using Application.Searches;
using EFDataAccess;

namespace EFCommands.EFDrinkCommand
{
    public class EFGetDrinksCommand : EFBaseCommand, IGetDrinksCommand
    {
        public EFGetDrinksCommand(DBContext context) : base(context)
        {
        }

        public PagedRespone<CreateDrinkDTO> Execute(DrinkSearch request)
        {
            var query = _context.Drinks.AsQueryable();

            if (request.DrinkName != null)
            {
                var drinName = request.DrinkName.ToLower();

                query = query.Where(d => d.DrinkName.ToLower().Contains(drinName));

            }

            if (request.MaxPrice.HasValue)
            {
                query = query.Where(d => d.Price >= request.MaxPrice);
            }

            if (request.MinPrice.HasValue)
            {
                query = query.Where(d => d.Price <= request.MinPrice);
            }
            if (request.Id.HasValue)
            {
                query = query.Where(d => d.Id == request.Id);
            }

            var TotalCount = query.Count();

            query = query
                .Skip((request.PageNumber - 1) * request.PerPage)
                .Take(request.PerPage);
              
            var pageCount = (int)Math.Ceiling((double)TotalCount / request.PerPage);

            var response = new PagedRespone<CreateDrinkDTO>
            {
                CurrentPage = request.PageNumber,
                TotalCount = TotalCount,
                PageCount = pageCount,
                Data = query
                .Select(d => new CreateDrinkDTO
                {
                    Id = d.Id,
                    DrinkName = d.DrinkName,
                    Price = d.Price
                })
        };

            return response;
        }
    }
}
