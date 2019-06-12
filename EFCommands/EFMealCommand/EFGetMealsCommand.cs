using Application.Commands.MealCommand;
using Application.DTO.MealDTO;
using Application.Responsed;
using Application.Searches;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands.EFMealCommand
{
    public class EFGetMealsCommand : EFBaseCommand, IGetMealsCommand
    {
        public EFGetMealsCommand(DBContext context) : base(context)
        {
        }

        public PagedRespone<MealGetDTO> Execute(MealSearch request)
        {
            var query = _context.Meals.AsQueryable();



            if (request.Name != null)
            {
                var name = request.Name.ToLower();
                query = query.Where(m => m.Name.ToLower().Contains(name));
            }

            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage)
                .Take(request.PerPage);

            var pageCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            var response = new PagedRespone<MealGetDTO>
            {

                CurrentPage = request.PageNumber,
                TotalCount = totalCount,
                PageCount = pageCount,
                Data = query.Select(m => new MealGetDTO
                {
                    Id = m.Id,
                    Name = m.Name,
                    Start = m.Start + " h",
                    Finish = m.Finish + " h",
                    IsDeleted = m.IsDeleted
                })
            };
            return response;
        }
    }
}
