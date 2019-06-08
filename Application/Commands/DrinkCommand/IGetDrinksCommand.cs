using Application.Commands.Response;
using Application.DTO.CreateDTO;
using Application.Interfaces;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.DrinkCommand
{
    public interface IGetDrinksCommand:ICommand<DrinkSearch,PagedResponse<CreateDrinkDTO>>
    {
    }
}
