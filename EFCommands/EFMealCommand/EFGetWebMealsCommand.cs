using Application.Commands.MealCommand;
using Application.DTO.MealDTO;
using Application.Searches;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands.EFMealCommand
{
    public class EFGetWebMealsCommand : EFBaseCommand, IGetWebMealsCommand
    {
        public EFGetWebMealsCommand(DBContext context) : base(context)
        {
        }

        public IEnumerable<MealGetDTO> Execute(ClassForNullObj request)
        {
            var obj = _context.Meals.AsQueryable();

            return obj.Select(m => new MealGetDTO {
                Id = m.Id,
                 Name = m.Name
            });
        }
    }
}
