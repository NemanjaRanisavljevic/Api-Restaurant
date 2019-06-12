using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.MealCommand
{
    public interface IDeleteMealCommand : ICommand<int>
    {
    }
}
