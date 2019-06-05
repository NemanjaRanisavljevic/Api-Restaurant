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
    public class EFEditDrinkCommand : EFBaseCommand, IEditDrinkCommand
    {
        public EFEditDrinkCommand(DBContext context) : base(context)
        {
        }

        public void Execute(CreateDrinkDTO request)
        {
            var drink = _context.Drinks.Find(request.Id);

            if(drink == null)
            {
                throw new NotFoundException();
            }

            if(_context.Drinks.Any(d => d.DrinkName == request.DrinkName))
            {
                throw new AlredyExistException();
            }

            if(request.Price <= 0)
            {
                throw new DataCanNotBeNull();
            }

            drink.DrinkName = request.DrinkName;
            drink.Price = request.Price;

            _context.SaveChanges();
        }
    }
}
