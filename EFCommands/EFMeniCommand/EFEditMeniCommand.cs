using Application.Commands.MeniCommand;
using Application.DTO.MeniDTO;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands.EFMeniCommand
{
    public class EFEditMeniCommand : EFBaseCommand, IEditMeniCommand
    {
        public EFEditMeniCommand(DBContext context) : base(context)
        {
        }

        public void Execute(MeniAddDTO request)
        {
            var meni = _context.Menis.Find(request.Id);

            if(meni == null)
            {
                throw new NotFoundException();
            }

            if (request.NameFood != null)
            {
                if (!_context.Menis.Any(m => m.NameFood == request.NameFood))
                {
                    meni.NameFood = request.NameFood;
                }
                else
                {
                    throw new AlredyExistException();
                }
            }

            if (request.Ingradiant != null)
            {
                if(meni.Ingrediant != request.Ingradiant)
                {
                    meni.Ingrediant = request.Ingradiant;
                }
                
            }

            if (request.Price != null)
            {
                if (meni.Price != request.Price)
                {
                    meni.Price = request.Price;
                }
               
            }

            if (request.FileName != null)
            {
                var idSlike = meni.ImageId;
                var slika = _context.Images.Find(idSlike);
                slika.Putanja = request.FileName;
            }

            if(meni.MealId != request.MealId)
            {
                if(_context.Meals.Any(m => m.Id == request.MealId))
                {
                    meni.MealId = request.MealId;
                }
                else
                {
                    throw new NotFoundException();
                }
            }

            _context.SaveChanges();

        }
    }
}
