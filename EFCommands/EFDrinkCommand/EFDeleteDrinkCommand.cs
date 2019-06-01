using Application.Commands.DrinkCommand;
using Application.Exceptions;
using Application.Interfaces;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCommands.EFDrinkCommand
{
    public class EFDeleteDrinkCommand : EFBaseCommand, IDeleteDrinkCommand
    {
        public EFDeleteDrinkCommand(DBContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var drink = _context.Drinks.Find(request);

            if(drink == null)
            {
                throw new NotFoundException();
            }

            _context.Drinks.Remove(drink);

            _context.SaveChanges();

        }
    }
}
