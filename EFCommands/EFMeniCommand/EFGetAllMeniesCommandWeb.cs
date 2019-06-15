using Application.Commands.MeniCommand;
using Application.DTO.MeniDTO;
using Application.Searches;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands.EFMeniCommand
{
    public class EFGetAllMeniesCommandWeb : EFBaseCommand, IGetAllMeniesCommandWeb
    {
        public EFGetAllMeniesCommandWeb(DBContext context) : base(context)
        {
        }

        public IEnumerable<MeniGetDTO> Execute(MeniSearchWeb request)
        {
            var query = _context.Menis.AsQueryable();

            if (request.NameFood != null)
            {
                var name = request.NameFood.ToLower();

                query = query.Where(m => m.NameFood.ToLower()
                .Contains(name)
                && m.IsDeleted == false);
                
            }

            return query.Select(m => new MeniGetDTO
            {
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
