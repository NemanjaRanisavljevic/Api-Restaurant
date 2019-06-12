using Application.Commands.MealCommand;
using Application.DTO.MealDTO;
using Application.Exceptions;
using Domain;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands.EFMealCommand
{
    public class EFAddMealCommand : EFBaseCommand, IAddMealCommand
    {
        public EFAddMealCommand(DBContext context) : base(context)
        {
        }

        public void Execute(MealCreateDTO request)
        {
            if(_context.Meals.Any(m => m.Name == request.Name))
            {
                throw new AlredyExistException();
            }

            _context.Meals.Add(new Meal {
                Name = request.Name,
                Start = request.Start,
                Finish = request.Finish
            });

            _context.SaveChanges();
        }
    }
}
