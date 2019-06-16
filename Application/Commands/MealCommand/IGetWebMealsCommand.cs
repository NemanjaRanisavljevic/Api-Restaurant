using Application.DTO.MealDTO;
using Application.Interfaces;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.MealCommand
{
    public interface IGetWebMealsCommand : ICommand<ClassForNullObj,IEnumerable<MealGetDTO>>
    {
    }
}
