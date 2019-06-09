
using Application.DTO.CreateDTO;
using Application.Interfaces;
using Application.Responsed;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.DrinkCommand
{
    public interface IGetDrinksCommand:ICommand<DrinkSearch,PagedRespone<CreateDrinkDTO>>
    {
    }
}
