using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands.DrinkCommand;
using Application.DTO.CreateDTO;
using Application.Searches;
using EFDataAccess;

namespace EFCommands.EFDrinkCommand
{
    public class EFGetDrinksCommand : EFBaseCommand, IGetDrinksCommand
    {
        public EFGetDrinksCommand(DBContext context) : base(context)
        {
        }

        public IEnumerable<CreateDrinkDTO> Execute(DrinkSearch request)
        {
            var query = _context.Drinks.AsQueryable();

            if(request.DrinkName != null)
            {
                var drinName = request.DrinkName.ToLower();

                query = query.Where(d => d.DrinkName.ToLower().Contains(drinName));

            }

            if(request.MaxPrice.HasValue)
            {
                query = query.Where(d => d.Price >= request.MaxPrice);
            }

            if(request.MinPrice.HasValue)
            {
                query = query.Where(d => d.Price <= request.MinPrice);
            }

            return query
                .Select(d => new CreateDrinkDTO {
                Id = d.Id,
                DrinkName = d.DrinkName,
                Price = d.Price
            });
        }
    }
}
