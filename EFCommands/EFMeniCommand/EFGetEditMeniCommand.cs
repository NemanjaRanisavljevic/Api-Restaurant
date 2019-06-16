using Application.Commands.MeniCommand;
using Application.DTO.WebDTO;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCommands.EFMeniCommand
{
    public class EFGetEditMeniCommand : EFBaseCommand, IGetEditMeniCommand
    {
        public EFGetEditMeniCommand(DBContext context) : base(context)
        {
        }

        public HttpEditMeni Execute(int request)
        {
            var obj = _context.Menis.Find(request);
            if(obj == null)
            {
                throw new NotFoundException();
            }

            return new HttpEditMeni
            {
                Id = obj.Id,
                NameFood = obj.NameFood,
                Ingradiant = obj.Ingrediant,
                Price = obj.Price,
                MealId = obj.MealId
            };
        }
    }
}
