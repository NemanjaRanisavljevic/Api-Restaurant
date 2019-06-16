using Application.Commands.MealCommand;
using Application.DTO.MealDTO;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace EFCommands.EFMealCommand
{
    public class EFEditMealCommand : EFBaseCommand, IEditMealCommand
    {
        public EFEditMealCommand(DBContext context) : base(context)
        {
        }

        public void Execute(MealGetDTO request)
        {
            var search = _context.Meals.Find(request.Id);

            if(search == null)
            {
                throw new NotFoundException();
            }

            if(request.Name != null)
            {
                if(!_context.Meals.Any(m => m.Name == request.Name))
                {
                    search.Name = request.Name;
                    
                }else
                {
                    throw new AlredyExistException();
                }
            }

            if(request.Start != null)
            {
                if(search.Start != request.Start)
                {
                    search.Start = request.Start;
                }

            }

            if (request.Finish != null)
            {
                if (search.Finish != request.Finish)
                {
                    search.Finish = request.Finish;
                }
                
            }

            if (search.IsDeleted != request.IsDeleted)
            {
                search.IsDeleted = request.IsDeleted;
            }

           

            _context.SaveChanges();
        }
    }
}
