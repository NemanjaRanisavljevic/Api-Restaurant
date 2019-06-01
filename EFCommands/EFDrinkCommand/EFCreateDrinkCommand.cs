using Application.Commands.DrinkCommand;
using Application.DTO.CreateDTO;
using EFDataAccess;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Application.Exceptions;
using Domain;

namespace EFCommands.EFDrinkCommand
{
    public class EFCreateDrinkCommand : EFBaseCommand, IDrinkCreateCommand
    {
        public EFCreateDrinkCommand(DBContext context) : base(context)
        {
        }

        public void Execute(CreateDrinkDTO request)
        {
            if(_context.Drinks.Any(d => d.DrinkName == request.DrinkName))
            {
                throw new AlredyExistException();
            }

            if (request.DrinkName == null)
            {
                throw new DataCanNotBeNull();
            }

            if (request.Price <= 0)
            {
                throw new DataCanNotBeNull();
            }
            
            _context.Add(new Drink
            {
                DrinkName = request.DrinkName,
                Price = request.Price
            });

            _context.SaveChanges();


        }
    }
}
