using Application.Commands.MeniCommand;
using Application.DTO.MeniDTO;
using Application.Exceptions;
using EFDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCommands.EFMeniCommand
{
    public class EFGetMeniWebCommand : EFBaseCommand, IGetMeniWebCommand
    {
        public EFGetMeniWebCommand(DBContext context) : base(context)
        {
        }

        public MeniGetDTO Execute(int request)
        {
            var obj = _context.Menis.Find(request);
            

            if (obj == null)
            {
                throw new NotFoundException();
            }
            var img = _context.Images.Find(obj.ImageId);
            var meal = _context.Meals.Find(obj.MealId);

            return new MeniGetDTO
            {
                Id = obj.Id,
                NameFood = obj.NameFood,
                Ingradiant = obj.Ingrediant,
                Price = obj.Price,
                FileName = img.Putanja,
                Alt = img.Alt,
                MealName = meal.Name
                
            };
        }
    }
}
