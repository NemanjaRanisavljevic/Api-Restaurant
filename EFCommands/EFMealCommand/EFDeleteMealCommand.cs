using Application.Commands.MealCommand;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCommands.EFMealCommand
{
    public class EFDeleteMealCommand : EFBaseCommand, IDeleteMealCommand
    {
        public EFDeleteMealCommand(DBContext context) : base(context)
        {
        }

        public void Execute(int id)
        {
            var meal = _context.Meals.Find(id);

            if(meal == null)
            {
                throw new NotFoundException();
            }

            meal.IsDeleted = true;
            _context.SaveChanges();
        }
    }
}
