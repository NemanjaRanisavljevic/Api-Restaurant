using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands.MeniCommand;
using Application.DTO.MeniDTO;
using Application.Exceptions;
using Domain;
using EFDataAccess;

namespace EFCommands.EFMeniCommand
{
    public class EFAddMeniCommand : EFBaseCommand, IAddMeniCommand
    {
        public EFAddMeniCommand(DBContext context) : base(context)
        {
        }

        public void Execute(MeniAddDTO request)
        {
            if(_context.Menis.Any(m => m.NameFood == request.NameFood))
            {
                throw new AlredyExistException();
            }

            if(_context.Meals.Any(m => m.Id == request.MealId))
            {
                
            }else
            {
                throw new NotFoundException();
            }
            

            var image = new Image
            {
                Putanja = request.FileName,
                Alt = request.NameFood
            };

            _context.Add(new Meni {
                NameFood = request.NameFood,
                Ingrediant = request.Ingradiant,
                Price = request.Price,
                MealId = request.MealId,
                Image = image
                });
            

            _context.SaveChanges();
        }
    }
}
