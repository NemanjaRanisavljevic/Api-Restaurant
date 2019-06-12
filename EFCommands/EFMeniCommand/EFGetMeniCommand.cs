using Application.Commands.MeniCommand;
using Application.DTO.MeniDTO;
using Application.Exceptions;
using EFDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands.EFMeniCommand
{
    public class EFGetMeniCommand : EFBaseCommand, IGetMeniCommand
    {
        public EFGetMeniCommand(DBContext context) : base(context)
        {
        }

        public IEnumerable<MeniGetDTO> Execute(int id)
        {
            var query = _context.Menis.AsQueryable();

            if (_context.Menis.Any(m => m.Id == id))
            {
                query = query.Where(m => m.Id == id);
            }
            else
            {
                throw new NotFoundException();
            }

            return query.Select(m => new MeniGetDTO {
                Id = m.Id,
                NameFood = m.NameFood,
                Ingradiant = m.Ingrediant,
                Price = m.Price,
                FileName = m.Image.Putanja,
                Alt = m.Image.Alt,
                MealName = m.Meal.Name
            });
        }
    }
}
