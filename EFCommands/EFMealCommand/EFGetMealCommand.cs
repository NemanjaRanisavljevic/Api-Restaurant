using Application.Commands.MealCommand;
using Application.DTO.MealDTO;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands.EFMealCommand
{
    public class EFGetMealCommand : EFBaseCommand, IGetMealCommand
    {
        public EFGetMealCommand(DBContext context) : base(context)
        {
        }

        public IEnumerable<MealGetDTO> Execute(int id)
        {
            var query = _context.Meals.AsQueryable();

            if (_context.Meals.Any(m => m.Id == id && m.IsDeleted == false))
            {
                query = query.Where(m => m.Id == id);
            }
            else
            {
                throw new NotFoundException();
            }

            return query.Select(m => new MealGetDTO {
                Id = m.Id,
                Name = m.Name,
                Start = m.Start + " h",
                Finish = m.Finish + " h",
                IsDeleted = m.IsDeleted
            });
        }
    }
}
