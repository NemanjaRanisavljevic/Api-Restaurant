using Application.DTO.MealDTO;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.MealCommand
{
    public interface IGetMealCommand : ICommand<int, IEnumerable<MealGetDTO>>
    {
    }
}
