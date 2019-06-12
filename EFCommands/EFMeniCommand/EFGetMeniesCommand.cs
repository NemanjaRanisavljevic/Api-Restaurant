using Application.Commands.MeniCommand;
using Application.DTO.MeniDTO;
using Application.Responsed;
using Application.Searches;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands.EFMeniCommand
{
    public class EFGetMeniesCommand : EFBaseCommand, IGetMeniesCommand
    {
        public EFGetMeniesCommand(DBContext context) : base(context)
        {
        }

        public PagedRespone<MeniGetDTO> Execute(MeniSearch request)
        {
            var query = _context.Menis.AsQueryable();

            if (request.NameFood != null)
            {
                var name = request.NameFood.ToLower();

                query = query.Where(m => m.NameFood.ToLower()
                .Contains(name)
                && m.IsDeleted == false);
            }

            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage)
                .Take(request.PerPage);

            var pageCount = (int)Math.Ceiling((double)totalCount / request.PerPage);


            var response = new PagedRespone<MeniGetDTO>
            {
                CurrentPage = request.PageNumber,
                TotalCount = totalCount,
                PageCount = pageCount,
                Data = query.Select(m => new MeniGetDTO {
                    Id = m.Id,
                    NameFood = m.NameFood,
                    Ingradiant = m.Ingrediant,
                    Price = m.Price,
                    FileName = m.Image.Putanja,
                    Alt = m.Image.Alt,
                    MealName = m.Meal.Name
                })

            };

            return response;
        }
    }
}
