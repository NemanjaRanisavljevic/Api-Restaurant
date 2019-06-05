using Application.Commands.DrinkCommand;
using Application.DTO.CreateDTO;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands.EFDrinkCommand
{
    public class EFGetDrinkCommand : EFBaseCommand,IGetDrinkCommand
    {
        public EFGetDrinkCommand(DBContext context) : base(context)
        {
        }

        public IEnumerable<CreateDrinkDTO> Execute(int id)
        {
            var query = _context.Drinks.AsQueryable();

            if(_context.Drinks.Any(d => d.Id == id))
            {
                query = query.Where(d => d.Id == id);
            }
            else
            {
                throw new NotFoundException();
            }

            return query.Select(d => new CreateDrinkDTO
            {
                Id = d.Id,
                DrinkName = d.DrinkName,
                Price = d.Price
            });

            
            



        }
    }
}
